using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using Microsoft.Win32;
using System;
using System.Activities.DynamicUpdate;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SiparissizMalGirisi_1 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SiparissizMalGirisi_1(string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

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

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label7.Font.Style);

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label9.Font.Style);

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            dtpDocDate.Font = new Font(dtpDocDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDate.Font.Style);

            dtpDocDueDate.Font = new Font(dtpDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpDocDueDate.Font.Style);

            txtWayBillNo.Font = new Font(txtWayBillNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWayBillNo.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            btnAddPurchaseOrder.Font = new Font(btnAddPurchaseOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddPurchaseOrder.Font.Style);

            btnEkle.Font = new Font(btnEkle.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnEkle.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnItemSearch.Font = new Font(btnItemSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnItemSearch.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgProducts.Font = new Font(dtgProducts.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgProducts.Font.Style);

            cmbWareHouse.Font = new Font(cmbWareHouse.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbWareHouse.Font.Style);

            cmbSuppLier.Font = new Font(cmbSuppLier.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbSuppLier.Font.Style);

            txtSupplierCode.Font = new Font(txtSupplierCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSupplierCode.Font.Style);

            txtSupplier.Font = new Font(txtSupplier.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtSupplier.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtDepoYeri.Font = new Font(txtDepoYeri.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeri.Font.Style);

            txtDepoYeriAdi.Font = new Font(txtDepoYeriAdi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtDepoYeriAdi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtSupplierCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtSupplier.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpDocDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtWayBillNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbWareHouse.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtItemName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtDepoYeri.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtDepoYeriAdi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            //cmbWareHouse.DropDownWidth = cmbWareHouse.Width + btnEkle.Width;
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

        private DataView dtview = new DataView();
        private Response respCmbSupplier = null;
        private DataTable dtProducts = new DataTable();
        private string formName = "";

        private void SiparissizMalGirisi_1_Load(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            txtBarCode.Focus();
            frmName.Text = formName;

            vScrollBar1.Maximum = dtgProducts.RowCount;
            dtProducts.Columns.Add("Kalem Kodu", typeof(string));
            dtProducts.Columns.Add("Kalem Tanımı", typeof(string));
            dtProducts.Columns.Add("Ölçü Birimi", typeof(string));
            dtProducts.Columns.Add("Barkod", typeof(string));
            dtProducts.Columns.Add("Miktar", typeof(double));
            dtProducts.Columns.Add("DepoMiktar", typeof(double));
            dtProducts.Columns.Add("Partili", typeof(string));
            dtProducts.Columns.Add("dtgSira", typeof(int));
            //dtProducts.Columns.Add("DepoKodu", typeof(string));
            dtProducts.Columns.Add("PaletIciKoliAD", typeof(double));
            dtProducts.Columns.Add("KoliIciAD", typeof(double));
            dtProducts.Columns.Add("PaletIciAD", typeof(double));

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtProducts.Columns.Add("DepoYeriId", typeof(string));
                dtProducts.Columns.Add("DepoYeriAdi", typeof(string));
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dtgProducts.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Detay";
            btn.Name = "btnDetail";
            btn.UseColumnTextForButtonValue = true;

            dtgProducts.DataSource = dtProducts;
            dtgProducts.EnableHeadersVisualStyles = false;

            dtgProducts.Columns["DepoMiktar"].Visible = false;
            dtgProducts.Columns["Barkod"].Visible = false;
            dtgProducts.Columns["btnDetail"].Visible = false;
            dtgProducts.Columns["dtgSira"].Visible = false;

            dtgProducts.Columns["Kalem Kodu"].Visible = false;
            dtgProducts.Columns["Partili"].Visible = false;

            dtgProducts.Columns["PaletIciKoliAD"].Visible = false;
            dtgProducts.Columns["KoliIciAD"].Visible = false;
            dtgProducts.Columns["PaletIciAD"].Visible = false;

            dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

            dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
            dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
            dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
            dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
            dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
            dtgProducts.Columns["DepoMiktar"].HeaderText = "STOKTA";
            dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

            dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
            dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
            dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
            dtgProducts.Columns["Miktar"].ReadOnly = true;
            dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
            dtgProducts.Columns["Partili"].ReadOnly = true;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                txtDepoYeri.Visible = false;
                txtDepoYeriAdi.Visible = false;
            }
            else
            {
                dtgProducts.Columns["DepoYeriId"].HeaderText = "DEPO YERI";
                dtgProducts.Columns["DepoYeriAdi"].HeaderText = "DEPO YERI ADI";
            }

            dtgProducts.RowTemplate.Height = 55;
            dtgProducts.ColumnHeadersHeight = 60;

            //dtgProducts.Columns["Kalem Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Ölçü Birimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgProducts.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgProducts.Columns["Partili"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dtgProducts.Columns["Kalem Tanımı"].Width = dtgProducts.Width - dtgProducts.Columns["Ölçü Birimi"].Width -
            //    dtgProducts.Columns["Miktar"].Width - dtgProducts.Columns["DepoMiktar"].Width;

            //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();

            //btn2 = new DataGridViewButtonColumn();
            //dtgProducts.Columns.Add(btn2);
            //btn2.HeaderText = "";
            //btn2.Text = "Sil";
            //btn2.Name = "btnDelete";
            //btn2.UseColumnTextForButtonValue = true;

            vScrollBar1.Maximum = dtgProducts.RowCount + 5;

            foreach (DataGridViewColumn column in dtgProducts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[0].Selected = false;
            }

            //watch.Stop();
            //MessageBox.Show(string.Format("Süre: {0}", watch.Elapsed.TotalMilliseconds));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtview.RowFilter = "CardCode like '%" + cmbSuppLier.Text + "%' or CardName like '%" + cmbSuppLier.Text + "%' or  CardCode = '' or CardName =''";

            cmbSuppLier.DroppedDown = true;
            cmbSuppLier.DataSource = null;
            cmbSuppLier.DisplayMember = "CardName";
            cmbSuppLier.ValueMember = "CardCode";
            cmbSuppLier.DataSource = dtview;

            cmbSuppLier.DroppedDown = true;
        }

        public static List<GoodRecieptPOBatch> goodRecieptPOBatches = new List<GoodRecieptPOBatch>();
        public static string arananItemCode = "";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ItemCode = "";
            //string partili = "";
            string wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();
            double warehouseQty = 0;

            if (wareHouse == "")
            {
                CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            List<dynamic> list = new List<dynamic>();
            string Val = txtBarCode.Text;

            if (Val == "")
            {
                CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                return;
            }

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = new Response();

            if (Val != "TANIMSIZ")
            {
                Val = Giris.UrunKoduBarkod(Val, "Barkod");
                resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse, Giris.mKodValue);
            }
            else
            {
                if (arananItemCode != "")
                {
                    Val = arananItemCode;
                }
                else
                {
                    Val = "";
                }
            }

            if (Val != "TANIMSIZ")
            {
                if (resp._list == null)
                {
                    Val = Giris.UrunKoduBarkod(Val, "Barkod");
                    resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, wareHouse, txtSupplierCode.Text, Giris.mKodValue);
                }
            }

            if (resp._list == null)
            {
                Val = Giris.UrunKoduBarkod(Val, "Barkod");
                resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse, txtSupplierCode.Text, Giris.mKodValue);
            }

            if (resp._list != null)
            {
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    try
                    {
                        resp._list.Columns.Add("DepoYeriId", typeof(string));
                        resp._list.Columns.Add("DepoYeriAdi", typeof(string));
                    }
                    catch (Exception)
                    {
                    }
                }

                foreach (DataRow item in resp._list.Rows)
                {
                    DataRow dr = dtProducts.NewRow();
                    dr["Kalem Kodu"] = item["Kalem Kodu"];
                    dr["Kalem Tanımı"] = item["Kalem Tanımı"];
                    dr["Barkod"] = item["Barkod"];
                    dr["Ölçü Birimi"] = item["Ölçü Birimi"];
                    dr["DepoMiktar"] = item["Depo Miktari"];
                    dr["Partili"] = item["Partili"];

                    dr["PaletIciKoliAD"] = item["PaletIciKoliAD"];
                    dr["KoliIciAD"] = item["KoliIciAD"];
                    dr["PaletIciAD"] = item["PaletIciAD"];
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        dr["DepoYeriId"] = txtDepoYeri.Text.ToString();
                        dr["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();

                        item["DepoYeriId"] = txtDepoYeri.Text.ToString();
                        item["DepoYeriAdi"] = txtDepoYeriAdi.Text.ToString();
                    }
                    //dr["DepoKodu"] = wareHouse;
                    partili = item["Partili"].ToString();

                    ItemCode = item["Kalem Kodu"].ToString();
                    list.Add(item["Kalem Kodu"]);
                    list.Add(item["Kalem Tanımı"]);
                    list.Add(item["Barkod"]);
                    list.Add(item["Ölçü Birimi"]);
                    list.Add(item["Depo Miktari"]);

                    list.Add(item["PaletIciKoliAD"]);
                    list.Add(item["KoliIciAD"]);
                    list.Add(item["PaletIciAD"]);
                    if (dtgProducts.Columns.Contains("DepoKodu") != true)
                    {
                        addcombo();
                        dtgProducts.Columns["DepoKodu"].ReadOnly = false;
                    }

                    if (!doubleclick)
                    {
                        dtProducts.Rows.Add(dr);
                    }

                    //dtProducts.AcceptChanges();
                    (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = wareHouse;
                }

                if (partili == "Y")
                {
                    if (!doubleclick)
                    {
                        currentRow = dtProducts.Rows.Count;
                    }

                    list.Add(wareHouse);
                    SiparisliMalGirisi_3 n = new SiparisliMalGirisi_3("20", list, "SİPARİŞSİZ MAL GİRİŞİ");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    if (SiparisliMalGirisi_3.dialogresult != "Ok")
                    {
                        if (!doubleclick)
                        {
                            dtProducts.Rows.RemoveAt(currentRow - 1);
                            dtgProducts.Refresh();
                        }
                    }
                    else
                    {
                        var quantity = goodRecieptPOBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                        dtgProducts.Refresh();
                    }

                    SiparisliMalGirisi_3.dialogresult = "";
                }
                else
                {
                    wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();

                    if (wareHouse == "")
                    {
                        CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                    list = new List<dynamic>();
                    Val = txtBarCode.Text;

                    if (Val == "")
                    {
                        CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    //aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    //resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

                    //if (resp._list == null)
                    //{
                    //    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
                    //}
                    if (!doubleclick)
                    {
                        currentRow = dtgProducts.Rows.Count;
                    }

                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());

                    var toplananmiktar = dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgProducts.Rows[currentRow - 1].Cells["Miktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        list.Add(resp._list.Rows[0]["DepoYeriId"]);
                        list.Add(resp._list.Rows[0]["DepoYeriAdi"]);
                        list.Add((dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                        list.Add((dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value.ToString());
                    }
                    txtBarCode.Text = "";
                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("20", list, "SİPARİŞSİZ MAL GİRİŞİ");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dtProducts.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            dtProducts.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                            (dtgProducts.Rows[dtgProducts.Rows.Count - 1].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = PartisizKalemSecimi.depoKodu;
                            PartisizKalemSecimi.depoYeriId = "";
                            PartisizKalemSecimi.depoYeriAdi = "";
                        }
                        dtProducts.Rows[currentRow - 1]["Miktar"] = PartisizKalemSecimi.quantity;
                        PartisizKalemSecimi.dialogresult = "";
                        dtgProducts.Rows[currentRow - 1].Selected = false;
                    }
                    else
                    {
                        if (!doubleclick)
                        {
                            dtProducts.Rows.RemoveAt(currentRow - 1);
                            dtgProducts.Refresh();
                            //dtgProducts.DataSource = dtProducts;
                        }
                    }

                    partili = "";
                    barcode = "";
                }

                //dtgProducts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgProducts.AutoResizeRows();
                //dtgProducts.Columns["DepoKodu"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
                dtgProducts.Columns["DepoKodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgProducts.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                txtBarCode.Focus();
                txtBarCode.Text = "";
                cmbItemName.Text = "";
                arananItemCode = "";
                txtItemName.Text = "";

                btnItemSearch.PerformClick();
                cmbItemName.DroppedDown = false;
                vScrollBar1.Maximum = dtgProducts.RowCount + 5;
                try
                {
                    if (dtgProducts.Rows.Count > 0)
                    {
                        dtgProducts.Rows[currentRow - 1].Selected = false;
                    }
                    else
                    {
                        txtBarCode.Select(0, txtBarCode.Text.Length);

                        //CustomMsgBox.Show(resp.Desc, "Uyarı", "TAMAM", "");
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        private void addcombo()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response r = null;
            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                r = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_BlgszMalGrs", Giris.mKodValue);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(r._list);

            DataGridViewComboBoxColumn comboLookup = new DataGridViewComboBoxColumn();
            comboLookup.DataSource = ds.Tables[0];
            comboLookup.HeaderText = "DEPO";
            comboLookup.Name = "DepoKodu";
            comboLookup.DisplayMember = "WhsName";
            comboLookup.ValueMember = "WhsCode";
            dtgProducts.Columns.Add(comboLookup);
            //comboLookup.Width = 55;
            //comboLookup.FillWeight = 55;
        }

        private void btnAddPurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProducts.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                if (txtSupplierCode.Text == "")
                {
                    CustomMsgBox.Show("LÜTFEN TEDARİKÇİ SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                    return;
                }
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                GoodRecieptPO goodRecieptPO = new GoodRecieptPO();
                GoodRecieptPODetails goodRecieptPODetails = new GoodRecieptPODetails();
                List<GoodRecieptPODetails> goodRecieptPODetails1 = new List<GoodRecieptPODetails>();
                List<GoodRecieptPOBatchList> goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                int index = 0;
                goodRecieptPO.CarCode = txtSupplierCode.Text;
                goodRecieptPO.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");
                goodRecieptPO.DocDueDate = dtpDocDueDate.Value.ToString("yyyyMMdd");
                goodRecieptPO.WayBillNo = txtWayBillNo.Text;
                foreach (DataRow items in dtProducts.Rows)
                {
                    if (items["Miktar"].ToString() == "0")
                    {
                        continue;
                    }

                    goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
                    foreach (var aifx in goodRecieptPOBatches.Where(x => x.ItemCode == items["Kalem Kodu"].ToString() && x.LineNumber == i))
                    {
                        goodRecieptPOBatchList1.Add(new GoodRecieptPOBatchList
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            BinCode = aifx.DepoYeriId
                        });
                    }

                    goodRecieptPODetails1.Add(new GoodRecieptPODetails
                    {
                        BatchLists = goodRecieptPOBatchList1.ToArray(),
                        ItemCode = items["Kalem Kodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["Miktar"]), Giris.genelParametreler.OndalikMiktar),
                        WareHouse = dtgProducts.Rows[index].Cells["DepoKodu"].Value.ToString(),
                        BinCode = Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtgProducts.Rows[index].Cells["DepoYeriId"].Value.ToString() : "",
                    });

                    goodRecieptPO.GoodRecieptPODetails = goodRecieptPODetails1.ToArray();
                    i++;
                    index++;
                }

                if (goodRecieptPO.GoodRecieptPODetails.Count() == 0)
                {
                    CustomMsgBox.Show("BELGENİN TÜM SATIRLARI 0 OLDUĞUNDAN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                }

                var resp1 = aIFTerminalServiceSoapClient1.AddGoodRecieptPO(Giris._dbName, Convert.ToInt32(Giris._userCode), goodRecieptPO);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
                    Close();
                }

                #region Purchase Order

                //    List<PurchaseOrdersDetails> purchaseOrdersDetails1 = new List<PurchaseOrdersDetails>();
                //    PurchaseOrders purchaseOrders = new PurchaseOrders();

                //    //txtsupplier boş olmama kontrolü yaz. Cihan
                //    purchaseOrders.CarCode = txtSupplier.Text;
                //    purchaseOrders.DocDate = dtpDocDate.Value.ToString("yyyyMMdd");
                //    purchaseOrders.DocDueDate = dtpDocDueDate.Value.ToString("yyyyMMdd");

                //    //datagridview'e bağlı datatable row count 0 'dan büyükse kontrolü yaz Cihan.
                //    foreach (DataRow item in dtProducts.Rows)
                //    {
                //        purchaseOrdersDetails1.Add(new PurchaseOrdersDetails
                //        {
                //            ItemCode = item["Kalem Kodu"].ToString(),
                //            Quantity = Convert.ToDouble(item["Miktar"])
                //        });
                //    }

                //    purchaseOrders.PurchaseOrdersDetails = purchaseOrdersDetails1.ToArray();

                //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                //    Response resp = aIFTerminalServiceSoapClient.AddPurchaseOrder(Giris._dbName, purchaseOrders);

                //    MessageBox.Show(resp.Desc);

                #endregion Purchase Order
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void dtgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                List<dynamic> list = new List<dynamic>();
                if (senderGrid.Columns[e.ColumnIndex].Name == "btnDetail")
                {
                    if (partili != "Y")
                    {
                        CustomMsgBox.Show("PARTİ TAKİBİ YAPILMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    currentRow = dtProducts.Rows.Count;

                    string ItemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Barkod"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["Ölçü Birimi"].ToString());
                    list.Add(dtProducts.Rows[e.RowIndex]["DepoMiktar"].ToString());

                    SiparisliMalGirisi_3 n = new SiparisliMalGirisi_3("20", list, "SİPARİŞSİZ MAL GİRİŞİ");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = goodRecieptPOBatches.Where(x => x.ItemCode == ItemCode && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtProducts.Rows[currentRow - 1]["Miktar"] = quantity;
                }
            }
        }

        private void cmbWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtgProducts.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("TÜM DEPOLARI DEĞİŞTİRMEYİ İSTİYOR MUSUNUZ?", "DEPO DEĞİŞİMİ", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                    {
                        (dtgProducts.Rows[i].Cells["DepoKodu"] as DataGridViewComboBoxCell).Value = cmbWareHouse.SelectedValue;
                    }
                }
                else
                {
                }
            }

            txtBarCode.Focus();
        }

        public static bool enter = false;

        private void cmbWareHouse_Click(object sender, EventArgs e)
        {
            cmbWareHouse.DroppedDown = true;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEkle.PerformClick();
            }
            return;
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();
                if (txtBarCode.Text != "")
                {
                    //if (partili == "Y")
                    //{
                    //}

                    //if (dtProducts.Rows.Count == 0)
                    //{
                    //    string wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();
                    //    string Val = txtBarCode.Text;
                    //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                    //    Response resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

                    //    if (resp._list == null)
                    //    {
                    //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
                    //    }

                    //    dtProducts = resp._list;

                    //    dtProducts.Columns.Add("dtgSira", typeof(int));
                    //    for (int i = 0; i <= dtgProducts.Rows.Count - 1; i++)
                    //    {
                    //        dtgProducts.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                    //    }

                    //}
                    //    var exits = dtProducts.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).ToList();

                    //    if (exits.Count > 0)
                    //    {
                    //        var dtgSira = dtProducts.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                    //        var arg = new DataGridViewCellEventArgs(dtProducts.Rows.Count, dtgSira);
                    //        dtgProducts_CellClick(dtgProducts, arg);

                    //        dtgProducts.ClearSelection();

                    //        dtgProducts.Rows[dtgSira].Cells[0].Selected = true;
                    //        btnEkle.PerformClick();
                    //    }
                    //    else
                    //    {
                    //        CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                    //        txtBarCode.Focus();
                    //        txtBarCode.Select(0, txtBarCode.Text.Length);
                    //        return;

                    //    }
                    //}
                    //else
                    //{
                    //    CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                    //    txtBarCode.Focus();
                    //    txtBarCode.Select(0, txtBarCode.Text.Length);
                    //    return;
                }
            }
        }

        public static int sapLineNum = 0;
        private int DocEntry = -1;
        private string barcode = "";
        private string partili = "";
        private string itemCode = "";
        private string itemName = "";
        public static int currentRow = 0;
        private double acceptqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;

        private double topMik = 0;

        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                partili = dtProducts.Rows[e.RowIndex]["Partili"].ToString();
                barcode = dtProducts.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtProducts.Rows[e.RowIndex]["Kalem Kodu"].ToString();
                itemName = dtProducts.Rows[e.RowIndex]["Kalem Tanımı"].ToString();
                //sapLineNum = Convert.ToInt32(dtProducts.Rows[e.RowIndex]["dtgSira"]);

                acceptqty = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? 0 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
                txtBarCode.Text = barcode == "" ? itemCode : barcode;
                currentRow = e.RowIndex + 1;

                paletIciKoliAD = dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtProducts.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtProducts.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtProducts.Rows[e.RowIndex]["Miktar"].ToString() == "" ? -1 : Convert.ToDouble(dtProducts.Rows[e.RowIndex]["Miktar"]);
            }
        }

        private void cmbWareHouse_DropDown(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp1 = null;

            if (Giris.genelParametreler.DepoCalismaTipi == "1")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "", Giris.mKodValue);
            }
            else if (Giris.genelParametreler.DepoCalismaTipi == "2")
            {
                resp1 = aIFTerminalServiceSoapClient.GetWareHouseByUserCode(Giris._dbName, Giris._userCode, "U_BlgszMalGrs", Giris.mKodValue);
            }

            if (resp1.Val == 0)
            {
                if (resp1._list.Rows.Count > 0)
                {
                    cmbWareHouse.DataSource = resp1._list;
                    cmbWareHouse.DisplayMember = "WhsName";
                    cmbWareHouse.ValueMember = "WhsCode";
                    cmbWareHouse.Enabled = true;
                }
            }
        }

        private void cmbSuppLier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuppLier.SelectedIndex > 0)
            {
                string code = cmbSuppLier.SelectedValue.ToString();
                txtSupplierCode.Text = code;
                txtWayBillNo.Focus();
            }
            else
            {
                //cmbSuppLierName.DroppedDown = true;
                txtSupplierCode.Text = "";
            }
        }

        private void cmbSuppLier_DropDown(object sender, EventArgs e)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp2 = aIFTerminalServiceSoapClient.GetBusinessVendorPartner(Giris._dbName, Giris.mKodValue);

            if (resp2.Val == 0)
            {
                if (resp2._list.Rows.Count > 0)
                {
                    respCmbSupplier = resp2;
                    dtview = new DataView(resp2._list);
                    cmbSuppLier.DataSource = resp2._list;
                    cmbSuppLier.DisplayMember = "CardName";
                    cmbSuppLier.ValueMember = "CardCode";
                    cmbSuppLier.Enabled = true;

                    //cmbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        private bool doubleclick = false;

        private void dtgProducts_DoubleClick(object sender, EventArgs e)
        {
            //if (partili == "Y")
            //{
            doubleclick = true;
            btnEkle.PerformClick();
            partili = "";
            barcode = "";
            doubleclick = false;
            return;
            //}
            //else
            //{
            //    string wareHouse = cmbWareHouse.SelectedValue == null ? "" : cmbWareHouse.SelectedValue.ToString();

            //    if (wareHouse == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }
            //    List<dynamic> list = new List<dynamic>();
            //    string Val = txtBarCode.Text;

            //    if (Val == "")
            //    {
            //        CustomMsgBox.Show("LÜTFEN BARKOD BİLGİSİ VEYA ÜRÜN BİLGİSİ GİRİNİZ.", "Uyarı", "Tamam", "");
            //        return;
            //    }

            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //    Response resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, wareHouse);

            //    if (resp._list == null)
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, wareHouse);
            //    }

            //    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
            //    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
            //    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
            //    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
            //    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), 4));
            //    list.Add(Math.Round(acceptqty, 4).ToString());

            //    txtBarCode.Text = "";
            //    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("20", list, "SİPARİŞSİZ MAL GİRİŞİ");
            //    partisizKalemSecimi.ShowDialog();

            //    if (PartisizKalemSecimi.dialogresult == "Ok")
            //    {
            //        dtProducts.Rows[currentRow]["Miktar"] = PartisizKalemSecimi.quantity;
            //        PartisizKalemSecimi.dialogresult = "";
            //    }
            //    dtgProducts.Rows[currentRow].Selected = false;

            //    partili = "";
            //    barcode = "";
            //}
        }

        private DataTable dtProductsItem = new DataTable();

        private DataView dtViewItem = new DataView();

        private void GetAllProducts()
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetAllProducts(Giris._dbName, Giris.mKodValue);

            if (resp.Val == 0)
            {
                if (resp._list.Rows.Count > 0)
                {
                    dtProductsItem = resp._list;
                    dtViewItem = new DataView(resp._list);
                }
                //vScrollBar1.Maximum = dtgProducts.RowCount + 10;
            }
        }

        private void cmbItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue != null)
            {
                var value = cmbItemName.SelectedValue.ToString();

                if (value != "")
                {
                    if (dtProductsItem.Rows.Count > 0)
                    {
                        var listProducts = dtProductsItem.AsEnumerable().Where(x => x.Field<string>("ItemCode") == value).ToList();

                        var itemCode = listProducts.Select(x => x.Field<string>("ItemCode")).First();
                        var barcode = listProducts.Select(x => x.Field<string>("CodeBars")).First();

                        if (barcode != "" && barcode != null)
                        {
                            txtBarCode.Text = barcode;
                        }
                        else
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }

                        dtgProducts.DataSource = dtProducts;

                        dtgProducts.Columns["DepoMiktar"].Visible = false;
                        dtgProducts.Columns["Barkod"].Visible = false;
                        dtgProducts.Columns["btnDetail"].Visible = false;
                        dtgProducts.Columns["dtgSira"].Visible = false;

                        dtgProducts.Columns["Kalem Kodu"].Visible = false;
                        dtgProducts.Columns["Partili"].Visible = false;

                        dtgProducts.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgProducts.Columns["Kalem Kodu"].HeaderText = "KALEM KODU";
                        dtgProducts.Columns["Kalem Tanımı"].HeaderText = "KALEM ADI";
                        dtgProducts.Columns["Ölçü Birimi"].HeaderText = "BRM";
                        dtgProducts.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgProducts.Columns["Miktar"].HeaderText = "MİKTAR";
                        dtgProducts.Columns["DepoMiktar"].HeaderText = "STOKTA";
                        dtgProducts.Columns["Partili"].HeaderText = "PARTİLİ";

                        dtgProducts.RowTemplate.Height = 55;

                        dtgProducts.Columns["Kalem Kodu"].ReadOnly = true;
                        dtgProducts.Columns["Kalem Tanımı"].ReadOnly = true;
                        dtgProducts.Columns["Ölçü Birimi"].ReadOnly = true;
                        dtgProducts.Columns["Miktar"].ReadOnly = true;
                        dtgProducts.Columns["DepoMiktar"].ReadOnly = true;
                        dtgProducts.Columns["Partili"].ReadOnly = true;

                        btnEkle.PerformClick();
                    }
                }
            }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
            {
                CustomMsgBox.Show("LÜTFEN GİRİŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }
            GetAllProducts();
            if (dtProductsItem.Rows.Count > 0)
            {
                dtViewItem.RowFilter = "ItemName = '' or ItemName like '%" + cmbItemName.Text + "%'";

                //cmbItemName.DroppedDown = true;
                cmbItemName.DataSource = null;

                if (dtViewItem.Count > 0)
                {
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemCode";
                    cmbItemName.DataSource = dtViewItem;

                    cmbItemName.DroppedDown = true;
                }
                else
                {
                    CustomMsgBox.Show("ARAMA SONUCU EŞLEŞEN KAYIT BULUNAMAMIŞTIR.", "Uyarı", "TAMAM", "");
                }
            }
        }

        private void dtgProducts_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgProducts.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = goodRecieptPOBatches.Where(x => x.ItemCode == itemCode).ToList();
            //if (partiler.Count == 0)
            //{
            //    CustomMsgBox.Show("PARTİ GİRİŞİ YAPILMAMIŞTIR.", "Uyarı", "TAMAM", "");
            //    return;
            //}
            if (txtBarCode.Text == "")
            {
                CustomMsgBox.Show("BARKOD VEYA KALEM KODU GİRİNİZ.", "Uyarı", "TAMAM", "");
                txtBarCode.Focus();
                txtBarCode.Select(0, txtBarCode.Text.Length);
                return;
            }
            string Val = txtBarCode.Text;

            if (partili == "Y")
            {
                if (partiler.Count > 0)
                {
                    foreach (var item in partiler)
                    {
                        #region BarCode = Val == itemCode ? "Tanımsız" : barcode ----vardı değiştirdim

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                        #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode ----vardı değiştirdim

                        if (Val == "Tanımsız")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            if (barcode == "")
                            {
                                ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                            }
                            else
                            {
                                ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                            }
                        }
                    }
                }
                else
                {
                    #region BarCode = Val == itemCode ? "Tanımsız" : barcode vardı değiştirdim

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                    #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode vardı değiştirdim

                    if (Val == "Tanımsız")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        if (barcode == "")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                    }
                }
            }
            else
            {
                #region BarCode = Val == itemCode ? "Tanımsız" : barcode vardı değiştirdim

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode vardı değiştirdim

                if (Val == "Tanımsız")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
                else
                {
                    if (barcode == "")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                }
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("20", ListParties, "SİPARİSSİZ MAL GİRİSİ");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();
            if (dtgProducts.Rows.Count > 0)
            {
                dtgProducts.Rows[currentRow - 1].Selected = false;
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void dtgProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is ComboBox comboBox)
            //{
            //    comboBox.SelectedIndexChanged += (a, b) =>
            //    {
            //        //comboBox.Dock = DockStyle.Fill;
            //        comboBox.Size = new Size(121, 65);
            //        //comboBox.Cursor = Cursors.Arrow;
            //        //Cursor.Current = Cursors.Arrow;

            //    };
            //}
        }

        private void txtSupplier_Click(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("20", "TedarikciAra", "TEDARİKÇİ ARAMA", txtSupplierCode, txtSupplier);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            if (cmbWareHouse.SelectedValue == "" || cmbWareHouse.SelectedValue == null)
            {
                CustomMsgBox.Show("LÜTFEN GİRİŞ DEPO SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }

            if (txtSupplier.Text == "")
            {
                CustomMsgBox.Show("LÜTFEN TEDARİKÇİ SEÇİMİ YAPINIZ.", "Uyarı", "Tamam", "");
                return;
            }

            SelectList nesne = new SelectList("20", "KalemAra", "KALEM ARAMA", txtBarCode, txtItemName);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                if (txtBarCode.Text == "")
                {
                    txtBarCode.Text = "TANIMSIZ";
                }
                btnEkle.PerformClick();
                SelectList.dialogResult = "";
            }
        }

        private void txtDepoYeri_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cmbWareHouse.SelectedValue.ToString();
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtDepoYeri, txtDepoYeriAdi, t);
                nesne.ShowDialog();
                nesne.Dispose();
                GC.Collect();

                if (SelectList.dialogResult == "Ok")
                {
                    SelectList.dialogResult = "";
                }
            }
            catch (Exception)
            {
            }
        }
    }
}