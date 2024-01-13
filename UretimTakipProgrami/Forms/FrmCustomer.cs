using FluentValidation.Results;
using System.Data;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Entities;
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
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Müşteri Adı / Unvanı";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[1].HeaderText = "Telefon-1";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[2].HeaderText = "Telefon-2";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[3].HeaderText = "E-Mail";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[4].HeaderText = "Adres";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[5].HeaderText = "Kayıt Tarihi";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[6].Visible = false;
            }
        }

        private void GetCustomerList()
        {
            try
            {
                string arananMusteriAdi = txtMusteriAdiAra.Text.ToUpper();
                string arananTelefonNo = string.IsNullOrEmpty(txtTelefonNoAra.Text) ? string.Empty : txtTelefonNoAra.Text;

                if (!string.IsNullOrEmpty(arananMusteriAdi) || !string.IsNullOrEmpty(arananTelefonNo))
                {
                    var customerList = _customerRepository.GetAll()
                    .Select(customer => new
                    {
                        customer.Name,
                        Tel1 = customer.Phone1,
                        Tel2 = customer.Phone2,
                        customer.Mail,
                        customer.Address,
                        customerCreatedDate = customer.CreatedDate.ToLocalTime(),
                        customer.Id,
                    })
                    .Where(customer =>
                        (string.IsNullOrEmpty(arananMusteriAdi) || customer.Name.Contains(arananMusteriAdi)) &&
                        (string.IsNullOrEmpty(arananTelefonNo) || customer.Tel1 == arananTelefonNo || customer.Tel2 == arananTelefonNo))
                    .ToList();

                    if (customerList.Count > 0)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = customerList;
                        lblKayitSayisi.Text = $"Kayıt Sayısı: {customerList.Count.ToString()}";

                        SetDataGridSettings();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        MessageBox.Show("Kayıtlı müşteri bulunamadı.", "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }

        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
            txtMusteriAdi.Enabled = false;
            txtTelefon1.Enabled = false;
            txtTelefon2.Enabled = false;
            txtMail.Enabled = false;
            txtAdres.Enabled = false;

            groupBox2.Enabled = true;
        }

        private void DisableButtonAndText()
        {
            btnYeni.Enabled = false;
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
            btnIptal.Enabled = true;
            txtMusteriAdi.Enabled = true;
            txtTelefon1.Enabled = true;
            txtTelefon2.Enabled = true;
            txtMail.Enabled = true;
            txtAdres.Enabled = true;

            groupBox2.Enabled = false;
        }

        private void ClearText()
        {
            txtMusteriAdi.Clear();
            txtTelefon1.Clear();
            txtTelefon1.Mask = "";
            txtTelefon2.Clear();
            txtTelefon2.Mask = "";
            txtMail.Clear();
            txtAdres.Clear();                      

            txtMusteriAdi.Focus();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ClearText();
            EnableButtonAndText();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            editMode = false;
            DisableButtonAndText();
            ClearText();
            txtMusteriAdiAra.Clear();
            txtTelefonNoAra.Clear();
            dataGridView1.DataSource= null;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SaveOrEditCustomer();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }

        }

        private async void SaveOrEditCustomer()
        {
            CustomerValidator customerValidation;

            var cs = new Customer
            {
                Name = txtMusteriAdi.Text.ToUpper(),
                Mail = txtMail.Text
            };

            if (!editMode)
            {
                customerValidation = new CustomerValidator();
            }
            else
            {
                string editCustomerId = dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString();
                customerValidation = new CustomerValidator(editCustomerId);
            }

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

            var phoneNumber1 = txtTelefon1.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "");
            var phoneNumber2 = txtTelefon2.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "");

            if (txtTelefon1.Text != "")
                phoneNumber1 = phoneNumber1.Substring(1);

            if (txtTelefon2.Text != "")
                phoneNumber2 = phoneNumber2.Substring(1);

            if (!editMode)
            {
                await _customerRepository.AddAsync(new()
                {
                    Name = txtMusteriAdi.Text.ToUpper(),
                    Phone1 = phoneNumber1,
                    Phone2 = phoneNumber2,
                    Mail = txtMail.Text,
                    Address = txtAdres.Text.ToUpper()
                });

                await _customerRepository.SaveAsync();
                _appMessage.SaveSuccessMessage();
            }
            else
            {
                var customerId = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString());
                var customer = _customerRepository.GetWhere(c => c.Id == customerId).FirstOrDefault();

                customer.CreatedDate = customer.CreatedDate;
                customer.Name = txtMusteriAdi.Text.ToUpper();
                customer.Phone1 = phoneNumber1;
                customer.Phone2 = phoneNumber2;
                customer.Mail = txtMail.Text;
                customer.Address = txtAdres.Text.ToUpper();

                _customerRepository.Update(customer);
                await _customerRepository.SaveAsync();

                txtMusteriAdiAra.Text = customer.Name;
                GetCustomerList();
                SetDataGridSettings();

                selectedIndex = 0;
                dataGridView1.Rows[selectedIndex].Selected = true;
                DataGridTextAktar();

                _appMessage.UpdateSuccessMessage();
            }

            EnableButtonAndText();
            editMode = false;
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {
            ClearText();

            if (!string.IsNullOrEmpty(txtMusteriAdiAra.Text.Trim()) || !string.IsNullOrEmpty(txtTelefonNoAra.Text.Trim()))
            {
                GetCustomerList();
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    selectedIndex = 0;

                    DataGridTextAktar();
                }                    
            }
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("Arama için en az bir alanı doldurun.", "Arama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMusteriAdiAra.Focus();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText();
            ClearText();
            dataGridView1.DataSource = null;
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

        private void DataGridTextAktar()
        {
            string phoneNumber = string.Empty;
            string maskedPhoneNumber = string.Empty;

            if (selectedIndex >= 0)
            {
                txtMusteriAdi.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                txtTelefon1.Text = MaskedPhoneNumber(dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString());
                txtTelefon2.Text = MaskedPhoneNumber(dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString());
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

        private void btnTelefonNoAra_Click(object sender, EventArgs e)
        {
            txtTelefonNoAra.Clear();
        }

        private void txtTelefon1_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxEnter(txtTelefon1);
        }

        private void txtTelefon2_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxEnter(txtTelefon2);
        }

        private void MaskedTextBoxEnter(MaskedTextBox maskedTextBox)
        {
            if (maskedTextBox.Text == string.Empty)
            {
                maskedTextBox.Mask = "9 (999) 000 00 00";
                maskedTextBox.Text = "0";
                maskedTextBox.Focus();
                maskedTextBox.Select(3, 0);
            }
        }

        private void txtTelefon1_Leave(object sender, EventArgs e)
        {
            SetPhoneNumber(txtTelefon1);
        }

        private void txtTelefon2_Leave(object sender, EventArgs e)
        {
            SetPhoneNumber(txtTelefon2);
        }

        private void txtTelefonNoAra_Leave(object sender, EventArgs e)
        {
            string phoneNumber = txtTelefonNoAra.Text;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                if (phoneNumber.Length < 10 || phoneNumber.Length > 10)
                    MessageBox.Show("Aranan telefon numarası 10 karakter olmalı.", "Hatalı Karakter Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SetPhoneNumber(MaskedTextBox maskedTextBox)
        {
            string phoneNumber = maskedTextBox.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "");

            if (phoneNumber.Length < 11)
            {
                maskedTextBox.Clear();
                maskedTextBox.Mask = "";
            }
        }

        public string MaskedPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                string maskedPhoneNumber = "0 (" + phoneNumber.Substring(0, 3) + ") " + phoneNumber.Substring(3, 3) + " " + phoneNumber.Substring(6, 2) + " " + phoneNumber.Substring(8);
                return maskedPhoneNumber;
            }
            else
                return string.Empty;
        }

        private void txtTelefonNoAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
