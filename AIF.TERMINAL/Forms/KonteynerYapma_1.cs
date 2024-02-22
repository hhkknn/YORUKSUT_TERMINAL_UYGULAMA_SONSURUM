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
    public partial class KonteynerYapma_1 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public KonteynerYapma_1(string _formName)
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

            initialFontSize = btnKonteynerDetay.Font.Size;
            btnKonteynerDetay.Resize += Form_Resize;

            initialFontSize = dtgKonteynerListesi.Font.Size;
            dtgKonteynerListesi.Resize += Form_Resize;
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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            btnListele.Font = new Font(btnListele.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnListele.Font.Style);

            btnKonteynerDetay.Font = new Font(btnKonteynerDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKonteynerDetay.Font.Style);

            dtgKonteynerListesi.Font = new Font(dtgKonteynerListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgKonteynerListesi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtKonteynerNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        private DataTable dtKonteynerYapmaListesi = new DataTable();
        private int selectedRow = -1;

        private void KonteynerleriListele()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.getKonteynerYapmaListesi(Giris._dbName, Giris.mKodValue);

            if (resp._list != null)
            {
                dtKonteynerYapmaListesi = resp._list;
                dtgKonteynerListesi.DataSource = null;

                if (!dtKonteynerYapmaListesi.Columns.Contains("dtgSira"))
                {
                    dtKonteynerYapmaListesi.Columns.Add("dtgSira", typeof(int));
                }

                for (int i = 0; i <= dtKonteynerYapmaListesi.Rows.Count - 1; i++)
                {
                    dtKonteynerYapmaListesi.Rows[i]["dtgSira"] = i.ToString();
                }

                dtgKonteynerListesi.DataSource = dtKonteynerYapmaListesi;

                dtgKonteynerListesi.RowTemplate.Height = 55;
                dtgKonteynerListesi.ColumnHeadersHeight = 60;

                dtgKonteynerListesi.Columns["KonteynerNo"].Name = "Konteyner No";
            }
            else
            {
                dtgKonteynerListesi.DataSource = null;
            }

            if (dtgKonteynerListesi.Rows.Count > 0)
            {
                dtgKonteynerListesi.Columns["dtgSira"].Visible = false;

                dtgKonteynerListesi.RowTemplate.Height = 55;
                dtgKonteynerListesi.ColumnHeadersHeight = 60;
            }
        }

        private void PaletYapma_Load(object sender, EventArgs e)
        {
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            KonteynerleriListele();
        }

        private void dtgKonteynerListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //header tıklama
            {
                txtKonteynerNo.Text = "";
                selectedRow = -1;
                return;
            }
            else
            {
                txtKonteynerNo.Text = dtKonteynerYapmaListesi.Rows[e.RowIndex]["KonteynerNo"].ToString();
                selectedRow = e.RowIndex;
            }
        }

        private void btnKonteynerDetay_Click(object sender, EventArgs e)
        {
            if (selectedRow == -1)
            {
                CustomMsgBox.Show("SATIR SEÇİLMEDEN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                return;
            }

            string konteynerNo = dtgKonteynerListesi.Rows[selectedRow].Cells[0].Value.ToString();

            KonteynerYapma_2 konteynerYapma_2 = new KonteynerYapma_2("KONTEYNER LİSTESİ DETAY", konteynerNo);
            konteynerYapma_2.ShowDialog();
            konteynerYapma_2.Dispose();
            GC.Collect();

            if (KonteynerYapma_2.kayitYapildi)
            {
                btnListele.PerformClick();
                KonteynerYapma_2.kayitYapildi = false;
            }

            if (dtgKonteynerListesi.Rows.Count > 0)
            {
                dtgKonteynerListesi.Rows[0].Selected = false;
            }
        }

        private void txtKonteynerNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKonteynerNo.Focus();

                string konteynerNo = txtKonteynerNo.Text;

                if (konteynerNo == "")
                {
                    return;
                }

                if (dtKonteynerYapmaListesi.AsEnumerable().Where(x => x.Field<string>("KonteynerNo") == konteynerNo).Count() > 0)
                {
                    int z = Convert.ToInt32(dtKonteynerYapmaListesi.AsEnumerable().Where(x => x.Field<string>("KonteynerNo") == konteynerNo).Select(x => x.Field<int>("dtgSira")).FirstOrDefault());

                    if (z != null)
                    {
                        selectedRow = z;
                        txtKonteynerNo.Text = "";
                        btnKonteynerDetay.PerformClick();
                    }
                }
                else
                {
                    txtKonteynerNo.Text = "";
                    KonteynerYapma_2 konteynerYapma_2 = new KonteynerYapma_2("KONTEYNER LİSTESİ DETAY", konteynerNo);
                    konteynerYapma_2.ShowDialog();
                    konteynerYapma_2.Dispose();
                    GC.Collect();

                    if (KonteynerYapma_2.kayitYapildi)
                    {
                        btnListele.PerformClick();
                        KonteynerYapma_2.kayitYapildi = false;
                    }

                    if (dtgKonteynerListesi.Rows.Count > 0)
                    {
                        dtgKonteynerListesi.Rows[0].Selected = false;
                    }
                }
            }
        }

        private void KonteynerYapma_1_Load(object sender, EventArgs e)
        {
            dtgKonteynerListesi.RowTemplate.Height = 55;
            dtgKonteynerListesi.ColumnHeadersHeight = 60;
            frmName.Text = formName;
            KonteynerleriListele();

            if (dtgKonteynerListesi.Rows.Count > 0)
            {
                dtgKonteynerListesi.Rows[0].Selected = false;
            }
        }

        private void dtgKonteynerListesi_DoubleClick(object sender, EventArgs e)
        {
            btnKonteynerDetay.PerformClick();
        }
    }
}