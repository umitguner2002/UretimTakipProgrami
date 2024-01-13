using System.Security.Cryptography;
using System.Text;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmDailyProductionUpdate : Form
    {
        public bool cancelSaving = false;
        private bool editMode;
        private Production production;
        private Order order;

        private int remainQuantity = 0;
        private int wastageQuantity = 0;

        private ProductionRepository _productionRepository;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;

        public FrmDailyProductionUpdate(bool EditMode, Production pr, int remainQuantity, int wastageQuantity)
        {
            InitializeComponent();

            _productionRepository = InstanceFactory.GetInstance<ProductionRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();
            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;

            this.editMode = EditMode;
            this.production = pr;

            this.remainQuantity = remainQuantity;
            this.wastageQuantity = wastageQuantity;
        }

        private void FrmDailyProductionUpdate_Load(object sender, EventArgs e)
        {
            var user = _userRepository.GetWhere(u => u.Id == production.UserId).FirstOrDefault();

            txtKullaniciAdi.Text = user.Name.ToString();

            txtDefoluMiktarı.Value = wastageQuantity;

            if (editMode)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker1.Value = Convert.ToDateTime(production.FinishDate).ToLocalTime();

                txtUretimMiktarı.Value = production.Quantity;
            }
            else
            {
                txtUretimMiktarı.Value = remainQuantity;
                dateTimePicker1.Value = DateTime.UtcNow.ToLocalTime();
                dateTimePicker1.Enabled = false;
            }

            txtUretimMiktarı.Focus();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            order = _orderRepository.GetWhere(x => x.Id == production.OrderId).FirstOrDefault();

            var user = _userRepository.GetWhere(u => u.Id == production.UserId && u.Password == SHA256Hash(txtSifre.Text)).FirstOrDefault();
            
            if (editMode)
            {
                int orderQuantity = _orderRepository.GetWhere(o => o.Id == production.OrderId).FirstOrDefault().Quantity;
                int totalProductionQuantity = _productionRepository.GetWhere(pr => pr.OrderId == production.OrderId).Sum(o => o.Quantity) - remainQuantity;
                remainQuantity = orderQuantity - totalProductionQuantity;
            }

            if ((remainQuantity - txtUretimMiktarı.Value) > -1)
            {
                if (user != null)
                {
                    if (editMode)
                    {
                        bool editStatus = _productionRepository.Update(new()
                        {
                            Id = production.Id,
                            OrderId = production.OrderId,
                            Quantity = Convert.ToInt16(txtUretimMiktarı.Value),
                            Wastage = Convert.ToInt16(txtDefoluMiktarı.Value),
                            FinishDate = Convert.ToDateTime(dateTimePicker1.Value).ToUniversalTime(),
                            CreatedDate = production.CreatedDate,
                            UserId = production.UserId,
                        });

                        await _productionRepository.SaveAsync();
                    }
                    else
                    {
                        bool editStatus = _productionRepository.Update(new()
                        {
                            Id = production.Id,
                            OrderId = production.OrderId,
                            Quantity = Convert.ToInt32(txtUretimMiktarı.Value),
                            Wastage = Convert.ToInt32(txtDefoluMiktarı.Value),
                            FinishDate = DateTime.UtcNow,
                            CreatedDate = production.CreatedDate,
                            UserId = production.UserId,
                            IsStarted = false
                        });

                        cancelSaving = false;

                        await _productionRepository.SaveAsync();
                    }

                    if ((remainQuantity - txtUretimMiktarı.Value) == 0)
                    {
                        order.IsReady = true;
                        order.IsProduction = false;
                        order.FinishDate = DateTime.UtcNow;
                        _orderRepository.Save();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Şifresi Hatalı", "Hatalı Şifre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifre.Focus();
                    txtSifre.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Kalan üretim miktarından fazla değer giremezsiniz.", "Üretim Miktarı Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUretimMiktarı.Value = remainQuantity;
                txtUretimMiktarı.Focus();
            }


        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            cancelSaving = true;
            this.Close();
        }

        private void FrmDailyProductionUpdate_Shown(object sender, EventArgs e)
        {

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
    }
}
