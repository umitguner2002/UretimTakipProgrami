using FluentValidation.Results;
using System.Data;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.DataAccess.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmProduct : Form
    {
        private ProductRepository _productRepository = new ProductRepository(FrmLogin.dbContext);
        private MachineProgramRepository _machineProgramRepository = new MachineProgramRepository(FrmLogin.dbContext);
        private MaterialRepository _materialRepository = new MaterialRepository(FrmLogin.dbContext);

        private int selectedIndex;
        private bool editMode = false;

        private string imageName, imageSourcePath, imageTargetPath;

        public FrmProduct()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {

            Product pr = new Product
            {
                Name = txtUrunAdi.Text.ToUpper()
            };

            ProductValidator productValidation = new ProductValidator();
            ValidationResult result = productValidation.Validate(pr);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (_materialRepository.GetById(listMalzeme.SelectedValue.ToString()) == null)
            {
                MessageBox.Show("Geçerli bir malzeme adı seçiniz.", "Malzeme Seçim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listMalzeme.Focus();
                return;
            }
            else if (_machineProgramRepository.GetById(listProgramAdi.SelectedValue.ToString()) == null)
            {
                MessageBox.Show("Geçerli bir program adı seçiniz.", "Program Seçim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listProgramAdi.Focus();
                return;
            }
            else
            {
                bool editStatus = false;

                if (!string.IsNullOrEmpty(imageSourcePath))
                {
                    imageName = $"{txtUrunAdi.Text}.jpg";
                    imageTargetPath = Path.Combine(Path.Combine(Application.StartupPath, $"Files\\Images"), imageName);
                }

                Entities.Material mt = _materialRepository.GetWhere(mt => mt.Id == Guid.Parse(listMalzeme.SelectedValue.ToString())).FirstOrDefault();
                MachineProgram mp = _machineProgramRepository.GetWhere(mp => mp.Id == Guid.Parse(listProgramAdi.SelectedValue.ToString())).FirstOrDefault();
                
                if (!editMode)
                {
                    await _productRepository.AddAsync(new()
                    {
                        Name = txtUrunAdi.Text.ToUpper(),
                        Material = mt,
                        MachineProgram = mp,
                        ImageName = !string.IsNullOrEmpty(imageName) ? imageName : "",
                        ImagePath = !string.IsNullOrEmpty(imageTargetPath) ? imageTargetPath : ""
                    });

                    if (!string.IsNullOrEmpty(imageSourcePath) && !string.IsNullOrEmpty(imageTargetPath))
                        File.Copy(imageSourcePath, imageTargetPath);
                }
                else
                {
                    editStatus = _productRepository.Update(new()
                    {
                        Name = txtUrunAdi.Text.ToUpper(),
                        Material = mt,
                        MachineProgram = mp,
                        ImageName = !string.IsNullOrEmpty(imageName) ? imageName : "",
                        ImagePath = !string.IsNullOrEmpty(imageTargetPath) ? imageTargetPath : ""
                    });
                }

                await _productRepository.SaveAsync();
                EnableButtonAndText();
                editMode = false;
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            dataGridView1.DataSource = null;
            ClearText();
            EnableButtonAndText();
            SetDataGridSettings();

            GetMaterialList();
            GetMachineProgramList();
        }

        private void GetProductList()
        {
            dataGridView1.DataSource = null;
            List<object> filteredList = new List<object>();

            var materialList = _materialRepository.GetAll().Select(mt => new
            {
                Id = mt.Id,
                Name = mt.Name
            });

            var programList = _machineProgramRepository.GetAll().Select(mc => new
            {
                Id = mc.Id,
                Name = mc.Name
            });

            var productList = _productRepository.GetAll()
                .Select(product => new
                {
                    product.Name,
                    materialName = product.Material.Name,
                    programName = product.MachineProgram.Name,
                    product.ImageName,
                    productCreatedDate = product.CreatedDate.ToLocalTime(),
                    product.Id,
                    product.ImagePath
                })
                .ToList();

            string arananUrunAdi = txtUrunAdiAra.Text.ToUpper();
            string arananTarih = txtKayitTarihiAra.Text;
            DateTime.TryParse(arananTarih, out DateTime kayitTarihi);

            foreach (var pr in productList)
            {
                if (arananUrunAdi != "" && arananTarih != "")
                {
                    if (pr.Name.Contains(arananUrunAdi) && pr.productCreatedDate.Date == kayitTarihi.ToLocalTime().Date)
                        filteredList.Add(pr);
                }
                else if (arananUrunAdi != "")
                {
                    if (pr.Name.Contains(arananUrunAdi))
                        filteredList.Add(pr);
                }
                else
                {
                    if (pr.productCreatedDate.Date == kayitTarihi.ToLocalTime().Date)
                        filteredList.Add(pr);
                }
            }

            dataGridView1.DataSource = filteredList;
            lblKayitSayisi.Text = $"Kayıt Sayısı: {filteredList.Count.ToString()}";

            SetDataGridSettings();
        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Ürün / Parça Adı";
                dataGridView1.Columns[1].HeaderText = "İşlenecek Malzeme";
                dataGridView1.Columns[2].HeaderText = "Tezgah Program Adı";
                dataGridView1.Columns[3].HeaderText = "Çizim Dosya Adı";
                dataGridView1.Columns[4].HeaderText = "Kayıt Tarihi";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
        }

        private void GetMaterialList()
        {
            try
            {
                var materialList = _materialRepository.GetAll()
                .Select(material => new
                {
                    material.Id,
                    material.Name
                })
                .ToList();

                var emptyItem = new
                {
                    Id = Guid.NewGuid(),
                    Name = "--Seçiniz--"
                };

                materialList.Insert(0, emptyItem);

                listMalzeme.DataSource = materialList;
                listMalzeme.DisplayMember = "Name";
                listMalzeme.ValueMember = "Id";

                listMalzeme.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                listMalzeme.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void GetMachineProgramList()
        {
            try
            {
                var programList = _machineProgramRepository.GetAll()
                .Select(program => new
                {
                    program.Id,
                    program.Name
                })
                .ToList();

                var emptyItem = new
                {
                    Id = Guid.NewGuid(),
                    Name = "--Seçiniz--"
                };

                programList.Insert(0, emptyItem);

                listProgramAdi.DataSource = programList;
                listProgramAdi.DisplayMember = "Name";
                listProgramAdi.ValueMember = "Id";

                listProgramAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                listProgramAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = dataGridView1.CurrentCell.RowIndex;

            if (selectedIndex >= 0)
            {
                txtUrunAdi.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                listMalzeme.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
                listProgramAdi.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();

                if (dataGridView1.Rows[selectedIndex].Cells[6].Value != null)
                    resimKutusu.ImageLocation = dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString();
            }
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Title = "Ürün Resim / Çizim Seç";
            dialog.Filter = "Resim Dosyası (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageSourcePath = dialog.FileName;
                var PictureBox1 = new PictureBox();
                resimKutusu.ImageLocation = imageSourcePath;
            }
            else
                imageSourcePath = "";

            dialog.Dispose();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            DisableButtonAndText();
            ClearText();
            txtUrunAdi.Focus();
        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
            btnSil.Enabled = true;
            btnResimEkle.Enabled = false;
            btnResimKaldir.Enabled = false;

            btnOpenFormMaterial.Enabled = false;
            btnOpenFormProgram.Enabled = false;

            txtUrunAdi.Enabled = false;

            listMalzeme.Enabled = false;
            listProgramAdi.Enabled = false;

            grpboxUrunAra.Enabled = true;
        }

        private void DisableButtonAndText()
        {
            btnYeni.Enabled = false;
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
            btnIptal.Enabled = true;
            btnSil.Enabled = false;
            btnResimEkle.Enabled = true;
            btnResimKaldir.Enabled = true;

            btnOpenFormMaterial.Enabled = true;
            btnOpenFormProgram.Enabled = true;

            txtUrunAdi.Enabled = true;

            listMalzeme.Enabled = true;
            listProgramAdi.Enabled = true;

            grpboxUrunAra.Enabled = false;
        }

        private void ClearText()
        {
            txtUrunAdi.Clear();
            txtUrunAdiAra.Clear();
            txtKayitTarihiAra.Clear();

            if (listMalzeme.Items.Count > 0)
                listMalzeme.SelectedIndex = 0;
            if (listProgramAdi.Items.Count > 0)
                listProgramAdi.SelectedIndex = 0;

            resimKutusu.Image = null;

            imageName = "";
            imageSourcePath = "";
            imageTargetPath = "";
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText();
            ClearText();
        }

        private void btnBulTarih_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            else
                monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtKayitTarihiAra.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
        }

        private void btnKayitTarihiSil_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            txtKayitTarihiAra.Clear();
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            txtUrunAdiAra.Clear();
        }

        private void btnUrunBul_Click(object sender, EventArgs e)
        {
            GetProductList();
            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows[0].Selected = true;
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (selectedIndex > -1 && dataGridView1.ColumnCount > 0)
            {
                selectedIndex = dataGridView1.CurrentCell.RowIndex;
                await _productRepository.RemoveAsync(dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString());
                GetProductList();
            }
        }

        private void btnProgramEkle_Click(object sender, EventArgs e)
        {

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            editMode = true;
            DisableButtonAndText();
        }

        private void btnResimKaldir_Click(object sender, EventArgs e)
        {
            resimKutusu.Image = null;
        }

        private void btnOpenFormMaterial_Click(object sender, EventArgs e)
        {            
            OpenDefitinitionForms(1);
            GetMaterialList();
        }

        private void btnOpenFormProgram_Click(object sender, EventArgs e)
        {
            OpenDefitinitionForms(2);
            GetMachineProgramList();
        }

        private void OpenDefitinitionForms(int formNumber)
        {
            FrmProductionDefinitions frmDef = new FrmProductionDefinitions();

            TabControl tabControl = frmDef.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;

            if (tabControl != null)
            {
                tabControl.SelectedIndex = formNumber;

                Button button1 = frmDef.Controls.Find("btnFormuKapat1", true).FirstOrDefault() as Button;
                button1.Visible = true;

                Button button2 = frmDef.Controls.Find("btnFormuKapat2", true).FirstOrDefault() as Button;
                button2.Visible = true;

                Button button3 = frmDef.Controls.Find("btnFormuKapat3", true).FirstOrDefault() as Button;
                button3.Visible = true;
            }

            frmDef.ShowDialog();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnGeriDon.Visible = false;
        }
    }
}
