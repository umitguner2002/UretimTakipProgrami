using FluentValidation.Results;
using System.Data;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Messages;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmCustomer : Form
    {
        private CustomerRepository _customerRepository;
        private int selectedIndex = -1;
        private bool editMode = false;
        private AppMessage _appMessage;

        public FrmCustomer()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();

            _appMessage = new AppMessage();
        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Müşteri Adı / Unvanı";
                dataGridView1.Columns[1].HeaderText = "Telefon-1";
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Telefon-2";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].HeaderText = "E-Mail";
                dataGridView1.Columns[4].HeaderText = "Adres";
                dataGridView1.Columns[5].HeaderText = "Kayıt Tarihi";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Visible = false;
            }
        }

        private void GetCustomerList()
        {
            dataGridView1.DataSource = null;
            List<object> filteredList = new List<object>();

            var customerList = _customerRepository.GetAll()
                .Select(customer => new
                {
                    customer.Name,
                    customer.Phone1,
                    customer.Phone2,
                    customer.Mail,
                    customer.Address,
                    customerCreatedDate = customer.CreatedDate.ToLocalTime(),
                    customer.Id,
                })
                .ToList();

            string arananMusteriAdi = txtMusteriAdiAra.Text;
            string arananTarih = txtKayitTarihiAra.Text;
            DateTime.TryParse(txtKayitTarihiAra.Text, out DateTime kayitTarihi);

            foreach (var cs in customerList)
            {
                if (arananMusteriAdi != "" && arananTarih != "")
                {
                    if (cs.Name.ToLower().StartsWith(arananMusteriAdi.ToLower()) && cs.customerCreatedDate.Date == kayitTarihi.ToLocalTime().Date)
                        filteredList.Add(cs);
                }
                else if (arananMusteriAdi != "")
                {
                    if (cs.Name.ToLower().StartsWith(arananMusteriAdi.ToLower()))
                        filteredList.Add(cs);
                }
                else
                {
                    if (cs.customerCreatedDate.Date == kayitTarihi.ToLocalTime().Date)
                        filteredList.Add(cs);
                }
            }

            dataGridView1.DataSource = filteredList;
            lblKayitSayisi.Text = $"Kayıt Sayısı: {filteredList.Count.ToString()}";

            SetDataGridSettings();
        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
            btnSil.Enabled = true;
            txtMusteriAdi.Enabled = false;
            txtTelefon1.Enabled = false;
            txtTelefon2.Enabled = false;
            txtMail.Enabled = false;
            txtAdres.Enabled = false;

            pnlArama.Enabled = true;
        }

        private void DisableButtonAndText()
        {
            btnYeni.Enabled = false;
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
            btnIptal.Enabled = true;
            btnSil.Enabled = false;
            txtMusteriAdi.Enabled = true;
            txtTelefon1.Enabled = true;
            txtTelefon2.Enabled = true;
            txtMail.Enabled = true;
            txtAdres.Enabled = true;

            pnlArama.Enabled = false;
        }

        private void ClearText()
        {
            txtMusteriAdi.Clear();
            txtTelefon1.Clear();
            txtTelefon2.Clear();
            txtMail.Clear();
            txtAdres.Clear();
            txtMusteriAdiAra.Clear();
            txtKayitTarihiAra.Clear();

            txtMusteriAdi.Focus();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            dataGridView1.DataSource = null;
            ClearText();
            EnableButtonAndText();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            editMode = false;
            DisableButtonAndText();
            ClearText();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            bool editStatus = false;

            Customer cs = new Customer
            {
                Name = txtMusteriAdi.Text.ToUpper(),
                Mail = txtMail.Text
            };

            CustomerValidator customerValidation = new CustomerValidator();
            ValidationResult result = customerValidation.Validate(cs);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!editMode)
            {
                await _customerRepository.AddAsync(new()
                {
                    Name = txtMusteriAdi.Text.ToUpper(),
                    Phone1 = txtTelefon1.Text,
                    Phone2 = txtTelefon2.Text,
                    Mail = txtMail.Text,
                    Address = txtAdres.Text.ToUpper()
                });

                _appMessage.SaveSuccessMessage();
            }
            else
            {
                _customerRepository.Update(new()
                {
                    Id = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString()),
                    Name = txtMusteriAdi.Text.ToUpper(),
                    Phone1 = txtTelefon1.Text,
                    Phone2 = txtTelefon2.Text,
                    Mail = txtMail.Text,
                    Address = txtAdres.Text.ToUpper()
                });

                _appMessage.UpdateSuccessMessage();
            }

            await _customerRepository.SaveAsync();

            if (editMode)
            {
                dataGridView1.DataSource = _customerRepository
                    .GetWhere(c => c.Id == Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString()))
                    .Select(customer => new
                    {
                        customer.Name,
                        customer.Phone1,
                        customer.Phone2,
                        customer.Mail,
                        customer.Address,
                        customerCreatedDate = customer.CreatedDate.ToLocalTime(),
                        customer.Id,
                    })
                    .ToList();
                SetDataGridSettings();
                DataGridTextAktar();
            }

            EnableButtonAndText();
            editMode = false;
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {
            GetCustomerList();
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                selectedIndex = 0;

                DataGridTextAktar();
            }

        }

        private void btnBulTarih_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText();
            ClearText();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtKayitTarihiAra.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridTextAktar();
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            txtMusteriAdiAra.Clear();
        }

        private void btnKayitTarihiSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtKayitTarihiAra.Clear();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount > 0 && selectedIndex > -1)
            {
                editMode = true;
                DisableButtonAndText();
            }
            else
                MessageBox.Show("Güncellenecek kaydı seçin.", "Güncelleme Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void DataGridTextAktar()
        {
            if (selectedIndex >= 0)
            {
                txtMusteriAdi.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                txtTelefon1.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
                txtTelefon2.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
                txtMail.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
                txtAdres.Text = dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnGeriDon.Enabled = false;
        }
    }
}
