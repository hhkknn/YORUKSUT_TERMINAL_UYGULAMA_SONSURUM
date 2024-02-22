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
    public partial class UrunSorgulama : form_Base
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public UrunSorgulama(string _formName)
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

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            lblBarcode.Font = new Font(lblBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBarcode.Font.Style);

            lblItemCode.Font = new Font(lblItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemCode.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            lblWareHouse.Font = new Font(lblWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblWareHouse.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            txtWareHouseQty.Font = new Font(txtWareHouseQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWareHouseQty.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnDelete.Font = new Font(btnDelete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDelete.Font.Style);

            dtgProductDetails.Font = new Font(dtgProductDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgProductDetails.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtWareHouseQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            ////font end.
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

        private void UrunSorgulama_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtBarCode.Focus();

            dtgProductDetails.RowTemplate.Height = 55;
            dtgProductDetails.ColumnHeadersHeight = 60;
            //dtgProductDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //cmbItemName.Font = new Font("Tahoma", 26);

            vScrollBar1.Maximum = dtgProductDetails.RowCount + 5;

            if (dtgProductDetails.RowCount > 0)
            {
                if (SelectList.dialogResult == "Ok")
                {
                    dtgProductDetails.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgProductDetails.Columns["WhsName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgProductDetails.Columns["OnHand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgProductDetails.Columns["UomCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dtgProductDetails.Columns["WhsName"].Width = dtgProductDetails.Width - dtgProductDetails.Columns["WhsCode"].Width - dtgProductDetails.Columns["OnHand"].Width - dtgProductDetails.Columns["UomCode"].Width;
                }
            }
        }

        private DataView dtview = new DataView();

        private void GetDetails(string itemcode, string barkod)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;
            if (barkod != "TANIMSIZ" && barkod != "")
            {
                itemcode = Giris.UrunKoduBarkod(itemcode, "Barkod");

                if (Giris.genelParametreler.UrunSorguFiyat == "Y" && Giris.genelParametreler.UrunSorguFiyatList != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductsByBarCodeWithWhsDetails(Giris._dbName, itemcode, Giris.genelParametreler.UrunSorguFiyatList, Giris.whsCodes.ToArray(), Giris._userCode, Giris.mKodValue);
                }
                else
                {
                    resp = aIFTerminalServiceSoapClient.GetProductsByBarCodeWithWhsDetails(Giris._dbName, itemcode, "", null, "", Giris.mKodValue);

                }
            }
            else
            {
                if (Giris.genelParametreler.UrunSorguFiyat == "Y" && Giris.genelParametreler.UrunSorguFiyatList != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductsByItemCodeWithWhsDetails(Giris._dbName, itemcode, Giris.genelParametreler.UrunSorguFiyatList, Giris.whsCodes.ToArray(), Giris._userCode, Giris.mKodValue);
                }
                else
                {
                    resp = aIFTerminalServiceSoapClient.GetProductsByItemCodeWithWhsDetails(Giris._dbName, itemcode, "", null, "", Giris.mKodValue);

                }
            }

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtgProductDetails.DataSource = resp._list;
                    dt = resp._list;

                    dtgProductDetails.Columns["ItemCode"].Visible = false;
                    dtgProductDetails.Columns["ItemName"].Visible = false;
                    dtgProductDetails.Columns["CodeBars"].Visible = false;
                    if (Giris.genelParametreler.UrunSorguFiyat == "Y" && Giris.genelParametreler.UrunSorguFiyatList != "")
                    {
                        dtgProductDetails.Columns["Sira"].Visible = false; 
                    }

                    var sum = dt.AsEnumerable().Sum(x => x.Field<decimal>("OnHand"));
                    //double sum = dt.AsEnumerable().Sum(x => x.Field<double>("Miktar"));

                    txtWareHouseQty.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    dtgProductDetails.Columns["OnHand"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                    dtgProductDetails.Columns["ItemCode"].HeaderText = "KALEM KODU";
                    dtgProductDetails.Columns["ItemName"].HeaderText = "KALEM ADI";
                    dtgProductDetails.Columns["CodeBars"].HeaderText = "BARKOD";
                    dtgProductDetails.Columns["WhsCode"].HeaderText = "DEPO KODU";
                    dtgProductDetails.Columns["WhsName"].HeaderText = "DEPO ADI";
                    dtgProductDetails.Columns["OnHand"].HeaderText = "MİKTAR";
                    dtgProductDetails.Columns["UomCode"].HeaderText = "BRM";

                    if (Giris.genelParametreler.UrunSorguFiyat == "Y" && Giris.genelParametreler.UrunSorguFiyatList != "")
                    {
                        dtgProductDetails.Columns["Price"].HeaderText = "FİYAT";
                        dtgProductDetails.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dtgProductDetails.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        int sira = dt.AsEnumerable().Select(y => y.Field<int>("Sira")).FirstOrDefault();

                        if (sira == 1)
                        {
                            DataGridViewCellStyle renk = new DataGridViewCellStyle();
                            renk.SelectionBackColor = Color.LimeGreen;
                            renk.BackColor = Color.LimeGreen;
                            //renk.ForeColor = Color.White; 
                            dtgProductDetails.Rows[0].DefaultCellStyle = renk; 
                        }
                    }

                    dtgProductDetails.Columns["WhsCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dtgProductDetails.Columns["WhsName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgProductDetails.Columns["OnHand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dtgProductDetails.Columns["UomCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    //dtgProductDetails.Columns["WhsName"].Width = dtgProductDetails.Width - dtgProductDetails.Columns["WhsCode"].Width - dtgProductDetails.Columns["OnHand"].Width - dtgProductDetails.Columns["UomCode"].Width;

                    dtgProductDetails.Columns["OnHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    vScrollBar1.Maximum = dtgProductDetails.RowCount + 5;
                }
            }
        }

        private DataTable dtProducts = new DataTable();

        private void GetAllProducts()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProducts = resp._list;
                    dtview = new DataView(resp._list);
                }
            }
        }

        private DataTable dt = new DataTable();

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Select(0, txtBarCode.Text.Length);

                if (txtBarCode.Text == "")
                {
                    txtBarCode.Focus();
                    txtBarCode.Select(0, txtBarCode.Text.Length);

                    return;
                }
                dtgProductDetails.DataSource = null;
                txtItemCode.Text = "";
                txtItemName.Text = "";
                cmbItemName.Text = "";
                txtWareHouseQty.Text = "";
                GetDetails(txtBarCode.Text, "Barkod sorgulaması yap");

                if (dtgProductDetails.Rows.Count == 0)
                {
                    GetDetails(txtItemCode.Text, "");
                    if (dtgProductDetails.Rows.Count == 0)
                    {
                        CustomMsgBox.Show("" + txtBarCode.Text + " NUMARALI BARKODA AİT ÜRÜN BULUNAMADI.", "Uyarı", "TAMAM", "");
                        txtBarCode.Select(0, txtBarCode.Text.Length);
                    }
                }
                else
                {
                    txtItemCode.Text = dt.Rows[0]["ItemCode"].ToString();
                    txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAllProducts();
            if (dtProducts.Rows.Count > 0)
            {
                dtview.RowFilter = "ItemCode like '%" + cmbItemName.Text.ToUpper() + "%' or ItemName like '%" + cmbItemName.Text + "%' or  ItemCode = '' or ItemName =''";
                dtview.RowFilter = "ItemCode like '%" + cmbItemName.Text.ToUpper() + "%' or ItemName like '%" + cmbItemName.Text + "%' or  ItemCode = '' or ItemName =''";

                //cmbItemName.DroppedDown = true;
                cmbItemName.DataSource = null;

                if (dtview.Count > 0)
                {
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemCode";
                    cmbItemName.DataSource = dtview;

                    cmbItemName.DroppedDown = true;
                }
                else
                {
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                }
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue != null)
            {
                var value = cmbItemName.SelectedValue.ToString();

                if (value != "")
                {
                    dtgProductDetails.DataSource = null;
                    if (dtProducts.Rows.Count > 0)
                    {
                        var listProducts = dtProducts.AsEnumerable().Where(x => x.Field<string>("ItemCode") == value).ToList();

                        var itemCode = listProducts.Select(x => x.Field<string>("ItemCode")).First();
                        var barcode = listProducts.Select(x => x.Field<string>("CodeBars")).First();

                        txtBarCode.Text = barcode;
                        txtItemCode.Text = itemCode;

                        if (txtBarCode.Text == null || txtBarCode.Text == "")
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }
                    }

                    string barkodMu = txtBarCode.Text != "TANIMSIZ" && txtBarCode.Text != "" ? "Barkod sorgulaması yap" : "";

                    GetDetails(txtBarCode.Text, barkodMu);

                    if (dtgProductDetails.Rows.Count == 0)
                    {
                        GetDetails(txtItemCode.Text, barkodMu);
                        if (dtgProductDetails.Rows.Count == 0)
                        {
                            CustomMsgBox.Show("BARKOD VEYA ÜRÜN KODUNA AİT KALEM BULUNAMADI.", "Uyarı", "TAMAM", "");
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dtgProductDetails.DataSource = null;
            txtBarCode.Text = "";
            txtItemCode.Text = "";
            txtWareHouseQty.Text = "";
            cmbItemName.Text = "";
            txtBarCode.Focus();
            txtBarCode.Select(0, txtBarCode.Text.Length);
            txtItemName.Text = "";

        }

        private void dtgProductDetails_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgProductDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        public static string ItemCode = "";

        private void temizle()
        {
            dtgProductDetails.DataSource = null;
            txtBarCode.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtWareHouseQty.Text = "";
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            temizle();
            SelectList nesne = new SelectList("UrunSorgula", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                txtItemCode.Text = ItemCode;
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Text = "TANIMSIZ";
                }

                if (txtBarCode.Text != "TANIMSIZ")
                {
                    GetDetails(txtBarCode.Text, "Barkod sorgulaması yap");
                }
                else
                {
                    GetDetails(txtItemCode.Text, "");
                }

                if (dtgProductDetails.Rows.Count == 0)
                {
                    if (txtBarCode.Text != "TANIMSIZ")
                    {
                        if (dtgProductDetails.Rows.Count == 0)
                        {
                            CustomMsgBox.Show("" + txtBarCode.Text + " NUMARALI BARKODA AİT MİKTAR BULUNAMADI.", "Uyarı", "TAMAM", "");
                            txtBarCode.Select(0, txtBarCode.Text.Length);
                            temizle();
                        }
                    }
                    else
                    {
                        if (dtgProductDetails.Rows.Count == 0)
                        {
                            CustomMsgBox.Show("" + txtItemCode.Text + " NUMARALI KODA AİT MİKTAR BULUNAMADI.", "Uyarı", "TAMAM", "");
                            txtBarCode.Select(0, txtBarCode.Text.Length);
                            temizle();
                        }
                    }
                }
                else
                {
                    txtItemCode.Text = dt.Rows[0]["ItemCode"].ToString();
                    txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                }
                //btnSearch.PerformClick();
                SelectList.dialogResult = "";
            }
        }
    }
}