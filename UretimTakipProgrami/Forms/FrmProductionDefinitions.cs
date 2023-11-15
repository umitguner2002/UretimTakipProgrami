using FluentValidation.Results;
using System.Data;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Business.Validators;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmProductionDefinitions : Form
    {
        private MachineRepository _machineRepository;
        private MachineProgramRepository _machineProgramRepository;
        private MaterialTypeRepository _materialTypeRepository;
        private MaterialShapeRepository _materialShapeRepository;
        private MaterialRepository _materialRepository;

        private int groupIndex = 0;
        private int countIndex = 0;
        private int selectedIndex = 0;
        private int selectedIndex2 = 0;
        private int selectedIndex3 = 0;
        private int selectedIndex4 = 0;
        private int selectedIndex5 = 0;
        private bool editMode = false;
        private int kodListIndex = 0;

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
        }

        private void SetMachineDataGridSettings()
        {
            if (listTezgah.Rows.Count > 0)
            {
                listTezgah.Columns[0].HeaderText = "Tezgah / Makina Adı";
                listTezgah.Columns[0].Width = 250;
                listTezgah.Columns[1].Visible = false;
                listTezgah.Columns[2].HeaderText = "";
            }
        }

        private void SetOperatorDataGridSettings()
        {

        }

        private void MachineTextDoldur()
        {
            selectedIndex = listTezgah.CurrentCell.RowIndex;

            if (selectedIndex >= 0)
            {
                txtTezgahAdi.Text = listTezgah.Rows[selectedIndex].Cells[0].Value.ToString();
            }
        }

        private void OperatorTextDoldur()
        {

        }

        private void GetMachineList()
        {
            listTezgah.DataSource = null;
            List<object> filteredList = new List<object>();

            var machineList = _machineRepository.GetAll()
                .Select(cs => new
                {
                    cs.Name,
                    cs.Id,
                    emptyColumn = ""
                })
                .OrderBy(x => x.Name)
                .ToList();

            listTezgah.DataSource = machineList;

            if (countIndex == 0)
            {
                listTezgah.DataSource = machineList;
                listTezgah.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                countIndex = 1;
            }
            else
            {
                listTezgah.DataSource = machineList.OrderByDescending(x => x.Name).ToList();
                listTezgah.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                countIndex = 0;
            }

            SetMachineDataGridSettings();

            if (listTezgah.RowCount > 0)
            {
                selectedIndex = 0;
                listTezgah.Rows[selectedIndex].Selected = true;
                MachineTextDoldur();
            }

        }

        private void GetOperatorList()
        {

        }

        private void EnableButtonAndText(int _groupIndex)
        {
            if (_groupIndex == 0)
            {
                btnYeniTezgah.Enabled = true;
                btnDuzenleTezgah.Enabled = true;
                btnKaydetTezgah.Enabled = false;
                btnIptalTezgah.Enabled = false;
                btnSilTezgah.Enabled = true;
                txtTezgahAdi.Enabled = false;

                GetMachineList();
            }
            else if (_groupIndex == 1)
            {
                btnYeniMalzeme.Enabled = true;
                btnDuzenleMalzeme.Enabled = true;
                btnKaydetMalzeme.Enabled = false;
                btnIptalMalzeme.Enabled = false;
                btnSilMalzeme.Enabled = true;

                listMalzemeTuru.Enabled = false;
                listMalzemeSekli.Enabled = false;
                txtMalzemeBoy.Enabled = false;
                txtMalzemeDisCap.Enabled = false;
                txtMalzemeDelikCap.Enabled = false;
            }
            else if (_groupIndex == 2)
            {
                btnYeniProgram.Enabled = true;
                btnProgramGuncelle.Enabled = true;
                btnProgramKaydet.Enabled = false;
                btnProgramIptal.Enabled = false;
                btnProgramSil.Enabled = true;
                btnProgramEkle.Enabled = false;
                txtProgramKodu.Enabled = false;
                txtProgramAdi.Enabled = false;

                txtProgramKodu.Clear();
                txtProgramAdi.Clear();
                txtKodSatir.Clear();
                listKod.Items.Clear();

                //listKod.Enabled = false;
                txtKodSatir.Enabled = false;
                btnKodDeğiştir.Enabled = false;
            }
        }

        private void DisableButtonAndText(int _groupIndex)
        {
            if (_groupIndex == 0)
            {
                btnYeniTezgah.Enabled = false;
                btnDuzenleTezgah.Enabled = false;
                btnKaydetTezgah.Enabled = true;
                btnIptalTezgah.Enabled = true;
                btnSilTezgah.Enabled = false;
                txtTezgahAdi.Enabled = true;
            }
            else if (_groupIndex == 1)
            {
                btnYeniMalzeme.Enabled = false;
                btnDuzenleMalzeme.Enabled = false;
                btnKaydetMalzeme.Enabled = true;
                btnIptalMalzeme.Enabled = true;
                btnSilMalzeme.Enabled = false;

                listMalzemeTuru.Enabled = true;
                listMalzemeSekli.Enabled = true;
                txtMalzemeBoy.Enabled = true;
                txtMalzemeDisCap.Enabled = true;
                txtMalzemeDelikCap.Enabled = true;

                listMalzemeTuru.Text = "";
            }
            else if (_groupIndex == 2)
            {
                btnYeniProgram.Enabled = false;
                btnProgramGuncelle.Enabled = false;
                btnProgramKaydet.Enabled = true;
                btnProgramIptal.Enabled = true;
                btnProgramSil.Enabled = false;
                btnProgramEkle.Enabled = true;
                txtProgramKodu.Enabled = true;
                txtProgramAdi.Enabled = true;

                //listKod.Enabled = true;
                txtKodSatir.Enabled = true;
                btnKodDeğiştir.Enabled = true;
            }

        }

        private void ClearText()
        {
            txtTezgahAdi.Clear();
        }

        private void btnYeniTezgah_Click(object sender, EventArgs e)
        {
            DisableButtonAndText(groupIndex = 0);
            txtTezgahAdi.Focus();
        }

        private void btnYeniOperator_Click(object sender, EventArgs e)
        {
            DisableButtonAndText(groupIndex = 1);
        }

        private void btnIptalTezgah_Click(object sender, EventArgs e)
        {
            txtTezgahAdi.Clear();
            EnableButtonAndText(groupIndex = 0);
        }

        private async void btnKaydetOperator_Click(object sender, EventArgs e)
        {
            /*
            bool editStatus = false;

            Entity.Entities.Operator op = new Entity.Entities.Operator
            {
                Name = txtOperatorAdi.Text.ToUpper()
            };

            OperatorValidator operatorValidation = new OperatorValidator();
            ValidationResult result = operatorValidation.Validate(op);
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
                await _operatorRepository.AddAsync(new()
                {
                    Name = txtOperatorAdi.Text.ToUpper()
                    //CreatedDate = DateTime.UtcNow,
                    //IsDeleted = false
                });
            }
            else
            {
                editStatus = _operatorRepository.Update(new()
                {
                    Id = Guid.Parse(listOperator.Rows[selectedIndex].Cells[1].Value.ToString()),
                    Name = txtOperatorAdi.Text.ToUpper()
                });
            }

            await _operatorRepository.SaveAsync();
            EnableButtonAndText(1);
            GetOperatorList();
            editMode = false;

            */
        }

        private void btnDuzenleTezgah_Click(object sender, EventArgs e)
        {
            if (selectedIndex > -1)
            {
                editMode = true;
                DisableButtonAndText(0);
            }
            else
                MessageBox.Show("Listeden Bir Tezgah / Makina Seçiniz.");
        }

        private void FrmMachineOperator_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            listMalzemeTuru.Items.AddRange(new string[] { "DOLU", "DELİKLİ", "BOYDAN" });
            GetMachineList();
            GetOperatorList();
        }

        private void listTezgah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MachineTextDoldur();
        }

        private void listOperator_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OperatorTextDoldur();
        }

        private void listTezgah_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetMachineList();
        }

        private void listOperator_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetOperatorList();
        }

        private void btnDuzenleOperator_Click(object sender, EventArgs e)
        {
            if (selectedIndex > -1)
            {
                editMode = true;
                DisableButtonAndText(1);
            }
            else
                MessageBox.Show("Listeden Bir Operatör Seçiniz.");
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
        }

        private void btnProgramEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // İletişim kutusunun başlık ve filtre ayarlarını yapın
            openFileDialog.Title = "Dosya Seç";
            openFileDialog.Filter = "Tüm Dosyalar|*.*";



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                // Kopyalanacak hedef klasörü belirleyin
                //string hedefKlasor = @"C:\Users\umitg\Desktop\deneme";

                //string dosyaAdi = Path.Combine(hedefKlasor, Path.GetFileName(dosyaYolu));

                //string hedefDosyaYolu = Path.Combine(hedefKlasor, dosyaAdi);

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
                /*
                if (File.Exists(dosyaAdi))
                {
                    DialogResult cvp = MessageBox.Show("Dosya var silmek istiyor musun", "Dosya Mevcut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cvp == DialogResult.Yes)
                    {
                        File.Delete(dosyaAdi);
                        File.Copy(openFileDialog.FileName, hedefDosyaYolu);
                    }
                }
                else
                    File.Copy(openFileDialog.FileName, hedefDosyaYolu);
                */
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
            if (kodListIndex > -1 && listKod.SelectedItem.ToString() != "")
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
            DisableButtonAndText(groupIndex = 2);
            txtProgramKodu.Focus();
        }

        private void btnProgramIptal_Click(object sender, EventArgs e)
        {
            EnableButtonAndText(groupIndex = 2);
        }

        private async void btnProgramKaydet_Click(object sender, EventArgs e)
        {
            bool editStatus = false;

            MachineProgram mp = new MachineProgram
            {
                Code = txtProgramKodu.Text,
                Name = txtProgramAdi.Text.ToUpper()
            };

            MachineProgramValidator machineProgramValidation = new MachineProgramValidator();
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
                }
                else
                {
                    editStatus = _machineProgramRepository.Update(new()
                    {
                        Id = Guid.Parse(dataListProgramDef.Rows[selectedIndex3].Cells[1].Value.ToString()),
                        Code = txtProgramKodu.Text,
                        Name = txtProgramAdi.Text.ToUpper()
                    });
                }

                await _machineProgramRepository.SaveAsync();

                //GetMachineList();
                editMode = false;

                EnableButtonAndText(groupIndex = 2);
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
                //lblKayitSayisi.Text = $"Kayıt Sayısı: {orderList.Count.ToString()}";
            }

        }

        private List<object> GetProgramList(string arananProgram)
        {
            var programList = _machineProgramRepository.GetAll()
                .Select(program => new
                {
                    program.Code,
                    program.Name,
                    program.Id,
                    program.Path
                })
                .Where(prg =>
                    (string.IsNullOrEmpty(arananProgram) || prg.Name.ToLower().Contains(arananProgram.ToLower())))
                .OrderBy(prg => prg.Name)
                .ToList();

            return programList.Cast<object>().ToList();

        }

        private void SetDataListProgramGridSettings()
        {
            if (dataListProgramDef.Rows.Count > 0)
            {
                dataListProgramDef.Columns[0].HeaderText = "Program Kodu";
                dataListProgramDef.Columns[0].Width = 65;
                dataListProgramDef.Columns[1].HeaderText = "Program Adı";
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
                string malzemeAdi = $"{listMalzemeTuru.Text}";
                malzemeAdi += listMalzemeSekli.Text !="" ? $" {listMalzemeSekli.Text}" : "";
                malzemeAdi += txtMalzemeBoy.Value > 0 ? $"_BOY={txtMalzemeBoy.Value.ToString()}" : "";
                malzemeAdi += txtMalzemeDisCap.Value > 0 ? $"_DIŞ={txtMalzemeDisCap.Value.ToString()}" : "";
                malzemeAdi += txtMalzemeDelikCap.Value > 0 ? $"_İÇ={txtMalzemeDelikCap.Value.ToString()}" : "";

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
            bool editStatus = false;

            if (!editMode)
            {
                await _materialRepository.AddAsync(new()
                {
                    Name = txtMalzemeAdi.Text.ToUpper(),
                    Length = Convert.ToInt32(txtMalzemeBoy.Value),
                    OuterDiameter = Convert.ToInt32(txtMalzemeDisCap.Value),
                    HoleDiameter = Convert.ToInt32(txtMalzemeDisCap.Value),
                    MaterialTypeId = Guid.Parse(listMalzemeTuru.SelectedValue.ToString()),
                    MaterialShapeId = Guid.Parse(listMalzemeSekli.SelectedValue.ToString())
                });
            }
            else
            {
                /*
                editStatus = _machineRepository.Update(new()
                {
                    Id = Guid.Parse(listTezgah.Rows[selectedIndex].Cells[1].Value.ToString()),
                    Name = txtTezgahAdi.Text.ToUpper()
                });
                */
            }

            await _materialRepository.SaveAsync();
            EnableButtonAndText(1);

            editMode = false;
        }

        private async void btnKaydetTezgah_Click(object sender, EventArgs e)
        {
            bool editStatus = false;

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

            if (!editMode)
            {
                await _machineRepository.AddAsync(new()
                {
                    Name = txtTezgahAdi.Text.ToUpper()
                    //CreatedDate = DateTime.UtcNow,
                    //IsDeleted = false
                });
            }
            else
            {
                editStatus = _machineRepository.Update(new()
                {
                    Id = Guid.Parse(listTezgah.Rows[selectedIndex].Cells[1].Value.ToString()),
                    Name = txtTezgahAdi.Text.ToUpper()
                });
            }

            await _machineRepository.SaveAsync();
            EnableButtonAndText(0);
            GetMachineList();
            editMode = false;
        }

        private void btnYeniMalzeme_Click(object sender, EventArgs e)
        {
            DisableButtonAndText(groupIndex = 1);
        }

        private void listMalzemeTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDuzenleMalzeme_Click(object sender, EventArgs e)
        {

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
            btnFormuKapat3.Visible = false;
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
    }
}
