using DocumentFormat.OpenXml.Drawing.Charts;
using Irony.Parsing;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Predictions;
using static Microsoft.ML.DataOperationsCatalog;
using Order = UretimTakipProgrami.Entities.Order;
using Production = UretimTakipProgrami.Entities.Production;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmSendToProduction : Form
    {
        private ProductionRepository _productionRepository;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private MachineRepository _machineRepository;

        private string orderId;
        private Machine freeMachine;

        private Order currentOrder;
        System.Windows.Forms.ToolTip buttonToolTip;

        public FrmSendToProduction(string OrderId)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;

            _productionRepository = InstanceFactory.GetInstance<ProductionRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();
            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();

            this.orderId = OrderId;

            buttonToolTip = new System.Windows.Forms.ToolTip();
        }

        private void GetMachineList()
        {
            try
            {
                var machineList = _machineRepository.GetAll()
                .Select(machine => new
                {
                    machine.Id,
                    machine.Name
                })
                .ToList();

                if (machineList != null)
                {
                    listTezgah.DataSource = machineList;
                    listTezgah.DisplayMember = "Name";
                    listTezgah.ValueMember = "Id";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void GetUserList()
        {
            try
            {
                var userList = _userRepository.GetAll()
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.IsOperator,
                    user.IsActive
                })
                .Where(u => u.IsOperator && u.IsActive)
                .ToList();

                if (userList != null)
                {
                    listAyarOperator.DataSource = userList;
                    listAyarOperator.DisplayMember = "Name";
                    listAyarOperator.ValueMember = "Id";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void GetFreeMachine()
        {
            try
            {
                var machineJobList = _orderRepository
                    .GetWhere(o => o.MachineId != null && !o.IsReady && !o.IsWaiting)
                    .GroupBy(o => o.MachineId)
                    .Select(g => new
                    {
                        MachineId = g.Key,
                        TotalQuantity = g.Sum(o => o.Quantity)
                    })
                    .OrderBy(g => g.TotalQuantity).ToList();

                var machineList = _machineRepository.GetAll()
                    .Select(m => m.Id).ToList();

                var result = machineList
                    .GroupJoin(
                        machineJobList,
                        machineId => machineId,
                        job => job.MachineId,
                        (machineId, jobs) => new
                        {
                            MachineId = machineId,
                            TotalQuantity = jobs.Any() ? jobs.First().TotalQuantity : 0
                        })
                    .OrderBy(result => result.TotalQuantity)
                    .FirstOrDefault();

                freeMachine = _machineRepository.GetWhere(m => m.Id == result.MachineId).FirstOrDefault();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void SetListTezgahSelectedItem(string freeMachine)
        {
            foreach (var item in listTezgah.Items)
            {
                if (item.ToString().Contains(freeMachine))
                {
                    listTezgah.SelectedItem = item;
                    break;
                }
            }
        }

        private void FrmSendToProduction_Load(object sender, EventArgs e)
        {
            GetMachineList();
            GetUserList();

            if (listAyarOperator.Items.Count > 0)
                listAyarOperator.SelectedIndex = 0;

            currentOrder = _orderRepository.GetWhere(o => o.Id == Guid.Parse(orderId)).FirstOrDefault();

            GetFreeMachine();
            if (freeMachine != null)
                SetListTezgahSelectedItem(freeMachine.Name);
        }

        private void listTezgah_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listAyarOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (listTezgah.Items.Count > 0 && listAyarOperator.Items.Count > 0)
                {
                    DialogResult result = MessageBox.Show($"Seçilen Tezgah: {listTezgah.Text}\n" +
                        $"Ayar Yapacak Operatör: {listAyarOperator.Text}\n\n" +
                        $"Bu iş emrini ÜRETİM ONAY LİSTESİNE almak istiyor musunuz?", "İş Emri Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var order = await _orderRepository.GetByIdAsync(currentOrder.Id.ToString());
                        order.IsWaiting = false;
                        order.UserId = Guid.Parse(listAyarOperator.SelectedValue.ToString());
                        order.MachineId = Guid.Parse(listTezgah.SelectedValue.ToString());

                        await _orderRepository.SaveAsync();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tanımlı Tezgah veya Operatör yok.?", "Tezgah Ve Operatör Tanım Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUygunTezgahSec_Click(object sender, EventArgs e)
        {
            var results = PredictMachine(0.01f, 50, 3, false);

            if (results != null)
            {
                if (results[0].ToString() != listTezgah.Text)
                {
                    DialogResult tezgahCevap = MessageBox.Show($"Uygun Boş Tezgah : {freeMachine.Name}\n" +
                                $"Tavsiye Edilen Tezgah : {results[0]}\n" +
                                //$"Tahmin Doğruluğu: {Convert.ToSingle(results[1]) * 100:F2} %\n\n" +
                                $"Tavsiye edilen {results[0]} tezgahını seçmek istiyor musunuz?",
                                "Tezgah Bilgisi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (tezgahCevap == DialogResult.Yes)
                        SetListTezgahSelectedItem(results[0].ToString());
                }
                else
                    MessageBox.Show($"Tavsiye edilen tezgah şu an seçili olan {listTezgah.Text} tezgahıdır.\n" +
                                $"Tahmin Doğruluğu: {Convert.ToSingle(results[1]) * 100:F2} %\n",
                                "Tezgah Bilgisi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Yeterli veri yok. Tezgahı manuel olarak seçiniz.", "Tezgah Bilgisi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<Production> GetProductionDataForPrediction(int dataOfPastMonths)
        {
            // Son üç aylık üretim verilerini al.
            DateTime pastDate = DateTime.UtcNow.AddMonths(-dataOfPastMonths);
            var productions = _productionRepository
                .GetWhere(pr => pr.Order.MachineId != null && !pr.IsStarted && pr.CreatedDate >= pastDate)
                .ToList<Production>();

            return productions;
        }

        public List<object> PredictMachine(float tolerance, int numberOfIteration, int dataOfPastMonths, bool shuffleState)
        {
            try
            {
                var mlContext = new MLContext();
                float totalWorkTime = 0.0f;

                var productions = GetProductionDataForPrediction(dataOfPastMonths);
                var orders = _orderRepository.GetWhere(o => o.MachineId != null).ToList();

                List<MachineData> data = new List<MachineData>();
                List<object> results = new List<object>();

                if (productions.Count > 30)
                {
                    foreach (var pr in productions)
                    {
                        TimeSpan differenceProductionTime = Convert.ToDateTime(pr.FinishDate) - Convert.ToDateTime(pr.CreatedDate);

                        var order = orders.FirstOrDefault(x => x.Id == pr.OrderId);
                        TimeSpan orderDeliveryTime = Convert.ToDateTime(order.DeliveryDate) - Convert.ToDateTime(order.CreatedDate);

                        var workTime = Convert.ToSingle(differenceProductionTime.TotalHours);
                        totalWorkTime += workTime;

                        data.Add(new MachineData
                        {
                            Performance = Convert.ToSingle((pr.Quantity / (float)(pr.Quantity + pr.Wastage)) * 100),
                            WorkTime = Convert.ToSingle(Math.Abs(differenceProductionTime.TotalHours)),
                            ProductId = order.ProductId.ToString(),
                            OrderQuantity = Convert.ToSingle(order.Quantity),
                            DeliveryTime = Convert.ToSingle(orderDeliveryTime.TotalHours),
                            MachineId = order.MachineId.ToString()
                        });
                    }

                    //string filePath = "C:\\Users\\user\\Desktop\\output.csv"; // CSV dosyasının yolu ve adı

                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                    //using (StreamWriter writer = new StreamWriter(filePath))
                    //{
                    //    // Başlık satırı yazılıyor
                    //    writer.WriteLine("Performance,WorkTime,ProductId,DeliveryTime,OrderQuantity,MachineId");

                    //    // Her MachineData nesnesini CSV'ye yazma
                    //    foreach (var item in data)
                    //    {
                    //        string line = $"{item.Performance.ToString("F3")},{item.WorkTime.ToString("F3")},{item.ProductId},{item.DeliveryTime.ToString("F3")},{item.OrderQuantity},{item.MachineId}";
                    //        writer.WriteLine(line);
                    //    }
                    //}

                    IDataView dataView = mlContext.Data.LoadFromEnumerable(data);

                    // Veri setini bölme
                    TrainTestData trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
                    IDataView trainData = trainTestSplit.TrainSet;
                    IDataView testData = trainTestSplit.TestSet;

                    var pipeline = mlContext.Transforms.Text.FeaturizeText(inputColumnName: "ProductId", outputColumnName: "ProductFeaturized")
                        .Append(mlContext.Transforms.Concatenate("Features", nameof(MachineData.Performance),
                                                                nameof(MachineData.WorkTime), "ProductFeaturized",
                                                                nameof(MachineData.OrderQuantity), nameof(MachineData.DeliveryTime)))
                        .Append(mlContext.Transforms.NormalizeMinMax("Features", "Features"))
                        .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", "MachineId"))
                        .AppendCacheCheckpoint(mlContext);

                    var options = new SdcaNonCalibratedMulticlassTrainer.Options
                    {
                        LabelColumnName = "Label",
                        FeatureColumnName = "Features",

                        ConvergenceTolerance = tolerance,
                        MaximumNumberOfIterations = numberOfIteration,
                        Shuffle = shuffleState
                    };
                    var trainer = mlContext.MulticlassClassification.Trainers.SdcaNonCalibrated(options);

                    var trainingPipeline = pipeline.Append(trainer)
                        .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

                    // Model eğitimi
                    var model = trainingPipeline.Fit(trainData);

                    // Test veri seti üzerinde tahmin yapma
                    var predictions = model.Transform(testData);
                    var metrics = mlContext.MulticlassClassification.Evaluate(predictions, "Label");

                    // Yeni işin tahmini
                    var predictionEngine = mlContext.Model.CreatePredictionEngine<MachineData, MachinePrediction>(model);

                    currentOrder = _orderRepository.GetWhere(o => o.Id == Guid.Parse(orderId)).FirstOrDefault();
                    TimeSpan orderTime = Convert.ToDateTime(currentOrder.DeliveryDate) - Convert.ToDateTime(currentOrder.CreatedDate);

                    MachineData machineJob = new MachineData
                    {
                        Performance = 98.0f,
                        WorkTime = Convert.ToSingle((float)totalWorkTime / productions.Count),
                        ProductId = currentOrder.ProductId.ToString(),
                        OrderQuantity = Convert.ToSingle(currentOrder.Quantity),
                        DeliveryTime = Convert.ToSingle(orderTime.TotalHours)
                    };

                    var prediction = predictionEngine.Predict(machineJob);

                    var predictedMachineId = prediction.PredictedMachineID.ToString();

                    var predictedMachineName = _machineRepository.GetWhere(m => m.Id == Guid.Parse(predictedMachineId)).FirstOrDefault().Name;

                    results.Add(predictedMachineName);
                    results.Add(metrics.MicroAccuracy);

                    return results;
                }
                else
                    return null;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
                return null;
            }
        }

        private void btnUygunTezgahSec_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnUygunTezgahSec, "Oluşturulan iş emrinin üretimi için uygun olan makinayı belirtir.");
        }

        private void FrmSendToProduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnKaydet_Click(sender, e);
            else if (e.KeyChar == (char)Keys.Escape)
                btnIptal_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
