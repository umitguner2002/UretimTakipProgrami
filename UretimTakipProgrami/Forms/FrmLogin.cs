using System.Text;
using UretimTakipProgrami.Forms;
using System.Security.Cryptography;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.DataAccess;

namespace UretimTakipProgrami
{
    public partial class FrmLogin : Form
    {

        private UserRepository _userRepository;
        private ProductionDbContext _dbContext;

        public FrmLogin()
        {
            InitializeComponent();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();
            _dbContext = InstanceFactory.GetInstance<ProductionDbContext>();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var user = _userRepository.GetWhere(u => u.Username == txtKullaniciAdi.Text && u.Password == SHA256Hash(txtSifre.Text)).FirstOrDefault();

            if (user != null)
            {
                FrmMain frmMain = new FrmMain(user, this);
                this.Hide();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı !", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAdi.Focus();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext.Database.EnsureCreated();

                string directoryPath = Application.StartupPath;
                string imageTargetPath = Path.Combine(directoryPath, $"Files\\Images"); // Ürün resimlerinin kaydedileceği klasörü oluştur.
                string programsTargetPath = Path.Combine(directoryPath, $"Files\\Programs"); // Tezgah programlarının kaydedileceği klasörü oluştur.

                if (!Directory.Exists(imageTargetPath) || !Directory.Exists(programsTargetPath))
                {
                    Directory.CreateDirectory(imageTargetPath);
                    Directory.CreateDirectory(programsTargetPath);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error! Database is not exist.\n{err.ToString()}");
            }
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

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = "umt";
            txtSifre.Text = "dev";
            txtKullaniciAdi.Focus();
        }
    }
}
