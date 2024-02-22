using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class PaletYapma_1 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public PaletYapma_1(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //initialFontSize = dtpStartDate.Font.Size;
            //dtpStartDate.Resize += Form_Resize;

            //initialFontSize = dtpEndDate.Font.Size;
            //dtpEndDate.Resize += Form_Resize;

            //initialFontSize = txtSearch.Font.Size;
            //txtSearch.Resize += Form_Resize;

            initialFontSize = btnListele.Font.Size;
            btnListele.Resize += Form_Resize;

            initialFontSize = btnPaletDetay.Font.Size;
            btnPaletDetay.Resize += Form_Resize;

            initialFontSize = dtgPaletListesi.Font.Size;
            dtgPaletListesi.Resize += Form_Resize;
            //end font

            formName = _formName;

            PaletleriListele();

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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            btnListele.Font = new Font(btnListele.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListele.Font.Style);

            btnPaletDetay.Font = new Font(btnPaletDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPaletDetay.Font.Style);

            dtgPaletListesi.Font = new Font(dtgPaletListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgPaletListesi.Font.Style);

            btnOtomatikPaletNo.Font = new Font(btnOtomatikPaletNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOtomatikPaletNo.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            cmbPasifler.Font = new Font(cmbPasifler.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPasifler.Font.Style);

            btnPaletTransfer.Font = new Font(btnPaletTransfer.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPaletTransfer.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtPaletNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbPasifler.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        //declares
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
        IntPtr hWnd, // handle to destination window
        Int32 msg, // message
        Int32 wParam, // first message parameter
        Int32 lParam // second message parameter
        );

        private const Int32 WM_LBUTTONDOWN = 0x0201;

        //
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

        private string formName = "";
        private DataTable dtPaletYapmaListesi = new DataTable();
        private int selectedRow = -1;
        private string _paletNo = "";

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaletNo.Focus();

                string paletNo = txtPaletNo.Text;

                if (dtPaletYapmaListesi.AsEnumerable().Where(x => x.Field<string>("PaletNo") == paletNo).Count() > 0)
                {
                    _paletNo = paletNo;
                    btnPaletDetay.PerformClick();
                    _paletNo = "";
                }
                else
                {
                    PaletYapma_2 paletYapma_2 = new PaletYapma_2("PALET LİSTESİ DETAY", paletNo);
                    paletYapma_2.ShowDialog();
                    paletYapma_2.Dispose();
                    GC.Collect();

                    if (PaletYapma_2.kayitYapildi)
                    {
                        btnListele.PerformClick();
                        PaletYapma_2.kayitYapildi = false;
                    }

                    if (dtgPaletListesi.Rows.Count > 0)
                    {
                        dtgPaletListesi.Rows[0].Selected = false;
                    }

                    txtPaletNo.Text = "";
                }
            }
        }

        private void PaletleriListele()
        {
            ComboboxItem aa = (ComboboxItem)cmbPasifler.SelectedItem;
            string aktifpasif = "";
            if (aa != null)
            {
                aktifpasif = aa.Value.ToString() == "Y" ? "Y" : "N";
            }
            else
            {
                aktifpasif = "N";
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getPaletYapmaListesi(Giris._dbName, aktifpasif, Giris.mKodValue);

            if (resp._list != null)
            {
                dtPaletYapmaListesi = resp._list;
                dtgPaletListesi.DataSource = null;

                dtgPaletListesi.DataSource = dtPaletYapmaListesi;

                dtgPaletListesi.RowTemplate.Height = 55;
                dtgPaletListesi.ColumnHeadersHeight = 60;

                dtgPaletListesi.Columns["PaletNo"].HeaderText = "Palet No";
            }
            else
            {
                dtgPaletListesi.DataSource = null;
            }

            vScrollBar1.Maximum = dtgPaletListesi.RowCount + 5;
        }

        private void PaletYapma_Load(object sender, EventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = "GÖSTER";
            item.Value = "Y";

            cmbPasifler.Items.Add(item);

            item = new ComboboxItem();
            item.Text = "GÖSTERME";
            item.Value = "N";

            cmbPasifler.Items.Add(item);

            cmbPasifler.SelectedIndex = 1;

            frmName.Text = formName;

            if (dtgPaletListesi.Rows.Count > 0)
            {
                dtgPaletListesi.Rows[0].Selected = false;

                dtgPaletListesi.Columns[0].HeaderText = "Palet No";

            }

            dtgPaletListesi.RowTemplate.Height = 55;
            dtgPaletListesi.ColumnHeadersHeight = 60;
        }

        private void dtgPaletListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                selectedRow = -1;
                return;
            }
            else
            {
                selectedRow = e.RowIndex;
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            PaletleriListele();

            if (dtgPaletListesi.Rows.Count > 0)
            {
                dtgPaletListesi.Rows[0].Selected = false;

            }
        }

        private void btnPaletDetay_Click(object sender, EventArgs e)
        {
            string paletNo = "";

            if (_paletNo != "")
            {
                paletNo = _paletNo;
            }
            else
            {
                if (selectedRow == -1)
                {
                    CustomMsgBox.Show("SATIR SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                paletNo = dtgPaletListesi.Rows[selectedRow].Cells[0].Value.ToString();
            }

            PaletYapma_2 paletYapma_2 = new PaletYapma_2("PALET LİSTESİ DETAY", paletNo);
            paletYapma_2.ShowDialog();
            paletYapma_2.Dispose();
            GC.Collect();

            if (PaletYapma_2.kayitYapildi)
            {
                btnListele.PerformClick();
                PaletYapma_2.kayitYapildi = false;
            }

            if (dtgPaletListesi.Rows.Count > 0)
            {
                dtgPaletListesi.Rows[0].Selected = false;
            }

            txtPaletNo.Text = "";
        }

        private bool doubleclick = false;

        private void dtgPaletListesi_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
            btnPaletDetay.PerformClick();
            doubleclick = false;
        }

        private void btnOtomatikPaletNo_Click(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetPaletNumarasiGetir(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                int siradakiNo = Convert.ToInt32(resp._list.Rows[0]["U_SiradakiNo"]);
                int docEntry = Convert.ToInt32(resp._list.Rows[0]["DocEntry"]);

                txtPaletNo.Text = siradakiNo.ToString();

                resp = aIFTerminalServiceSoapClient.UpdatePaletNumarasi(Giris._dbName, docEntry, siradakiNo, Giris.mKodValue);

                if (resp.Val != 0)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                }

                PaletYapma_2 paletYapma_2 = new PaletYapma_2("PALET LİSTESİ DETAY", txtPaletNo.Text);
                paletYapma_2.ShowDialog();
                paletYapma_2.Dispose();
                GC.Collect();

                if (PaletYapma_2.kayitYapildi)
                {
                    btnListele.PerformClick();
                    PaletYapma_2.kayitYapildi = false;
                }

                if (dtgPaletListesi.Rows.Count > 0)
                {
                    dtgPaletListesi.Rows[0].Selected = false;
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
            }
        }

        private void dtgPaletListesi_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                vScrollBar1.Value = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgPaletListesi.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnPaletTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                string paletNo = "";

                if (_paletNo != "")
                {
                    paletNo = _paletNo;
                }
                else
                {
                    if (selectedRow == -1)
                    {
                        CustomMsgBox.Show("SATIR SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    paletNo = dtgPaletListesi.Rows[selectedRow].Cells[0].Value.ToString();
                }

                #region palet detayları
                DataTable dtPaletDetay = new DataTable();
                DataTable dtPaletParti = new DataTable();

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                resp = aIFTerminalServiceSoapClient.getPaletYapmaListesiDetaylari(Giris._dbName, paletNo, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                if (resp._list != null && resp._list.Rows.Count > 0)
                {
                    dtPaletDetay = resp._list;

                    #region palet partileri
                    resp = aIFTerminalServiceSoapClient.GetPaletYapmaListesiParti(Giris._dbName, paletNo, Giris.mKodValue);

                    if (resp._list != null && resp._list.Rows.Count > 0)
                    {
                        dtPaletParti = resp._list;

                        PaletYapma_2 paletYapma_2 = new PaletYapma_2("PALET TRANSFER", paletNo);
                        paletYapma_2.ShowDialog();
                        paletYapma_2.Dispose();
                        GC.Collect();
                    }
                    else
                    {
                        dtPaletParti = null;
                    }
                    #endregion
                }
                else
                {
                    dtPaletDetay = null;
                }
                #endregion



            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("Hata oluştu."+ex.Message, "Uyarı", "TAMAM", ""); 
            }
        } 
    }
}