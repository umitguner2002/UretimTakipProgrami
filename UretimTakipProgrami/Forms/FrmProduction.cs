using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

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
        private FrmProductionDefinitions frmDef;

        private int selectedIndex1 = 0; // Order List Index
        private int selectedIndex2 = 0;
        private int selectedIndex3 = 0; // Production List Index
        private int selectedIndex4 = 0; // Daily Production List Index
        private int selectedIndex5 = 0; // Daily Production Search Page Index

        private int monthCalendarNo = 0;

        private Point lastLocation;
        private System.Windows.Controls.Panel selectedPanel;
        System.Windows.Forms.ToolTip buttonToolTip;

        private User _user;

        private bool editMode = false;

        public FrmProduction(User user)
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
            buttonToolTip = new System.Windows.Forms.ToolTip();
            _user = _userRepository.GetWhere(u => u.Id == user.Id).FirstOrDefault();

            CheckUserAuth(_user);
        }

        private class Durumlar
        {
            public const string Acil = "Acil";
            public const string Uretimde = "Üretimde";
            public const string Beklemede = "Beklemede";
        }

        private class TabPageName
        {
            public const string Page1 = "tabPage1";
            public const string Page2 = "tabPage2";
            public const string Page3 = "tabPage3";
            public const string Page4 = "tabPage4";
        }

        private void GetOrderList()
        {
            dataListOrder.DataSource = null;

            var orderList = _orderRepository.GetAll()
            .Select(order => new
            {
                order.OrderCode,
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
                order.OrderCode, // 0
                orderCreatedDate = order.CreatedDate.ToLocalTime(), // 1
                productName = order.Product.Name, // 2
                customerName = order.Customer.Name, // 3
                order.Quantity, // 4
                deliveryDate = order.DeliveryDate.ToLocalTime().Date, // 5
                orderAciliyet = order.IsUrgent ? Durumlar.Acil : "", // 6
                order.Id, // 7
                order.IsUrgent, // 8
                machineName = order.Machine.Name != null ? order.Machine.Name : "", // 9
                userName = order.User.Name != null ? order.User.Name : "", // 10
                order.Description, // 11
                order.IsWaiting, // 12
                order.IsProduction, // 13
                order.IsReady // 14
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

            var orderList = _orderRepository.GetAll()
            .Select(order => new
            {
                order.OrderCode,
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
                order.OrderCode, // 0
                order.orderCreatedDate, // 1
                order.productName, // 2
                order.customerName, // 3
                order.Quantity, // 4
                order.productionQuantity, // 5
                order.productionWastage, // 6
                productionRemain = order.Quantity - order.productionQuantity, // 7
                order.deliveryDate, // 8
                order.orderAciliyet, // 9
                order.orderMachine, // 10
                order.operatorName, // 11
                order.Description, // 12
                order.Id, // 13
                order.IsWaiting, // 14
                order.IsProduction, // 15
                order.programName, //16
                order.productionState, // 17
                order.IsReady // 18
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
                    .OrderByDescending(pr => pr.productionStartDate)
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
                    .Where(pr => pr.orderId == Guid.Parse(dataListProduction.Rows[selectedIndex3].Cells[13].Value.ToString()) && pr.Quantity >= 0)
                    .ToList();

                if (dailyProductionList.Count > 0)
                {
                    dataListDailyProduction.DataSource = dailyProductionList;

                    startActive = dailyProductionList
                        .FirstOrDefault(pr => pr.IsStarted != null && pr.IsStarted == true)?.IsStarted ?? false;
                }

                if (startActive)
                {
                    btnStart.Enabled = false;
                    btnFinish.Enabled = true;
                    btnDuzenle.Enabled = false;
                    btnSil.Enabled = false;

                    lblProductionState.Text = "ÜRETİME BAŞLANDI";
                    panel7.BackColor = Color.FromArgb(80, 200, 120);
                }
                else
                {
                    btnStart.Enabled = true;
                    btnFinish.Enabled = false;
                    btnDuzenle.Enabled = true;
                    btnSil.Enabled = true;

                    lblProductionState.Text = "BEKLEMEDE";
                    panel7.BackColor = Color.FromArgb(175, 174, 209);
                }
            }
        }

        public List<object> GetDailyProductionT(string orderId) // Test için
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
                    .OrderByDescending(pr => pr.productionStartDate)
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
                    .Where(pr => pr.orderId == Guid.Parse(orderId) && pr.Quantity >= 0)
                    .ToList<object>();

            return dailyProductionList;
        }

        private void SearchDailyProductionList() // Günlük arama listesi sonucunu getir.
        {
            dataListSearchDailyProduction.DataSource = null;

            DateTime? baslangicTarih = null;
            DateTime? bitisTarih = null;

            string arananIsEmriNo = txtIsEmriNoAra.Text;
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

            var dailyProductionList = _productionRepository.GetWhere(pr => pr.FinishDate != null)
            .Select(production => new
            {
                production.Order.OrderCode,
                productionStartDate = production.CreatedDate.ToLocalTime(),
                productionFinishDate = production.FinishDate != null ? ((DateTime)production.FinishDate).ToLocalTime() : (DateTime?)null,
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
                (!bitisTarih.HasValue || (pr.productionFinishDate.HasValue && pr.productionFinishDate.Value.Date <= bitisTarih.Value)) &&
                (string.IsNullOrEmpty(arananIsEmriNo) || pr.OrderCode == arananIsEmriNo) &&
                (string.IsNullOrEmpty(arananTezgah) || pr.machineName.ToLower().Contains(arananTezgah)) &&
                (string.IsNullOrEmpty(arananOperator) || pr.producedOperatorName.ToLower().Contains(arananOperator)) &&
                (string.IsNullOrEmpty(arananMusteri) || pr.customerName.ToLower().Contains(arananMusteri.ToLower())) &&
                (string.IsNullOrEmpty(arananUrun) || pr.productName.ToLower().Contains(arananUrun.ToLower())))
            .OrderBy(pr => pr.OrderCode)
            .ThenBy(pr => pr.productionFinishDate)
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

                dataListOrder.Columns[0].HeaderText = "İş Emri No";
                dataListOrder.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrder.Columns[1].HeaderText = "Sipariş Tarihi";
                dataListOrder.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrder.Columns[2].HeaderText = "Ürün Adı";
                dataListOrder.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrder.Columns[3].HeaderText = "Müşteri Adı / Unvanı";
                dataListOrder.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrder.Columns[4].HeaderText = "Miktar";
                dataListOrder.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrder.Columns[5].HeaderText = "Teslim Tarihi";
                dataListOrder.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrder.Columns[6].HeaderText = "Öncelik";
                dataListOrder.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrder.Columns[7].HeaderText = "Açıklama";
                dataListOrder.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrder.Columns[8].Visible = false; // Order Id
                dataListOrder.Columns[9].Visible = false; // Product Id
                dataListOrder.Columns[10].Visible = false; // Customer Id
                dataListOrder.Columns[11].Visible = false; // IsWaiting
                dataListOrder.Columns[12].Visible = false; // IsProduction
                dataListOrder.Columns[13].Visible = false; // ProgramName

                int acilDurumSutunu = 6;

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

                dataListOrderProduction.Columns[0].HeaderText = "İş Emri No";
                dataListOrderProduction.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrderProduction.Columns[1].HeaderText = "Sipariş Tarihi";
                dataListOrderProduction.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrderProduction.Columns[2].HeaderText = "Ürün Adı";
                dataListOrderProduction.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrderProduction.Columns[3].HeaderText = "Müşteri Adı / Unvanı";
                dataListOrderProduction.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrderProduction.Columns[4].HeaderText = "Miktar";
                dataListOrderProduction.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrderProduction.Columns[5].HeaderText = "Teslim Tarihi";
                dataListOrderProduction.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrderProduction.Columns[6].HeaderText = "Öncelik";
                dataListOrderProduction.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListOrderProduction.Columns[7].Visible = false; // Order Id
                dataListOrderProduction.Columns[8].Visible = false; // Öncelik/Aciliyet

                dataListOrderProduction.Columns[9].HeaderText = "Makina/Tezgah";
                dataListOrderProduction.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrderProduction.Columns[10].HeaderText = "Ayar Yapan Operatör";
                dataListOrderProduction.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrderProduction.Columns[11].HeaderText = "Açıklama";
                dataListOrderProduction.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListOrderProduction.Columns[12].Visible = false; // IsWaiting
                dataListOrderProduction.Columns[13].Visible = false; // IsProduction
                dataListOrderProduction.Columns[14].Visible = false; // IsReady

                int acilDurumSutunu = 6;

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
                dataListProduction.ColumnHeadersHeight = 25;

                dataListProduction.Columns[0].HeaderText = "İş Emri No";
                dataListProduction.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[1].Visible = false; // Sipariş Tarihi

                dataListProduction.Columns[2].HeaderText = "Ürün Adı";
                dataListProduction.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProduction.Columns[3].HeaderText = "Müşteri Adı / Unvanı";
                dataListProduction.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProduction.Columns[4].HeaderText = "Sipariş";
                dataListProduction.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[5].HeaderText = "Üretim";
                dataListProduction.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[6].HeaderText = "Defolu";
                dataListProduction.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[7].HeaderText = "Kalan";
                dataListProduction.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[8].HeaderText = "Teslim Tarihi";
                dataListProduction.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[9].HeaderText = "Öncelik";
                dataListProduction.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListProduction.Columns[10].HeaderText = "Tezgah/Makina";
                dataListProduction.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProduction.Columns[11].Visible = false; // Ayar Yapan
                dataListProduction.Columns[12].Visible = false; // Açıklama
                dataListProduction.Columns[13].Visible = false; // Order Id
                dataListProduction.Columns[14].Visible = false; // IsWaiting
                dataListProduction.Columns[15].Visible = false; // IsProduction
                dataListProduction.Columns[16].Visible = false; // Program No

                dataListProduction.Columns[17].HeaderText = "Üretim Durumu"; // IsStarted
                dataListProduction.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProduction.Columns[18].Visible = false; // IsReady
                dataListProduction.ScrollBars = ScrollBars.Both;

                int acilDurumSutunu = 9;
                int orderColumn = 4;
                int remainColumn = 7;

                int productionColumn = 5;
                int wastageColumn = 6;
                int productionStateColumn = 17;

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

                lblKayitSayisi3.Text = $"İş Emri Sayısı: {dataListProduction.RowCount.ToString()}";
            }
            else
                lblKayitSayisi3.Text = "Gösterilecek kayıt yok";
        }

        private void SetDailyProductionDataGridSettings()
        {
            if (dataListDailyProduction.Rows.Count > 0)
            {
                dataListProduction.ColumnHeadersHeight = 25;

                dataListDailyProduction.Columns[0].HeaderText = "Üretim Başlangıç";
                dataListDailyProduction.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataListDailyProduction.Columns[1].HeaderText = "Üretim Bitiş";
                dataListDailyProduction.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataListDailyProduction.Columns[2].HeaderText = "Çalışma Süresi";
                dataListDailyProduction.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataListDailyProduction.Columns[3].HeaderText = "Miktar";
                dataListDailyProduction.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListDailyProduction.Columns[4].HeaderText = "Defolu";
                dataListDailyProduction.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListDailyProduction.Columns[5].Visible = false;
                dataListDailyProduction.Columns[6].Visible = false;
                dataListDailyProduction.Columns[7].Visible = false;
                dataListDailyProduction.Columns[8].HeaderText = "Üretimi Yapan";
                dataListDailyProduction.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetDailyProductionSearchDataGridSettings() // Search Daily Production
        {
            if (dataListSearchDailyProduction.Rows.Count > 0)
            {
                dataListSearchDailyProduction.ColumnHeadersHeight = 25;

                dataListSearchDailyProduction.Columns[0].HeaderText = "İş Emri No";
                dataListSearchDailyProduction.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataListSearchDailyProduction.Columns[1].HeaderText = "Üretim Başlangıç";
                dataListSearchDailyProduction.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListSearchDailyProduction.Columns[2].HeaderText = "Üretim Bitiş";
                dataListSearchDailyProduction.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListSearchDailyProduction.Columns[3].HeaderText = "Çalışma Süresi";
                dataListSearchDailyProduction.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListSearchDailyProduction.Columns[4].HeaderText = "Ürün Adı";
                dataListSearchDailyProduction.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListSearchDailyProduction.Columns[5].HeaderText = "Müşteri Adı";
                dataListSearchDailyProduction.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListSearchDailyProduction.Columns[6].HeaderText = "Miktar";
                dataListSearchDailyProduction.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListSearchDailyProduction.Columns[7].HeaderText = "Defolu";
                dataListSearchDailyProduction.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataListSearchDailyProduction.Columns[8].HeaderText = "Tezgah/Makina";
                dataListSearchDailyProduction.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListSearchDailyProduction.Columns[9].HeaderText = "Ayar Yapan";
                dataListSearchDailyProduction.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListSearchDailyProduction.Columns[10].HeaderText = "Üretim Yapan";
                dataListSearchDailyProduction.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListSearchDailyProduction.Columns[11].HeaderText = "Açıklama";
                dataListSearchDailyProduction.Columns[11].Visible = false;

                dataListSearchDailyProduction.Columns[12].HeaderText = "Program Adı";
                dataListSearchDailyProduction.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataListSearchDailyProduction.Columns[12].Visible = false; // Program Number
                
                dataListSearchDailyProduction.Columns[13].Visible = false; // OrderId
                dataListSearchDailyProduction.Columns[14].Visible = false; // IsStarted
                dataListSearchDailyProduction.Columns[15].Visible = false; // ProductionId
            }
        }

        private void OrderDataGridTextAktar()
        {
            if (selectedIndex1 >= 0 && dataListOrder.RowCount > 0)
            {
                txtIsEmriNo1.Text = dataListOrder.Rows[selectedIndex1].Cells[0].Value.ToString();
                txtSiparisTarihi.Text = Convert.ToDateTime(dataListOrder.Rows[selectedIndex1].Cells[1].Value).ToShortDateString();
                txtUrunAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[2].Value.ToString();
                txtMusteriAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[3].Value.ToString();
                txtMiktar.Text = dataListOrder.Rows[selectedIndex1].Cells[4].Value.ToString();
                txtTeslimTarihi.Text = Convert.ToDateTime(dataListOrder.Rows[selectedIndex1].Cells[5].Value).ToShortDateString();
                txtProgramAdi.Text = dataListOrder.Rows[selectedIndex1].Cells[13].Value.ToString();

                dataListOrder.Rows[selectedIndex1].Selected = true;
                btnOnayaGönder.Enabled = true;
            }
            else
            {
                dataListOrder.DataSource = null;
                txtIsEmriNo1.Clear();
                txtSiparisTarihi.Clear();
                txtUrunAdi.Clear();
                txtMusteriAdi.Clear();
                txtIslenecekMalzeme.Clear();
                txtProgramAdi.Clear();
                txtMiktar.Clear();
                txtTeslimTarihi.Clear();
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
                txtIsEmriNo3.Text = dataListProduction.Rows[selectedIndex3].Cells[0].Value.ToString();
                txtUrunAdi3.Text = dataListProduction.Rows[selectedIndex3].Cells[2].Value.ToString();
                txtMusteriAdi3.Text = dataListProduction.Rows[selectedIndex3].Cells[3].Value.ToString();
                txtTezgah3.Text = dataListProduction.Rows[selectedIndex3].Cells[10].Value.ToString();
                txtAciklama3.Text = dataListProduction.Rows[selectedIndex3].Cells[12].Value.ToString();
                txtAyarYapan3.Text = dataListProduction.Rows[selectedIndex3].Cells[11].Value.ToString();
                txtProgramNo3.Text = dataListProduction.Rows[selectedIndex3].Cells[16].Value.ToString(); ;

                dataListProduction.Rows[selectedIndex3].Selected = true;
            }
            else
            {
                dataListProduction.DataSource = null;
            }
        }

        private void ListeYenile(string tabpagename)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Name == tabpagename)
                {
                    switch (tabpagename)
                    {
                        case TabPageName.Page1:
                            GetOrderList();
                            SetOrderDataGridSettings();
                            OrderDataGridTextAktar();

                            BaslikKayitEtiketLocation();
                            break;

                        case TabPageName.Page2:
                            GetOrderProductionList();
                            SetOrderProductionDataGridSettings();
                            OrderProductionDataGridTextAktar();

                            lblOnayBilgi.Text = "Listeden seçilen bir İş Emrini 'Onayla' butonu ile üretime alabilirsiniz. \nOnay verilerek üretime gönderilen İş Emirleri üretimden tekrar geri alınamaz.";
                            BaslikKayitEtiketLocation();
                            break;

                        case TabPageName.Page3:
                            GetProductionList();
                            SetProductionDataGridSettings();
                            ProductionDataGridTextAktar();

                            GetDailyProductionList();
                            SetDailyProductionDataGridSettings();

                            BaslikKayitEtiketLocation();
                            break;

                        case TabPageName.Page4:
                            BaslikKayitEtiketLocation();
                            break;
                    }
                }
            }
        }

        private void FrmProduction_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void CheckUserAuth(User u)
        {
            List<TabPage> hideTabPages = new List<TabPage>();
            List<int> hideTabPageNumbers = new List<int>();
            bool isAdminManager = false;

            if (u.IsAdmin)
                hideTabPageNumbers = new List<int> { 1 };
            else if (u.IsManager)
                hideTabPageNumbers = new List<int> { 0, 2 };
            else if (u.IsOperator)
                hideTabPageNumbers = new List<int> { 0, 1, 3 };

            if (u.IsManager && u.IsOperator)
                hideTabPageNumbers = new List<int> { 0 };

            if (u.IsAdmin && u.IsOperator)
                hideTabPageNumbers = new List<int> { 1 };

            if (u.IsAdmin && u.IsManager)
                isAdminManager = true;

            if (!isAdminManager)
            {
                foreach (int i in hideTabPageNumbers)
                {
                    hideTabPages.Add(tabControl1.TabPages[i]);
                }

                foreach (TabPage tabPage in hideTabPages)
                {
                    tabControl1.TabPages.Remove(tabPage);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTabControlIndex();
        }

        private void CheckTabControlIndex()
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Name == TabPageName.Page1)
                    ListeYenile(TabPageName.Page1);
                else if (tabPage.Name == TabPageName.Page2)
                    ListeYenile(TabPageName.Page2);
                else if (tabPage.Name == TabPageName.Page3)
                    ListeYenile(TabPageName.Page3);
                else if (tabPage.Name == TabPageName.Page4)
                    ListeYenile(TabPageName.Page4);
            }
        }

        private void FrmProduction_Shown(object sender, EventArgs e)
        {
            CheckTabControlIndex();
        }

        private void listOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex1 = dataListOrder.CurrentCell.RowIndex;
            OrderDataGridTextAktar();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            ListeYenile(TabPageName.Page1);
        }

        private void btnYenile2_Click(object sender, EventArgs e)
        {
            ListeYenile(TabPageName.Page2);
        }

        private async void btnOnayaGönder_Click(object sender, EventArgs e)
        {
            if (selectedIndex1 > -1)
            {
                string orderId = dataListOrder.Rows[selectedIndex1].Cells[8].Value.ToString();

                FrmSendToProduction frmSendToProduction = new FrmSendToProduction(orderId);
                frmSendToProduction.ShowDialog();

                if (dataListOrder.RowCount == 0)
                    selectedIndex1 = -1;

                ListeYenile(TabPageName.Page1);
            }
        }

        private async void btnGeriGonder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu iş emrini ÜRETİM ONAY LİSTESİNDEN geri çekmek istiyor musunuz?", "İş Emri Geri Çek", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var order = await _orderRepository.GetByIdAsync(dataListOrderProduction.Rows[selectedIndex2].Cells[7].Value.ToString());
                order.IsWaiting = true;

                await _orderRepository.SaveAsync();

                selectedIndex2 = 0;
                ListeYenile(TabPageName.Page2);
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
                ProductionDataGridTextAktar();
                GetDailyProductionList();
                SetDailyProductionDataGridSettings();
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
            DialogResult result = MessageBox.Show($"Müşteri : {dataListOrderProduction.Rows[selectedIndex2].Cells[3].Value}\n" +
                    $"Ürün: {dataListOrderProduction.Rows[selectedIndex2].Cells[2].Value}\n" +
                    $"Tezgah / Makina: {dataListOrderProduction.Rows[selectedIndex2].Cells[9].Value}\n" +
                    $"Ayar Yapacak Operatör: {dataListOrderProduction.Rows[selectedIndex2].Cells[10].Value}\n\n" +
                    $"Bu iş emrini ONAYLAMAK istediğinize emin misiniz?\n" +
                    $"Onay işleminden sonra İş Emrini GERİ ALAMAZSINIZ.", "Üretim Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var pr = await _orderRepository.GetByIdAsync(dataListOrderProduction.Rows[selectedIndex2].Cells[7].Value.ToString());
                pr.IsProduction = true;

                await _orderRepository.SaveAsync();

                selectedIndex2 = 0;
                ListeYenile(TabPageName.Page2);
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

            SolidBrush fillbrush = new SolidBrush(Color.FromArgb(175, 174, 209));
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);
            background.Size = new Size(tabControl1.Right - background.Left, lasttabrect.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);
        }

        private void btnYenile3_Click(object sender, EventArgs e)
        {
            if (dataListProduction.RowCount > 0)
            {
                selectedIndex3 = 0;
                ListeYenile(TabPageName.Page3);
                dataListProduction.Rows[selectedIndex3].Selected = true;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataListDailyProduction.RowCount > 0)
            {
                var dailyProduction = _productionRepository
                    .GetWhere(pr => pr.Id == Guid.Parse(dataListDailyProduction.Rows[selectedIndex4].Cells[6].Value.ToString()), false).FirstOrDefault();

                int editQuantity = Convert.ToInt32(dataListDailyProduction.Rows[selectedIndex4].Cells[3].Value.ToString());
                int wastageQuantity = Convert.ToInt32(dataListDailyProduction.Rows[selectedIndex4].Cells[4].Value.ToString());

                if (dailyProduction != null)
                {
                    frmDailyProductionUpdate = new FrmDailyProductionUpdate(true, dailyProduction, editQuantity, wastageQuantity);
                    frmDailyProductionUpdate.ShowDialog();
                    ListeYenile(TabPageName.Page3);
                }
                else
                    MessageBox.Show("Veritabanında istenen kayda erişelemedi.", "Erişim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Güncellenecek kayıt yok.", "Üretim Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void dataListDailyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex4 = dataListDailyProduction.CurrentCell.RowIndex;
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dataListDailyProduction.RowCount > 0)
            {
                var result = MessageBox.Show("Bu üretimi silmek istediğinize emin misiniz?", "Günlük Üretim Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool isDeleted = _productionRepository.Delete(dataListDailyProduction.Rows[selectedIndex4].Cells[6].Value.ToString());

                    await _productionRepository.SaveAsync();

                    GetProductionList();
                    SetProductionDataGridSettings();
                    GetDailyProductionList();
                    SetDailyProductionDataGridSettings();
                }
            }
            else
                MessageBox.Show("Silinecek kayıt yok.", "Üretim Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string orderId = dataListProduction.Rows[selectedIndex3].Cells[13].Value.ToString();

            frmDailyProductionConfirm = new FrmDailyProductionConfirm(orderId);
            frmDailyProductionConfirm.ShowDialog();

            ListeYenile(TabPageName.Page3);
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var production = _productionRepository
                    .GetWhere(pr => pr.Order.Id == Guid.Parse(dataListProduction.Rows[selectedIndex3].Cells[13].Value.ToString()) && pr.IsStarted).FirstOrDefault();

            int remainQuantity = Convert.ToInt32(dataListProduction.Rows[selectedIndex3].Cells[7].Value.ToString());
            int wastageQuantity = 0;

            if (production != null)
            {
                frmDailyProductionUpdate = new FrmDailyProductionUpdate(false, production, remainQuantity, wastageQuantity);
                frmDailyProductionUpdate.ShowDialog();
                ListeYenile(TabPageName.Page3);
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
            if (!string.IsNullOrEmpty(txtUrunAdiAra.Text) || !string.IsNullOrEmpty(txtMusteriAdiAra.Text) ||
               !string.IsNullOrEmpty(txtTezgahAdiAra.Text) || !string.IsNullOrEmpty(txtBaslangicTarihi.Text) ||
               !string.IsNullOrEmpty(txtBitisTarihi.Text) || !string.IsNullOrEmpty(txtOperatorAdiAra.Text) ||
               !string.IsNullOrEmpty(txtIsEmriNoAra.Text))
            {
                SearchDailyProductionList();

                if (dataListSearchDailyProduction.RowCount > 0)
                {
                    dataListSearchDailyProduction.Rows[0].Selected = true;
                    selectedIndex5 = 0;
                }
            }
        }

        private void dataListSearchDailyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListSearchDailyProduction.RowCount > 0)
                selectedIndex5 = dataListSearchDailyProduction.CurrentCell.RowIndex;
        }

        private void btnTezgahAdiSil_Click(object sender, EventArgs e)
        {
            txtTezgahAdiAra.Clear();
        }

        private void btnOperatorAdiSil_Click(object sender, EventArgs e)
        {
            txtOperatorAdiAra.Clear();
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

        private void SaveToExcel()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.Title = "Excel'e Kaydet";
            saveFileDialog1.FileName = "report.xlsx";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Veri Sayfası");


                    for (int i = 0; i < dataListSearchDailyProduction.Columns.Count - 4; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataListSearchDailyProduction.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    }

                    // DataGridView'deki verileri Excel'e aktar
                    for (int j = 1; j < dataListSearchDailyProduction.Rows.Count + 1; j++)
                    {
                        for (int k = 0; k < dataListSearchDailyProduction.Columns.Count - 4; k++)
                        {
                            var cellValue = dataListSearchDailyProduction.Rows[j - 1].Cells[k].Value;
                            var cell = worksheet.Cell(j + 1, k + 1);

                            //if ((j % 2) == 0) // Satır numarasına göre renklendirme
                            //{
                            //    cell.Style.Fill.BackgroundColor = XLColor.DarkSeaGreen;
                            //}

                            if (cellValue != null)
                            {
                                if(k == 6 || k == 7)
                                    cell.Value = Convert.ToInt16(cellValue);
                                else
                                    cell.Value = cellValue.ToString();
                            }
                            else
                            {
                                cell.Value = string.Empty;
                            }
                        }
                    }

                    // Sütun genişliklerini otomatik ayarla
                    worksheet.Columns().AdjustToContents();

                    // Dosyayı kaydet
                    workbook.SaveAs(saveFileDialog1.FileName);
                }

                MessageBox.Show("Rapor Excel olarak oluşturuldu.", "Excel Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Rapor Oluşturma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcelRapor_Click(object sender, EventArgs e)
        {
            if (dataListSearchDailyProduction.RowCount > 0)
                SaveToExcel();
        }

        private void btnOnayaGönder_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnOnayaGönder, "İş emrini üretim sorumlusu onay ekranına gönderir.");
        }

        private void btnIsEmriNoSil_Click(object sender, EventArgs e)
        {
            txtIsEmriNoAra.Clear();
        }

        private void btnUrunResmiGoster_Click(object sender, EventArgs e)
        {
            string orderId = dataListProduction.Rows[selectedIndex3].Cells[13].Value.ToString();
            string productId = _orderRepository.GetWhere(o => o.Id == Guid.Parse(orderId)).FirstOrDefault().ProductId.ToString();
            string imagePath = _productRepository.GetWhere(pr => pr.Id == Guid.Parse(productId)).FirstOrDefault().ImagePath;

            if (!string.IsNullOrEmpty(imagePath))
            {
                FrmDisplayProductImage frmDisplayProductImage = new FrmDisplayProductImage(imagePath);
                frmDisplayProductImage.ShowDialog();
            }
            else
                MessageBox.Show("Ürüne ait yüklü bir resim dosyası yok.", "Resim Dosyası Yok.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMakinaAktar_Click(object sender, EventArgs e)
        {
            string productionState = dataListProduction.Rows[selectedIndex3].Cells[17].Value.ToString();
            if (productionState != Durumlar.Uretimde)
            {
                string? orderId = dataListProduction.Rows[selectedIndex3].Cells[13].Value.ToString();
                int productionQuantity = Convert.ToInt32(dataListProduction.Rows[selectedIndex3].Cells[5].Value.ToString());

                if (!string.IsNullOrEmpty(orderId))
                {
                    FrmTransferOrderToDifferentMachine frmTransferOrderToDifferentMachine = new FrmTransferOrderToDifferentMachine(orderId, productionQuantity);
                    frmTransferOrderToDifferentMachine.ShowDialog();

                    ListeYenile(TabPageName.Page3);
                    dataListProduction.Rows[selectedIndex3].Selected = true;
                }
            }
            else
                MessageBox.Show("Üretim işlemini durdurmadan üretimdeki iş emrini başka makinaya aktaramazsınız.", "İş emri Aktarma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnProgramFormuAc_Click(object sender, EventArgs e)
        {
            frmDef = new FrmProductionDefinitions(_user);

            TabControl tabControl = frmDef.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;

            if (tabControl != null)
            {
                if (_user.IsOperator && _user.IsAdmin)
                {
                    tabControl.SelectedIndex = 2;

                    Button button1 = frmDef.Controls.Find("btnFormuKapat1", true).FirstOrDefault() as Button;
                    button1.Visible = true;

                    Button button2 = frmDef.Controls.Find("btnFormuKapat2", true).FirstOrDefault() as Button;
                    button2.Visible = true;

                    Button button3 = frmDef.Controls.Find("btnFormuKapat3", true).FirstOrDefault() as Button;
                    button3.Visible = true;                   
                }
                else
                {
                    Button button3 = frmDef.Controls.Find("btnFormuKapat3", true).FirstOrDefault() as Button;
                    button3.Visible = true;
                }                
            }

            frmDef.ShowDialog();
        }
    }
}
