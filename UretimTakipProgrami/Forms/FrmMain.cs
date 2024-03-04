using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using UretimTakip.Forms;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;
using Color = System.Drawing.Color;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmMain : Form
    {
        private Form currentChildForm;
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public User _user;
        private FrmLogin frmLogin;

        private ProductionDbContext dbContext;

        public FrmMain(User user, FrmLogin frmLogin)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 58);
            pnlSideBar.Controls.Add(leftBorderBtn);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 saniye
            timer.Tick += Timer_Tick;
            timer.Start();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this._user = user;
            this.frmLogin = frmLogin;

            dbContext = new ProductionDbContext();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlStatus_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmProduct());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);

            foreach (Form childForm in pnlDesktop.Controls.OfType<Form>())
            {
                childForm.Close();
            }

            ShowData();
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmOrder());
        }

        private void pnlStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Hoşgeldin, {_user.Name}";

            CheckUserAuth(this._user);

            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void CheckUserAuth(User u)
        {
            if (u.IsAdmin)
            {
                btnUrun.Visible = true;
                btnMusteri.Visible = true;
                btnSiparis.Visible = true;
                btnUretim.Visible = true;
                btnTezgahOperator.Visible = true;
                btnKullanici.Visible = true;
            }
            else if (u.IsManager)
            {
                btnUrun.Visible = true;
                btnMusteri.Visible = true;
                btnSiparis.Visible = true;
                btnUretim.Visible = true;
                btnTezgahOperator.Visible = true;
                btnKullanici.Visible = false;
            }
            else if (u.IsOperator)
            {
                btnUrun.Visible = false;
                btnMusteri.Visible = false;
                btnSiparis.Visible = false;
                btnUretim.Visible = true;
                btnTezgahOperator.Visible = true;
                btnKullanici.Visible = false;
            }
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmCustomer());
        }

        private void btnUretim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmProduction(this._user));
        }

        private void btnTezgahOperator_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmProductionDefinitions(this._user));
        }

        private void btnKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmUser());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.Show();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            lblDate.Location = new Point((pnlStatus.Width - lblDate.Width) / 2, ((pnlStatus.Height - lblDate.Height) / 2) - 15);
            lblTime.Location = new Point((pnlStatus.Width - lblTime.Width) / 2, (pnlStatus.Height - lblTime.Height + 50) / 2);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            lblDate.Location = new Point((pnlStatus.Width - lblDate.Width) / 2, ((pnlStatus.Height - lblDate.Height) / 2) - 15);
            lblTime.Location = new Point((pnlStatus.Width - lblTime.Width) / 2, (pnlStatus.Height - lblTime.Height + 50) / 2);

            ActivateButton(btnAnaEkran, RGBColors.color6);
            ShowData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ShowData()
        {
            lblNumberOfProduct.Text = dbContext.Products.Count().ToString();
            lblNumberOfCustomer.Text = dbContext.Customers.Count().ToString();
            lblNumberOfUser.Text = dbContext.Users.Where(u => u.IsOperator).Count().ToString();
            lblNumberOfMachine.Text = dbContext.Machines.Count().ToString();
            lblNumberOfProgram.Text = dbContext.MachinePrograms.Count().ToString();

            lblNumberOfPOrder.Text = dbContext.Orders.Where(o => o.IsProduction && !o.IsReady).ToList().Count().ToString();
            lblNumberOfWaiting.Text = dbContext.Orders.Where(o => !o.IsWaiting && !o.IsProduction && !o.IsReady).ToList().Count().ToString();
            lblNumberOfWaitingSelectMachine.Text = dbContext.Orders.Where(o => o.IsWaiting && !o.IsProduction && !o.IsReady).ToList().Count().ToString();
        }
    }
}
