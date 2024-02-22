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
    public partial class DepoSorgulama : form_Base
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public DepoSorgulama(string _formName)
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

            lblWareHouseCode.Font = new Font(lblWareHouseCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblWareHouseCode.Font.Style);

            lblWareHouseName.Font = new Font(lblWareHouseName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblWareHouseName.Font.Style);

            txtWareHouseCode.Font = new Font(txtWareHouseCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWareHouseCode.Font.Style);

            cmbWareHouseName.Font = new Font(cmbWareHouseName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouseName.Font.Style);

            btnDelete.Font = new Font(btnDelete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDelete.Font.Style);

            dtgWareHouseDetails.Font = new Font(dtgWareHouseDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgWareHouseDetails.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtWareHouseCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbWareHouseName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private string formName = "";

        private void DepoSorgulama_Load(object sender, EventArgs e)
        {
            txtWareHouseCode.Focus();
            frmName.Text = formName;

            //dtgWareHouseDetails.EnableHeadersVisualStyles = false;
            dtgWareHouseDetails.RowTemplate.Height = 55;
            dtgWareHouseDetails.ColumnHeadersHeight = 60;

            GetWareHouseByUserCodeAddName();
        }

        private DataTable dtWarehouses = new DataTable();

        private void GetWareHouseByUserCodeAddName()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCodeAddName(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp = aIFTerminalServiceSoapClient.GetWareHouseByUserCodeAddName(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtWarehouses = resp._list;
                    cmbWareHouseName.DisplayMember = "WhsName";
                    cmbWareHouseName.ValueMember = "WhsCode";
                    cmbWareHouseName.DataSource = dtWarehouses;

                    cmbWareHouseName.Enabled = true;

                    if (txtWareHouseCode.Text.ToString() == "System.Data.DataRowView")
                    {
                        txtWareHouseCode.Text = "";
                    }
                }
            }
            vScrollBar1.Maximum = dtgWareHouseDetails.RowCount;
        }

        private DataTable dt = new DataTable();
        private DataView dtview = new DataView();

        private void GetWareHouseDetailsWithQty()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetWareHouseDetailsWithQty(Giris._dbName, txtWareHouseCode.Text, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtgWareHouseDetails.DataSource = resp._list;

                    dtgWareHouseDetails.Columns["Stokta"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    dtgWareHouseDetails.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                    dtgWareHouseDetails.Columns["Kalem Adı"].HeaderText = "KALEM ADI";
                    dtgWareHouseDetails.Columns["Stokta"].HeaderText = "STOKTA";
                    dtgWareHouseDetails.Columns["Birim"].HeaderText = "BRM";

                    dtgWareHouseDetails.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgWareHouseDetails.Columns["Stokta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgWareHouseDetails.Columns["Birim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgWareHouseDetails.Columns["Kalem Adı"].Width = dtgWareHouseDetails.Width - dtgWareHouseDetails.Columns["Kalem Kodu"].Width - dtgWareHouseDetails.Columns["Stokta"].Width - dtgWareHouseDetails.Columns["Birim"].Width;

                    dtgWareHouseDetails.Columns["Stokta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //foreach (var Control in dtgWareHouseDetails.Controls)
                    //{
                    //    if (Control.GetType() == typeof(VScrollBar))
                    //    {
                    //        (((VScrollBar)Control).Visible) = false;
                    //        //your checking here
                    //        //specifically... if (((VScrollBar)Control).Visible)
                    //    }
                    //}
                }
            }
            vScrollBar1.Maximum = dtgWareHouseDetails.RowCount;
        }

        private void GetWareHouse()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetWareHouse(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dt = resp._list;

                    var whs = dt.AsEnumerable().Where(x => x.Field<string>("WhsCode") == txtWareHouseCode.Text).ToList();

                    if (whs.Count > 0)
                    {
                        var whsname = whs[0][1].ToString();

                        if (dtWarehouses.AsEnumerable().Where(x => x.Field<string>("WhsCode") == txtWareHouseCode.Text).Count() == 0)
                        {
                            CustomMsgBox.Show("" + whsname + " ADLI DEPO İÇİN YETKİNİZ BULUNMAMAKTADIR.", "Uyarı", "TAMAM", "");
                            cmbWareHouseName.SelectedValue = "";
                            return;
                        }
                        else
                        {
                            cmbWareHouseName.SelectedValue = whs[0][0].ToString();
                            //cmbWareHouseName.Text = whsname.ToString();
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("" + txtWareHouseCode.Text + " KODLU DEPO BULUNAMADI.", "Uyarı", "TAMAM", "");
                        cmbWareHouseName.SelectedValue = "";
                        txtWareHouseCode.Text = "";
                        return;
                    }
                }
            }
        }

        private void cmbWareHouseName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbWareHouseName.SelectedValue != null)
            {
                var whsCode = cmbWareHouseName.SelectedValue.ToString();

                if (whsCode == "")
                {
                    return;
                }
                dtgWareHouseDetails.DataSource = null;

                txtWareHouseCode.Text = whsCode;
                GetWareHouseDetailsWithQty();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dtgWareHouseDetails.DataSource = null;
            txtWareHouseCode.Text = "";
            cmbWareHouseName.Text = "";
            txtWareHouseCode.Focus();
        }

        private void txtWareHouseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgWareHouseDetails.DataSource = null;
                GetWareHouse();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtWareHouseCode.Text == "")
            {
                CustomMsgBox.Show("DEPO SEÇİLMEDEN SORGULAMA YAPILAMAZ.", "Uyarı", "TAMAM", "");
                txtWareHouseCode.Focus();
                return;
            }
            txtWareHouseCode.Focus();
            dtgWareHouseDetails.DataSource = null;
            GetWareHouse();

            txtWareHouseCode.Focus();
        }

        private void dtgWareHouseDetails_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgWareHouseDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void dtgWareHouseDetails_DoubleClick(object sender, EventArgs e)
        {
            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                if (urunKodu != "")
                {
                    RaporForm raporForm = new RaporForm("1", urunKodu);
                    raporForm.ShowDialog();
                    raporForm.Dispose();
                    GC.Collect();
                }
            }
        }

        private string urunKodu = "";

        private void dtgWareHouseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                urunKodu = dtgWareHouseDetails.Rows[e.RowIndex].Cells["Kalem Kodu"].Value.ToString();
            }
        }
    }
}