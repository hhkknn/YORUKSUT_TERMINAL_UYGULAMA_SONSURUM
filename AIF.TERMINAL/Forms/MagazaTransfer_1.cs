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
    public partial class MagazaTransfer_1 : form_Base
    {
        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font

        private string formName = "";
        public static bool formAciliyor = false;
        private DataGridViewCheckBoxColumn checkColumn = null;
        List<MagazaMalGirisCikis> magazaMalGirisCikis = new List<MagazaMalGirisCikis>();
        //List<SiparisKabulDetay> siparisKabulDetay = new List<SiparisKabulDetay>();
        public MagazaTransfer_1(string _formName)
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

            dtgMagazaTransfer.Font = new Font(dtgMagazaTransfer.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgMagazaTransfer.Font.Style);
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
        private void MagazaTransfer_1_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            vScrollBar1.Maximum = dtgMagazaTransfer.RowCount;

            dtgMagazaTransfer.RowTemplate.Height = 55;
            dtgMagazaTransfer.ColumnHeadersHeight = 60;

            formAciliyor = true;
            btnListele.PerformClick();
            formAciliyor = false;
        }
        private void GetTransfer()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response response = new Response();

            try
            {
                response = aIFTerminalServiceSoapClient.GetMagazaMalGirisCikis(Giris._dbName, dtpStartDate.Value.ToString("yyyyMMdd"), dtpEndDate.Value.ToString("yyyyMMdd"), Giris.mKodValue);

                if (response == null || response._list.Rows.Count == 0)
                {
                    dtgMagazaTransfer.DataSource = null;
                    dtgMagazaTransfer.Columns.RemoveAt(0);
                    formAciliyor = false;
                    CustomMsgBox.Show(response.Desc, "UYARI", "TAMAM", "");
                    return;
                }
                else if (response._list.Rows.Count > 0)
                {
                    dtgMagazaTransfer.DataSource = null;
                    dtgMagazaTransfer.DataSource = response._list;

                    if (dtgMagazaTransfer.Columns.Contains("ScmCheck") == true)
                    {
                        dtgMagazaTransfer.Columns.RemoveAt(0);
                    }
                    //dtgMagazaMalKabul.DataSource = dtPurchase; 

                    if (dtgMagazaTransfer.Columns.Contains("ScmCheck") != true)
                    {
                        Checkboxolustur();
                    }

                    dtgMagazaTransfer.Columns["belgeNo"].HeaderText = "BELGE NO";
                    dtgMagazaTransfer.Columns["tarih"].HeaderText = "BELGE TARİHİ";
                    dtgMagazaTransfer.Columns["girisMiCikisMi"].HeaderText = "İŞLEM TİPİ";
                    dtgMagazaTransfer.Columns["gondericiSube"].HeaderText = "GÖNDERİCİ ŞUBE";
                    dtgMagazaTransfer.Columns["fark"].HeaderText = "FARK";
                    dtgMagazaTransfer.Columns["aliciSube"].HeaderText = "ALICI ŞUBE";

                    dtgMagazaTransfer.Columns["fark"].Visible = false;
                    dtgMagazaTransfer.Columns["girisMiCikisMi"].Visible = false;
                    //dtgMagazaTransfer.Columns["tarih"].Visible = false;
                }

                dtgMagazaTransfer.RowTemplate.Height = 55;
                dtgMagazaTransfer.ColumnHeadersHeight = 60;
            }
            catch (Exception ex)
            {
                dtgMagazaTransfer.DataSource = null;
                dtgMagazaTransfer.Columns.RemoveAt(0);
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
            dtgMagazaTransfer.Columns.Add(checkColumn);

            dtgMagazaTransfer.RowHeadersVisible = false;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dtgMagazaTransfer.DataSource = null;
            //siparisKabuls = new List<MagazaMalGirisCikis>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            txtSearch.ReadOnly = false;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }
            GetTransfer();
        }

        private void dtgMagazaTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) //header tıklama
                {
                    return;
                }
                DataGridViewRow row = dtgMagazaTransfer.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];

                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    DateTime dtpSiparisTar = new DateTime();
                    dtpSiparisTar = Convert.ToDateTime(row.Cells["tarih"].Value); 
                    if (magazaMalGirisCikis.Count == 0)
                    { 
                        magazaMalGirisCikis.Add(new MagazaMalGirisCikis
                        {
                            belgeNo = Convert.ToInt32(row.Cells["belgeNo"].Value),
                            tarih = dtpSiparisTar,
                            girisMiCikisMi = "Mağaza Çıkış",
                            gondericiSube = row.Cells["gondericiSube"].Value.ToString(),
                            aliciSube = row.Cells["aliciSube"].Value.ToString(), 
                        });
                    }
                    else
                    {
                        string belgeNo = row.Cells["belgeNo"].Value.ToString();

                        //string vendor = dtPurchase.Rows[e.RowIndex]["Tedarikçi Kodu"].ToString();

                        if (belgeNo != magazaMalGirisCikis[0].belgeNo.ToString())
                        {
                            CustomMsgBox.Show("BİRDEN FAZLA .. SEÇİM YAPILAMAZ.", "Uyarı", "Tamam", "");
                            return;
                        }
                        else
                        {
                            magazaMalGirisCikis.Add(new MagazaMalGirisCikis
                            {
                                belgeNo = Convert.ToInt32(row.Cells["belgeNo"].Value),
                                tarih = dtpSiparisTar,
                                girisMiCikisMi = "Mağaza Çıkış",
                                gondericiSube = row.Cells["gondericiSube"].Value.ToString(),
                                aliciSube = row.Cells["aliciSube"].Value.ToString(),
                            });
                        }
                    }
                    chk.Value = chk.TrueValue;
                    dtgMagazaTransfer.EndEdit();
                    //setFormatGrid(dataGridView1, 15);
                }
                else
                {
                    chk.Value = chk.FalseValue;
                    magazaMalGirisCikis.RemoveAt(0);
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
                if (magazaMalGirisCikis.Count > 0)
                {
                    MagazaTransfer_2 magazaTransfer_2 = new MagazaTransfer_2(magazaMalGirisCikis,"MAĞAZA TRANSFER DETAY");
                    magazaTransfer_2.ShowDialog();
                    magazaTransfer_2.Dispose();
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

        private void dtgMagazaTransfer_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgMagazaTransfer.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }
}
