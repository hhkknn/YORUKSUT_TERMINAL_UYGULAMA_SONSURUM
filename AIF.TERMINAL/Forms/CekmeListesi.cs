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
    public partial class CekmeListesi : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public CekmeListesi(string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = label4.Font.Size;
            label4.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //initialFontSize = dtpStartDate.Font.Size;
            //dtpStartDate.Resize += Form_Resize;

            //initialFontSize = dtpEndDate.Font.Size;
            //dtpEndDate.Resize += Form_Resize;

            //initialFontSize = txtSearch.Font.Size;
            //txtSearch.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = dtgCekmeListesi.Font.Size;
            dtgCekmeListesi.Resize += Form_Resize;
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

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            dtgCekmeListesi.Font = new Font(dtgCekmeListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgCekmeListesi.Font.Style);

            btnToplamaListesi.Font = new Font(btnToplamaListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnToplamaListesi.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            dtpStartDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpEndDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtSearch.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        public static bool formAciliyor = false;

        private void CekmeListesi_Load(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = true;
            //dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpStartDate.Value = DateTime.Now.AddYears(-1);
            vScrollBar1.Maximum = dtgCekmeListesi.RowCount;

            dtgCekmeListesi.RowTemplate.Height = 55;

            formAciliyor = true;
            button1.PerformClick();
            formAciliyor = false;
            frmName.Text = formName.ToUpper();

            if (dtgCekmeListesi.Rows.Count > 0)
            {
                txtSearch.Focus();
            }
        }

        public static string dialogresult = "";
        private int selectedRow = -1;

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRow > -1)
            {
                if (txtTur.Text == "CekmeListesi")
                {
                    CekmeListesi_2.cekmeListesiOnaylamaKoliDetays = new List<CekmeListesiOnaylamaKoliDetay>();

                    string belgeNo = dtCekmeListesi.Rows[selectedRow]["DocEntry"].ToString();
                    string musteriKodu = dtCekmeListesi.Rows[selectedRow]["U_MusteriKodu"].ToString();
                    string musteriAdi = dtCekmeListesi.Rows[selectedRow]["U_MusteriAdi"].ToString();

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = aIFTerminalServiceSoapClient.getCekmeListesiDetaylari(Giris._dbName, belgeNo, Giris.mKodValue, Giris.genelParametreler.CekmeListesiKalemleriniGrupla);

                    if (resp._list == null)
                    {
                        CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                        if (dtgCekmeListesi.Rows.Count > 0)
                        {
                            dtgCekmeListesi.Rows[selectedRow].Selected = false;
                        }
                    }
                    else
                    {
                        CekmeListesi_2 cekmeListesi_2 = new CekmeListesi_2("ÇEKME LİSTESİ ONAY", belgeNo, musteriKodu, musteriAdi);
                        cekmeListesi_2.ShowDialog();
                        cekmeListesi_2.Dispose();
                        GC.Collect();

                        if (dtgCekmeListesi.Rows.Count > 0)
                        {
                            dtgCekmeListesi.Rows[selectedRow].Selected = false;
                        }

                        selectedRow = -1;
                    }
                }
                else if (txtTur.Text == "ToplamaListesi")
                {
                    string belgeNo = dtCekmeListesi.Rows[selectedRow]["U_BelgeNo"].ToString();
                    string musteriKodu = dtCekmeListesi.Rows[selectedRow]["MusteriKodu"].ToString();
                    string musteriAdi = dtCekmeListesi.Rows[selectedRow]["MusteriAdi"].ToString();

                    CekmeListesiToplanan cekmeListesiToplanan = new CekmeListesiToplanan("TOPLANAN LİSTE", belgeNo, musteriKodu, musteriAdi);
                    cekmeListesiToplanan.ShowDialog();
                    cekmeListesiToplanan.Dispose();
                    GC.Collect();
                }
            }
        }

        private List<CekmeListesi> cekmeListesis = new List<CekmeListesi>();
        private string dbName = "";
        private DataTable dtCekmeListesi = new DataTable();

        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.Text = "ÇEKME LİSTESİNE GİT";
            dtgCekmeListesi.DataSource = null;
            cekmeListesis = new List<CekmeListesi>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            txtSearch.ReadOnly = false;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getCekmeListesi(Giris._dbName, startDate, endDate, Giris.mKodValue);

            if (resp._list != null)
            {
                dtCekmeListesi = resp._list;
                dtgCekmeListesi.DataSource = null;

                dtgCekmeListesi.DataSource = dtCekmeListesi;

                dtgCekmeListesi.RowTemplate.Height = 55;
                dtgCekmeListesi.ColumnHeadersHeight = 60;

                dtgCekmeListesi.Columns["DocEntry"].HeaderText = "BELGE NO";
                dtgCekmeListesi.Columns["U_MusteriKodu"].HeaderText = "MÜŞTERİ KODU";
                dtgCekmeListesi.Columns["U_MusteriAdi"].HeaderText = "MÜŞTERİ ADI";
                dtgCekmeListesi.Columns["U_Aciklama"].HeaderText = "AÇIKLAMA";
            }
            else
            {
                dtgCekmeListesi.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgCekmeListesi.Columns.Count > 0)
                {
                    dtgCekmeListesi.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgCekmeListesi.RowCount;

            foreach (DataGridViewColumn column in dtgCekmeListesi.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgCekmeListesi.Rows.Count > 0)
            {
                dtgCekmeListesi.Rows[0].Selected = false;

                dtgCekmeListesi.Columns["SatirSayisi"].Visible = false;
            }

            txtTur.Text = "CekmeListesi";
        }

        private void dtgCekmeListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                return;
            }
            else
            {
                selectedRow = e.RowIndex;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtpStartDate_DropDown(object sender, EventArgs e)
        {
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dtpStartDate_Leave(object sender, EventArgs e)
        {
        }

        private void dtpEndDate_Leave(object sender, EventArgs e)
        {
        }

        private void dtgPurchaseOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgPurchaseOrders_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgCekmeListesi.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomMonthCalendar customMonthCalendar = new CustomMonthCalendar();
            customMonthCalendar.ShowDialog();
            customMonthCalendar.Dispose();
            GC.Collect();
        }

        private void dtgPurchaseOrders_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dtgCekmeListesi_DoubleClick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void btnToplamaListesi_Click(object sender, EventArgs e)
        {
            txtTur.Text = "ToplamaListesi";
            button2.Text = "TOPLAMA LİSTESİNE GİT";
            dtgCekmeListesi.DataSource = null;
            cekmeListesis = new List<CekmeListesi>();
            string startDate = dtpStartDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");

            txtSearch.ReadOnly = false;

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                CustomMsgBox.Show("BAŞLANGIÇ TARİHİ, BİTİŞ TARİHİNDEN BÜYÜK OLAMAZ.", "Uyarı", "Tamam", "");
                dtpStartDate.Focus();
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getToplamaListesi(Giris._dbName, startDate, endDate, Giris.mKodValue);

            if (resp._list != null)
            {
                dtCekmeListesi = resp._list;
                dtgCekmeListesi.DataSource = null;

                dtgCekmeListesi.DataSource = dtCekmeListesi;

                dtgCekmeListesi.RowTemplate.Height = 55;
                dtgCekmeListesi.ColumnHeadersHeight = 60;

                dtgCekmeListesi.Columns["U_BelgeNo"].HeaderText = "BELGE NO";
                dtgCekmeListesi.Columns["MusteriKodu"].HeaderText = "MÜŞTERİ KODU";
                dtgCekmeListesi.Columns["MusteriAdi"].HeaderText = "MÜŞTERİ ADI";
                dtgCekmeListesi.Columns["U_Aciklama"].HeaderText = "AÇIKLAMA";

                //dtgCekmeListesi.Columns["TeslimatTarihi"].Visible = false;
                dtgCekmeListesi.Columns["KonteynerVarmi"].Visible = false;
            }
            else
            {
                dtgCekmeListesi.DataSource = null;

                if (!formAciliyor)
                {
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");

                    return;
                }

                if (dtgCekmeListesi.Columns.Count > 0)
                {
                    dtgCekmeListesi.Columns.RemoveAt(0);
                }

                formAciliyor = false;
            }
            vScrollBar1.Maximum = dtgCekmeListesi.RowCount;

            foreach (DataGridViewColumn column in dtgCekmeListesi.Columns) //columns tıklayınca girişe atma
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgCekmeListesi.Rows.Count > 0)
            {
                dtgCekmeListesi.Rows[0].Selected = false;
            }
        }
    }
}