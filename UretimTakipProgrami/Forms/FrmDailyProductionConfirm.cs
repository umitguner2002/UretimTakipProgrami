
using System.Security.Cryptography;
using System.Text;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmDailyProductionConfirm : Form
    {
        private ProductionRepository _productionRepository;
        private UserRepository _userRepository;

        private string orderId;

        public FrmDailyProductionConfirm(string OrderId)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;

            _productionRepository = InstanceFactory.GetInstance<ProductionRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();

            this.orderId = OrderId;
        }

        private void FrmDailyProductionConfirm_Load(object sender, EventArgs e)
        {

        }

        private async void btnTamam_Click(object sender, EventArgs e)
        {
            var user = _userRepository.GetWhere(u => u.Username == txtKullaniciAdi.Text && u.Password == SHA256Hash(txtSifre.Text)).FirstOrDefault();

            if (user != null)
            {
                if (user.IsOperator)
                {
                    await _productionRepository.AddAsync(new()
                    {
                        UserId = user.Id,
                        OrderId = Guid.Parse(orderId),
                        IsStarted = true
                    });

                    await _productionRepository.SaveAsync();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Üretim yapabilmek için operatör yetkisi almanız gerekiyor.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Kullanıcı Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }

            txtKullaniciAdi.Focus();
            txtKullaniciAdi.SelectAll();

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

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
