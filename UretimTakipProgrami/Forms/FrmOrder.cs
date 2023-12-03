using Microsoft.EntityFrameworkCore;
using System.Data;
using UretimTakipProgrami;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Forms;

namespace UretimTakip.Forms
{
    public partial class FrmOrder : Form
    {
        private OrderRepository _orderRepository;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;

        private int selectedIndex = 0;
        private int monthCalendarNo = 0;

        public FrmOrder()
        {
            InitializeComponent();

            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private class Durumlar
        {
            public const string Tezgah = "Tezgah Seçiminde";
            public const string OnayBekliyor = "Onay Bekliyor";
            public const string Uretimde = "Üretimde";
            public const string Hazir = "Hazır";
            public const string Acil = "Acil";
        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Sipariş Tarihi";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "İş Emri No";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Ürün Adı";
                dataGridView1.Columns[2].Width = 300;

                dataGridView1.Columns[3].HeaderText = "Müşteri Adı / Unvanı";
                dataGridView1.Columns[3].Width = 300;

                dataGridView1.Columns[4].HeaderText = "Sipariş";
                dataGridView1.Columns[4].Width = 50;

                dataGridView1.Columns[5].HeaderText = "Üretim";
                dataGridView1.Columns[5].Width = 50;

                dataGridView1.Columns[6].HeaderText = "Teslim Tarihi";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Aciliyet";
                dataGridView1.Columns[7].Width = 50;

                dataGridView1.Columns[8].HeaderText = "Durum";
                dataGridView1.Columns[8].Width = 150;

                dataGridView1.Columns[9].HeaderText = "Açıklama";
                dataGridView1.Columns[9].Width = 300;

                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;

                int acilDurumSutunu = 7;
                int durumSutunu = 8; // Durum sütununun indeksi

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[acilDurumSutunu].Value != null)
                    {

                        if (row.Cells[durumSutunu].Value.ToString() == Durumlar.Uretimde)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.FromArgb(175, 225, 175);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[durumSutunu].Value.ToString() == Durumlar.Hazir)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.FromArgb(167, 199, 231);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[durumSutunu].Value.ToString() == Durumlar.Tezgah)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.FromArgb(248, 200, 220);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[acilDurumSutunu].Value.ToString() == Durumlar.Acil)
                        {
                            row.Cells[acilDurumSutunu].Style.BackColor = Color.FromArgb(187, 33, 36);
                            row.Cells[acilDurumSutunu].Style.ForeColor = Color.White;
                            row.Cells[acilDurumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }
                    }

                }
            }
        }

        private void GetOrderList()
        {
            dataGridView1.DataSource = null;

            DateTime? isEmriBaslangic = null;
            DateTime? isEmriBitis = null;
            DateTime? teslimBaslangic = null;
            DateTime? teslimBitis = null;
            string arananMusteri = txtMusteriAdiAra.Text;
            string arananUrun = txtUrunAdiAra.Text;

            if (DateTime.TryParse(txtIsEmriBaslangic.Text, out var parsedIsemriBaslangic))
            {
                isEmriBaslangic = parsedIsemriBaslangic;
            }

            if (DateTime.TryParse(txtIsEmriBitis.Text, out var parsedIsemriBitis))
            {
                isEmriBitis = parsedIsemriBitis;
            }

            if (DateTime.TryParse(txtTeslimBaslangic.Text, out var parsedTeslimBaslangic))
            {
                teslimBaslangic = parsedTeslimBaslangic;
            }

            if (DateTime.TryParse(txtTeslimBitis.Text, out var parsedTeslimBitis))
            {
                teslimBitis = parsedTeslimBitis;
            }

            var orderList = _orderRepository.GetAll()
                .Select(order => new
                {
                    orderCreatedDate = order.CreatedDate.ToLocalTime(), // 0
                    order.OrderCode, // 1                   
                    productName = order.Product.Name, // 2
                    customerName = order.Customer.Name, // 3
                    order.Quantity, // 4
                    productionQuantity = order.Productions.Where(pr => pr.OrderId == order.Id).Sum(pr => pr.Quantity), // 5
                    deliveryDate = order.DeliveryDate.ToLocalTime().Date, // 6
                    orderAciliyet = order.IsUrgent ? Durumlar.Acil : "", // 7
                    orderDurum = order.IsWaiting ? Durumlar.Tezgah : !order.IsProduction && !order.IsReady ? Durumlar.OnayBekliyor : order.IsReady ? Durumlar.Hazir : Durumlar.Uretimde, // 8
                    order.Description, // 9
                    order.Id, // 10
                    order.IsUrgent, // 11
                    materialName = order.Product.Material.Name, // 12 
                    programName = order.Product.MachineProgram.Name // 13 
                })
                .Where(order =>
                    (checkAcilAra.Checked ? order.IsUrgent : true) &&
                    (!isEmriBaslangic.HasValue || order.orderCreatedDate.Date >= isEmriBaslangic) &&
                    (!isEmriBitis.HasValue || order.orderCreatedDate.Date <= isEmriBitis) &&
                    (!teslimBaslangic.HasValue || order.deliveryDate.Date >= teslimBaslangic) &&
                    (!teslimBitis.HasValue || order.deliveryDate.Date <= teslimBitis) &&
                    (string.IsNullOrEmpty(arananMusteri) || order.customerName.ToLower().Contains(arananMusteri.ToLower())) &&
                    (string.IsNullOrEmpty(arananUrun) || order.productName.ToLower().Contains(arananUrun.ToLower())))
                .OrderBy(order => order.orderCreatedDate)
                .ToList();

            if (orderList.Count > 0)
            {
                dataGridView1.DataSource = orderList.ToList();
                SetDataGridSettings();
            }
            else
            {
                dataGridView1.DataSource = null;
            }

            lblKayitSayisi.Text = $"Kayıt Sayısı: {orderList.Count.ToString()}";

        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
            btnSil.Enabled = true;
            btnOpenFormCustomer.Enabled = false;
            btnOpenFormProduct.Enabled = false;

            listUrunAdi.Enabled = false;
            listMusteriAdi.Enabled = false;
            txtIsEmriNo.Enabled = false;
            txtMiktar.Enabled = false;
            txtTeslimTarihi.Enabled = false;
            txtAciklama.Enabled = false;
            txtIslenecekMalzeme.Enabled = false;
            txtProgramAdi.Enabled = false;
            txtSiparisTarihi.Enabled = false;

            checkAcil.Enabled = false;

            grpboxUrunAra.Enabled = true;
        }

        private void DisableButtonAndText()
        {
            btnYeni.Enabled = false;
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
            btnIptal.Enabled = true;
            btnSil.Enabled = false;
            btnOpenFormCustomer.Enabled = true;
            btnOpenFormProduct.Enabled = true;

            listUrunAdi.Enabled = true;
            listMusteriAdi.Enabled = true;
            txtIsEmriNo.Enabled = true;
            txtMiktar.Enabled = true;
            txtTeslimTarihi.Enabled = true;
            txtAciklama.Enabled = true;
            txtIslenecekMalzeme.Enabled = true;
            txtProgramAdi.Enabled = true;
            txtSiparisTarihi.Enabled = true;

            checkAcil.Enabled = true;
            checkAcil.Checked = false;

            grpboxUrunAra.Enabled = false;
        }

        private void ClearText()
        {
            listUrunAdi.DataSource = null;
            listMusteriAdi.DataSource = null;
            txtMiktar.Value = txtMiktar.Minimum;
            txtAciklama.Clear();
            txtTeslimTarihi.Value = DateTime.UtcNow;
            txtIsEmriNo.Clear();
            txtSiparisTarihi.Clear();
            txtProgramAdi.Clear();
            txtIslenecekMalzeme.Clear();

            listUrunAdi.Focus();
        }

        private void DataGridTextAktar()
        {
            if (selectedIndex >= 0)
            {
                txtSiparisTarihi.Text = Convert.ToDateTime(dataGridView1.Rows[selectedIndex].Cells[0].Value).ToShortDateString();
                txtIsEmriNo.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
                listUrunAdi.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
                txtIslenecekMalzeme.Text = dataGridView1.Rows[selectedIndex].Cells[12].Value.ToString();
                txtProgramAdi.Text = dataGridView1.Rows[selectedIndex].Cells[13].Value.ToString();
                listMusteriAdi.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
                txtMiktar.Text = dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString();
                txtTeslimTarihi.Value = Convert.ToDateTime(dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString());
                txtAciklama.Text = dataGridView1.Rows[selectedIndex].Cells[9].Value.ToString();
                checkAcil.Checked = (bool)(dataGridView1.Rows[selectedIndex].Cells[11].Value);
            }
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {

        }

        private void txtUrunAciklama_TextChanged(object sender, EventArgs e)
        {
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            await _orderRepository.AddAsync(new()
            {
                OrderCode = txtIsEmriNo.Text,
                ProductId = Guid.Parse(listUrunAdi.SelectedValue.ToString()),
                CustomerId = Guid.Parse(listMusteriAdi.SelectedValue.ToString()),
                Quantity = Convert.ToInt32(txtMiktar.Value),
                DeliveryDate = Convert.ToDateTime(txtTeslimTarihi.Value).ToUniversalTime().Date,
                Description = txtAciklama.Text,
                IsUrgent = checkAcil.Checked ? true : false
            });

            await _orderRepository.SaveAsync();
            EnableButtonAndText();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            DisableButtonAndText();
            ClearText();
            txtIsEmriNo.Text = GenerateOrderCode();

            txtSiparisTarihi.Text = DateTime.Now.ToShortDateString();

            var emptyItem = new
            {
                Id = Guid.NewGuid(),
                Name = "--Seçiniz--"
            };

            var productList = _productRepository.GetAll()
                .Select(product => new
                {
                    product.Id,
                    product.Name
                })
                .ToList();

            productList.Insert(0, emptyItem);

            var customerList = _customerRepository.GetAll()
                .Select(customer => new
                {
                    customer.Id,
                    customer.Name
                })
                .ToList();

            customerList.Insert(0, emptyItem);

            listUrunAdi.DataSource = productList;
            listUrunAdi.DisplayMember = "Name";
            listUrunAdi.ValueMember = "Id";

            listUrunAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            listUrunAdi.AutoCompleteSource = AutoCompleteSource.ListItems;

            listMusteriAdi.DataSource = customerList;
            listMusteriAdi.DisplayMember = "Name";
            listMusteriAdi.ValueMember = "Id";

            listMusteriAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            listMusteriAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText();
            ClearText();
        }

        private void btnSiparisBaşlangic_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(332, 51);
            monthCalendar1.Visible = true;
            monthCalendarNo = 0;
        }

        private void btnSiparisBitis_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(332, 81);
            monthCalendar1.Visible = true;
            monthCalendarNo = 1;
        }

        private void btnTeslimBaslangic_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(612, 51);
            monthCalendar1.Visible = true;
            monthCalendarNo = 2;
        }

        private void btnTeslimBitis_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(612, 81);
            monthCalendar1.Visible = true;
            monthCalendarNo = 3;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            switch (monthCalendarNo)
            {
                case 0:
                    txtIsEmriBaslangic.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
                case 1:
                    txtIsEmriBitis.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
                case 2:
                    txtTeslimBaslangic.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
                case 3:
                    txtTeslimBitis.Text = monthCalendar1.SelectionStart.ToShortDateString();
                    break;
            }

            monthCalendar1.Visible = false;
        }

        private void btnUrunBul_Click(object sender, EventArgs e)
        {
            GetOrderList();
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                selectedIndex = 0;

                DataGridTextAktar();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridTextAktar();
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            txtUrunAdiAra.Clear();
        }

        private void btnMusteriAdıSil_Click(object sender, EventArgs e)
        {
            txtMusteriAdiAra.Clear();
        }

        private void btnTeslimBaslangicSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtTeslimBaslangic.Clear();
        }

        private void btnTeslimBitisSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtTeslimBitis.Clear();
        }

        private void btnSiparisBaslangicSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtIsEmriBaslangic.Clear();
        }

        private void btnSiparisBitisSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtIsEmriBitis.Clear();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFormProduct_Click(object sender, EventArgs e)
        {
            FrmProduct frmProduct = new FrmProduct();

            System.Windows.Forms.Button button1 = frmProduct.Controls.Find("btnGeriDon", true).FirstOrDefault() as System.Windows.Forms.Button;
            if (button1 != null)
                button1.Visible = true;

            frmProduct.ShowDialog();
        }

        private void btnOpenFormCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer();

            System.Windows.Forms.Button button1 = frmCustomer.Controls.Find("btnGeriDon", true).FirstOrDefault() as System.Windows.Forms.Button;
            if (button1 != null)
                button1.Visible = true;

            frmCustomer.ShowDialog();
        }

        private void listUrunAdi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listUrunAdi.SelectedValue != null && Guid.TryParse(listUrunAdi.SelectedValue.ToString(), out var selectedGuid))
            {
                var product = _productRepository
                    .GetWhere(p => p.Id == selectedGuid)
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

        private string GenerateOrderCode()
        {
            int currentYear = DateTime.Now.Year;

            string lastProductCode = GetLastProductCodeFromDatabase();

            if (string.IsNullOrEmpty(lastProductCode) || !lastProductCode.StartsWith(currentYear.ToString()))
            {
                return currentYear.ToString() + "00001";
            }
            else
            {
                int lastCodeNumber = int.Parse(lastProductCode.Substring(4));
                int newCodeNumber = lastCodeNumber + 1;

                return currentYear.ToString() + newCodeNumber.ToString("D5");
            }
        }

        public string GetLastProductCodeFromDatabase()
        {
            var lastOrder = _orderRepository.GetAll()
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => o.OrderCode)
                .FirstOrDefault();

            return lastOrder;
        }

        private void listUrunAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
