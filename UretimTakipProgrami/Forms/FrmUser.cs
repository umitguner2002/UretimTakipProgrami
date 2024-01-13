using FluentValidation.Results;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Messages;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmUser : Form
    {
        private UserRepository _userRepository;

        private int selectedIndex;
        private bool editMode = false;
        private AppMessage _appMessage;

        public FrmUser()
        {
            InitializeComponent();

            _userRepository = InstanceFactory.GetInstance<UserRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _appMessage = new AppMessage();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {

        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Adı Soyadı";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[2].HeaderText = "Telefon";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[3].HeaderText = "E-Mail";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[4].HeaderText = "Yönetici";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[5].HeaderText = "Sorumlu";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[6].HeaderText = "Operatör";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[7].HeaderText = "Durumu Aktif";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns[8].Visible = false;
            }
        }

        private void GetUserList()
        {
            dataGridView1.DataSource = null;

            var userList = _userRepository.GetAll()
                .Select(user => new
                {
                    user.Name, // 0
                    user.Username, // 1
                    userPhone = MaskedPhoneNumber(user.Phone), //2
                    user.Email, // 3                    
                    user.IsAdmin, // 4
                    user.IsManager, // 5
                    user.IsOperator, // 6
                    user.IsActive, // 7
                    user.Id, // 8
                }).OrderBy(x => x.Name).ToList();

            dataGridView1.DataSource = userList;

            SetDataGridSettings();

            if (dataGridView1.RowCount > 0)
            {
                selectedIndex = 0;
                dataGridView1.Rows[selectedIndex].Selected = true;
            }

            //lblKayitSayisi.Text = $"Kayıt Sayısı: {filteredList.Count.ToString()}";

        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
            btnSil.Enabled = true;
            groupUserInfo.Enabled = false;
            groupUserAuth.Enabled = false;

            pnlArama.Enabled = true;
        }

        private void DisableButtonAndText()
        {
            btnYeni.Enabled = false;
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
            btnIptal.Enabled = true;
            btnSil.Enabled = false;
            groupUserInfo.Enabled = true;
            groupUserAuth.Enabled = true;

            pnlArama.Enabled = false;
        }

        private void ClearText()
        {
            txtAdiSoyadi.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();
            txtSifre.Clear();

            txtAdiSoyadi.Focus();

            checkActive.Checked = true;
            checkOperator.Checked = true;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            editMode = false;
            DisableButtonAndText();
            ClearText();
            txtAdiSoyadi.Focus();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            UserValidator userValidation;

            var u = new User
            {
                Name = txtAdiSoyadi.Text.ToUpper(),
                Username = txtKullaniciAdi.Text,
                Email = txtEmail.Text,
                Password = txtSifre.Text
            };

            if (!editMode)
            {
                userValidation = new UserValidator();
            }
            else
            {
                string editUserId = dataGridView1.Rows[selectedIndex].Cells[8].Value.ToString();
                userValidation = new UserValidator(editUserId, u.Password);
            }

            ValidationResult result = userValidation.Validate(u);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var phoneNumber = txtTelefon.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "");
            if (txtTelefon.Text != "")
                phoneNumber = phoneNumber.Substring(1);

            if (!editMode)
            {
                var newUser = new User
                {
                    Name = txtAdiSoyadi.Text.ToUpper(),
                    Username = txtKullaniciAdi.Text,
                    Password = SHA256Hash(txtSifre.Text),
                    Phone = phoneNumber,
                    Email = txtEmail.Text,
                    IsAdmin = checkAdmin.Checked,
                    IsManager = checkManager.Checked,
                    IsOperator = checkOperator.Checked,
                    IsActive = checkActive.Checked
                };

                _userRepository.AddAsync(newUser);
                await _userRepository.SaveAsync();

                _appMessage.SaveSuccessMessage();
            }
            else
            {
                var userId = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[8].Value.ToString());
                var user = _userRepository.GetWhere(u => u.Id == userId).FirstOrDefault();

                user.CreatedDate = user.CreatedDate;
                user.Name = txtAdiSoyadi.Text.ToUpper();
                user.Username = txtKullaniciAdi.Text;
                user.Password = !string.IsNullOrEmpty(txtSifre.Text) ? SHA256Hash(txtSifre.Text) : user.Password;
                user.Phone = phoneNumber;
                user.Email = txtEmail.Text;
                user.IsAdmin = checkAdmin.Checked;
                user.IsManager = checkManager.Checked;
                user.IsOperator = checkOperator.Checked;
                user.IsActive = checkActive.Checked;

                await _userRepository.SaveAsync();
                _appMessage.UpdateSuccessMessage();

            }

            EnableButtonAndText();
            editMode = false;
            txtSifre.Clear();

            GetUserList();
        }

        public string SHA256Hash(string text)
        {
            string source = text;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
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

        private void SetPhoneNumber(MaskedTextBox maskedTextBox)
        {
            string phoneNumber = maskedTextBox.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("_", "");

            if (phoneNumber.Length < 11)
            {
                maskedTextBox.Clear();
                maskedTextBox.Mask = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;
            UserDataGridTextAktar();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText();
            ClearText();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            editMode = true;
            DisableButtonAndText();
            txtAdiSoyadi.Focus();
        }

        private static string MaskedPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                string maskedPhoneNumber = "0 (" + phoneNumber.Substring(0, 3) + ") " + phoneNumber.Substring(3, 3) + " " + phoneNumber.Substring(6, 2) + " " + phoneNumber.Substring(8);
                return maskedPhoneNumber;
            }
            else
                return string.Empty;
        }

        private void FrmUser_Shown(object sender, EventArgs e)
        {
            GetUserList();
            UserDataGridTextAktar();
        }

        private void UserDataGridTextAktar()
        {
            if (selectedIndex != -1)
            {
                txtAdiSoyadi.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                txtKullaniciAdi.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
                txtTelefon.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();

                checkAdmin.Checked = (bool)dataGridView1.Rows[selectedIndex].Cells[4].Value;
                checkManager.Checked = (bool)dataGridView1.Rows[selectedIndex].Cells[5].Value;
                checkOperator.Checked = (bool)dataGridView1.Rows[selectedIndex].Cells[6].Value;
                checkActive.Checked = (bool)dataGridView1.Rows[selectedIndex].Cells[7].Value;

                dataGridView1.Rows[selectedIndex].Selected = true;
            }
        }

        private void txtTelefon_Enter(object sender, EventArgs e)
        {
            MaskedTextBoxEnter(txtTelefon);
        }

        private void txtTelefon_Leave(object sender, EventArgs e)
        {
            SetPhoneNumber(txtTelefon);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
