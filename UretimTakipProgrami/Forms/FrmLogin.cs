using System.Text;
using UretimTakipProgrami.Forms;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.DataAccess;

namespace UretimTakipProgrami
{
    public partial class FrmLogin : Form
    {

        public static ProductionDbContext dbContext = new ProductionDbContext();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var user = dbContext.Users.Where(u => u.Username == txtKullaniciAdi.Text && u.Password == SHA256Hash(txtSifre.Text)).FirstOrDefault();

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
            string directoryPath = Application.StartupPath;
            string imageTargetPath = Path.Combine(directoryPath, $"Files\\Images"); // Ürün resimlerinin kaydedileceği klasörü oluştur.
            string programsTargetPath = Path.Combine(directoryPath, $"Files\\Programs"); // Tezgah programlarının kaydedileceği klasörü oluştur.

            if (!Directory.Exists(imageTargetPath) || !Directory.Exists(programsTargetPath))
            {
                Directory.CreateDirectory(imageTargetPath);
                Directory.CreateDirectory(programsTargetPath);
            }

            try
            {
                dbContext.Database.EnsureCreated();

                if (!dbContext.Users.Any())
                {
                    var user = new User
                    {
                        CreatedDate = DateTime.UtcNow,
                        Name = "ÜMİT",
                        Username = "umt",
                        Password = SHA256Hash("dev"),
                        Phone = "",
                        Email = "",
                        IsAdmin = true,
                        IsManager = false,
                        IsOperator = false,
                        IsActive = true,
                        IsDeleted = false
                    };

                    dbContext.Users.Add(user);

                    var startDate = DateTime.UtcNow;

                    var materialShapes = new List<MaterialShape>();
                    var materialShapeNames = new List<string> { "DOLU", "DELİKLİ", "BOYDAN" ,"BORU", "MİL"};                    

                    foreach (var name in materialShapeNames)
                    {
                        var materialShape = new MaterialShape
                        {
                            CreatedDate = startDate,
                            Name = name
                        };
                        materialShapes.Add(materialShape);
                    }

                    dbContext.MaterialShapes.AddRange(materialShapes);

                    var materialTypes = new List<MaterialType>();
                    var materialTypeNames = new List<string> { "DEMİR", "ÇELİK", "BAKIR", "PİRİNÇ", "ALÜMİNYUM", "DERLİN" };

                    foreach (var name in materialTypeNames)
                    {
                        var materialType = new MaterialType
                        {
                            CreatedDate = startDate,
                            Name = name
                        };
                        materialTypes.Add(materialType);
                    }

                    dbContext.MaterialTypes.AddRange(materialTypes);

                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı Oluşturma Hatası: {ex.ToString()}");
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
