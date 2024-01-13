using FluentValidation.Results;
using System.Data;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.DependencyResolver;
using System.Diagnostics;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Messages;
using System.Windows.Forms;
using Microsoft.Win32;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmProduct : Form
    {
        private ProductRepository _productRepository;
        private MachineProgramRepository _machineProgramRepository;
        private MaterialRepository _materialRepository;
        private AppMessage _appMessage;

        private int selectedIndex;
        private bool editMode = false;

        private string imageName, imageSourcePath, imageTargetPath;

        FrmProductionDefinitions frmDef;

        public FrmProduct()
        {
            InitializeComponent();

            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
            _machineProgramRepository = InstanceFactory.GetInstance<MachineProgramRepository>();
            _materialRepository = InstanceFactory.GetInstance<MaterialRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _appMessage = new AppMessage();
        }

        private void DataGridTextAktar()
        {
            if (selectedIndex >= 0)
            {
                txtUrunAdi.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                listMalzeme.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
                listProgramAdi.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();

                if (dataGridView1.Rows[selectedIndex].Cells[6].Value != null)
                {
                    imageTargetPath = dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString();

                    if (imageTargetPath != null && imageTargetPath != "")
                        resimKutusu.ImageLocation = dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString();
                    else
                        resimKutusu.ImageLocation = "";
                }
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                object selectedProgramValue = listProgramAdi.SelectedValue;
                object selectedMaterialValue = listMalzeme.SelectedValue;

                bool isValidMachineProgram = selectedProgramValue != null && !string.IsNullOrEmpty(selectedProgramValue.ToString());
                bool isValidMaterial = selectedMaterialValue != null && !string.IsNullOrEmpty(selectedMaterialValue.ToString());

                if (!isValidMaterial)
                {
                    MessageBox.Show("Geçersiz Malzeme Adı", "Malzeme Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listMalzeme.Focus();
                }
                else if (!isValidMachineProgram)
                {
                    MessageBox.Show("Geçersiz Program Adı", "Program Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listProgramAdi.Focus();
                }
                else
                {
                    Product pr = new Product
                    {
                        Name = txtUrunAdi.Text.ToUpper(),
                        MachineProgramId = Guid.Parse(listProgramAdi.SelectedValue.ToString())
                    };

                    ProductValidator productValidation = new ProductValidator();
                    ValidationResult result = productValidation.Validate(pr);
                    IList<ValidationFailure> errors = result.Errors;

                    if (!result.IsValid && !editMode)
                    {
                        foreach (ValidationFailure failure in errors)
                        {
                            MessageBox.Show(failure.ErrorMessage, "Mevcut Veri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        var materialId = Guid.Parse(listMalzeme.SelectedValue.ToString());
                        var machineProgramId = Guid.Parse(listProgramAdi.SelectedValue.ToString());

                        if (!editMode)
                        {
                            var x = await _productRepository.AddAsync(new()
                            {
                                Name = txtUrunAdi.Text.ToUpper(),
                                MaterialId = materialId,
                                MachineProgramId = machineProgramId,
                                ImageName = !string.IsNullOrEmpty(imageName) ? imageName : "",
                                ImagePath = !string.IsNullOrEmpty(imageTargetPath) ? imageTargetPath : ""
                            });

                            if (!string.IsNullOrEmpty(imageSourcePath) && !string.IsNullOrEmpty(imageTargetPath))
                                File.Copy(imageSourcePath, imageTargetPath);

                            await _productRepository.SaveAsync();
                        }
                        else
                        {
                            if (!result.IsValid)
                            {
                                foreach (ValidationFailure failure in errors)
                                {
                                    MessageBox.Show(failure.ErrorMessage, "Mevcut Veri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            var productId = Guid.Parse(dataGridView1.Rows[selectedIndex].Cells[5].Value.ToString());
                            var product = _productRepository.GetWhere(p => p.Id == productId).FirstOrDefault();

                            product.CreatedDate = product.CreatedDate;
                            product.Name = txtUrunAdi.Text.ToUpper();
                            product.MaterialId = materialId;
                            product.MachineProgramId = machineProgramId;
                            product.ImageName = !string.IsNullOrEmpty(imageName) ? imageName : "";
                            product.ImagePath = !string.IsNullOrEmpty(imageTargetPath) ? imageTargetPath : "";

                            await _productRepository.SaveAsync();

                            txtUrunAdiAra.Text = product.Name;
                            GetProductList();
                            SetDataGridSettings();

                            selectedIndex = 0;
                            dataGridView1.Rows[selectedIndex].Selected = true;
                            DataGridTextAktar();


                            if (!string.IsNullOrEmpty(imageSourcePath) && !string.IsNullOrEmpty(imageTargetPath))
                            {
                                if (File.Exists(imageTargetPath))
                                {
                                    File.Delete(imageTargetPath); // Eğer varsa hedef dosyayı sil
                                }
                                File.Copy(imageSourcePath, imageTargetPath); // Dosyayı kopyala
                            }
                            else
                            {
                                if (File.Exists(imageTargetPath))
                                {
                                    File.Delete(imageTargetPath); // Eğer varsa hedef dosyayı sil
                                }
                            }

                            _appMessage.UpdateSuccessMessage();
                        }

                        EnableButtonAndText();
                        editMode = false;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }


        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
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

            string arananUrunAdi = txtUrunAdiAra.Text.ToLower();
            string arananMalzeme = txtMalzemeAra.Text.ToLower();

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
                .Where(product =>
                      (string.IsNullOrEmpty(arananUrunAdi) || product.Name.ToLower().Contains(arananUrunAdi)) &&
                      (string.IsNullOrEmpty(arananMalzeme) || product.materialName.ToLower().Contains(arananMalzeme)))
                .OrderBy(product => product.Name)
                .ToList();

            if (productList.Count > 0)
            {
                dataGridView1.DataSource = productList;
                lblKayitSayisi.Text = $"Kayıt Sayısı: {productList.Count.ToString()}";
                SetDataGridSettings();
            }
            else
            {
                lblKayitSayisi.Text = "Gösterilecek kayıt yok";
                MessageBox.Show("Aranan değer bulunamadı.", "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            LblKayitSayisiYerlestir();

        }

        private void SetDataGridSettings()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersHeight = 25;

                dataGridView1.Columns[0].HeaderText = "Ürün / Parça Adı";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[1].HeaderText = "İşlenecek Malzeme";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[2].HeaderText = "Tezgah Program Adı";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[3].HeaderText = "Çizim Dosya Adı";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dataGridView1.Columns[4].HeaderText = "Kayıt Tarihi";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

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

            DataGridTextAktar();
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();

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
            txtUrunAdiAra.Clear();
            txtMalzemeAra.Clear();
            dataGridView1.DataSource = null;
            txtUrunAdi.Focus();
        }

        private void EnableButtonAndText()
        {
            btnYeni.Enabled = true;
            btnDuzenle.Enabled = true;
            btnKaydet.Enabled = false;
            btnIptal.Enabled = false;
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
            dataGridView1.DataSource = null;
        }

        private void btnUrunAdiSil_Click(object sender, EventArgs e)
        {
            txtUrunAdiAra.Clear();
        }

        private void btnUrunBul_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUrunAdiAra.Text.Trim()) || !string.IsNullOrEmpty(txtMalzemeAra.Text.Trim()))
            {
                GetProductList();
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
                txtUrunAdiAra.Focus();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            editMode = true;
            DisableButtonAndText();
        }

        private void btnResimKaldir_Click(object sender, EventArgs e)
        {
            resimKutusu.Image = null;
            imageName = "";
            imageSourcePath = "";
        }

        private void btnOpenFormMaterial_Click(object sender, EventArgs e)
        {
            OpenDefitinitionForms(0);
            GetMaterialList();
        }

        private void btnOpenFormProgram_Click(object sender, EventArgs e)
        {
            OpenDefitinitionForms(1);
            GetMachineProgramList();
            if (!string.IsNullOrEmpty(frmDef.selectedMachineProgramName))
                listProgramAdi.Text = frmDef.selectedMachineProgramName;
        }

        private void OpenDefitinitionForms(int formNumber)
        {
            frmDef = new FrmProductionDefinitions();

            TabControl tabControl = frmDef.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;

            if (tabControl != null)
            {
                tabControl.SelectedIndex = formNumber;

                Button button1 = frmDef.Controls.Find("btnFormuKapat1", true).FirstOrDefault() as Button;
                button1.Visible = true;

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

        private void btnMalzemeAdiSil_Click(object sender, EventArgs e)
        {
            txtMalzemeAra.Clear();
        }

        private void FrmProduct_Resize(object sender, EventArgs e)
        {
            LblKayitSayisiYerlestir();
        }

        private void LblKayitSayisiYerlestir()
        {
            lblKayitSayisi.Left = pnlArama.Width - lblKayitSayisi.Width - 10;
        }

        private void resimKutusu_DoubleClick(object sender, EventArgs e)
        {
            if (resimKutusu.ImageLocation != "" && resimKutusu.ImageLocation != null)
            {
                FrmDisplayProductImage frmDisplayProductImage = new FrmDisplayProductImage(resimKutusu.ImageLocation);
                frmDisplayProductImage.ShowDialog();
            }
        }
    }
}
