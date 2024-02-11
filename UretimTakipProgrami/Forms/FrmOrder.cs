using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows.Controls;
using System.Windows.Media;
using UretimTakipProgrami;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Forms;
using UretimTakipProgrami.Messages;

namespace UretimTakip.Forms
{
    public partial class FrmOrder : Form
    {
        private OrderRepository _orderRepository;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;
        private AppMessage _appMessage;

        private int selectedIndex = -1;
        private int monthCalendarNo = 0;
        private string lastOrderCode = "";

        private bool editMode = false;

        public FrmOrder()
        {
            InitializeComponent();

            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _appMessage = new AppMessage();
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
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[1].HeaderText = "İş Emri No";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[2].HeaderText = "Ürün Adı";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[3].HeaderText = "Müşteri Adı / Unvanı";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[4].HeaderText = "Sipariş";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[5].HeaderText = "Üretim";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[6].HeaderText = "Teslim Tarihi";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[7].HeaderText = "Aciliyet";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[8].HeaderText = "Durum";
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[9].Visible = false; // Açıklama
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;

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
                                row.Cells[i].Style.BackColor = System.Drawing.Color.FromArgb(175, 225, 175);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[durumSutunu].Value.ToString() == Durumlar.Hazir)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = System.Drawing.Color.FromArgb(167, 199, 231);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[durumSutunu].Value.ToString() == Durumlar.OnayBekliyor)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                row.Cells[i].Style.BackColor = System.Drawing.Color.FromArgb(248, 200, 220);
                            }

                            row.Cells[durumSutunu].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        }

                        if (row.Cells[acilDurumSutunu].Value.ToString() == Durumlar.Acil)
                        {
                            row.Cells[acilDurumSutunu].Style.BackColor = System.Drawing.Color.FromArgb(187, 33, 36);
                            row.Cells[acilDurumSutunu].Style.ForeColor = System.Drawing.Color.White;
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
            string arananIsEmriNo = txtIsEmriNoAra.Text;
            string arananMusteri = txtMusteriAdiAra.Text;
            string arananUrun = txtUrunAdiAra.Text;
            int uretimDurumu = listİsEmriDurum.SelectedIndex;

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
                    programName = order.Product.MachineProgram.Name, // 13 
                    order.IsWaiting,
                    order.IsProduction,
                    order.IsReady
                })
                .Where(order =>
                    (checkAcilAra.Checked ? order.IsUrgent : true) &&
                    (!isEmriBaslangic.HasValue || order.orderCreatedDate.Date >= isEmriBaslangic) &&
                    (!isEmriBitis.HasValue || order.orderCreatedDate.Date <= isEmriBitis) &&
                    (!teslimBaslangic.HasValue || order.deliveryDate.Date >= teslimBaslangic) &&
                    (!teslimBitis.HasValue || order.deliveryDate.Date <= teslimBitis) &&
                    (uretimDurumu == 0 ? order.IsWaiting && !order.IsProduction && !order.IsReady :
                     uretimDurumu == 1 ? !order.IsWaiting && !order.IsProduction && !order.IsReady :
                     uretimDurumu == 2 ? !order.IsWaiting && order.IsProduction && !order.IsReady :
                     uretimDurumu == 3 ? order.IsReady :
                     order.IsWaiting || order.IsProduction || order.IsReady) &&
                    (string.IsNullOrEmpty(arananIsEmriNo) || order.OrderCode == arananIsEmriNo) &&
                    (string.IsNullOrEmpty(arananMusteri) || order.customerName.ToLower().Contains(arananMusteri.ToLower())) &&
                    (string.IsNullOrEmpty(arananUrun) || order.productName.ToLower().Contains(arananUrun.ToLower())))
                .OrderBy(order => order.orderCreatedDate)
                .ToList();

            if (orderList.Count > 0)
            {
                dataGridView1.DataSource = orderList.ToList();
                contextMenuStrip1.Items[0].Enabled = true;
                SetDataGridSettings();
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = true;
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
            btnOpenFormCustomer.Enabled = false;
            btnOpenFormProduct.Enabled = false;

            if (editMode)
                btnOncekiIsEmriNo.Enabled = false;
            else
                btnOncekiIsEmriNo.Enabled = true;

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
            btnOpenFormCustomer.Enabled = true;
            btnOpenFormProduct.Enabled = true;

            if (editMode)
                btnOncekiIsEmriNo.Enabled = false;
            else
                btnOncekiIsEmriNo.Enabled = true;

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

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool editStatus = false;

                ProductValidator productValidation;
                object selectedProductNameValue = listUrunAdi.SelectedValue;
                object selectedCustomerValue = listMusteriAdi.SelectedValue;

                bool isValidProductName = selectedProductNameValue != null && !string.IsNullOrEmpty(listUrunAdi.ToString());
                bool isValidCustomer = selectedCustomerValue != null && !string.IsNullOrEmpty(listMusteriAdi.ToString());

                if (!isValidProductName)
                {
                    MessageBox.Show("Geçersiz Ürün Adı", "Ürün Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listUrunAdi.Focus();
                }
                else if (!isValidCustomer)
                {
                    MessageBox.Show("Geçersiz Müşteri Adı", "Müşteri Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listMusteriAdi.Focus();
                }
                else
                {
                    if (_productRepository.GetById(listUrunAdi.SelectedValue.ToString()) == null)
                    {
                        MessageBox.Show("Geçerli bir ürün adı seçiniz.", "Ürün Seçim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        listUrunAdi.Focus();
                        return;
                    }
                    else if (_customerRepository.GetById(listMusteriAdi.SelectedValue.ToString()) == null)
                    {
                        MessageBox.Show("Geçerli bir müşteri adı seçiniz.", "Müşteri Seçim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        listMusteriAdi.Focus();
                        return;
                    }
                    else
                    {
                        if (!editMode)
                        {
                            await _orderRepository.AddAsync(new()
                            {
                                OrderCode = txtIsEmriNo.Text,
                                ProductId = Guid.Parse(listUrunAdi.SelectedValue.ToString()),
                                CustomerId = Guid.Parse(listMusteriAdi.SelectedValue.ToString()),
                                Quantity = Convert.ToInt32(txtMiktar.Value),
                                DeliveryDate = Convert.ToDateTime(txtTeslimTarihi.Value).ToUniversalTime().Date,
                                Description = txtAciklama.Text.ToUpper(),
                                IsUrgent = checkAcil.Checked ? true : false
                            });

                            await _orderRepository.SaveAsync();
                            _appMessage.SaveSuccessMessage();
                        }
                        else
                        {
                            try
                            {
                                var orderId = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[10].Value.ToString());
                                var order = _orderRepository.GetWhere(o => o.Id == orderId).FirstOrDefault();

                                order.CreatedDate = order.CreatedDate;
                                order.OrderCode = txtIsEmriNo.Text;
                                order.Quantity = Convert.ToInt32(txtMiktar.Value);
                                order.Description = txtAciklama.Text.ToUpper();
                                order.DeliveryDate = Convert.ToDateTime(txtTeslimTarihi.Value).ToUniversalTime().Date;
                                order.ProductId = Guid.Parse(listUrunAdi.SelectedValue.ToString());
                                order.CustomerId = Guid.Parse(listMusteriAdi.SelectedValue.ToString());
                                order.IsUrgent = checkAcil.Checked ? true : false;

                                _orderRepository.Save();

                                txtUrunAdiAra.Text = _productRepository.GetWhere(p => p.Id == order.ProductId).FirstOrDefault().Name;
                                txtMusteriAdiAra.Text = _customerRepository.GetWhere(c => c.Id == order.CustomerId).FirstOrDefault().Name;
                                GetOrderList();
                                SetDataGridSettings();

                                if (dataGridView1.Rows.Count > 0)
                                {
                                    selectedIndex = 0;
                                    dataGridView1.Rows[selectedIndex].Selected = true;
                                    DataGridTextAktar();
                                }

                                _appMessage.UpdateSuccessMessage();
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.ToString());
                            }
                        }
                        EnableButtonAndText();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            DisableButtonAndText();
            ClearText();
            txtIsEmriNo.Text = GenerateOrderCode(DateTime.Now.Year);

            txtSiparisTarihi.Text = DateTime.Now.ToShortDateString();

            GetProductList();
            GetCustomerList();
            dataGridView1.DataSource = null;
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
            if (dataGridView1.Rows.Count > 0)
            {
                object status = dataGridView1.Rows[selectedIndex].Cells[8].Value.ToString();
                bool statusReady = status != null && status.ToString() == Durumlar.Hazir;

                if (!statusReady)
                {
                    try
                    {
                        if (dataGridView1.ColumnCount > 0 && selectedIndex > -1)
                        {
                            editMode = true;
                            DisableButtonAndText();

                            var productList = _productRepository.GetAll()
                            .Select(product => new
                            {
                                product.Id,
                                product.Name
                            })
                            .ToList();

                            var customerList = _customerRepository.GetAll()
                                .Select(customer => new
                                {
                                    customer.Id,
                                    customer.Name
                                })
                                .ToList();

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

                            foreach (var item in listUrunAdi.Items)
                            {
                                if (item.ToString().Contains(dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString())) // ProductName
                                {
                                    listUrunAdi.SelectedItem = item;
                                    break;
                                }
                            }

                            foreach (var item in listMusteriAdi.Items)
                            {
                                if (item.ToString().Contains(dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString())) // CustomerName
                                {
                                    listMusteriAdi.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Güncellenecek kaydı seçin.", "Güncelleme Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show($"Error: {err.ToString()}");
                    }
                }
                else
                    MessageBox.Show("Hazır durumdaki bir iş emrini düzenleyemezsiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Güncelleme yapılacak kaydı seçiniz.", "İş Emri Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnOpenFormProduct_Click(object sender, EventArgs e)
        {
            FrmProduct frmProduct = new FrmProduct();

            System.Windows.Forms.Button button1 = frmProduct.Controls.Find("btnGeriDon", true).FirstOrDefault() as System.Windows.Forms.Button;
            if (button1 != null)
                button1.Visible = true;

            frmProduct.ShowDialog();

            GetProductList();
            if (!string.IsNullOrEmpty(frmProduct.selectedProductName))
                listUrunAdi.Text = frmProduct.selectedProductName;
        }

        private void btnOpenFormCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer();

            System.Windows.Forms.Button button1 = frmCustomer.Controls.Find("btnGeriDon", true).FirstOrDefault() as System.Windows.Forms.Button;
            if (button1 != null)
                button1.Visible = true;

            frmCustomer.ShowDialog();

            GetCustomerList();
            if (!string.IsNullOrEmpty(frmCustomer.selectedCustomerName))
                listMusteriAdi.Text = frmCustomer.selectedCustomerName;
        }

        private void GetProductList()
        {
            try
            {
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
                    .OrderBy(x => x.Name)
                    .ToList();

                productList.Insert(0, emptyItem);

                listUrunAdi.DataSource = productList;
                listUrunAdi.DisplayMember = "Name";
                listUrunAdi.ValueMember = "Id";

                listUrunAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                listUrunAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void GetCustomerList()
        {
            try
            {
                var emptyItem = new
                {
                    Id = Guid.NewGuid(),
                    Name = "--Seçiniz--"
                };

                var customerList = _customerRepository.GetAll()
                    .Select(customer => new
                    {
                        customer.Id,
                        customer.Name
                    })
                    .OrderBy(x => x.Name)
                    .ToList();

                customerList.Insert(0, emptyItem);

                listMusteriAdi.DataSource = customerList;
                listMusteriAdi.DisplayMember = "Name";
                listMusteriAdi.ValueMember = "Id";

                listMusteriAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                listMusteriAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        private void listUrunAdi_SelectedValueChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }

        public string GenerateOrderCode(int currentYear)
        {
            lastOrderCode = GetLastProductCodeFromDatabase();

            if (string.IsNullOrEmpty(lastOrderCode) || !lastOrderCode.StartsWith(currentYear.ToString()))
            {
                return currentYear.ToString() + "000001";
            }
            else
            {
                int lastCodeNumber = int.Parse(lastOrderCode.Substring(4));
                int newCodeNumber = lastCodeNumber + 1;

                return currentYear.ToString() + newCodeNumber.ToString("D6");
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

        private void txtIsEmriNoSil_Click(object sender, EventArgs e)
        {
            txtIsEmriNoAra.Clear();
        }

        private void btnOncekiIsEmriNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastOrderCode))
                txtIsEmriNo.Text = lastOrderCode;
            else
                GenerateOrderCode(DateTime.Now.Year);
        }

        private void listİsEmriDurum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            listİsEmriDurum.SelectedIndex = 0;            
        }

        private void seçiliÜrünİçinİşEmriOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                var urunAdi = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
                var musteriAdi = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
                btnYeni_Click(sender, e);
                listUrunAdi.Text = urunAdi;
                listMusteriAdi.Text = musteriAdi;
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {
                selectedIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (selectedIndex > -1)
                {
                    dataGridView1.Rows[selectedIndex].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    DataGridTextAktar();
                }
            }
        }
    }
}
