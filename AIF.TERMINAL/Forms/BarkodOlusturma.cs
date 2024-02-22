using AIF.TERMINAL.AIFTerminalService;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace AIF.TERMINAL.Forms
{
    public partial class BarkodOlusturma : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public BarkodOlusturma(string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblPrintMik.Font.Size;
            lblPrintMik.Resize += Form_Resize;

            //initialFontSize = txtPrintMik.Font.Size;
            //txtPrintMik.Resize += Form_Resize;

            initialFontSize = lblBarcode.Font.Size;
            lblBarcode.Resize += Form_Resize;

            initialFontSize = lblBarcodeSize.Font.Size;
            lblBarcodeSize.Resize += Form_Resize;

            initialFontSize = lblItemCode.Font.Size;
            lblItemCode.Resize += Form_Resize;

            initialFontSize = lblItemName.Font.Size;
            lblItemName.Resize += Form_Resize;

            initialFontSize = lblQty.Font.Size;
            lblQty.Resize += Form_Resize;

            initialFontSize = lblBag.Font.Size;
            lblBag.Resize += Form_Resize;

            initialFontSize = lblPartyNo.Font.Size;
            lblPartyNo.Resize += Form_Resize;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;

            //initialFontSize = txtBarCode.Font.Size;
            //txtBarCode.Resize += Form_Resize;

            //initialFontSize = txtItemCode.Font.Size;
            //txtItemCode.Resize += Form_Resize;

            //initialFontSize = cmbBarcodeSize.Font.Size;
            //cmbBarcodeSize.Resize += Form_Resize;

            //initialFontSize = cmbItemName.Font.Size;
            //cmbItemName.Resize += Form_Resize;

            //initialFontSize = txtQty.Font.Size;
            //txtQty.Resize += Form_Resize;

            //initialFontSize = txtBag.Font.Size;
            //txtBag.Resize += Form_Resize;

            //initialFontSize = txtPartyNo.Font.Size;
            //txtPartyNo.Resize += Form_Resize;

            initialFontSize = btnSearch.Font.Size;
            btnSearch.Resize += Form_Resize;

            initialFontSize = btnCreate.Font.Size;
            btnCreate.Resize += Form_Resize;

            initialFontSize = btnPrint.Font.Size;
            btnPrint.Resize += Form_Resize;

            initialFontSize = pictureBarcode.Font.Size;
            pictureBarcode.Resize += Form_Resize;

            //end font
            formName = _formName;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;
            lblPrintMik.Font = new Font(lblPrintMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPrintMik.Font.Style);

            txtPrintMik.Font = new Font(txtPrintMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPrintMik.Font.Style);

            lblBarcode.Font = new Font(lblBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBarcode.Font.Style);

            lblBarcodeSize.Font = new Font(lblBarcodeSize.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBarcodeSize.Font.Style);

            lblItemCode.Font = new Font(lblItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemCode.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            lblQty.Font = new Font(lblQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblQty.Font.Style);

            lblBag.Font = new Font(lblBag.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBag.Font.Style);

            lblPartyNo.Font = new Font(lblPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPartyNo.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            cmbBarcodeSize.Font = new Font(cmbBarcodeSize.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbBarcodeSize.Font.Style);

            numQty.Font = new Font(numQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                numQty.Font.Style);

            txtBag.Font = new Font(txtBag.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBag.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyNo.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnCreate.Font = new Font(btnCreate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCreate.Font.Style);

            btnPrint.Font = new Font(btnPrint.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPrint.Font.Style);

            pictureBarcode.Font = new Font(pictureBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                pictureBarcode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPrinter.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            dtpKaliteKntTarihi.Font = new Font(dtpKaliteKntTarihi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpKaliteKntTarihi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartyNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            numQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBag.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPrintMik.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);
            txtSonSatinalmaBelgeNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpKaliteKntTarihi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private string formName = "";

        private void BarkodOlusturma_Load(object sender, EventArgs e)
        {
            //this.AutoSize = true;
            frmName.Text = formName;
            txtBarCode.Focus();

            cmbBarcodeSize.DisplayMember = "Text";
            cmbBarcodeSize.ValueMember = "Value";

            cmbBarcodeSize.Items.Add(new { Text = "3X5", Value = "3X5" });
            cmbBarcodeSize.Items.Add(new { Text = "6X10", Value = "6X10" });

            //cmbItemName.Font = new Font("Arial", 28,FontStyle.Bold);
            //cmbItemName.Size = new System.Drawing.Size(100, 120);

            //cmbItemName.Font = new Font("Tahoma", 26);

            txtPrintMik.Value = 1;
            //cmbItemName.Dock = DockStyle.Fill;

            //TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition(cmbItemName);
            //int width = tableLayoutPanel1.GetColumnWidths()[pos.Column];
            //int height = tableLayoutPanel1.GetRowHeights()[pos.Row];

            //cmbItemName.Height = height;

            listAllPrinters();

            dtpKaliteKntTarihi.Value = DateTime.Now;

            if (Giris.genelParametreler.CrystalKullan == "Y")
            {
                pictureBarcode.Visible = false;
            }
        }

        private DataView dtview = new DataView();
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

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Select(0, txtBarCode.Text.Length);

                temizle(true);
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Focus();
                    txtBarCode.Select(0, txtBarCode.Text.Length);

                    return;
                }
                //cmbItemName.SelectedValue = "";
                //cmbItemName.SelectionLength = 0;

                //btnSearch.PerformClick();
                GetAllProducts();
                //cmbItemName.DroppedDown = false;

                if (txtBarCode.Text != "TANIMSIZ" && txtBarCode.Text != "")
                {
                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    Response resp = new Response();
                    string Val = txtBarCode.Text;
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCode(Giris._dbName, Val, Giris.mKodValue);

                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, "", "", Giris.mKodValue);
                    }

                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCode(Giris._dbName, Val, Giris.mKodValue);
                    }

                    if (resp._list != null)
                    {
                        txtItemName.Text = resp._list.Rows[0]["Kalem Tanımı"].ToString();
                        txtItemCode.Text = resp._list.Rows[0]["Kalem Kodu"].ToString();
                        txtBarCode.Text = resp._list.Rows[0]["Barkod"] == null || resp._list.Rows[0]["Barkod"].ToString() == "" ? "TANIMSIZ" : resp._list.Rows[0]["Barkod"].ToString();
                    }
                    else
                    {
                        CustomMsgBox.Show("" + txtBarCode.Text + " BULUNAMADI.", "Uyarı", "TAMAM", "");
                        return;
                    }
                    //var sum1 = dtProducts.AsEnumerable().Where(x => x.Field<string>("CodeBars") == txtBarCode.Text || x.Field<string>("ItemCode") == txtBarCode.Text).ToList();

                    //if (sum1.Count > 0)
                    //{
                    //    txtItemName.Text = sum1[0][1].ToString();
                    //    txtItemCode.Text = sum1[0][0].ToString();
                    //    txtBarCode.Text = sum1[0][2].ToString() == null || sum1[0][2].ToString() == "" ? "TANIMSIZ" : sum1[0][2].ToString();

                    //    //cmbItemName.SelectedValue = sum1[0][0].ToString();
                    //    //itemNamem = itemName;

                    //}
                    //else
                    //{
                    //    CustomMsgBox.Show("" + txtBarCode.Text + " BULUNAMADI.", "Uyarı", "TAMAM", "");
                    //    return;
                    //}
                }
                else
                {
                    //var sum2 = dtProducts.AsEnumerable().Where(x => x.Field<string>("ItemCode") == txtItemCode.Text).ToList();

                    //if (sum2.Count > 0)
                    //{
                    //    var itemName = sum2[0][1].ToString();

                    //    //cmbItemName.SelectedValue = sum2[0][0].ToString();
                    //    itemNamem = itemName;

                    //}
                    //else
                    //{
                    //    CustomMsgBox.Show("" + txtBarCode.Text + " BULUNAMADI.", "Uyarı", "TAMAM", "");
                    //    return;
                    //}
                }

                //GetDetails(txtBarCode.Text, "Barkod sorgulaması yap");
                //txtBag.Text = "";
                //txtQty.Text = "";
                //txtPartyNo.Text = "";
                //pictureBarcode.Image = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAllProducts();
            cmbItemName.Font = new Font("Tahoma", 26);

            if (dtProducts.Rows.Count > 0)
            {
                string arama = cmbItemName.Text.ToUpper();
                arama = arama.Replace("I", "İ");

                dtview.RowFilter = "ItemCode like '%" + arama + "%' or ItemName like '%" + arama + "%' or  ItemCode = '' or ItemName =''";
                dtview.RowFilter = "ItemCode like '%" + arama + "%' or ItemName like '%" + arama + "%' or  ItemCode = '' or ItemName =''";

                //cmbItemName.DroppedDown = true;
                cmbItemName.DataSource = null;
                //txtBag.Text = "";
                //txtQty.Text = "";
                //txtPartyNo.Text = "";
                //pictureBarcode.Image = null;

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
                cmbItemName.Font = new Font("Tahoma", 26);

                var value = cmbItemName.SelectedValue.ToString();

                if (value != "")
                {
                    //dtgProductDetails.DataSource = null;
                    if (dtProducts.Rows.Count > 0)
                    {
                        var listProducts = dtProducts.AsEnumerable().Where(x => x.Field<string>("ItemCode") == value).ToList();

                        var itemCode = listProducts.Select(x => x.Field<string>("ItemCode")).First();
                        var itemName = listProducts.Select(x => x.Field<string>("ItemName")).First();
                        var barcode = listProducts.Select(x => x.Field<string>("CodeBars")).First();

                        txtBarCode.Text = barcode;
                        txtItemCode.Text = itemCode;
                        //barkod için
                        itemNamem = itemName;
                        itemCodem = itemCode;
                        barcodem = barcode;

                        if (txtBarCode.Text == null || txtBarCode.Text == "")
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }
                        txtBag.Text = "";
                        numQty.Text = "";
                        txtPartyNo.Text = "";
                        if (pictureBarcode.Image != null)
                        {
                            pictureBarcode.Image = null;
                        }
                    }

                    //string barkodMu = txtBarCode.Text != "TANIMSIZ" && txtBarCode.Text != "" ? "Barkod sorgulaması yap" : "";
                }
                numQty.Focus();
            }
        }

        public string StringReplace(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }

        private void PrintPageBarcode1(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.RotateTransform(-90);
            e.Graphics.DrawImage(pictureBarcode.Image, 2, 2);
            return;
            if (cmbBarcodeSize.Text == "3X5")
            {
                //RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
                //GraphicsUnit units = GraphicsUnit.Pixel;

                e.Graphics.DrawImage(pictureBarcode.Image, 1, 1);
            }
            else if (cmbBarcodeSize.Text == "6X10")
            {
                e.Graphics.DrawImage(pictureBarcode.Image, 2, 2);
            }
            //e.Graphics.DrawImage(pictureBarcode.Image, 6, 10);
            //e.Graphics.DrawImage(pictureBox2.Image, 10, 10);
        }

        private string barcodem = "";
        private string itemCodem = "";
        private string itemNamem = "";

        //string qty = "";
        //string bag = "";
        //string partyNo = "";
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (cmbBarcodeSize.Text == "")
            //{
            //    CustomMsgBox.Show("LÜTFEN BOYUT GİRİNİZ.","UYARI","TAMAM","");
            //    cmbBarcodeSize.Focus();
            //    return;
            //}
            //pictureBarcode.Image = null;

            string barkodNo = "Barkod No : ";
            string urunKodu = "Ürün Kodu : ";
            string urunTanimi = "Ürün Tanımı:";
            string miktar = "Miktar        :";
            string bag = "Bağ             :";
            string partiNo = "Parti No: ";
            string barkodDeger = "";
            string partiNoDeger = "";

            Graphics g;
            Font fnt = new Font("Calibri", 12, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            Bitmap bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);

            //if (barcodem == null)
            //{
            //    barcodem = txtBarCode.Text;
            //}
            barkodDeger = txtBarCode.Text;
            partiNoDeger = txtPartyNo.Text;

            if (txtBarCode.Text != "TANIMSIZ" && txtBarCode.Text != "")
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                g.Clear(Color.White);

                if (txtPartyNo.Text != "")
                {
                    //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                    //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                    //using (var graphics = Graphics.FromImage(bmp))
                    //using (var font = new Font("Consolas", 12))
                    //using (var brush = new SolidBrush(Color.Black))
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        //g.Clear(Color.White);
                        partiNoDeger = StringReplace(txtPartyNo.Text);
                        g.DrawImage(barcode.Draw(partiNoDeger, 60, 1), new Point(410, 285)); //400,410

                        g.DrawString(txtPartyNo.Text, fnt, brush, 475, 370, format);//430,490
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                }

                //barkodun içerisine yazar
                barkodDeger = txtBarCode.Text;
                //barkodDeger += urunKodu + ":" + itemCodem + Environment.NewLine;
                //barkodDeger += urunTanimi + ":" + itemNamem + Environment.NewLine;
                //barkodDeger += miktar + ":" + qty + Environment.NewLine;
                //barkodDeger += bag + ":" + txtBag.Text + Environment.NewLine;
                //barkodDeger += partiNo + ":" + txtPartyNo.Text + Environment.NewLine;

                #region resimsiz - orjinal barkod oluşturma

                //Etiketler
                //g.DrawString(barkodNo, fnt, brush, 15, 15);
                //g.DrawString(urunKodu, fnt, brush, 15, 30);
                //g.DrawString(urunTanimi, new Font(fnt, FontStyle.Regular), Brushes.Black, 15, 45);
                g.DrawString(urunKodu, fnt, brush, 55, 45);
                g.DrawString(miktar, fnt, brush, 55, 65);
                g.DrawString(bag, fnt, brush, 55, 85);
                //g.DrawString(miktar, fnt, brush, 15, 105);
                //g.DrawString(partiNo, fnt, brush, 15, 90);
                //Değerler
                //g.DrawString(txtBarCode.Text, fnt, brush, 120, 15);
                txtItemName.Text = txtItemName.Text.Replace(txtItemCode.Text + "-", "");
                g.DrawString(txtItemName.Text, fnt, brush, 15, 15);
                g.DrawString(txtItemCode.Text, fnt, brush, 140, 45);
                g.DrawString(numQty.Text, fnt, brush, 140, 65);
                g.DrawString(txtBag.Text, fnt, brush, 140, 85);
                //g.DrawString(txtPartyNo.Text, fnt, brush, 120, 90);
                barkodDeger = StringReplace(barkodDeger);

                g.DrawImage(barcode.Draw(barkodDeger, 60, 2), new Point(15, 130));

                g.DrawString(txtBarCode.Text, fnt, brush, 80, 190);

                pictureBarcode.Image = bmp;

                txtBarCode.Focus();
                txtBarCode.Select(0, txtBarCode.Text.Length);

                #endregion resimsiz - orjinal barkod oluşturma

                #region resimli barkod oluşturma

                ////Etiketler
                ////g.DrawString(barkodNo, fnt, brush, 15, 15);
                ////g.DrawString(urunKodu, fnt, brush, 15, 30);
                ////g.DrawString(urunTanimi, new Font(fnt, FontStyle.Regular), Brushes.Black, 15, 45);
                //g.DrawString(urunKodu, fnt, brush, 15, 45);
                //g.DrawString(miktar, fnt, brush, 15, 65);
                //g.DrawString(bag, fnt, brush, 15, 85);
                ////g.DrawString(miktar, fnt, brush, 15, 105);
                ////g.DrawString(partiNo, fnt, brush, 15, 90);
                ////Değerler
                ////g.DrawString(txtBarCode.Text, fnt, brush, 120, 15);
                //txtItemName.Text = txtItemName.Text.Replace(txtItemCode.Text + "-", "");
                //g.DrawString(txtItemName.Text, fnt, brush, 15, 15);
                //g.DrawString(txtItemCode.Text, fnt, brush, 100, 45);
                //g.DrawString(txtQty.Text, fnt, brush, 100, 65);
                //g.DrawString(txtBag.Text, fnt, brush, 100, 85);
                ////g.DrawString(txtPartyNo.Text, fnt, brush, 120, 90);
                //barkodDeger = StringReplace(barkodDeger);

                //g.DrawImage(barcode.Draw(barkodDeger, 60, 2), new Point(15, 130));

                //g.DrawString(txtBarCode.Text, fnt, brush, 80, 190);
                //var file = Application.StartupPath + "\\disli_72x74.png";
                //g.DrawImage(Image.FromFile(file), new Point(200, 50));
                //pictureBarcode.Image = bmp;

                //txtBarCode.Focus();
                //txtBarCode.Select(0, txtBarCode.Text.Length);

                #endregion resimli barkod oluşturma
            }
            else if (txtBarCode.Text == "TANIMSIZ")
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                g.Clear(Color.White);
                if (txtPartyNo.Text != "")
                {
                    //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                    //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                    //using (var graphics = Graphics.FromImage(bmp))
                    //using (var font = new Font("Consolas", 12))
                    //using (var brush = new SolidBrush(Color.Black))
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        //g.Clear(Color.White);
                        partiNoDeger = StringReplace(txtPartyNo.Text);
                        g.DrawImage(barcode.Draw(partiNoDeger, 60, 1), new Point(410, 285)); //400,410

                        g.DrawString(txtPartyNo.Text, fnt, brush, 475, 370, format);//430,490
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                }

                #region resimsiz - orjinal barkod oluşturma

                //Etiketler
                g.DrawString(urunKodu, fnt, brush, 55, 45);
                g.DrawString(miktar, fnt, brush, 55, 65);
                g.DrawString(bag, fnt, brush, 55, 85);
                g.DrawString(barkodNo, fnt, brush, 55, 130);

                //Değerler
                txtItemName.Text = txtItemName.Text.Replace(txtItemCode.Text + "-", "");
                g.DrawString(txtItemName.Text, fnt, brush, 15, 15);
                g.DrawString(txtItemCode.Text, fnt, brush, 140, 45);
                g.DrawString(numQty.Text, fnt, brush, 140, 65);
                g.DrawString(txtBag.Text, fnt, brush, 140, 85);
                g.DrawString(txtBarCode.Text, fnt, brush, 140, 130);

                pictureBarcode.Image = bmp;
                txtBarCode.Focus();
                txtBarCode.Select(0, txtBarCode.Text.Length);

                #endregion resimsiz - orjinal barkod oluşturma

                #region resimli barkod oluşturma

                ////Etiketler
                ////g.DrawString(barkodNo, fnt, brush, 15, 15);
                ////g.DrawString(urunKodu, fnt, brush, 15, 30);
                ////g.DrawString(urunTanimi, new Font(fnt, FontStyle.Regular), Brushes.Black, 15, 45);
                //g.DrawString(urunKodu, fnt, brush, 15, 45);
                //g.DrawString(miktar, fnt, brush, 15, 65);
                //g.DrawString(bag, fnt, brush, 15, 85);
                //g.DrawString(barkodNo, fnt, brush, 15, 130);

                ////g.DrawString(miktar, fnt, brush, 15, 105);
                ////g.DrawString(partiNo, fnt, brush, 15, 90);
                ////Değerler
                ////g.DrawString(txtBarCode.Text, fnt, brush, 120, 15);
                //txtItemName.Text = txtItemName.Text.Replace(txtItemCode.Text + "-", "");
                //g.DrawString(txtItemName.Text, fnt, brush, 15, 15);
                //g.DrawString(txtItemCode.Text, fnt, brush, 100, 45);
                //g.DrawString(txtQty.Text, fnt, brush, 100, 65);
                //g.DrawString(txtBag.Text, fnt, brush, 100, 85);
                //g.DrawString(txtBarCode.Text, fnt, brush, 100, 130);

                //var file = Application.StartupPath + "\\disli_72x74.png";
                //g.DrawImage(Image.FromFile(file), new Point(200, 50));
                //pictureBarcode.Image = bmp;

                //txtBarCode.Focus();
                //txtBarCode.Select(0, txtBarCode.Text.Length);

                #endregion resimli barkod oluşturma
            }
        }

        private int yazdirMik = 0;

        private void Print()
        {
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                int yazdirmakistenilenMikar = Convert.ToInt32(txtPrintMik.Value);
                int ikilidenyazdirilacakMiktar_Gecici = 0;
                int birliyazilacak = 0;

                if (yazdirmakistenilenMikar % 2 != 0)
                {
                    ikilidenyazdirilacakMiktar_Gecici = yazdirmakistenilenMikar - 1;
                    birliyazilacak = 1;
                }
                else
                {
                    ikilidenyazdirilacakMiktar_Gecici = yazdirmakistenilenMikar;
                }

                int ikilidenyazdirilacakMiktar = Convert.ToInt32(ikilidenyazdirilacakMiktar_Gecici) / 2;

                string path = "";
                //if (Convert.ToInt32(txtPrintMik.Text) % 2 == 0)
                //{
                //    path = System.AppDomain.CurrentDomain.BaseDirectory + "Ant_105_70_mm.rpt_2.rpt";

                //    ReportDocument cryRpt = new ReportDocument();
                //    cryRpt.Load(path);

                //    string server = @"ANATOLYA-SAP\SAPB1";

                //    cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                //    cryRpt.VerifyDatabase();

                //    cryRpt.SetParameterValue(0, txtItemCode.Text);
                //    cryRpt.SetParameterValue(1, dtpKaliteKntTarihi.Value);
                //    cryRpt.SetParameterValue(2, txtSonSatinalmaBelgeNo.Text == "" ? "0" : txtSonSatinalmaBelgeNo.Text);
                //    cryRpt.SetParameterValue(3, txtQty.Text == "" ? "1" : txtQty.Text);

                //    cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                //    cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : Convert.ToInt32(txtPrintMik.Text), false, 0, 1);

                //    cryRpt.Close();
                //}
                //else
                //{
                if (ikilidenyazdirilacakMiktar > 0)
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Ant_105_70_mm_2.rpt";

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);

                    string server = @"ANATOLYA-SAP\SAPB1";

                    cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                    cryRpt.VerifyDatabase();

                    cryRpt.SetParameterValue(0, txtItemCode.Text);
                    cryRpt.SetParameterValue(1, dtpKaliteKntTarihi.Value);
                    cryRpt.SetParameterValue(2, txtSonSatinalmaBelgeNo.Text == "" ? "0" : txtSonSatinalmaBelgeNo.Text);
                    cryRpt.SetParameterValue(3, numQty.Text == "" ? "1" : numQty.Text);

                    cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                    cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : ikilidenyazdirilacakMiktar, false, 0, 1);

                    cryRpt.Close();
                }

                if (birliyazilacak == 1)
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Ant_105_70_mm_1.rpt";
                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);

                    string server = @"ANATOLYA-SAP\SAPB1";

                    cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                    cryRpt.VerifyDatabase();

                    cryRpt.SetParameterValue(0, txtItemCode.Text);
                    cryRpt.SetParameterValue(1, dtpKaliteKntTarihi.Value);
                    cryRpt.SetParameterValue(2, txtSonSatinalmaBelgeNo.Text == "" ? "0" : txtSonSatinalmaBelgeNo.Text);
                    cryRpt.SetParameterValue(3, numQty.Text == "" ? "1" : numQty.Text);

                    cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                    cryRpt.PrintToPrinter(1, false, 0, 1);

                    cryRpt.Close();
                }
                //  }
            }
            catch (Exception x)
            {
            }

            #endregion Crystal reports işlemlerinin yapıldığı yer
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Giris.genelParametreler.CrystalKullan == "Y")
            {
                Print();
            }
            else
            {
                if (pictureBarcode.Image == null)
                {
                    CustomMsgBox.Show("BARKOD OLUŞTURULMADAN YAZDIRMA İŞLEMİ YAPILAMAZ.", "Uyarı", "TAMAM", "");
                    return;
                }
                try
                {
                    yazdirMik = Convert.ToInt32(txtPrintMik.Value);
                    for (int i = 1; i <= yazdirMik; i++)
                    {
                        PrintDialog myPrinDialog1 = new PrintDialog();
                        System.Drawing.Printing.PrintDocument prnt = new System.Drawing.Printing.PrintDocument();
                        prnt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPageBarcode1);
                        prnt.Print();
                        //MessageBox.Show("Sayı"+i);
                    }
                    txtBarCode.Focus();
                    txtBarCode.Select(0, txtBarCode.Text.Length);
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "Uyarı", "TAMAM", "");
                    return;
                }
            }
        }

        //string ItemCode = "";
        public static string arananItemCode = "";

        private void temizle(bool barkodMu = false)
        {
            if (!barkodMu)
            {
                txtBarCode.Text = "";
            }
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtBag.Text = "";
            numQty.Text = "";
            txtPartyNo.Text = "";
            if (pictureBarcode.Image != null)
            {
                pictureBarcode.Image = null;
            }
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            temizle();
            SelectList nesne = new SelectList("UrunSorgulaBarkod", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                txtItemCode.Text = arananItemCode;
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Text = "TANIMSIZ";
                }

                SelectList.dialogResult = "";
            }
        }

        private void listAllPrinters()
        {
            cmbPrinter.Items.Clear();
            //cmbPrinter.Items.Add("");

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(item);
            }
            //default
            PrintDocument printDocument = new PrintDocument();
            string defaultPrinter = printDocument.PrinterSettings.PrinterName;
            cmbPrinter.SelectedItem = defaultPrinter;
        }

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }

        private void cmbPrinter_SelectedValueChanged(object sender, EventArgs e)
        {
            string pname = this.cmbPrinter.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            #region Barkodu oluşturulmak istenen kalemin son satınalma belgesi numarası getirliyor.

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

            Response respSonSatinalmaBelgesi = aIFTerminalServiceSoapClient1.getSonSatinalmaBelgesiNo(Giris._dbName, txtItemCode.Text, Giris.mKodValue);

            if (respSonSatinalmaBelgesi == null && respSonSatinalmaBelgesi._list.Rows.Count == 0)
            {
                txtSonSatinalmaBelgeNo.Text = "0";
                CustomMsgBox.Show(respSonSatinalmaBelgesi.Desc, "Uyarı", "TAMAM", "");
                return;
            }
            else
            {
                txtSonSatinalmaBelgeNo.Text = respSonSatinalmaBelgesi._list.Rows[0][0].ToString();
            }

            #endregion Barkodu oluşturulmak istenen kalemin son satınalma belgesi numarası getirliyor.
        }

        private void txtPrintMik_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPrintMik, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void numQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(numQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}