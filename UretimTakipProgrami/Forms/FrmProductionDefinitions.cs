using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation.Results;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Messages;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using User = UretimTakipProgrami.Entities.User;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmProductionDefinitions : Form
    {
        private MachineRepository _machineRepository;
        private MachineProgramRepository _machineProgramRepository;
        private MaterialTypeRepository _materialTypeRepository;
        private MaterialShapeRepository _materialShapeRepository;
        private MaterialRepository _materialRepository;
        private UserRepository _userRepository;
        private AppMessage _appMessage;
        private User _user;

        private int groupIndex = 0;
        private int countIndex = 0;
        private int selectedIndex = 0;
        private int selectedIndex2 = 0;
        private int selectedIndex3 = 0;
        private int selectedIndex4 = 0;
        private int selectedIndex5 = 0;
        private bool editMode = false;
        private int kodListIndex = 0;

        public string? selectedMaterialName;
        public string? selectedMachineProgramName;

        System.Windows.Forms.ToolTip buttonToolTip;

        Dictionary<string, string> hedefList = new Dictionary<string, string>();

        public FrmProductionDefinitions()
        {
            InitializeComponent();

            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();
            _machineProgramRepository = InstanceFactory.GetInstance<MachineProgramRepository>();
            _materialTypeRepository = InstanceFactory.GetInstance<MaterialTypeRepository>();
            _materialShapeRepository = InstanceFactory.GetInstance<MaterialShapeRepository>();
            _materialRepository = InstanceFactory.GetInstance<MaterialRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _appMessage = new AppMessage();
            buttonToolTip = new System.Windows.Forms.ToolTip();
        }

        public FrmProductionDefinitions(User user)
        {
            InitializeComponent();

            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();
            _machineProgramRepository = InstanceFactory.GetInstance<MachineProgramRepository>();
            _materialTypeRepository = InstanceFactory.GetInstance<MaterialTypeRepository>();
            _materialShapeRepository = InstanceFactory.GetInstance<MaterialShapeRepository>();
            _materialRepository = InstanceFactory.GetInstance<MaterialRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = string.Empty;
            this.ControlBox = false;

            _user = _userRepository.GetWhere(u => u.Id == user.Id).FirstOrDefault();
            CheckUserAuth(_user);

            _appMessage = new AppMessage();
            buttonToolTip = new System.Windows.Forms.ToolTip();
        }

        private void EnableButtonAndText(int _groupIndex)
        {
            if (_groupIndex == 1)
            {
                btnYeniProgram.Enabled = true;
                btnProgramGuncelle.Enabled = true;
                btnProgramKaydet.Enabled = false;
                btnProgramIptal.Enabled = false;
                btnProgramEkle.Enabled = false;
                txtProgramKodu.Enabled = false;
                txtProgramAdi.Enabled = false;

                txtProgramKodu.Clear();
                txtProgramAdi.Clear();
                txtKodSatir.Clear();
                listKod.Items.Clear();

                txtKodSatir.Enabled = false;
                btnKodDeğiştir.Enabled = false;
            }

            if (_groupIndex == 2)
            {
                btnYeniProgram.Enabled = true;
                btnProgramGuncelle.Enabled = true;
                btnProgramKaydet.Enabled = false;
                btnProgramIptal.Enabled = false;
                btnProgramEkle.Enabled = false;
                txtProgramKodu.Enabled = false;
                txtProgramAdi.Enabled = false;

                txtKodSatir.Enabled = false;
                btnKodDeğiştir.Enabled = false;
            }
        }

        private void DisableButtonAndText(int _groupIndex)
        {
            if (_groupIndex == 1)
            {
                btnYeniProgram.Enabled = false;
                btnProgramGuncelle.Enabled = false;
                btnProgramKaydet.Enabled = true;
                btnProgramIptal.Enabled = true;
                btnProgramEkle.Enabled = true;
                txtProgramKodu.Enabled = true;
                txtProgramAdi.Enabled = true;

                txtKodSatir.Enabled = true;
                btnKodDeğiştir.Enabled = true;
            }

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.FromArgb(175, 174, 209), Color.FromArgb(175, 174, 209), System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.White);
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);

            SolidBrush fillbrush = new SolidBrush(Color.FromArgb(175, 174, 209));
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);
            background.Size = new Size(tabControl1.Right - background.Left, lasttabrect.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);
        }

        private void btnProgramEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Dosya Seç";
            openFileDialog.Filter = "Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;

                listKod.Items.Clear();

                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;
                    int rowNumber = 1;

                    // Dosyadan satır satır oku
                    while ((satir = sr.ReadLine()) != null)
                    {

                        listKod.Items.Add($"{satir}");

                        if (rowNumber == 2)
                        {
                            EditProgramCodeTextBox(satir);
                        }
                        rowNumber++;
                    }
                }

                if (!string.IsNullOrEmpty(listKod.Items[1].ToString()))
                {
                    kodListIndex = 1;
                    listKod.SelectedIndex = 1;
                    txtKodSatir.Text = listKod.Items[kodListIndex].ToString();
                }

            }
        }

        private void listKod_Click(object sender, EventArgs e)
        {
            kodListIndex = listKod.SelectedIndex;
            if (kodListIndex > -1)
                txtKodSatir.Text = listKod.SelectedItem.ToString();
        }

        private void btnKodDeğiştir_Click(object sender, EventArgs e)
        {
            if (kodListIndex > -1 && !string.IsNullOrEmpty(listKod.SelectedItem.ToString()))
            {
                if (listKod.SelectedItem.ToString().CompareTo(txtKodSatir.Text) != 0)
                {
                    DialogResult cvp = MessageBox.Show("Program kodunda değişiklik yapmak istiyor musun?", "Dikkat Program Kod Değişikliği", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (cvp == DialogResult.Yes)
                    {
                        listKod.Items[kodListIndex] = txtKodSatir.Text;
                        if (kodListIndex == 1)
                            EditProgramCodeTextBox(txtKodSatir.Text);
                    }
                    else
                        txtKodSatir.Text = listKod.Items[kodListIndex].ToString();
                }
            }
        }

        private void EditProgramCodeTextBox(string row)
        {
            txtProgramAdi.Text = row.ToString();

            int parantezFirstIndex = row.IndexOf('(');

            if (parantezFirstIndex != -1)
            {
                txtProgramKodu.Text = row.Substring(0, parantezFirstIndex);
            }
        }

        private void btnYeniProgram_Click(object sender, EventArgs e)
        {
            DisableButtonAndText(groupIndex = 1);
            dataListProgramDef.DataSource = null;
            txtProgramKodu.Clear();
            txtProgramAdi.Clear();
            txtKodSatir.Clear();
            listKod.Items.Clear();
            txtProgramAra.Clear();
            txtProgramKodu.Focus();
        }

        private void btnProgramIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText(groupIndex = 1);
            DataGridProgramTextAktar();
        }

        private async void btnProgramKaydet_Click(object sender, EventArgs e)
        {
            MachineProgramValidator machineProgramValidation; ;

            var mp = new MachineProgram
            {
                Code = txtProgramKodu.Text,
                Name = txtProgramAdi.Text.ToUpper()
            };

            if (!editMode)
            {
                machineProgramValidation = new MachineProgramValidator();
            }
            else
            {
                string editMachineProgramId = dataListProgramDef.Rows[selectedIndex2].Cells[2].Value.ToString();
                machineProgramValidation = new MachineProgramValidator(editMachineProgramId);
            }

            ValidationResult result = machineProgramValidation.Validate(mp);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            selectedMaterialName = txtMalzemeAdi.Text;
            selectedMachineProgramName = txtProgramAdi.Text;

            string filePath = CopyProgramToFolder();

            if (filePath != null)
            {
                if (!editMode)
                {
                    await _machineProgramRepository.AddAsync(new()
                    {
                        Code = txtProgramKodu.Text,
                        Name = txtProgramAdi.Text.ToUpper(),
                        Path = filePath
                    });

                    _machineProgramRepository.Save();
                    EnableButtonAndText(groupIndex = 1);
                }
                else
                {
                    MachineProgram m = _machineProgramRepository
                        .GetWhere(x => x.Id == Guid.Parse(dataListProgramDef.Rows[selectedIndex2].Cells[2].Value.ToString())).FirstOrDefault();

                    m.Code = txtProgramKodu.Text;
                    m.Name = txtProgramAdi.Text.ToUpper();
                    m.Path = filePath;

                    txtProgramAra.Text = m.Name;

                    _machineProgramRepository.Save();

                    List<object> programList = GetProgramList(txtProgramAra.Text);

                    if (programList.Count > 0)
                    {
                        dataListProgramDef.DataSource = programList.ToList();
                        selectedIndex2 = 0;
                        dataListProgramDef.Rows[0].Selected = true;
                        SetDataListProgramGridSettings();
                        DataGridProgramTextAktar();
                    }

                    EnableButtonAndText(groupIndex = 2);
                }

                editMode = false;

                int machineProgramCount = _machineProgramRepository.GetAll().Select(x => x.Name).ToList().Count();
                if (machineProgramCount > 0)
                    lblProgramSayisi.Text = "Program Sayısı: " + machineProgramCount.ToString();
                else
                    lblProgramSayisi.Text = "Program Sayısı: 0";
            }
        }

        private string CopyProgramToFolder()
        {
            string selectedFileName = txtProgramAdi.Text; // Dosya adı
            string filePath;

            if (listKod.Items.Count > 0)
            {
                string directoryPath = Application.StartupPath;
                string filesFolderPath = Path.Combine(directoryPath, $"Files\\Programs");

                if (!Directory.Exists(filesFolderPath))
                {
                    Directory.CreateDirectory(filesFolderPath);
                }

                filePath = Path.Combine(filesFolderPath, selectedFileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in listKod.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }

                return filePath;
            }

            return null;
        }

        private void btnProgramBul_Click(object sender, EventArgs e)
        {
            listKod.Items.Clear();
            txtProgramAdi.Clear();
            txtProgramKodu.Clear();
            dataListProgramDef.DataSource = null;

            List<object> programList = GetProgramList(txtProgramAra.Text);

            if (programList.Count > 0)
            {
                dataListProgramDef.DataSource = programList.ToList();
                SetDataListProgramGridSettings();
                dataListProgramDef.Rows[0].Selected = true;
                DataGridProgramTextAktar();
            }
        }

        private List<object> GetProgramList(string arananProgram)
        {
            arananProgram = arananProgram.Trim();

            var programList = _machineProgramRepository.GetAll()
                .Select(program => new
                {
                    program.Code,
                    program.Name,
                    program.Id,
                    program.Path
                })
                .Where(prg =>
                    (string.IsNullOrEmpty(arananProgram) || prg.Name.ToUpper().Contains(arananProgram.ToUpper())))
                .OrderBy(prg => prg.Name)
                .ToList();

            return programList.Cast<object>().ToList();
        }

        private void SetDataListProgramGridSettings()
        {
            if (dataListProgramDef.Rows.Count > 0)
            {
                dataListProgramDef.Columns[0].HeaderText = "Program Kodu";
                dataListProgramDef.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProgramDef.Columns[1].HeaderText = "Program Adı";
                dataListProgramDef.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataListProgramDef.Columns[2].Visible = false; // Id
                dataListProgramDef.Columns[3].Visible = false; // Program Path
            }
        }

        private void SetDataListProgramKopyalaGridSettings()
        {
            if (dataListProgramKopyala.Rows.Count > 0)
            {
                dataListProgramKopyala.Columns[0].HeaderText = "Program Kodu";
                dataListProgramKopyala.Columns[0].Width = 65;
                dataListProgramKopyala.Columns[1].HeaderText = "Program Adı";
                dataListProgramKopyala.Columns[2].Visible = false; // Id
                dataListProgramKopyala.Columns[3].Visible = false; // Program Path
            }
        }

        private void dataListProgramDef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListProgramDef.RowCount > 0)
            {
                selectedIndex2 = dataListProgramDef.CurrentCell.RowIndex;
                DataGridProgramTextAktar();
            }
        }

        private void DataGridProgramTextAktar()
        {
            if (selectedIndex2 >= 0 && dataListProgramDef.Rows.Count > 0)
            {
                txtProgramKodu.Text = dataListProgramDef.Rows[selectedIndex2].Cells[0].Value.ToString();
                txtProgramAdi.Text = dataListProgramDef.Rows[selectedIndex2].Cells[1].Value.ToString();
                string dosyaYolu = dataListProgramDef.Rows[selectedIndex2].Cells[3].Value.ToString();

                listKod.Items.Clear();

                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;
                    int rowNumber = 1;

                    // Dosyadan satır satır oku
                    while ((satir = sr.ReadLine()) != null)
                    {
                        listKod.Items.Add($"{satir}");
                        rowNumber++;
                    }
                }

                if (listKod.Items.Count > 0)
                    txtKodSatir.Text = listKod.Items[1].ToString();
            }
        }

        private void btnProgramAdiSil_Click(object sender, EventArgs e)
        {
            txtProgramAra.Clear();
        }

        private void txtArananProgram2_TextChanged(object sender, EventArgs e)
        {
            if (txtArananProgram2.Text != "")
            {
                List<object> programList = GetProgramList(txtArananProgram2.Text);

                if (programList.Count > 0)
                {
                    dataListProgramKopyala.DataSource = programList.ToList();
                    SetDataListProgramKopyalaGridSettings();
                    dataListProgramKopyala.Rows[0].Selected = true;
                }
            }
            else
                dataListProgramKopyala.DataSource = null;

        }

        private void dataListProgramKopyala_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex4 = dataListProgramKopyala.CurrentRow.Index;
        }

        private void btnDosyaAl_Click(object sender, EventArgs e)
        {
            if (selectedIndex4 > -1 && txtArananProgram2.Text != "")
            {
                string programName = dataListProgramKopyala.Rows[selectedIndex4].Cells[1].Value.ToString();
                string programPath = dataListProgramKopyala.Rows[selectedIndex4].Cells[3].Value.ToString();

                if (!hedefList.ContainsKey(programName))
                {
                    hedefList.Add(programName, programPath);
                    dataListHedef.DataSource = hedefList.ToList();
                    dataListHedef.Columns[0].HeaderText = "Program Adı";
                    dataListHedef.Columns[1].Visible = false;
                }
                else
                {
                    MessageBox.Show("Bu Program listede zaten var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnListedenKaldir_Click(object sender, EventArgs e)
        {
            if (hedefList.Count > 0)
            {
                string programName = dataListHedef.Rows[selectedIndex5].Cells[0].Value.ToString();
                hedefList.Remove(programName);

                if (hedefList.Count == 0)
                    dataListHedef.DataSource = null;
                else
                    dataListHedef.DataSource = hedefList.ToList();
            }

            selectedIndex5 = 0;
        }

        private void dataListHedef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex5 = dataListHedef.CurrentRow.Index;
        }

        private void btnKlasorSec_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Bir klasör seçin:";
                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer; // Başlangıç klasörü
                folderBrowser.ShowNewFolderButton = false; // Yeni klasör oluşturma seçeneği kapatılsın mı?

                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtHedefYol.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void btnHedefYolSil_Click(object sender, EventArgs e)
        {
            txtHedefYol.Clear();
        }

        private void btnDosyaGonder_Click(object sender, EventArgs e)
        {
            string hedefKlasorYolu = txtHedefYol.Text;

            if (txtHedefYol.Text != "")
            {
                if (hedefList.Count > 0)
                {
                    try
                    {
                        List<string> dosyaListesi = new List<string>();
                        // Kaynak klasördeki dosyaların yollarını al.
                        foreach (string copyFilePath in hedefList.Values)
                        {
                            dosyaListesi.Add(copyFilePath);
                        }

                        // Dosyaları hedef klasöre kopyala
                        foreach (string dosyaYolu in dosyaListesi)
                        {
                            string dosyaAdi = Path.GetFileName(dosyaYolu); // Dosya adını al
                            string hedefDosyaYolu = Path.Combine(hedefKlasorYolu, dosyaAdi); // Hedef dosya yolunu oluştur

                            File.Copy(dosyaYolu, hedefDosyaYolu, true); // Dosyayı kopyala (varsa üzerine yaz)
                            Console.WriteLine("Dosya kopyalandı: " + hedefDosyaYolu);
                        }

                        MessageBox.Show("Tüm dosyalar başarıyla kopyalandı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        hedefList.Clear();
                        dataListHedef.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu" + ex.Message, "Kopyalama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Listede kopyalanacak dosya yok.", "Dosya Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("Dosyaların kopyalanacağı klasörü seçiniz.", "Klasör Yolu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnListeyiTemzile_Click(object sender, EventArgs e)
        {
            hedefList.Clear();
            dataListHedef.DataSource = null;
        }

        private void MalzemeAdiYaz()
        {
            if (listMalzemeTuru.Text != "")
            {
                string malzemeAdi = listMalzemeSekli.Text != "" ? $"{listMalzemeSekli.Text}" : "";
                malzemeAdi += $" {listMalzemeTuru.Text}";
                malzemeAdi += txtMalzemeDelikCap.Value > 0 ? $" İç={txtMalzemeDelikCap.Value.ToString()}" : "";
                malzemeAdi += txtMalzemeDisCap.Value > 0 ? $" Dış={txtMalzemeDisCap.Value.ToString()}" : "";
                malzemeAdi += txtMalzemeBoy.Value > 0 ? $" L={txtMalzemeBoy.Value.ToString()}" : "";

                txtMalzemeAdi.Text = malzemeAdi;
            }
        }

        private void listMalzemeTuru_DropDown(object sender, EventArgs e)
        {
            var materialTypeList = _materialTypeRepository.GetAll()
                .Select(materialType => new
                {
                    materialType.Id,
                    materialType.Name
                })
                .ToList();

            listMalzemeTuru.DataSource = materialTypeList;
            listMalzemeTuru.DisplayMember = "Name";
            listMalzemeTuru.ValueMember = "Id";
        }

        private void txtMalzemeBoy_ValueChanged(object sender, EventArgs e)
        {
            MalzemeAdiYaz();
        }

        private void txtMalzemeDisCap_ValueChanged(object sender, EventArgs e)
        {
            MalzemeAdiYaz();
        }

        private void txtMalzemeDelikCap_ValueChanged(object sender, EventArgs e)
        {
            MalzemeAdiYaz();
        }

        private void listMalzemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            MalzemeAdiYaz();
        }

        private async void btnKaydetMalzeme_Click(object sender, EventArgs e)
        {
            Material mt = new Material
            {
                Name = txtMalzemeAdi.Text.ToUpper()
            };

            MaterialValidator machineValidation = new MaterialValidator();
            ValidationResult result = machineValidation.Validate(mt);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            selectedMaterialName = txtMalzemeAdi.Text;

            await _materialRepository.AddAsync(new()
            {
                Name = txtMalzemeAdi.Text.ToUpper(),
                Length = Convert.ToInt32(txtMalzemeBoy.Value),
                OuterDiameter = Convert.ToInt32(txtMalzemeDisCap.Value),
                HoleDiameter = Convert.ToInt32(txtMalzemeDisCap.Value),
                MaterialTypeId = Guid.Parse(listMalzemeTuru.SelectedValue.ToString()),
                MaterialShapeId = Guid.Parse(listMalzemeSekli.SelectedValue.ToString())
            });

            await _materialRepository.SaveAsync();
            _appMessage.SaveSuccessMessage();

            txtMalzemeBoy.Value = 0;
            txtMalzemeDisCap.Value = 0;
            txtMalzemeDelikCap.Value = 0;
            listMalzemeTuru.DataSource = null;
            listMalzemeSekli.DataSource = null;
            txtMalzemeAdi.Clear();

            RefreshLabels();
        }

        private async void btnKaydetTezgah_Click(object sender, EventArgs e)
        {
            Machine mc = new Machine
            {
                Name = txtTezgahAdi.Text.ToUpper()
            };

            MachineValidator machineValidation = new MachineValidator();
            ValidationResult result = machineValidation.Validate(mc);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            await _machineRepository.AddAsync(new()
            {
                Name = txtTezgahAdi.Text.ToUpper()
            });

            await _machineRepository.SaveAsync();
            _appMessage.SaveSuccessMessage();

            RefreshLabels();

            txtTezgahAdi.Clear();
        }

        private void listMalzemeTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnIptalMalzeme_Click(object sender, EventArgs e)
        {
            txtMalzemeAdi.Clear();
            EnableButtonAndText(groupIndex = 1);
        }

        private void btnFormuKapat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductionDefinitions_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnFormuKapat1.Visible = false;
            btnFormuKapat2.Visible = false;
        }

        private void listMalzemeSekli_DropDown(object sender, EventArgs e)
        {
            var materialShapeList = _materialShapeRepository.GetAll()
                .Select(materialShape => new
                {
                    materialShape.Id,
                    materialShape.Name
                })
                .ToList();

            listMalzemeSekli.DataSource = materialShapeList;
            listMalzemeSekli.DisplayMember = "Name";
            listMalzemeSekli.ValueMember = "Id";
        }

        private void listMalzemeSekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            MalzemeAdiYaz();
        }

        private async void btnKaydetMalzemeTuru_Click(object sender, EventArgs e)
        {
            MaterialType mt = new MaterialType
            {
                Name = txtMalzemeTuru.Text.ToUpper()
            };

            MaterialTypeValidator materialTypeValidation = new MaterialTypeValidator();
            ValidationResult result = materialTypeValidation.Validate(mt);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            await _materialTypeRepository.AddAsync(new()
            {
                Name = txtMalzemeTuru.Text.ToUpper()
            });

            await _materialTypeRepository.SaveAsync();
            _appMessage.SaveSuccessMessage();

            RefreshLabels();
            txtMalzemeTuru.Clear();
        }

        private async void btnKaydetMalzemeSekli_Click(object sender, EventArgs e)
        {
            MaterialShape ms = new MaterialShape
            {
                Name = txtMalzemeSekli.Text.ToUpper()
            };

            MaterialShapeValidator materialShapeValidation = new MaterialShapeValidator();
            ValidationResult result = materialShapeValidation.Validate(ms);
            IList<ValidationFailure> errors = result.Errors;

            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            await _materialShapeRepository.AddAsync(new()
            {
                Name = txtMalzemeSekli.Text.ToUpper()
            });

            await _materialShapeRepository.SaveAsync();
            _appMessage.SaveSuccessMessage();

            RefreshLabels();
            txtMalzemeSekli.Clear();
        }

        private void FrmProductionDefinitions_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            RefreshLabels();
        }

        private void RefreshLabels()
        {
            int machineCount = _machineRepository.GetAll().Select(x => x.Name).ToList().Count();
            int materialTypeCount = _materialTypeRepository.GetAll().Select(x => x.Name).ToList().Count();
            int materialShapeCount = _materialShapeRepository.GetAll().Select(x => x.Name).ToList().Count();
            int materialCount = _materialRepository.GetAll().Select(x => x.Name).ToList().Count();
            int machineProgramCount = _machineProgramRepository.GetAll().Select(x => x.Name).ToList().Count();

            if (machineCount > 0)
                lblTezgahSayisi.Text = "Tezgah Sayısı: " + machineCount.ToString();
            else
                lblTezgahSayisi.Text = "Tanımlı Tezgah Yok.";

            if (materialTypeCount > 0)
                lblMalzemeTuruSayisi.Text = "Malzeme Türü Sayısı: " + materialTypeCount.ToString();
            else
                lblMalzemeTuruSayisi.Text = "Tanımlı Malzeme Türü Yok.";

            if (materialShapeCount > 0)
                lblMalzemeSekliSayisi.Text = "Malzeme Şekli Sayısı: " + materialShapeCount.ToString();
            else
                lblMalzemeSekliSayisi.Text = "Tanımlı Malzeme Şekli Yok.";

            if (materialCount > 0)
                lblMalzemeSayisi.Text = "Malzeme Sayısı: " + materialCount.ToString();
            else
                lblMalzemeSayisi.Text = "Tanımlı Malzeme Yok.";

            if (machineProgramCount > 0)
                lblProgramSayisi.Text = "Kayıtlı Program Sayısı: " + machineProgramCount.ToString();
            else
                lblProgramSayisi.Text = "Kayıtlı Program Sayısı: 0";
        }

        private void btnProgramGuncelle_Click(object sender, EventArgs e)
        {
            if (dataListProgramDef.RowCount > 0)
            {
                editMode = true;
                DisableButtonAndText(1);

                if (listKod.Items.Count > 0)
                {
                    listKod.SelectedIndex = 1;
                    kodListIndex = 1;
                    txtKodSatir.Text = listKod.Items[kodListIndex].ToString();
                }
            }
            else
                MessageBox.Show("Güncellenecek kaydı seçin.", "Güncelleme Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKaydetTezgah_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnKaydetTezgah, "Tezgah Kaydet");
        }

        private void btnKaydetMalzemeTuru_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnKaydetMalzemeTuru, "Malzeme Türü Kaydet");
        }

        private void btnKaydetMalzemeSekli_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnKaydetMalzemeSekli, "Malzeme Şekli Kaydet");
        }

        private void btnKaydetMalzeme_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.SetToolTip(btnKaydetMalzeme, "Malzeme Kaydet");
        }

        private void CheckUserAuth(User u)
        {
            List<TabPage> hideTabPages = new List<TabPage>();
            List<int> hideTabPageNumbers = new List<int>();
            bool isAdminManager = false;

            if (this._user.IsAdmin)
                isAdminManager = true;
            else
                hideTabPageNumbers = new List<int> { 0, 1 };

            if (!isAdminManager)
            {
                foreach (int i in hideTabPageNumbers)
                {
                    hideTabPages.Add(tabControl1.TabPages[i]);
                }

                foreach (TabPage tabPage in hideTabPages)
                {
                    tabControl1.TabPages.Remove(tabPage);
                }
            }
        }

        private void txtMalzemeDelikCap_Enter(object sender, EventArgs e)
        {
            txtMalzemeDelikCap.Select(0, txtMalzemeDelikCap.Text.Length);
        }

        private void txtMalzemeDisCap_Enter(object sender, EventArgs e)
        {
            txtMalzemeDisCap.Select(0, txtMalzemeDisCap.Text.Length);
        }

        private void txtMalzemeBoy_Enter(object sender, EventArgs e)
        {
            txtMalzemeBoy.Select(0, txtMalzemeBoy.Text.Length);
        }

        private void txtMalzemeDelikCap_Leave(object sender, EventArgs e)
        {
            if (txtMalzemeDelikCap.Text.Length == 0)
                txtMalzemeDelikCap.Value = txtMalzemeDelikCap.Minimum;
        }

        private void listMalzemeSekli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnFormuKapat3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
