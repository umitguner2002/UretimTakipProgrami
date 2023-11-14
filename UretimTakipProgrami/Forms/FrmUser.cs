using FluentValidation.Results;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.DataAccess.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmUser : Form
    {
        private UserRepository _userRepository = new UserRepository(FrmLogin.dbContext);

        private int selectedIndex;
        private bool editMode = false;

        public FrmUser()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            GetUserList();
        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Adı Soyadı";
                dataGridView1.Columns[0].Width = 250;
                dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Telefon";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "E-Mail";
                dataGridView1.Columns[3].Width = 250;
                dataGridView1.Columns[4].HeaderText = "Yönetici";
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].HeaderText = "Sorumlu";
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].HeaderText = "Operatör";
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Visible = false;
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
                    user.Phone, // 2
                    user.Email, // 3                    
                    user.IsAdmin, // 4
                    user.IsManager, // 5
                    user.IsOperator, // 6
                    user.IsActive, // 7
                    user.Id, // 8
                }).ToList();

            dataGridView1.DataSource = userList;

            //lblKayitSayisi.Text = $"Kayıt Sayısı: {filteredList.Count.ToString()}";

            SetDataGridSettings();
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

            txtAdiSoyadi.Focus();

            checkActive.Checked = true;
            checkOperator.Checked = true;
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

            User u = new User
            {
                Name = txtAdiSoyadi.Text.ToUpper(),
                Username = txtKullaniciAdi.Text,
                Email = txtEmail.Text
            };

            UserValidator userValidation = new UserValidator();
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

            if (!editMode)
            {
                var newUser = new User
                {
                    Name = txtAdiSoyadi.Text.ToUpper(),
                    Username = txtKullaniciAdi.Text,
                    Password = SHA256Hash(txtSifre.Text),
                    Phone = txtTelefon.Text,
                    Email = txtEmail.Text,
                    IsAdmin = checkAdmin.Checked,
                    IsManager = checkManager.Checked,
                    IsOperator = checkOperator.Checked,
                    IsActive = checkActive.Checked
                };

                _userRepository.AddAsync(newUser);
            }
            else
            {
                editStatus = _userRepository.Update(new()
                {
                    Id = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[8].Value.ToString()),
                    Name = txtAdiSoyadi.Text.ToUpper(),
                    Username = txtKullaniciAdi.Text,
                    Password = SHA256Hash(txtSifre.Text),
                    Phone = txtTelefon.Text,
                    Email = txtEmail.Text
                });
            }

            await _userRepository.SaveAsync();
            EnableButtonAndText();
            editMode = false;

            GetUserList();
        }

        private string SHA256Hash(string text)
        {
            string source = text;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;
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

        private void btnIptal_Click(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

        }
    }
}
