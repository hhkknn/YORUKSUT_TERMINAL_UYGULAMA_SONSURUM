using AIF.TERMINAL.AIFTerminalService;
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
    public partial class RaporForm : form_Base
    {
        public RaporForm(string _raporTipi, string _deger1)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblArama.Font.Size;
            lblArama.Resize += Form_Resize;


            //Rapor Tipi = 1 Depo yerlerine göre miktarları getirir.
            raporTipi = _raporTipi;
            deger1 = _deger1;
        }


        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            lblArama.Font = new Font(lblArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblArama.Font.Style);

            lblForm.Font = new Font(lblForm.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblForm.Font.Style);

            lblUrunKodu.Font = new Font(lblUrunKodu.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblUrunKodu.Font.Style);

            lblTanim.Font = new Font(lblTanim.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblTanim.Font.Style);

            txtArama.Font = new Font(txtArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtArama.Font.Style);

            btnKapat.Font = new Font(btnKapat.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKapat.Font.Style);

            txtUrunKodu.Font = new Font(txtUrunKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunKodu.Font.Style);

            txtUrunTanim.Font = new Font(txtUrunTanim.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunTanim.Font.Style);

            dtgDetay.Font = new Font(dtgDetay.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetay.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtArama.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUrunKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUrunTanim.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        //start font.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //end font
        string raporTipi = "";
        string deger1 = "";
        private void dtgDetay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RaporForm_Load(object sender, EventArgs e)
        {
            if (raporTipi == "1")
            {
                lblForm.Text = "DEPO YERİ RAPORU";

                depoYerlerineGoreMiktarlar();


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtUrunKodu.Text = dt.Rows[0]["Ürün Kodu"].ToString();
                        txtUrunTanim.Text = dt.Rows[0]["Ürün Adı"].ToString();
                    }
                }
            }

            dtgDetay.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgDetay.RowCount + 5;

        }
        DataTable dt = new DataTable();
        private void depoYerlerineGoreMiktarlar()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.getDepoYeriMiktarlari(Giris._dbName, deger1, Giris.mKodValue);

            if (resp.Val == 0)
            {

                if (resp._list.Rows.Count > 0)
                {
                    dt = resp._list;

                    dtgDetay.DataSource = dt;

                    dtgDetay.Columns["Ürün Kodu"].Visible = false;
                    dtgDetay.Columns["Ürün Adı"].Visible = false;
                    dtgDetay.Columns["AbsEntry"].Visible = false;

                    dtParams = resp._list.Copy();
                    dtParamsOrjinalValues = resp._list.Copy();

                    foreach (DataRow row in dtParams.Rows)
                    {
                        string depoYeri = row["Depo Yeri"].ToString();

                        depoYeri = KarakterDegistir(depoYeri);

                        row.SetField("Depo Yeri", depoYeri);

                    }
                    dtgDetay.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                }
            }
            vScrollBar1.Maximum = dtgDetay.RowCount;

            foreach (DataGridViewColumn column in dtgDetay.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgDetay.Rows.Count > 0)
            {
                dtgDetay.Rows[0].Selected = false;

            }

        }

        private string KarakterDegistir(string text)
        {
            string val = text;

            val = val.Replace("i", "I");
            val = val.Replace("İ", "I");
            val = val.Replace("ç", "C");
            val = val.Replace("Ç", "C");
            val = val.Replace("ş", "S");
            val = val.Replace("Ş", "S");
            val = val.Replace("Ü", "U");
            val = val.Replace("ü", "U");
            val = val.Replace("Ö", "O");
            val = val.Replace("ö", "O");
            val = val.Replace("Ğ", "G");
            val = val.Replace("ğ", "G");

            return val;
        }

        DataTable dtParamsOrjinalValues = new DataTable();
        DataTable dtParams = new DataTable();
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (raporTipi == "1")
            {
                string kelime = txtArama.Text;

                kelime = KarakterDegistir(kelime);

                var resp = dtParams.AsEnumerable().Where(x => x.Field<string>("Depo Yeri").Contains(kelime.ToUpper())).ToList();

                if (resp.Count > 0)
                {
                    DataTable dts = resp.CopyToDataTable();
                    DataTable dtsOrjinalValues = dts.Copy();
                    dtsOrjinalValues.Rows.Clear();

                    foreach (DataRow item in dts.Rows)
                    {
                        string tempAbsEntry = item["AbsEntry"].ToString();

                        var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<int>("AbsEntry") == Convert.ToInt32(tempAbsEntry)).ToList();

                        if (dt.Count > 0)
                        {

                            DataRow dr = dtsOrjinalValues.NewRow();
                            dr["AbsEntry"] = dt[0]["AbsEntry"].ToString();
                            dr["Depo Yeri"] = dt[0]["Depo Yeri"].ToString();
                            dr["Miktar"] = dt[0]["Miktar"].ToString();
                            dr["Ürün Kodu"] = dt[0]["Ürün Kodu"].ToString();
                            dr["Ürün Adı"] = dt[0]["Ürün Adı"].ToString();

                            dtsOrjinalValues.Rows.Add(dr);

                        }


                    }
                    dtgDetay.DataSource = dtsOrjinalValues;


                    dtgDetay.Columns["Ürün Kodu"].Visible = false;
                    dtgDetay.Columns["Ürün Adı"].Visible = false;
                    dtgDetay.Columns["AbsEntry"].Visible = false;
                }
                else
                {
                    dtgDetay.DataSource = null;
                }

            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
