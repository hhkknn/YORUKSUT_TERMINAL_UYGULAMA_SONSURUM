using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class SiparisliMalGirisi_2 : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        public SiparisliMalGirisi_2(List<PurchaseOrderList> purchaseOrderList, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            //end font
            formName = _formName;

            PurchaseOrderList = purchaseOrderList;

            if (PurchaseOrderList != null)
            {
                txtVendorCode.Text = purchaseOrderList[0].VendorCardCode;
                txtVendorName.Text = purchaseOrderList[0].VendorName;

                var max = PurchaseOrderList.OrderByDescending(t => t.TaxDate)
                   .FirstOrDefault();

                dtpOrderTaxDate.Value = new DateTime(Convert.ToInt32(max.TaxDate.Substring(0, 4)), Convert.ToInt32(max.TaxDate.Substring(4, 2)), Convert.ToInt32(max.TaxDate.Substring(6, 2)));
                dtpOrderDocDueDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));

                List<string> docEntryList = new List<string>();
                foreach (var item in PurchaseOrderList)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }

                GetPurchaseOrderDetails(docEntryList);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

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

            lblItemName.Font = new Font(lblItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblItemName.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtVendorCode.Font = new Font(txtVendorCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtVendorCode.Font.Style);

            txtVendorName.Font = new Font(txtVendorName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtVendorName.Font.Style);

            dtpOrderDocDueDate.Font = new Font(dtpOrderDocDueDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpOrderDocDueDate.Font.Style);

            dtpOrderTaxDate.Font = new Font(dtpOrderTaxDate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpOrderTaxDate.Font.Style);

            txtWayBillNo.Font = new Font(txtWayBillNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWayBillNo.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            btnSearch.Font = new Font(btnSearch.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSearch.Font.Style);

            btnAddOrUpdate.Font = new Font(btnAddOrUpdate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnAddOrUpdate.Font.Style);

            btnBarkodGoster.Font = new Font(btnBarkodGoster.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodGoster.Font.Style);

            dtgDetails.Font = new Font(dtgDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgDetails.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtVendorCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtVendorName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpOrderDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpOrderTaxDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtWayBillNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        private List<PurchaseOrderList> PurchaseOrderList = new List<PurchaseOrderList>();

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
        private Color defaultColor = Color.White;

        private void SiparisliMalGirisi_2_Load(object sender, EventArgs e)
        {
            defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;
            //cmbItemName.Font = new Font("Tahoma", 26);

            goodRecieptPOBatches = new List<GoodRecieptPOBatch>();

            frmName.Text = formName.ToUpper();
            //btnColumnsWidth.Visible = false;
            txtBarCode.Focus();

            dtgDetails.Columns["btnDetail"].Visible = false;
            dtgDetails.Columns["Barkod"].Visible = false;
            dtgDetails.Columns["Partili"].Visible = false;
            dtgDetails.Columns["DepoKodu"].Visible = false;
            dtgDetails.Columns["SiraNo"].Visible = false;
            //new
            dtgDetails.Columns["BelgeNumarasi"].Visible = false;
            dtgDetails.Columns["KalemKodu"].Visible = false;

            dtgDetails.Columns["PaletIciKoliAD"].Visible = false;
            dtgDetails.Columns["KoliIciAD"].Visible = false;
            dtgDetails.Columns["PaletIciAD"].Visible = false;
            dtgDetails.Columns["MuhatapKatalogNo"].Visible = false;
            dtgDetails.Columns["DepoTanimi"].Visible = false;

            //new

            dtgDetails.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["DepoMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["Miktar"].Width -
                dtgDetails.Columns["ToplananMiktar"].Width - dtgDetails.Columns["DepoMiktar"].Width;

            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;

            vScrollBar1.Maximum = dtgDetails.RowCount + 5;
            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[0].Selected = false;

                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    dtgDetails.Rows[i].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;

                //}
            }

            //btnColumnsWidth.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtVendorName.Text != "")
            {
                if (txtBarCode.Text == "")
                {
                    CustomMsgBox.Show("BARKOD GİRİŞİ YAPILMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }
            }

            if (partili != "Y")
            {
                //CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                //txtBarCode.Text = "";
                //return;

                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
                Val = Giris.UrunKoduBarkod(Val, "Barkod");
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), Giris.mKodValue);
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        if (Val != "")
                        {
                            //Val = cmbItemName.SelectedValue.ToString();
                            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                        }
                    }
                }
                else
                {
                    if (resp._list == null)
                    {
                        Val = cmbItemName.SelectedValue.ToString();
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);

                    string brkd = "";
                    if (resp._list.Rows[0]["Barkod"].ToString() == "" && resp._list.Rows[0]["MuhatapKatalogNo"].ToString() == "")
                    {
                        brkd = "Tanımsız";
                    }
                    else if (resp._list.Rows[0]["Barkod"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["Barkod"].ToString();
                    }
                    else if (resp._list.Rows[0]["MuhatapKatalogNo"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                    }

                    list.Add(brkd);

                    //list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(depoTanimi);
                    list.Add(warehouse);
                    list.Add(depoYeriId);
                    list.Add(depoYeriAdi);

                    txtBarCode.Text = "";
                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("22", list, "SİPARİŞLİ MAL GİRİŞİ");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        dtDetails.Rows[currentRow]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dtDetails.Rows[currentRow]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            PartisizKalemSecimi.depoYeriId = "";
                        }
                        PartisizKalemSecimi.dialogresult = "";
                    }
                    dtgDetails.Rows[currentRow].Selected = false;
                }

                partili = "";
                barcode = "";
            }
            else
            {
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
                Val = Giris.UrunKoduBarkod(Val, "Barkod");
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = new Response();

                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), Giris.mKodValue);
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        if (Val != "")
                        {
                            //Val = cmbItemName.SelectedValue.ToString();
                            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                        }
                    }
                }
                else
                {
                    if (resp._list == null)
                    {
                        Val = cmbItemName.SelectedValue.ToString();
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);

                    string brkd = "";
                    if (resp._list.Rows[0]["Barkod"].ToString() == "" && resp._list.Rows[0]["MuhatapKatalogNo"].ToString() == "")
                    {
                        brkd = "Tanımsız";
                    }
                    else if (resp._list.Rows[0]["Barkod"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["Barkod"].ToString();
                    }
                    else if (resp._list.Rows[0]["MuhatapKatalogNo"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                    }

                    list.Add(brkd);

                    //string barcode = resp._list.Rows[0]["Barkod"] == null || resp._list.Rows[0]["Barkod"].ToString() == "" ? resp._list.Rows[0]["MuhatapKatalogNo"].ToString() : resp._list.Rows[0]["Barkod"].ToString();
                    //list.Add(barcode);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(warehouse);
                    SiparisliMalGirisi_3 siparisliMalGirisi_3 = new SiparisliMalGirisi_3("22", list, "SİPARİŞLİ MAL GİRİŞİ");
                    siparisliMalGirisi_3.ShowDialog();
                    siparisliMalGirisi_3.Dispose();
                    GC.Collect();
                    //this.Hide();

                    if (SiparisliMalGirisi_3.dialogresult == "Ok")
                    {
                        var quantity = goodRecieptPOBatches.Where(x => x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtDetails.Rows[currentRow]["ToplananMiktar"] = quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
                        SiparisliMalGirisi_3.dialogresult = "";
                    }
                    dtgDetails.Rows[currentRow].Selected = false;
                }
            }

            //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgDetails.AutoResizeRows();
            txtBarCode.Focus();
            txtBarCode.Text = "";
            cmbItemName.Text = "";

            btnSearch.PerformClick();
            cmbItemName.DroppedDown = false;
        }

        private DataTable dtDetails = new DataTable();

        private void GetPurchaseOrderDetails(List<string> docentryList)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetPurchaseOrdersDetails(Giris._dbName, docentryList.ToArray(), Giris.whsCodes.ToArray(), Giris.mKodValue);

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgDetails.DataSource = null;

                dtDetails.Columns.Add("ToplananMiktar", typeof(double));
                dtDetails.Columns.Add("dtgSira", typeof(int));

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgDetails.Columns.Add(btn);
                //dtgDetails.Columns[dtgDetails.ColumnCount - 1].DisplayIndex = dtgDetails.Columnscount-1;
                btn.HeaderText = "";
                btn.Text = "Detay";
                btn.Name = "btnDetail";

                btn.UseColumnTextForButtonValue = true;

                dtgDetails.DataSource = dtDetails;

                dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                dtgDetails.Columns["BelgeNumarasi"].ReadOnly = true;
                dtgDetails.Columns["KalemKodu"].ReadOnly = true;
                dtgDetails.Columns["KalemAdi"].ReadOnly = true;
                dtgDetails.Columns["Miktar"].ReadOnly = true;
                dtgDetails.Columns["Barkod"].ReadOnly = true;
                dtgDetails.Columns["Partili"].ReadOnly = true;
                dtgDetails.Columns["OlcuBirimi"].ReadOnly = true;
                dtgDetails.Columns["DepoMiktar"].ReadOnly = true;
                dtgDetails.Columns["ToplananMiktar"].ReadOnly = true;
                dtgDetails.Columns["MuhatapKatalogNo"].ReadOnly = true;
                dtgDetails.Columns["DepoTanimi"].ReadOnly = true;
                dtgDetails.Columns["DepoYeriId"].ReadOnly = true;
                dtgDetails.Columns["DepoYeriAdi"].ReadOnly = true;

                dtgDetails.Columns["btnDetail"].DisplayIndex = 0;
                dtgDetails.Columns["BelgeNumarasi"].DisplayIndex = 1;
                dtgDetails.Columns["KalemKodu"].DisplayIndex = 2;
                dtgDetails.Columns["KalemAdi"].DisplayIndex = 3;
                dtgDetails.Columns["OlcuBirimi"].DisplayIndex = 4;//5
                dtgDetails.Columns["Barkod"].DisplayIndex = 5;
                dtgDetails.Columns["Miktar"].DisplayIndex = 6;//4
                dtgDetails.Columns["ToplananMiktar"].DisplayIndex = 7;//11
                dtgDetails.Columns["Partili"].DisplayIndex = 8;
                dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                dtgDetails.Columns["SiraNo"].DisplayIndex = 10;
                dtgDetails.Columns["DepoMiktar"].DisplayIndex = 11;//10
                dtgDetails.Columns["MuhatapKatalogNo"].DisplayIndex = 12;
                dtgDetails.Columns["DepoTanimi"].DisplayIndex = 13;
                dtgDetails.Columns["DepoYeriId"].DisplayIndex = 14;
                dtgDetails.Columns["DepoYeriAdi"].DisplayIndex = 15;

                dtgDetails.Columns["BelgeNumarasi"].HeaderText = "BELGE NO";
                dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                dtgDetails.Columns["ToplananMiktar"].HeaderText = "GEL.MİK";
                dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                dtgDetails.Columns["Miktar"].HeaderText = "SİP.MİK";
                dtgDetails.Columns["DepoMiktar"].HeaderText = "STOK";
                dtgDetails.Columns["MuhatapKatalogNo"].HeaderText = "KAT.NO";
                dtgDetails.Columns["DepoTanimi"].HeaderText = "DEPO TAN.";

                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (Giris.genelParametreler.DepoYeriCalisir != "Y")
                {
                    dtgDetails.Columns["DepoYeriId"].Visible = false;
                    dtgDetails.Columns["DepoYeriAdi"].Visible = false;
                }
                dtgDetails.RowTemplate.Height = 55;

                //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeRows();
                //dtgDetails.AutoResizeColumns();

                //vScrollBar1.Maximum = dtgDetails.RowCount = + 5;
                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    var partili = dtgDetails.Rows[i].Cells["Partili"].Value;

                //    if (partili.ToString() == "Y")
                //    {
                //        dtgDetails.Rows[i].Cells["Toplanan Miktar"].ReadOnly = true;
                //    }
                //}

                for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                {
                    dtgDetails.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                dtgDetails.Columns["dtgSira"].Visible = false;

                foreach (DataGridViewColumn column in dtgDetails.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
                //dtgDetails.Columns["KalemAdi"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeRows();
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        public static int sapLineNum = 0;
        public static int DocEntry = 0;
        private string warehouse = "";
        private string itemCode = "";
        private string itemName = "";
        private string barcode = "";
        private string partili = "";
        private string depoTanimi = "";
        private string depoYeriId = "";
        private string depoYeriAdi = "";
        private double orderqty = 0;
        private double acceptqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;

        private double topMik = 0;

        public static List<GoodRecieptPOBatch> goodRecieptPOBatches = new List<GoodRecieptPOBatch>();
        public static int currentRow = 0;

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtDetails.Rows[e.RowIndex]["Barkod"].ToString() == "" ? dtDetails.Rows[e.RowIndex]["MuhatapKatalogNo"].ToString() : dtDetails.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString();
                warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                depoTanimi = dtDetails.Rows[e.RowIndex]["DepoTanimi"].ToString();
                depoYeriId = dtDetails.Rows[e.RowIndex]["DepoYeriId"].ToString();
                depoYeriAdi = dtDetails.Rows[e.RowIndex]["DepoYeriAdi"].ToString();
                orderqty = Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Miktar"]);
                partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex;
                DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                sapLineNum = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["SiraNo"]);
                acceptqty = dtDetails.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? 0 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["ToplananMiktar"]);

                paletIciKoliAD = dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtDetails.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtDetails.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciAD"]);

                topMik = dtDetails.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["ToplananMiktar"]);
            }
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDetails.Rows.Count == 0)
                {
                    //ne uyarısı yazılabilir buraya?
                    //CustomMsgBox.Show("Lütfen Çıkış Depo Seçimi Yapınız.", "Uyarı", "Tamam", "");
                    return;
                }
                //if (txtBarCode.Text == "")
                //{
                //    CustomMsgBox.Show("Lütfen Barkod Girişi Yapınız.", "Uyarı", "Tamam", "");
                //    txtBarCode.Focus();
                //    return;
                //}
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
                goodRecieptPO.CarCode = txtVendorCode.Text;
                //goodRecieptPO.DocDate = dtpOrderDocDate.Value.ToString("yyyyMMdd");
                //goodRecieptPO.DocDueDate = dtpOrderDocDueDate.Value.ToString("yyyyMMdd");
                goodRecieptPO.DocDate = DateTime.Now.ToString("yyyyMMdd");
                goodRecieptPO.DocDueDate = DateTime.Now.ToString("yyyyMMdd");
                goodRecieptPO.WayBillNo = txtWayBillNo.Text;

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["ToplananMiktar"].ToString() == "0" || items["ToplananMiktar"].ToString() == "")
                    {
                        continue;
                    }

                    goodRecieptPOBatchList1 = new List<GoodRecieptPOBatchList>();
                    foreach (var aifx in goodRecieptPOBatches.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.SAPLineNum == Convert.ToInt32(items["SiraNo"]) && x.DocEntry == Convert.ToInt32(items["BelgeNumarasi"])))
                    {
                        goodRecieptPOBatchList1.Add(new GoodRecieptPOBatchList
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = Math.Round(Convert.ToDouble(aifx.BatchQuantity), Giris.genelParametreler.OndalikMiktar),
                            BinCode = aifx.DepoYeriId
                        });
                    }

                    goodRecieptPODetails1.Add(new GoodRecieptPODetails
                    {
                        BatchLists = goodRecieptPOBatchList1.ToArray(),
                        ItemCode = items["KalemKodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["ToplananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        BaseEntry = Convert.ToInt32(items["BelgeNumarasi"]),
                        BaseType = 22,
                        BaseLine = Convert.ToInt32(items["SiraNo"]),
                        BinCode = Giris.genelParametreler.DepoYeriCalisir == "Y" && items["Partili"].ToString() != "Y" ? items["DepoYeriId"].ToString() : "",
                        WareHouse = items["DepoKodu"].ToString(),
                    });

                    goodRecieptPO.GoodRecieptPODetails = goodRecieptPODetails1.ToArray();
                    i++;
                }
                if (goodRecieptPO.GoodRecieptPODetails == null)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }
                else if (goodRecieptPO.GoodRecieptPODetails.Count() == 0)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    return;
                }

                var resp1 = aIFTerminalServiceSoapClient1.AddGoodRecieptPO(Giris._dbName, Convert.ToInt32(Giris._userCode), goodRecieptPO);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    SiparisliMalGirisi_1.formAciliyor = true;
                    SiparisliMalGirisi_1.dialogresult = "Ok";
                    Close();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            if (partili == "Y")
            {
                button1.PerformClick();
                //if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), 4) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), 4))
                //{
                //    dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.GreenYellow;
                //}
                //else
                //{
                //    dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.Crimson;

                //}
                partili = "";
                barcode = "";
                return;
            }
            else
            {
                //dtgDetails.Rows[e.RowIndex].Cells["ToplananMiktar"].Style.BackColor = Color.GreenYellow;
                //dtgDetails.Columns["OlcuBirimi"].ReadOnly = false;
                //dtgDetails.Columns["Miktar"].ReadOnly = false;

                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;
                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                if (Val != "TANIMSIZ")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), Giris.mKodValue);
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        resp = aIFTerminalServiceSoapClient.GetProductByMuhatapKatalogNoWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (Val != "TANIMSIZ")
                {
                    if (resp._list == null)
                    {
                        if (Val != "")
                        {
                            //Val = cmbItemName.SelectedValue.ToString();
                            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                        }
                    }
                }
                else
                {
                    if (resp._list == null)
                    {
                        Val = cmbItemName.SelectedValue.ToString();
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtVendorCode.Text, Giris.mKodValue);
                    }
                }

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    string brkd = "";
                    if (resp._list.Rows[0]["Barkod"].ToString() == "" && resp._list.Rows[0]["MuhatapKatalogNo"].ToString() == "")
                    {
                        brkd = "Tanımsız";
                    }
                    else if (resp._list.Rows[0]["Barkod"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["Barkod"].ToString();
                    }
                    else if (resp._list.Rows[0]["MuhatapKatalogNo"].ToString() != "")
                    {
                        brkd = resp._list.Rows[0]["MuhatapKatalogNo"].ToString();
                    }

                    list.Add(brkd);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(Math.Round(acceptqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    list.Add(depoTanimi);
                    list.Add(warehouse);
                    list.Add(depoYeriId);
                    list.Add(depoYeriAdi);

                    txtBarCode.Text = "";
                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("22", list, "SİPARİŞLİ MAL GİRİŞİ");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        dtDetails.Rows[currentRow]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dtDetails.Rows[currentRow]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            dtDetails.Rows[currentRow]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi;
                            dtDetails.Rows[currentRow]["DepoKodu"] = PartisizKalemSecimi.depoKodu;
                            dtDetails.Rows[currentRow]["DepoTanimi"] = PartisizKalemSecimi.depoAdi;

                            PartisizKalemSecimi.depoYeriId = "";
                            PartisizKalemSecimi.depoYeriAdi = "";
                            PartisizKalemSecimi.depoKodu = "";
                            PartisizKalemSecimi.depoAdi = "";
                        }
                        PartisizKalemSecimi.dialogresult = "";
                    }
                    dtgDetails.Rows[currentRow].Selected = false;
                }

                partili = "";
                barcode = "";
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();

                if (txtBarCode.Text != "")
                {
                    txtBarCode.Text = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");
                    bool urunbulundu = false;
                    var exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).ToList();

                    if (exits.Count > 0)
                    {
                        var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                        var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                        dtgDetails_CellClick(dtgDetails, arg);

                        dtgDetails.ClearSelection();

                        dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                        button1.PerformClick();
                        urunbulundu = true;
                    }

                    if (!urunbulundu)
                    {
                        exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarCode.Text).ToList();
                        if (exits.Count > 0)
                        {
                            var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("MuhatapKatalogNo") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();
                            var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                            dtgDetails_CellClick(dtgDetails, arg);

                            dtgDetails.ClearSelection();

                            dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                            button1.PerformClick();
                            urunbulundu = true;
                        }
                    }

                    if (!urunbulundu)
                    {
                        CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtBarCode.Focus();
                        txtBarCode.Select(0, txtBarCode.Text.Length);
                        return;
                    }
                }
                else
                {
                    CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    txtBarCode.Select(0, txtBarCode.Text.Length);
                    return;
                }
            }
        }

        private void dtgDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text != "")
                {
                    button1.PerformClick();
                }
            }
        }

        private void btnColumnsWidth_Click(object sender, EventArgs e)
        {
            dtgDetails.Columns["btnDetail"].Width = 0;
            dtgDetails.Columns["BelgeNumarasi"].Width = 0;
            dtgDetails.Columns["KalemKodu"].Width = 0;
            dtgDetails.Columns["KalemAdi"].Width = 220;
            dtgDetails.Columns["OlcuBirimi"].Width = 42;
            dtgDetails.Columns["Barkod"].Width = 0;
            dtgDetails.Columns["Miktar"].Width = 71;
            dtgDetails.Columns["ToplananMiktar"].Width = 71;
            dtgDetails.Columns["Partili"].Width = 0;
            dtgDetails.Columns["DepoKodu"].Width = 0;
            dtgDetails.Columns["SiraNo"].Width = 0;
            dtgDetails.Columns["MuhatapKatalogNo"].Width = 0;
            dtgDetails.Columns["DepoTanimi"].Width = 0;
            dtgDetails.Columns["DepoMiktar"].Width = 80;

            //int gridWidth = dtgDetails.Width;
            //dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["BelgeNumarasi"].Width -
            //    dtgDetails.Columns["KalemKodu"].Width - dtgDetails.Columns["OlcuBirimi"].Width -
            //    dtgDetails.Columns["Miktar"].Width - dtgDetails.Columns["ToplananMiktar"].Width -
            //    dtgDetails.Columns["DepoMiktar"].Width;
            MessageBox.Show(
                "btnDetail=" + dtgDetails.Columns["btnDetail"].Width +
                " Barkod=" + dtgDetails.Columns["Barkod"].Width +
                " Partili=" + dtgDetails.Columns["Partili"].Width +
                " DepoKodu=" + dtgDetails.Columns["DepoKodu"].Width +
                " SiraNo=" + dtgDetails.Columns["SiraNo"].Width +
                " BelgeNumarasi=" + dtgDetails.Columns["BelgeNumarasi"].Width +
                " KalemKodu=" + dtgDetails.Columns["KalemKodu"].Width +
                " KalemAdi=" + dtgDetails.Columns["KalemAdi"].Width +
                " OlcuBirimi=" + dtgDetails.Columns["OlcuBirimi"].Width +
                " Miktar=" + dtgDetails.Columns["Miktar"].Width +
                " ToplananMiktar=" + dtgDetails.Columns["ToplananMiktar"].Width +
                " DepoMiktar=" + dtgDetails.Columns["DepoMiktar"].Width +
                " Grid Genişlik=" + dtgDetails.Width);
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
                        else if (itemCode != "" && itemCode != null)
                        {
                            txtBarCode.Text = "TANIMSIZ";
                        }

                        dtgDetails.DataSource = dtDetails;

                        dtgDetails.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                        dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
                        dtgDetails.Columns["DepoMiktar"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;

                        dtgDetails.Columns["btnDetail"].DisplayIndex = 0;
                        dtgDetails.Columns["BelgeNumarasi"].DisplayIndex = 1;
                        dtgDetails.Columns["KalemKodu"].DisplayIndex = 2;
                        dtgDetails.Columns["KalemAdi"].DisplayIndex = 3;
                        dtgDetails.Columns["OlcuBirimi"].DisplayIndex = 4;
                        dtgDetails.Columns["Barkod"].DisplayIndex = 5;
                        dtgDetails.Columns["Miktar"].DisplayIndex = 6;
                        dtgDetails.Columns["ToplananMiktar"].DisplayIndex = 7;
                        dtgDetails.Columns["Partili"].DisplayIndex = 8;
                        dtgDetails.Columns["DepoKodu"].DisplayIndex = 9;
                        dtgDetails.Columns["SiraNo"].DisplayIndex = 10;

                        dtgDetails.Columns["BelgeNumarasi"].HeaderText = "BELGE NO";
                        dtgDetails.Columns["KalemKodu"].HeaderText = "KALEM KODU";
                        dtgDetails.Columns["KalemAdi"].HeaderText = "KALEM ADI";
                        dtgDetails.Columns["OlcuBirimi"].HeaderText = "BRM";
                        dtgDetails.Columns["ToplananMiktar"].HeaderText = "TOP.MİKTAR";
                        dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";

                        dtgDetails.Columns["Partili"].Visible = false;
                        dtgDetails.Columns["DepoKodu"].Visible = false;
                        dtgDetails.Columns["SiraNo"].Visible = false;
                        dtgDetails.Columns["DepoMiktar"].Visible = false;
                        dtgDetails.Columns["Barkod"].Visible = false;
                        dtgDetails.Columns["btnDetail"].Visible = false;

                        button1.PerformClick();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAllProducts();
            if (dtProductsItem.Rows.Count > 0)
            {
                dtViewItem.RowFilter = "ItemName = '' or ItemName like '%" + cmbItemName.Text + "%'";
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

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();

            var partiler = goodRecieptPOBatches.Where(x => x.ItemCode == itemCode && x.SAPLineNum == Convert.ToInt32(sapLineNum) && x.DocEntry == Convert.ToInt32(DocEntry)).ToList();

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
                        #region saçmalık oldugunu düşündüğümden kapattım

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(item.DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                        #endregion saçmalık oldugunu düşündüğümden kapattım

                        if (Val == "Tanımsız")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(item.DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(item.DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                        }
                    }
                }
                else
                {
                    #region saçmalık olduğunu düşündüğümden kapattım

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                    #endregion saçmalık olduğunu düşündüğümden kapattım

                    if (Val == "Tanımsız")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                    }
                }
            }
            else
            {
                #region saçmalık olduğunu düşündüğümden kapattım

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });

                #endregion saçmalık olduğunu düşündüğümden kapattım

                if (Val == "Tanımsız")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
                else
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), TopMik = Convert.ToDouble(topMik) });
                }
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("22", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();

            try
            {
                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[currentRow].Selected = false;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("CURRENTROW HATASI: " + ex.Message, "UYARI", "TAMAM", "");
                return;
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void dtgDetails_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dtgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}