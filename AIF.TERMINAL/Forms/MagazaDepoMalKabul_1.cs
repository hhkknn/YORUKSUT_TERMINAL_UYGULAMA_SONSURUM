using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class MagazaDepoMalKabul_1 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        private string formName = "";
        public static bool formAciliyor = false;
        private DataGridViewCheckBoxColumn checkColumn = null;
        List<SiparisKabul> siparisKabuls = new List<SiparisKabul>();
        List<SiparisKabulDetay> siparisKabulDetay = new List<SiparisKabulDetay>();
        public MagazaDepoMalKabul_1(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;
            //end font

            formName = _formName;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label4.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtpStartDate.Font = new Font(dtpStartDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpStartDate.Font.Style);

            dtpEndDate.Font = new Font(dtpEndDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpEndDate.Font.Style);

            txtSearch.Font = new Font(txtSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSearch.Font.Style);

            btnListele.Font = new Font(btnListele.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListele.Font.Style);

            btnSipariseGit.Font = new Font(btnSipariseGit.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSipariseGit.Font.Style);

            dtgMagazaMalKabul.Font = new Font(dtgMagazaMalKabul.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgMagazaMalKabul.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        private void MagazaDepoMalKabul_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgMagazaMalKabul.RowCount;

            dtgMagazaMalKabul.RowTemplate.Height = 55;
            dtgMagazaMalKabul.ColumnHeadersHeight = 60;

            formAciliyor = true;
            btnListele.PerformClick();
            formAciliyor = false;
        }
        private void GetSiparis()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response response = new Response();
            string baslangic = dtpStartDate.Value.ToString("yyyyMMdd");
            string bitis = dtpEndDate.Value.ToString("yyyyMMdd");
            try
            {
                response = aIFTerminalServiceSoapClient.GetMagazaSiparis(Giris._dbName, SubeSecim.subeId, chkKapaliListele.Checked == true ? "Y" : "N",baslangic,bitis, Giris.mKodValue);

                if (response == null || response._list == null || response._list.Rows.Count == 0)
                {
                    if (dtgMagazaMalKabul.RowCount > 0)
                    {
                        dtgMagazaMalKabul.DataSource = null;
                        dtgMagazaMalKabul.Columns.RemoveAt(0);
                    }
                    formAciliyor = false;
                    CustomMsgBox.Show(response.Desc, "UYARI", "TAMAM", "");
                    return;
                }
                else if (response._list.Rows.Count > 0)
                {
                    dtgMagazaMalKabul.DataSource = null;
                    dtgMagazaMalKabul.DataSource = response._list;

                    if (dtgMagazaMalKabul.Columns.Contains("ScmCheck") == true)
                    {
                        dtgMagazaMalKabul.Columns.RemoveAt(0);
                    }
                    //dtgMagazaMalKabul.DataSource = dtPurchase; 

                    if (dtgMagazaMalKabul.Columns.Contains("ScmCheck") != true)
                    {
                        Checkboxolustur();
                    }

                    dtgMagazaMalKabul.Columns["magaza"].HeaderText = "MAĞAZA";
                    dtgMagazaMalKabul.Columns["tarih"].HeaderText = "SİPARİŞ TARİHİ";
                    dtgMagazaMalKabul.Columns["durum"].HeaderText = "BELGE DURUMU";
                    dtgMagazaMalKabul.Columns["siparisRefNo"].HeaderText = "SİPARİŞ REF.NO";
                    dtgMagazaMalKabul.Columns["terminTarihi"].HeaderText = "TERMİN TARİHİ";

                    dtgMagazaMalKabul.Columns["subeId"].Visible = false;
                    dtgMagazaMalKabul.Columns["durumNo"].Visible = false;
                    dtgMagazaMalKabul.Columns["magaza"].Visible = false;
                    dtgMagazaMalKabul.Columns["durum"].Visible = false;
                }

                dtgMagazaMalKabul.RowTemplate.Height = 55;
                dtgMagazaMalKabul.ColumnHeadersHeight = 60;
            }
            catch (Exception ex)
            {
                if (dtgMagazaMalKabul.RowCount > 0)
                {
                    dtgMagazaMalKabul.DataSource = null;
                    dtgMagazaMalKabul.Columns.RemoveAt(0);
                }
                formAciliyor = false;

                CustomMsgBox.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM", "");
            }
        }

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.HeaderText = "SEÇ";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dtgMagazaMalKabul.Columns.Add(checkColumn);

            dtgMagazaMalKabul.RowHeadersVisible = false;
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            dtgMagazaMalKabul.DataSource = null;
            siparisKabuls = new List<SiparisKabul>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            txtSearch.ReadOnly = false;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }
            GetSiparis();
        }

        private void chkKapaliListele_CheckedChanged(object sender, EventArgs e)
        {
            dtgMagazaMalKabul.DataSource = null;
            siparisKabuls = new List<SiparisKabul>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            GetSiparis();
        }

        private void dtgMagazaMalKabul_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) //header tıklama
                {
                    return;
                }
                DataGridViewRow row = dtgMagazaMalKabul.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    DateTime dtpSiparisTar = new DateTime();
                    dtpSiparisTar = Convert.ToDateTime(row.Cells["tarih"].Value);
                    //DateTime dtpSiparisTar = DateTime.ParseExact(row.Cells["tarih"].Value.ToString(), "dd/MM/yyyy", null);
                    DateTime dtpTerminTar = new DateTime();
                    dtpTerminTar = Convert.ToDateTime(row.Cells["terminTarihi"].Value);
                    if (siparisKabuls.Count == 0)
                    {
                        siparisKabuls.Add(new SiparisKabul
                        {
                            magaza = row.Cells["magaza"].Value.ToString(),
                            siparisRefNo = row.Cells["siparisRefNo"].Value.ToString(),
                            siparisTarihi = dtpSiparisTar,
                            terminTarihi = dtpTerminTar,
                            subeId = row.Cells["subeId"].Value.ToString(),
                            durum = row.Cells["durum"].Value.ToString(),
                            durumNo = row.Cells["durumNo"].Value.ToString(),
                        });
                    }
                    else
                    {
                        string refno = row.Cells["siparisRefNo"].Value.ToString();

                        //string vendor = dtPurchase.Rows[e.RowIndex]["Tedarikçi Kodu"].ToString();

                        if (refno != siparisKabuls[0].siparisRefNo)
                        {
                            CustomMsgBox.Show("BİRDEN FAZLA .. SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                            return;
                        }
                        else
                        {
                            siparisKabuls.Add(new SiparisKabul
                            {
                                magaza = row.Cells["magaza"].Value.ToString(),
                                siparisRefNo = row.Cells["siparisRefNo"].Value.ToString(),
                                siparisTarihi = dtpSiparisTar,
                                terminTarihi = dtpTerminTar,
                                subeId = row.Cells["subeId"].Value.ToString(),
                                durum = row.Cells["durum"].Value.ToString(),
                                durumNo = row.Cells["durumNo"].Value.ToString(),
                            });
                        }
                    }
                    chk.Value = chk.TrueValue;
                    dtgMagazaMalKabul.EndEdit();
                    //setFormatGrid(dataGridView1, 15);
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    siparisKabuls.RemoveAt(0);
                }

            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "Uyarı", "Tamam", "");
                return;
            }
        }

        private void btnSipariseGit_Click(object sender, EventArgs e)
        {
            try
            {
                if (siparisKabuls.Count > 0)
                {
                    MagazaDepoMalKabul_2 magazaDepoKabulDetayEkrani = new MagazaDepoMalKabul_2(siparisKabuls, "MAĞAZA DEPO KABUL DETAY");
                    magazaDepoKabulDetayEkrani.ShowDialog();
                    magazaDepoKabulDetayEkrani.Dispose();
                    GC.Collect();
                    txtSearch.Text = "";
                    btnListele.PerformClick();
                    //this.Hide();
                }
                else
                {
                    CustomMsgBox.Show("SİPARİŞ SEÇİLMEDEN SİPARİŞE GİDİLEMEZ.", "Uyarı", "Tamam", "");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");

            }
        }

        private void dtgMagazaMalKabul_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgMagazaMalKabul.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}
