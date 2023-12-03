using Microsoft.EntityFrameworkCore;
using System.Data;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmProduction : Form
    {
        private OrderRepository _orderRepository;
        private ProductionRepository _productionRepository;
        private ProductRepository _productRepository;
        private MachineRepository _machineRepository;
        private MachineProgramRepository _machineProgramRepository;
        private UserRepository _userRepository;

        private FrmDailyProductionUpdate frmDailyProductionUpdate;
        private FrmDailyProductionConfirm frmDailyProductionConfirm;

        private int selectedIndex1 = 0;
        private int selectedIndex2 = 0;
        private int selectedIndex3 = 0; // Production List Index
        private int selectedIndex4 = 0; // Daily Production List Index
        private int selectedIndex5 = 0; // Daily Production Search Page Index

        private int monthCalendarNo = 0;

        private Point lastLocation;
        private System.Windows.Controls.Panel selectedPanel;

        private bool editMode = false;

        public FrmProduction()
        {
            InitializeComponent();

            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            _productionRepository = InstanceFactory.GetInstance<ProductionRepository>();
            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();
            _machineProgramRepository = InstanceFactory.GetInstance<MachineProgramRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        public class Durumlar
        {
            public const string Acil = "Acil";
            public const string Uretimde = "Üretimde";
            public const string Beklemede = "Beklemede";
        }

        private void GetMachineList()
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

                //listTezgah.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //listTezgah.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void GetUserList()
        {
            var userList = _userRepository.GetAll()
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.IsOperator
                })
                .Where(u => u.IsOperator)
                .ToList();

            if (userList != null)
            {
                listAyarOperator.DataSource = userList;
                listAyarOperator.DisplayMember = "Name";
                listAyarOperator.ValueMember = "Id";

                //listAyarOperator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //listAyarOperator.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void GetOrderList()
        {
            dataListOrder.DataSource = null;

            var orderList = _orderRepository.GetAll()
            .Select(order => new
            {
                orderCreatedDate = order.CreatedDate.ToLocalTime(),
                productName = order.Product.Name,
                customerName = order.Customer.Name,
                order.Quantity,
                deliveryDate = order.DeliveryDate.ToLocalTime().Date,
                orderAciliyet = order.IsUrgent ? Durumlar.Acil : "",
                order.Description,
                order.Id,
                productId = order.Product.Id,
                customerId = order.Customer.Id,
                order.IsWaiting,
                order.IsProduction,
                programName = order.Product.MachineProgram.Name
            })
            .Where(or => or.IsWaiting && !or.IsProduction)
            .OrderByDescending(order => order.orderAciliyet)
            .ThenBy(order => order.deliveryDate)
            .ToList();

            if (orderList.Count > 0)
                dataListOrder.DataSource = orderList;
        }

        private void GetOrderProductionList()
        {
            dataListOrderProduction.DataSource = null;

            var orderList = _orderRepository.GetAll()
            .Select(order => new
            {
                orderCreatedDate = order.CreatedDate.ToLocalTime(), // 0
                productName = order.Product.Name, // 1
                customerName = order.Customer.Name, // 2
                order.Quantity, // 3
                deliveryDate = order.DeliveryDate.ToLocalTime().Date, // 4
                orderAciliyet = order.IsUrgent ? Durumlar.Acil : "", // 5
                order.Id, // 6
                order.IsUrgent, // 7
                machineName = order.Machine.Name != null ? order.Machine.Name : "", // 8
                userName = order.User.Name != null ? order.User.Name : "", // 9
                order.Description, // 10
                order.IsWaiting, // 11
                order.IsProduction, // 12
                order.IsReady // 13
            })
            .Where(or => !or.IsWaiting && !or.IsProduction && !or.IsReady)
            .OrderByDescending(order => order.orderAciliyet)
            .ThenBy(order => order.deliveryDate)
            .ToList();

            if (orderList.Count > 0)
                dataListOrderProduction.DataSource = orderList;
        }

        private void GetProductionList()
        {
            dataListProduction.DataSource = null;

            var programList = _machineProgramRepository.GetAll().Select(mc => new
            {
                Id = mc.Id,
                Name = mc.Name
            });

            var userList = _userRepository.GetAll();

            var orderList = _orderRepository.GetAll()
            .Select(order => new
            {
                orderCreatedDate = order.CreatedDate.ToLocalTime(),
                productName = order.Product.Name,
                customerName = order.Customer.Name,
                order.Quantity,
                productionQuantity = order.Productions.Where(pr => pr.Order.Id == order.Id).Sum(pr => pr.Quantity),
                productionWastage = order.Productions.Where(pr => pr.Order.Id == order.Id).Sum(pr => pr.Wastage),
                deliveryDate = order.DeliveryDate.ToLocalTime().Date,
                orderAciliyet = order.IsUrgent ? Durumlar.Acil : "",
                orderMachine = order.Machine.Name,
                operatorName = order.User.Name,
                order.Description,
                order.Id,
                order.IsWaiting,
                order.IsProduction,
                programName = order.Product.MachineProgram.Name,
                order.IsReady,
                productionState = order.Productions
                    .Where(pr => pr.Order.Id == order.Id && pr.IsStarted)
                    .FirstOrDefault().IsStarted ? Durumlar.Uretimde : Durumlar.Beklemede
            })
            .Select(order => new
            {
                order.orderCreatedDate, // 0
                order.productName, // 1
                order.customerName, // 2
                order.Quantity, // 3
                order.productionQuantity, // 4
                order.productionWastage, // 5
                productionRemain = order.Quantity - order.productionQuantity, // 6
                order.deliveryDate, // 7
                order.orderAciliyet, // 8
                order.orderMachine, // 9
                order.operatorName, // 10
                order.Description, // 11
                order.Id, // 12
                order.IsWaiting, // 13
                order.IsProduction, // 14
                order.programName, //15
                order.productionState, // 16
                order.IsReady // 17
            })
            .Where(or => or.IsProduction && or.productionRemain > 0)
            .OrderByDescending(order => order.orderAciliyet)
            .ThenBy(order => order.deliveryDate)
            .ToList();

            if (orderList.Count > 0)
                dataListProduction.DataSource = orderList;

        }

        private void GetDailyProductionList()
        {
            dataListDailyProduction.DataSource = null;
            bool startActive = false;

            if (dataListProduction.RowCount > 0)
            {
                var dailyProductionList = _productionRepository.GetAll()
                    .Select(production => new
                    {
                        productionStartDate = production.CreatedDate.ToLocalTime(),
                        productionFinishDate = production.FinishDate == null ? null : (object)Convert.ToDateTime(production.FinishDate).ToLocalTime(),
                        production.Quantity,
                        production.Wastage,
                        orderId = production.Order.Id,
                        production.Id,
                        production.IsStarted,
                        userName = production.User.Name
                    })
                    .Select(pr => new
                    {
                        pr.productionStartDate, // 0
                        pr.productionFinishDate, // 1
                        productionTime = pr.productionFinishDate != null && pr.productionStartDate != null // 2
                            ? ((DateTime)pr.productionFinishDate - (DateTime)pr.productionStartDate).ToString("hh\\:mm\\:ss")
                            : "",
                        pr.Quantity, // 3
                        pr.Wastage, // 4
                        pr.orderId, // 5
                        pr.Id, // 6
                        pr.IsStarted, // 7
                        pr.userName // 8
                    })
                    .Where(pr => pr.orderId == Guid.Parse(dataListProduction.Rows[selectedIndex3].Cells[12].Value.ToString()) && pr.Quantity >= 0)
                    .ToList();

                if (dailyProductionList.Count > 0)
                {
                    dataListDailyProduction.DataSource = dailyProductionList;

                    startActive = dailyProductionList
                        .FirstOrDefault(pr => pr.IsStarted != null && pr.IsStarted == true)?.IsStarted ?? false;
                }
            }

            if (startActive)
            {
                btnStart.Enabled = false;
                btnFinish.Enabled = true;

                lblProductionState.Text = "ÜRETİME BAŞLANDI";
                panel7.BackColor = Color.FromArgb(80, 200, 120);
            }
            else
            {
                btnStart.Enabled = true;
                btnFinish.Enabled = false;

                lblProductionState.Text = "BEKLEMEDE";
                panel7.BackColor = Color.FromArgb(175, 174, 209);
            }
        }

        private void SearchDailyProductionList() // Günlük arama listesi sonucunu getir.
        {
            dataListSearchDailyProduction.DataSource = null;

            var userList = _userRepository.GetAll();

            var programList = _machineProgramRepository.GetAll().Select(mc => new
            {
                Id = mc.Id,
                Name = mc.Name
            });

            DateTime? baslangicTarih = null;
            DateTime? bitisTarih = null;

            string arananMusteri = txtMusteriAdiAra.Text;
            string arananUrun = txtUrunAdiAra.Text;

            string arananTezgah = txtTezgahAdiAra.Text;
            string arananOperator = txtOperatorAdiAra.Text;

            if (DateTime.TryParse(txtBaslangicTarihi.Text, out var parsedBaslangicTarihi))
            {
                baslangicTarih = parsedBaslangicTarihi;
            }

            if (DateTime.TryParse(txtBitisTarihi.Text, out var parsedBitisTarihi))
            {
                bitisTarih = parsedBitisTarihi;
            }

            /*
            var dailyProductionList = _productionRepository.GetAll()
                .Select(production => new
                {
                    productionStartDate = production.CreatedDate.ToLocalTime(),
                    productionFinishDate = production.FinishDate == null ? null : (object)Convert.ToDateTime(production.FinishDate).ToLocalTime(),
                    productionTime = production.FinishDate != null && production.CreatedDate != null
                            ? ((DateTime)production.FinishDate - (DateTime)production.CreatedDate).ToString("hh\\:mm\\:ss")
                            : "",
                    productName = production.Order.Product.Name,
                    customerName = production.Order.Customer.Name,
                    production.Quantity,
                    production.Wastage,
                    machineName = production.Order.Machine.Name,
                    operatorName = production.Order.User.Name,
                    producedOperatorName = production.User.Name,
                    production.Order.Description,
                    programName = programList.FirstOrDefault(p => p.Id == production.Order.Product.MachineProgram.Id),
                    orderId = production.Order.Id,
                    production.IsStarted,
                    production.Id
                })
                .Where(pr =>
                    (!pr.IsStarted) &&
                    (!baslangicTarih.HasValue || pr.productionStartDate.Date >= baslangicTarih) &&
                    (!bitisTarih.HasValue || pr.productionStartDate.Date <= bitisTarih) &&
                    (string.IsNullOrEmpty(arananTezgah) || pr.machineName.ToLower().Contains(arananTezgah)) &&
                    (string.IsNullOrEmpty(arananOperator) || pr.producedOperatorName.ToLower().Contains(arananOperator)) &&
                    (string.IsNullOrEmpty(arananMusteri) || pr.customerName.ToLower().Contains(arananMusteri.ToLower())) &&
                    (string.IsNullOrEmpty(arananUrun) || pr.productName.ToLower().Contains(arananUrun.ToLower())))
                .OrderBy(pr => pr.productionStartDate)
                .ToList();
            */

            var dailyProductionList = _productionRepository.GetAll()
            .Select(production => new
            {
                productionStartDate = production.CreatedDate.ToLocalTime(),
                productionFinishDate = production.FinishDate != null ? (object)Convert.ToDateTime(production.FinishDate).ToLocalTime() : null,
                productionTime = production.FinishDate != null && production.CreatedDate != null
                        ? ((DateTime)production.FinishDate - (DateTime)production.CreatedDate).ToString("hh\\:mm\\:ss")
                        : "",
                productName = production.Order.Product.Name,
                customerName = production.Order.Customer.Name,
                production.Quantity,
                production.Wastage,
                machineName = production.Order.Machine.Name,
                operatorName = production.Order.User.Name,
                producedOperatorName = production.User.Name,
                production.Order.Description,
                programName = production.Order.Product.MachineProgram.Name,
                orderId = production.Order.Id,
                production.IsStarted,
                production.Id
            })
            .Where(pr =>
                (!pr.IsStarted) &&
                (!baslangicTarih.HasValue || pr.productionStartDate.Date >= baslangicTarih) &&
                (!bitisTarih.HasValue || pr.productionStartDate.Date <= bitisTarih) &&
                (string.IsNullOrEmpty(arananTezgah) || pr.machineName.ToLower().Contains(arananTezgah)) &&
                (string.IsNullOrEmpty(arananOperator) || pr.producedOperatorName.ToLower().Contains(arananOperator)) &&
                (string.IsNullOrEmpty(arananMusteri) || pr.customerName.ToLower().Contains(arananMusteri.ToLower())) &&
                (string.IsNullOrEmpty(arananUrun) || pr.productName.ToLower().Contains(arananUrun.ToLower())))
            .OrderBy(pr => pr.productionStartDate)
            .ToList();


            if (dailyProductionList.Count > 0)
            {
                dataListSearchDailyProduction.DataSource = dailyProductionList;
                SetDailyProductionSearchDataGridSettings();
            }
            else
            {
                dataListSearchDailyProduction.DataSource = null;
            }

            //lblKayitSayisi.Text = $"Kayıt Sayısı: {orderList.Count.ToString()}";
        }

        private void SetOrderDataGridSettings()
        {
            if (dataListOrder.Rows.Count > 0)
            {
                dataListOrder.ColumnHeadersHeight = 25;

                dataListOrder.Columns[0].HeaderText = "Sipariş Tarihi";
                dataListOrder.Columns[0].Width = 120;

                dataListOrder.Columns[1].HeaderText = "Ürün Adı";
                dataListOrder.Columns[1].Width = 250;

                dataListOrder.Columns[2].HeaderText = "Müşteri Adı / Unvanı";
                dataListOrder.Columns[2].Width = 250;

                dataListOrder.Columns[3].HeaderText = "Miktar";
                dataListOrder.Columns[3].Width = 60;

                dataListOrder.Columns[4].HeaderText = "Teslim Tarihi";
                dataListOrder.Columns[4].Width = 120;

                dataListOrder.Columns[5].HeaderText = "Öncelik";
                dataListOrder.Columns[5].Width = 60;

                dataListOrder.Columns[6].HeaderText = "Açıklama";
                dataListOrder.Columns[6].Width = 250;

                dataListOrder.Columns[7].Visible = false; // Order Id
                dataListOrder.Columns[8].Visible = false; // Product Id
                dataListOrder.Columns[9].Visible = false; // Customer Id
                dataListOrder.Columns[10].Visible = false; // IsWaiting
                dataListOrder.Columns[11].Visible = false; // IsProduction
                dataListOrder.Columns[12].Visible = false; // ProgramName

                int acilDurumSutunu = 5;

                foreach (DataGridViewRow row in dataListOrder.Rows)
                {
                    if (row.Cells[acilDurumSutunu].Value != null)
                    {
                        if (row.Cells[acilDurumSutunu].Value.ToString() == Durumlar.Acil)
                        {
                            row.Cells[acilDurumSutunu].Style.BackColor = Color.FromArgb(187, 33, 36);
                            row.Cells[acilDurumSutunu].Style.ForeColor = Color.White;
                            row.Cells[acilDurumSutunu].Style.Font = new Font(dataListOrder.Font, FontStyle.Bold);
                        }
                    }
                }

                lblKayitSayisi.Text = $"Bekleyen İş Emri Sayısı: {dataListOrder.RowCount.ToString()}";
            }
            else
                lblKayitSayisi.Text = "Gösterilecek kayıt yok";
        }

        private void SetOrderProductionDataGridSettings()
        {
            if (dataListOrderProduction.Rows.Count > 0)
            {
                dataListOrderProduction.ColumnHeadersHeight = 25;

                dataListOrderProduction.Columns[0].HeaderText = "Sipariş Tarihi";
                dataListOrderProduction.Columns[0].Width = 120;

                dataListOrderProduction.Columns[1].HeaderText = "Ürün Adı";
                dataListOrderProduction.Columns[1].Width = 250;

                dataListOrderProduction.Columns[2].HeaderText = "Müşteri Adı / Unvanı";
                dataListOrderProduction.Columns[2].Width = 250;

                dataListOrderProduction.Columns[3].HeaderText = "Miktar";
                dataListOrderProduction.Columns[3].Width = 60;

                dataListOrderProduction.Columns[4].HeaderText = "Teslim Tarihi";
                dataListOrderProduction.Columns[4].Width = 120;

                dataListOrderProduction.Columns[5].HeaderText = "Öncelik";
                dataListOrderProduction.Columns[5].Width = 60;

                dataListOrderProduction.Columns[6].Visible = false; // Order Id
                dataListOrderProduction.Columns[7].Visible = false; // Öncelik/Aciliyet

                dataListOrderProduction.Columns[8].HeaderText = "Makina/Tezgah";
                dataListOrderProduction.Columns[8].Width = 150;

                dataListOrderProduction.Columns[9].HeaderText = "Ayar Yapan Operatör";
                dataListOrderProduction.Columns[9].Width = 200;

                dataListOrderProduction.Columns[10].HeaderText = "Açıklama";
                dataListOrderProduction.Columns[10].Width = 250;

                dataListOrderProduction.Columns[11].Visible = false; // IsWaiting
                dataListOrderProduction.Columns[12].Visible = false; // IsProduction
                dataListOrderProduction.Columns[13].Visible = false; // IsReady

                int acilDurumSutunu = 5;

                foreach (DataGridViewRow row in dataListOrderProduction.Rows)
                {
                    if (row.Cells[acilDurumSutunu].Value != null)
                    {
                        if (row.Cells[acilDurumSutunu].Value.ToString() == Durumlar.Acil)
                        {
                            row.Cells[acilDurumSutunu].Style.BackColor = Color.FromArgb(187, 33, 36);
                            row.Cells[acilDurumSutunu].Style.ForeColor = Color.White;
                            row.Cells[acilDurumSutunu].Style.Font = new Font(dataListOrderProduction.Font, FontStyle.Bold);
                        }
                    }
                }

                lblKayitSayisi2.Text = $"Onaylanacak İş Emri Sayısı: {dataListOrderProduction.RowCount.ToString()}";
            }
            else
                lblKayitSayisi2.Text = "Gösterilecek kayıt yok";
        }

        private void SetProductionDataGridSettings()
        {

            if (dataListProduction.Rows.Count > 0)
            {
                dataListProduction.Columns[0].Visible = false; // Sipariş Tarihi
                dataListProduction.Columns[1].HeaderText = "Ürün Adı";
                dataListProduction.Columns[2].HeaderText = "Müşteri Adı / Unvanı";
                dataListProduction.Columns[3].HeaderText = "Sipariş";
                dataListProduction.Columns[3].Width = 35;
                dataListProduction.Columns[4].HeaderText = "Üretim";
                dataListProduction.Columns[4].Width = 35;
                dataListProduction.Columns[5].HeaderText = "Defolu";
                dataListProduction.Columns[5].Width = 35;
                dataListProduction.Columns[6].HeaderText = "Kalan";
                dataListProduction.Columns[6].Width = 35;
                dataListProduction.Columns[7].HeaderText = "Teslim Tarihi";
                dataListProduction.Columns[7].Width = 60;
                dataListProduction.Columns[8].HeaderText = "Öncelik";
                dataListProduction.Columns[8].Width = 35;
                dataListProduction.Columns[9].HeaderText = "Tezgah/Makina";
                dataListProduction.Columns[10].HeaderText = "Ayar Yapan";
                dataListProduction.Columns[11].HeaderText = "Açıklama";
                dataListProduction.Columns[12].Visible = false; // Order Id
                dataListProduction.Columns[13].Visible = false; // IsWaiting
                dataListProduction.Columns[14].Visible = false; // IsProduction
                dataListProduction.Columns[15].Visible = false; // Program No
                dataListProduction.Columns[16].HeaderText = "Üretim Durumu"; ; // IsStarted
                dataListProduction.Columns[16].Width = 120;
                dataListProduction.Columns[17].Visible = false; // IsReady

                int acilDurumSutunu = 8;
                int orderColumn = 3;
                int remainColumn = 6;

                int productionColumn = 4;
                int wastageColumn = 5;
                int productionStateColumn = 16;

                foreach (DataGridViewRow row in dataListProduction.Rows)
                {
                    if (row.Cells[acilDurumSutunu].Value != null)
                    {
                        if (row.Cells[productionStateColumn].Value.ToString() == Durumlar.Uretimde)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.FromArgb(175, 225, 175);
                            }

                            row.Cells[productionStateColumn].Style.Font = new Font(dataListProduction.Font, FontStyle.Bold);
                        }

                        if (row.Cells[acilDurumSutunu].Value.ToString() == Durumlar.Acil)
                        {
                            row.Cells[acilDurumSutunu].Style.BackColor = Color.FromArgb(187, 33, 36);
                            row.Cells[acilDurumSutunu].Style.ForeColor = Color.White;
                            row.Cells[acilDurumSutunu].Style.Font = new Font(dataListProduction.Font, FontStyle.Bold);
                        }
                    }

                    row.Cells[orderColumn].Style.Font = new Font(dataListProduction.Font, FontStyle.Bold);
                    row.Cells[remainColumn].Style.Font = new Font(dataListProduction.Font, FontStyle.Bold);

                }

                lblKayitSayisi3.Text = $"Onaylanan İş Emri Sayısı: {dataListProduction.RowCount.ToString()}";
            }
            else
                lblKayitSayisi3.Text = "Gösterilecek kayıt yok";
        }

        private void SetDailyProductionDataGridSettings()
        {
            if (dataListDailyProduction.Rows.Count > 0)
            {
                dataListDailyProduction.Columns[0].HeaderText = "Üretim Başlangıç";
                dataListDailyProduction.Columns[0].Width = 80;
                dataListDailyProduction.Columns[1].HeaderText = "Üretim Bitiş";
                dataListDailyProduction.Columns[1].Width = 80;
                dataListDailyProduction.Columns[2].HeaderText = "Çalışma Süresi";
                dataListDailyProduction.Columns[2].Width = 50;
                dataListDailyProduction.Columns[3].HeaderText = "Miktar";
                dataListDailyProduction.Columns[3].Width = 35;
                dataListDailyProduction.Columns[4].HeaderText = "Defolu";
                dataListDailyProduction.Columns[4].Width = 35;
                dataListDailyProduction.Columns[5].Visible = false;
                dataListDailyProduction.Columns[6].Visible = false;
                dataListDailyProduction.Columns[7].Visible = false;
                dataListDailyProduction.Columns[8].HeaderText = "Üretimi Yapan";
            }
        }

        private void SetDailyProductionSearchDataGridSettings() // Search Daily Production
        {
            if (dataListSearchDailyProduction.Rows.Count > 0)
            {
                dataListSearchDailyProduction.Columns[0].HeaderText = "Üretim Başlangıç";
                dataListSearchDailyProduction.Columns[0].Width = 80;
                dataListSearchDailyProduction.Columns[1].HeaderText = "Üretim Bitiş";
                dataListSearchDailyProduction.Columns[1].Width = 80;
                dataListSearchDailyProduction.Columns[2].HeaderText = "Çalışma Süresi";
                dataListSearchDailyProduction.Columns[2].Width = 60;
                dataListSearchDailyProduction.Columns[3].HeaderText = "Ürün Adı";
                dataListSearchDailyProduction.Columns[4].HeaderText = "Müşteri Adı";
                dataListSearchDailyProduction.Columns[5].HeaderText = "Miktar";
                dataListSearchDailyProduction.Columns[5].Width = 35;
                dataListSearchDailyProduction.Columns[6].HeaderText = "Defolu";
                dataListSearchDailyProduction.Columns[6].Width = 35;
                dataListSearchDailyProduction.Columns[7].HeaderText = "Tezgah/Makina";
                dataListSearchDailyProduction.Columns[8].HeaderText = "Ayar Yapan";
                dataListSearchDailyProduction.Columns[9].HeaderText = "Üretim Yapan";
                dataListSearchDailyProduction.Columns[10].Visible = false; // Açıklama
                dataListSearchDailyProduction.Columns[11].Visible = false; // Program Number
                dataListSearchDailyProduction.Columns[12].Visible = false; // OrderId
                dataListSearchDailyProduction.Columns[13].Visible = false; // IsStarted
                dataListSearchDailyProduction.Columns[14].Visible = false; // ProductionId
            }
        }

        private void OrderDataGridTextAktar()
        {
            if (selectedIndex1 >= 0 && dataListOrder.RowCount > 0)
            {
                txtSiparisTarihi.Text = Convert.ToDateTime(dataListOrder.Rows[selectedIndex1].Cells[0].Value).ToShortDateString();
                txtUrunAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[1].Value.ToString();
                txtMusteriAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[2].Value.ToString();
                txtMiktar.Text = dataListOrder.Rows[selectedIndex1].Cells[3].Value.ToString();
                txtTeslimTarihi.Text = Convert.ToDateTime(dataListOrder.Rows[selectedIndex1].Cells[4].Value).ToShortDateString();
                txtAciklama.Text = dataListOrder.Rows[selectedIndex1].Cells[6].Value.ToString();
                txtProgramAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[12].Value.ToString();

                dataListOrder.Rows[selectedIndex1].Selected = true;
                btnOnayaGönder.Enabled = true;
            }
            else
            {
                dataListOrder.DataSource = null;
                txtSiparisTarihi.Clear();
                txtUrunAdi.Clear();
                txtMusteriAdi.Clear();
                txtMiktar.Clear();
                txtTeslimTarihi.Clear();
                txtAciklama.Clear();
                btnOnayaGönder.Enabled = false;
            }

        }

        private void OrderProductionDataGridTextAktar()
        {
            if (selectedIndex2 >= 0 && dataListOrderProduction.RowCount > 0)
            {
                dataListOrderProduction.Rows[selectedIndex2].Selected = true;
                btnGeriGonder.Enabled = true;
                btnOnayla.Enabled = true;
            }
            else
            {
                dataListOrderProduction.DataSource = null;
                btnGeriGonder.Enabled = false;
                btnOnayla.Enabled = false;
            }

        }

        private void ProductionDataGridTextAktar()
        {
            if (selectedIndex3 >= 0 && selectedIndex3 < dataListProduction.RowCount)
            {
                txtUrunAdi3.Text = dataListProduction.Rows[selectedIndex3].Cells[1].Value.ToString();
                txtMusteriAdi3.Text = dataListProduction.Rows[selectedIndex3].Cells[2].Value.ToString();
                txtTezgah3.Text = dataListProduction.Rows[selectedIndex3].Cells[9].Value.ToString();
                txtAciklama3.Text = dataListProduction.Rows[selectedIndex3].Cells[11].Value.ToString();
                txtAyarYapan3.Text = dataListProduction.Rows[selectedIndex3].Cells[10].Value.ToString();
                txtProgramNo3.Text = dataListProduction.Rows[selectedIndex3].Cells[15].Value.ToString(); ;

                dataListProduction.Rows[selectedIndex3].Selected = true;
            }
            else
            {
                dataListProduction.DataSource = null;
            }
        }

        private void SearchDailyProductionDataGridTextAktar()
        {

        }

        private void ListeYenile()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    GetOrderList();
                    SetOrderDataGridSettings();
                    OrderDataGridTextAktar();

                    BaslikKayitEtiketLocation();
                    break;

                case 1:
                    GetOrderProductionList();
                    SetOrderProductionDataGridSettings();
                    OrderProductionDataGridTextAktar();

                    lblOnayBilgi.Text = "Listeden seçilen bir İş Emrini 'Onayla' butonu ile üretime alabilirsiniz. \nOnay verilerek üretime gönderilen İş Emirleri üretimden tekrar geri alınamaz.";
                    BaslikKayitEtiketLocation();
                    break;

                case 2:
                    GetProductionList();
                    SetProductionDataGridSettings();
                    ProductionDataGridTextAktar();

                    GetDailyProductionList();
                    SetDailyProductionDataGridSettings();

                    BaslikKayitEtiketLocation();
                    break;

                case 3:
                    BaslikKayitEtiketLocation();
                    break;
            }
        }

        private void ProductionTabEnableButtonAndText()
        {
            btnDuzenle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void ProductionTabDisableButtonAndText()
        {
            btnDuzenle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void ProductionTabClearText()
        {

        }

        private void FrmProduction_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListeYenile();
        }

        private void FrmProduction_Shown(object sender, EventArgs e)
        {
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1_SelectedIndexChanged(tabControl1, EventArgs.Empty);
            ListeYenile();
        }

        private void listOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex1 = dataListOrder.CurrentCell.RowIndex;
            OrderDataGridTextAktar();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            ListeYenile();
        }

        private void btnYenile2_Click(object sender, EventArgs e)
        {
            ListeYenile();
        }

        private async void btnOnayaGönder_Click(object sender, EventArgs e)
        {
            if (listTezgah.Items.Count > 0 && listAyarOperator.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show($"Müşteri : {txtMusteriAdi.Text}\n" +
                    $"Ürün: {txtUrunAdi.Text}\n" +
                    $"Tezgah / Makina: {listTezgah.Text}\n" +
                    $"Ayar Yapacak Operatör: {listAyarOperator.Text}\n" +
                    $"Bu iş emrini ÜRETİM ONAY LİSTESİNE almak istiyor musunuz?", "İş Emri Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var order = await _orderRepository.GetByIdAsync(dataListOrder.Rows[selectedIndex1].Cells[7].Value.ToString());
                    order.IsWaiting = false;
                    order.UserId = Guid.Parse(listAyarOperator.SelectedValue.ToString());
                    order.MachineId = Guid.Parse(listTezgah.SelectedValue.ToString());

                    await _orderRepository.SaveAsync();

                    selectedIndex1 = 0;
                    ListeYenile();
                }
            }
            else
            {
                MessageBox.Show("Tanımlı Tezgah veya Operatör yok.?", "Tezgah Ve Operatör Tanım Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void btnGeriGonder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu iş emrini ÜRETİM ONAY LİSTESİNDEN geri çekmek istiyor musunuz?", "İş Emri Geri Çek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var order = await _orderRepository.GetByIdAsync(dataListOrderProduction.Rows[selectedIndex2].Cells[6].Value.ToString());
                order.IsWaiting = true;

                await _orderRepository.SaveAsync();

                selectedIndex2 = 0;
                ListeYenile();
            }
        }

        private void listOrderProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex2 = dataListOrderProduction.CurrentCell.RowIndex;
            OrderProductionDataGridTextAktar();
        }

        private void dataListProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListProduction.RowCount > 0)
            {
                selectedIndex3 = dataListProduction.CurrentCell.RowIndex;
                ListeYenile();
            }
        }

        private void pnlStatus1_Resize(object sender, EventArgs e)
        {
            BaslikKayitEtiketLocation();
        }

        private void pnlStatus2_Resize(object sender, EventArgs e)
        {
            BaslikKayitEtiketLocation();
        }

        private void BaslikKayitEtiketLocation()
        {
            label16.Location = new Point((pnlStatus1.Width - label16.Width) / 2, (pnlStatus1.Height - label16.Height) / 2);
            lblKayitSayisi.Left = (pnlStatus1.Width - lblKayitSayisi.Width - 10);

            label17.Location = new Point((pnlStatus2.Width - label17.Width) / 2, (pnlStatus2.Height - label17.Height) / 2);
            lblKayitSayisi2.Left = (pnlStatus2.Width - lblKayitSayisi2.Width - 10);

            label12.Location = new Point((pnlStatus3.Width - label12.Width) / 2, (pnlStatus3.Height - label12.Height) / 2);
            lblKayitSayisi3.Left = (pnlStatus3.Width - lblKayitSayisi3.Width - 10);

            label22.Location = new Point((pnlStatus4.Width - label22.Width) / 2, (pnlStatus4.Height - label22.Height) / 2);
            //lblKayitSayisi4.Left = (pnlStatus4.Width - lblKayitSayisi4.Width - 10);

        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Müşteri : {dataListOrderProduction.Rows[selectedIndex2].Cells[2].Value}\n" +
                    $"Ürün: {dataListOrderProduction.Rows[selectedIndex2].Cells[1].Value}\n" +
                    $"Tezgah / Makina: {dataListOrderProduction.Rows[selectedIndex2].Cells[8].Value}\n" +
                    $"Ayar Yapacak Operatör: {dataListOrderProduction.Rows[selectedIndex2].Cells[9].Value}\n\n" +
                    $"Bu iş emrini ONAYLAMAK istediğinize emin misiniz?\n" +
                    $"Onay işleminden sonra İş Emrini GERİ ALAMAZSINIZ.", "Üretim Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var pr = await _orderRepository.GetByIdAsync(dataListOrderProduction.Rows[selectedIndex2].Cells[6].Value.ToString());
                pr.IsProduction = true;

                await _orderRepository.SaveAsync();

                selectedIndex2 = 0;
                ListeYenile();
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.FromArgb(175, 174, 209), Color.FromArgb(175, 174, 209), System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.White);
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        private void listTezgah_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listAyarOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listUretimOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {


        }

        private void btnIptal_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile3_Click(object sender, EventArgs e)
        {
            if (dataListProduction.RowCount > 0)
            {
                selectedIndex3 = 0;
                ListeYenile();
                dataListProduction.Rows[selectedIndex3].Selected = true;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            var dailyProduction = _productionRepository
                    .GetWhere(pr => pr.Id == Guid.Parse(dataListDailyProduction.Rows[selectedIndex4].Cells[6].Value.ToString()), false).FirstOrDefault();

            int remainQuantity = 0;

            if (dailyProduction != null)
            {
                frmDailyProductionUpdate = new FrmDailyProductionUpdate(true, dailyProduction, remainQuantity);
                frmDailyProductionUpdate.ShowDialog();
                ListeYenile();
            }
            else
                MessageBox.Show("Veritabanında istenen kayda erişelemedi.", "Erişim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dataListDailyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex4 = dataListDailyProduction.CurrentCell.RowIndex;
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            bool isDeleted = _productionRepository.Delete(dataListDailyProduction.Rows[selectedIndex4].Cells[4].Value.ToString());

            await _productionRepository.SaveAsync();

            GetProductionList();
            SetProductionDataGridSettings();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string orderId = dataListProduction.Rows[selectedIndex3].Cells[12].Value.ToString();

            frmDailyProductionConfirm = new FrmDailyProductionConfirm(orderId);
            frmDailyProductionConfirm.ShowDialog();

            ListeYenile();

            btnStart.Enabled = false;
            btnFinish.Enabled = true;

            ListeYenile();
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var production = _productionRepository
                    .GetWhere(pr => pr.Order.Id == Guid.Parse(dataListProduction.Rows[selectedIndex3].Cells[12].Value.ToString()) && pr.IsStarted).FirstOrDefault();

            int remainQuantity = Convert.ToInt32(dataListProduction.Rows[selectedIndex3].Cells[6].Value.ToString());

            if (production != null)
            {
                frmDailyProductionUpdate = new FrmDailyProductionUpdate(false, production, remainQuantity);
                frmDailyProductionUpdate.ShowDialog();
                ListeYenile();
            }
            else
                MessageBox.Show("Veritabanında kayıt bulunamadı", "Erişim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmProduction_SizeChanged(object sender, EventArgs e)
        {
            BaslikKayitEtiketLocation();
        }

        private void btnBaşlangic_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(348, 51);
            monthCalendar1.Visible = true;
            monthCalendarNo = 0;
        }

        private void btnBitis_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(348, 81);
            monthCalendar1.Visible = true;
            monthCalendarNo = 1;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            switch (monthCalendarNo)
            {
                case 0:
                    txtBaslangicTarihi.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
                case 1:
                    txtBitisTarihi.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
            }

            monthCalendar1.Visible = false;
        }

        private void btnBaslangicSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtBaslangicTarihi.Clear();
        }

        private void btnBitisSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtBitisTarihi.Clear();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SearchDailyProductionList();

            if (dataListSearchDailyProduction.RowCount > 0)
            {
                dataListSearchDailyProduction.Rows[0].Selected = true;
                selectedIndex5 = 0;
            }
        }

        private void dataListSearchDailyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListSearchDailyProduction.RowCount > 0)
            {
                selectedIndex5 = dataListSearchDailyProduction.CurrentCell.RowIndex;
                SearchDailyProductionDataGridTextAktar();
            }
        }

        private void btnTezgahAdiSil_Click(object sender, EventArgs e)
        {
            txtTezgahAdiAra.Clear();
        }

        private void btnOperatorAdiSil_Click(object sender, EventArgs e)
        {
            txtOperatorAdiAra.Clear();
        }

        private void listTezgah_DropDown(object sender, EventArgs e)
        {
            GetMachineList();
        }

        private void listAyarOperator_DropDown(object sender, EventArgs e)
        {
            GetUserList();
        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text != "")
            {
                var product = _productRepository
                    .GetWhere(p => p.Name == txtUrunAdi.Text)
                    .Include(p => p.Material)
                    .Include(p => p.MachineProgram)
                    .FirstOrDefault();

                if (product != null)
                {
                    txtIslenecekMalzeme.Text = product.Material?.Name;
                    txtProgramAdi.Text = product.MachineProgram?.Name;
                }
            }
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            txtUrunAdiAra.Clear();
        }

        private void btnMusteriAdıSil_Click(object sender, EventArgs e)
        {
            txtMusteriAdiAra.Clear();
        }

        private void tabControl1_Leave(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 2)
            {
                e.Cancel = true; // Geçişi iptal et
                MessageBox.Show("Kontrolden çıkamazsınız.");
            }
        }
    }
}
