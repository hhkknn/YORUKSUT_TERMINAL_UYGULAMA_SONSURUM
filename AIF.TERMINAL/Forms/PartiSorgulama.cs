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
using System.Xml.Linq;

namespace AIF.TERMINAL.Forms
{
    public partial class PartiSorgulama : form_Base
    {
        //font start.
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end
        public PartiSorgulama(string _formName)
        {
            InitializeComponent();
            //font start.
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            formName = _formName;
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            btnQuery.Font = new Font(btnQuery.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnQuery.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            lblPartyNo.Font = new Font(lblPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPartyNo.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyNo.Font.Style);

            btnDelete.Font = new Font(btnDelete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDelete.Font.Style);

            dtgPartyDetails.Font = new Font(dtgPartyDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgPartyDetails.Font.Style);
            ResumeLayout();

            //start yükseklik-genislik
            txtPartyNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            ////font end
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
        string formName = "";

        private void PartiSorgulama_Load(object sender, EventArgs e)
        {
            txtPartyNo.Focus();
            frmName.Text = formName;

            dtgPartyDetails.EnableHeadersVisualStyles = false;

            dtgPartyDetails.RowTemplate.Height = 55;
            dtgPartyDetails.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgPartyDetails.RowCount + 5;
        }
        DataView dtview = new DataView();

        DataTable dtProducts = new DataTable();
        private void GetBatchByBatchNumber(string value)
        {

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetBatchByBatchNumber(Giris._dbName, value, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProducts = resp._list;
                    dtview = new DataView(resp._list);

                    dtgPartyDetails.DataSource = resp._list;
                    dt = resp._list;

                    dtgPartyDetails.Columns["PartiNo"].Visible = false;

                    dtgPartyDetails.Columns["Miktar"].DefaultCellStyle.Format = "N"+ Giris.genelParametreler.OndalikMiktar;
                    dtgPartyDetails.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                    dtgPartyDetails.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
                    dtgPartyDetails.Columns["PartiNo"].HeaderText = "PARTİ NO";
                    dtgPartyDetails.Columns["Depo Kodu"].HeaderText = "DEPO KODU";
                    dtgPartyDetails.Columns["Depo Adı"].HeaderText = "DEPO ADI";
                    dtgPartyDetails.Columns["Miktar"].HeaderText = "MİKTAR";
                    dtgPartyDetails.Columns["Birim"].HeaderText = "BRM";

                    dtgPartyDetails.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgPartyDetails.Columns["PartiNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgPartyDetails.Columns["Depo Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgPartyDetails.Columns["Depo Adı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgPartyDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgPartyDetails.Columns["Birim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgPartyDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    vScrollBar1.Maximum = dtgPartyDetails.RowCount + 5;

                }
            }
        }
        DataTable dt = new DataTable();

        private void txtPartyNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetBatchByBatchNumber(txtPartyNo.Text);
                if (dtProducts.Rows.Count > 0)
                {
                    dtview.RowFilter = "PartiNo like '%" + txtPartyNo.Text.ToString() + "%'";
                    txtPartyNo.Select(0, txtPartyNo.Text.Length);

                }
                if (dtview.Count > 0)
                {
                    txtPartyNo.Text = dt.Rows[0]["PartiNo"].ToString();
                    txtPartyNo.Focus();
                    txtPartyNo.Select(0, txtPartyNo.Text.Length);

                }
                else
                {
                    dtgPartyDetails.DataSource = null;
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                    txtPartyNo.Focus();
                    txtPartyNo.Select(0, txtPartyNo.Text.Length);
                }
                //if (dt.Rows.Count == 0)
                //{
                //    CustomMsgBox.Show("" + txtPartyNo.Text + " NUMARALI BARKODA AİT ÜRÜN BULUNAMADI.", "Uyarı", "TAMAM", "");

                //}


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dtgPartyDetails.DataSource = null;
            txtPartyNo.Text = "";
            txtPartyNo.Focus();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetBatchByBatchNumber(txtPartyNo.Text);
            //txtPartyNo.Focus();
            //txtPartyNo.Select(0, txtPartyNo.Text.Length);
            if (dtProducts.Rows.Count > 0)
            {
                dtview.RowFilter = "PartiNo like '%" + txtPartyNo.Text.ToString() + "%'";
                txtPartyNo.Select(0, txtPartyNo.Text.Length);

            }
            if (dtview.Count > 0)
            {
                txtPartyNo.Text = dt.Rows[0]["PartiNo"].ToString();
                txtPartyNo.Focus();
                txtPartyNo.Select(0, txtPartyNo.Text.Length);

            }
            else
            {
                dtgPartyDetails.DataSource = null;
                CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                txtPartyNo.Focus();
                txtPartyNo.Select(0, txtPartyNo.Text.Length);
            }
            //if (dt.Rows.Count == 0)
            //{
            //    CustomMsgBox.Show("" + txtPartyNo.Text + " NUMARALI BARKODA AİT ÜRÜN BULUNAMADI.", "Uyarı", "TAMAM", "");

            //}
        }

        private void dtgPartyDetails_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgPartyDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }
    }

}
