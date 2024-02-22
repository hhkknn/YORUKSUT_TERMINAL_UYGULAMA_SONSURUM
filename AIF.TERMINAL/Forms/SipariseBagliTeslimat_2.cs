using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    //ek bilgiler butonu false edildi
    public partial class SipariseBagliTeslimat_2 : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private List<OrderList> OrderLists = new List<OrderList>();

        private Button buttonListele = new Button();

        public SipariseBagliTeslimat_2(List<OrderList> _orderLists, Button _buttonListele, string _formName)
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

            OrderLists = _orderLists;
            //buttonListele = _buttonListele;

            if (OrderLists != null)
            {
                txtCardCode.Text = OrderLists[0].CardCode;
                txtCardName.Text = OrderLists[0].CardName;
                txtAddress.Text = OrderLists[0].Address;
                var max = OrderLists.OrderByDescending(t => t.TaxDate)
                   .FirstOrDefault();

                //dtpOrderTaxDate.Value = new DateTime(Convert.ToInt32(max.TaxDate.Substring(0, 4)), Convert.ToInt32(max.TaxDate.Substring(4, 2)), Convert.ToInt32(max.TaxDate.Substring(6, 2)));

                dtpOrderTaxDate.Value = DateTime.Now;

                dtpOrderDocDueDate.Value = new DateTime(Convert.ToInt32(max.DocDueDate.Substring(0, 4)), Convert.ToInt32(max.DocDueDate.Substring(4, 2)), Convert.ToInt32(max.DocDueDate.Substring(6, 2)));

                List<string> docEntryList = new List<string>();
                foreach (var item in OrderLists)
                {
                    docEntryList.Add(item.DocEntry.ToString());
                }

                GetOrderDetails(docEntryList);
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

            txtCardCode.Font = new Font(txtCardCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCardCode.Font.Style);

            txtCardName.Font = new Font(txtCardName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtCardName.Font.Style);

            cmbItemName.Font = new Font(cmbItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbItemName.Font.Style);

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

            btnDetails.Font = new Font(btnDetails.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDetails.Font.Style);

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

            txtAddress.Font = new Font(txtAddress.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAddress.Font.Style);

            btnEkBilgi.Font = new Font(btnEkBilgi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnEkBilgi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtCardCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtCardName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtAddress.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);

            dtpOrderDocDueDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            dtpOrderTaxDate.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            txtWayBillNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        private Color defaultColor = Color.White;

        private void SipariseBagliTeslimat_2_Load(object sender, EventArgs e)
        {
            //SipariseBagliTeslimat_2.deliveryDetails.DriverName
            deliveryDetails.DriverName = "";
            deliveryDetails.CarPlate = "";
            deliveryDetails.CarTemp = 0;
            deliveryDetails.PostType = "";

            SipariseBagliTeslimat_2.DeliveryBatches = new List<DeliveryBatch>();
            frmName.Text = formName;
            cmbItemName.DropDownWidth = cmbItemName.Width + btnSearch.Width;

            defaultColor = dtgDetails.Rows[0].Cells[0].Style.BackColor;
            //cmbItemName.Font = new Font("Tahoma", 26);

            dtgDetails.Columns["OlcuBirimi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgDetails.Columns["ToplananMiktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgDetails.Columns["DepoYeriId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgDetails.Columns["DepoYeriAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            }
            dtgDetails.Columns["DepoAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtgDetails.Columns["KalemAdi"].Width = dtgDetails.Width - dtgDetails.Columns["OlcuBirimi"].Width - dtgDetails.Columns["Miktar"].Width - dtgDetails.Columns["ToplananMiktar"].Width;

            dtgDetails.RowTemplate.Height = 55;
            dtgDetails.ColumnHeadersHeight = 60;

            dtgDetails.Columns["btnDetail"].Visible = false;
            

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                dtgDetails.Columns["DepoYeriAdi"].Visible = false;
                dtgDetails.Columns["DepoYeriId"].Visible = false;
            }

            txtBarCode.Focus();
            vScrollBar1.Maximum = dtgDetails.RowCount;
            if (dtgDetails.Rows.Count > 0)
            {
                if (dtgDetails.Rows.Count == 1)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
                else
                {
                    //dtgDetails.Rows[currentRow].Selected = false;
                }
            }
        }

        public static string wareHouse = "";

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (txtBarCode.Text == "")
            {
                CustomMsgBox.Show("BARKOD GİRİŞİ YAPILMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                return;
            }
            if (partili != "Y")
            {
                //CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                //return;
                List<dynamic> list = new List<dynamic>();

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
                Response resp = null;

                if (barcode != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, barcode, warehouse.ToString(), Giris.mKodValue);
                }
                else if (itemCode != "")
                {
                    resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, itemCode, warehouse.ToString(), txtCardCode.Text, Giris.mKodValue);
                }

                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"].ToString());
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());

                    var toplananmiktar = dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());

                    list.Add(dtDetails.Rows[currentRow - 1]["DepoKodu"].ToString());
                    list.Add(dtDetails.Rows[currentRow - 1]["DepoAdi"].ToString());

                    list.Add(Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtDetails.Rows[currentRow - 1]["DepoYeriId"].ToString():"");
                    list.Add(Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtDetails.Rows[currentRow - 1]["DepoYeriAdi"].ToString():"");

                    if (Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar) == 0) //3 e gitmeden önce depo miktarı kontrolü
                    {
                        CustomMsgBox.Show("DEPODA OLMAYAN ÜRÜN İÇİN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("17", list, "SİPARİŞE BAĞLI TESLİMAT");
                    partisizKalemSecimi.ShowDialog();
                    partisizKalemSecimi.Dispose();
                    GC.Collect();
                    txtBarCode.Focus();

                    //this.Hide();

                    if (PartisizKalemSecimi.dialogresult == "Ok")
                    {
                        dtDetails.Rows[currentRow - 1]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            dtDetails.Rows[currentRow - 1]["DepoYeriId"] = PartisizKalemSecimi.depoYeriId;
                            dtDetails.Rows[currentRow - 1]["DepoYeriAdi"] = PartisizKalemSecimi.depoYeriAdi; 
                        }
                        dtDetails.Rows[currentRow - 1]["DepoKodu"] = PartisizKalemSecimi.depoKodu;

                        if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                        {
                            PartisizKalemSecimi.depoYeriId = "";
                            PartisizKalemSecimi.depoYeriAdi = ""; 
                        }
                        PartisizKalemSecimi.depoKodu = "";
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
                        //SipariseBagliTeslimat_3.dialogResult = "";
                    }
                    if (dtgDetails.Rows.Count > 0)
                    {
                        dtgDetails.Rows[currentRow - 1].Selected = false;
                    }
                }
                partili = "";
                barcode = "";
            }
            else
            {
                List<dynamic> list = new List<dynamic>();
                string Val = txtBarCode.Text;

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
                        if (Val != "")
                        {
                            //Val = cmbItemName.SelectedValue.ToString();
                            resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtCardCode.Text, Giris.mKodValue);
                        }
                    }
                }
                else
                {
                    if (resp._list == null)
                    {
                        Val = cmbItemName.SelectedValue.ToString();
                        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, Val, warehouse.ToString(), txtCardCode.Text, Giris.mKodValue);
                    }
                }
                if (resp._list != null)
                {
                    list.Add(resp._list.Rows[0]["Kalem Kodu"]);
                    list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
                    list.Add(resp._list.Rows[0]["Barkod"]);
                    list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
                    list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar));
                    list.Add(Math.Round(orderqty, Giris.genelParametreler.OndalikMiktar).ToString());
                    var toplananmiktar = dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value);

                    list.Add(Math.Round(toplananmiktar, Giris.genelParametreler.OndalikMiktar).ToString());
                    if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                    {
                        list.Add(partino);
                        partino = "";
                    }
                    if (Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), Giris.genelParametreler.OndalikMiktar) == 0) //3 e gitmeden önce depo miktarı kontrolü
                    {
                        CustomMsgBox.Show("DEPODA OLMAYAN ÜRÜN İÇİN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    SipariseBagliTeslimat_3 sipariseBagliTeslimat_3 = new SipariseBagliTeslimat_3("17", list, "SİPARİŞE BAĞLI TESLİMAT");
                    sipariseBagliTeslimat_3.ShowDialog();
                    sipariseBagliTeslimat_3.Dispose();
                    GC.Collect();
                    txtBarCode.Focus();

                    //this.Hide();

                    if (SipariseBagliTeslimat_3.dialogResult == "Ok")
                    {
                        var quantity = DeliveryBatches.Where(x => x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                        dtDetails.Rows[currentRow - 1]["ToplananMiktar"] = quantity;
                        //dtDetails.AcceptChanges();
                        if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["Miktar"].Value), Giris.genelParametreler.OndalikMiktar) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar))
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
                        }
                        else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Value), Giris.genelParametreler.OndalikMiktar) == 0)
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = defaultColor;
                        }
                        else
                        {
                            dtgDetails.Rows[currentRow - 1].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;
                        }
                        SipariseBagliTeslimat_3.dialogResult = "";
                    }
                    if (dtgDetails.Rows.Count > 0)
                    {
                        dtgDetails.Rows[currentRow - 1].Selected = false;
                    }
                }
            }

            //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            //var resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, warehouse, itemCode);

            //if (resp.Val != 0) //depoda olan bir ürünün parti miktarı 0 olmamamasından dolayı kontrol kaldırıldı
            //{
            //    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            //    return;
            //}
            //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgDetails.AutoResizeRows();
            txtBarCode.Focus();
            txtBarCode.Text = "";
            cmbItemName.Text = "";

            btnSearch.PerformClick();
            cmbItemName.DroppedDown = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex > 0)
            //{
            //    txtCardName.Text = comboBox1.Text;

            //}
            //else
            //{
            //    txtCardName.Text = "";
            //}
        }

        private DataTable dtDetails = new DataTable();

        private void GetOrderDetails(List<string> docentryList)
        {
            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = aIFTerminalServiceSoapClient.GetOrdersDetails(Giris._dbName, docentryList.ToArray(), Giris.whsCodes.ToArray(), Giris.mKodValue);

            if (resp._list != null)
            {
                dtDetails = resp._list;
                dtgDetails.DataSource = null;

                dtDetails.Columns.Add("ToplananMiktar", typeof(double));
                dtDetails.Columns.Add("dtgSira", typeof(int));

                try
                {
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        dtDetails.Columns.Add("DepoYeriId", typeof(string));
                        dtDetails.Columns.Add("DepoYeriAdi", typeof(string)); 
                    }
                }
                catch (Exception)
                {
                }

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
                dtgDetails.Columns["ToplananMiktar"].HeaderText = "TOP.MİK";
                dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";

                dtgDetails.Columns["Partili"].Visible = false;
                dtgDetails.Columns["DepoKodu"].Visible = false;
                dtgDetails.Columns["SiraNo"].Visible = false;
                dtgDetails.Columns["DepoMiktar"].Visible = false;
                dtgDetails.Columns["Barkod"].Visible = false;
                dtgDetails.Columns["btnDetail"].Visible = false;
                //new
                dtgDetails.Columns["BelgeNumarasi"].Visible = false;
                dtgDetails.Columns["KalemKodu"].Visible = false;

                dtgDetails.Columns["PaletIciKoliAD"].Visible = false;
                dtgDetails.Columns["KoliIciAD"].Visible = false;
                dtgDetails.Columns["PaletIciAD"].Visible = false;
                //new
                dtgDetails.Columns["MusteriSipNo"].Visible = false;
                dtgDetails.Columns["SevkiyatAdresi"].Visible = false;
                dtgDetails.EnableHeadersVisualStyles = false;
                dtgDetails.RowTemplate.Height = 55;

                dtgDetails.Columns["ToplananMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgDetails.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                vScrollBar1.Maximum = dtgDetails.RowCount;
                //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeColumns();

                //for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                //{
                //    var partili = dtgDetails.Rows[i].Cells["Partili"].Value;

                //    if (partili.ToString() == "Y")
                //    {
                //        dtgDetails.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                //    }
                //    else
                //    {
                //        dtgDetails.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                //    }
                //}

                for (int i = 0; i <= dtgDetails.Rows.Count - 1; i++)
                {
                    dtgDetails.Rows[i].Cells["dtgSira"].Value = Convert.ToInt32(i);
                }
                dtgDetails.Columns["dtgSira"].Visible = false;

                //dtgDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDetails.AutoResizeRows();

                foreach (DataGridViewColumn column in dtgDetails.Columns) //columns tıklayınca girişe atıyor
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                //dtgPurchaseOrders.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                if (dtgDetails.Rows.Count > 0)
                {
                    dtgDetails.Rows[0].Selected = false;
                }
            }
            else
            {
                CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        public static int sapLineNum = 0;
        public static int DocEntry = 0;
        public static string warehouse = "";
        private string itemCode = "";
        private string itemName = "";
        private string barcode = "";
        private string partili = "";
        private double orderqty = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private string musteriSipNo = "";
        private string sevkiyatAdresi = "";
        public static List<DeliveryBatch> DeliveryBatches = new List<DeliveryBatch>();
        public static int currentRow = 0;

        private double topMik = 0;

        private void dtgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                barcode = dtDetails.Rows[e.RowIndex]["Barkod"].ToString();
                itemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();
                itemName = dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString();
                warehouse = dtDetails.Rows[e.RowIndex]["DepoKodu"].ToString();
                orderqty = Convert.ToDouble(dtDetails.Rows[e.RowIndex]["Miktar"]);
                partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                txtBarCode.Text = barcode.ToString() != "" ? barcode.ToString() : itemCode;
                currentRow = e.RowIndex + 1;
                DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                sapLineNum = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["SiraNo"]);

                paletIciKoliAD = dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciKoliAD"]);
                koliIciAD = dtDetails.Rows[e.RowIndex]["KoliIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["KoliIciAD"]);
                paletIciAD = dtDetails.Rows[e.RowIndex]["PaletIciAD"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["PaletIciAD"]);

                sevkiyatAdresi = dtDetails.Rows[e.RowIndex]["SevkiyatAdresi"].ToString() == "" ? "" : dtDetails.Rows[e.RowIndex]["SevkiyatAdresi"].ToString();

                musteriSipNo = dtDetails.Rows[e.RowIndex]["MusteriSipNo"].ToString() == "" ? "-1" : dtDetails.Rows[e.RowIndex]["MusteriSipNo"].ToString();

                topMik = dtDetails.Rows[e.RowIndex]["ToplananMiktar"].ToString() == "" ? -1 : Convert.ToDouble(dtDetails.Rows[e.RowIndex]["ToplananMiktar"]);
            }
        }

        private void dtgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                List<dynamic> list = new List<dynamic>();
                if (senderGrid.Columns[e.ColumnIndex].Name == "btnDetail")
                {
                    partili = dtDetails.Rows[e.RowIndex]["Partili"].ToString();
                    //if (partili != "Y")
                    //{
                    CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                    return;
                    //}
                    string ItemCode = dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString();

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    var resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, warehouse, ItemCode, Giris.mKodValue);

                    if (resp.Val != 0)
                    {
                        CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
                        return;
                    }

                    DocEntry = Convert.ToInt32(dtDetails.Rows[e.RowIndex]["BelgeNumarasi"]);
                    currentRow = e.RowIndex;

                    list.Add(dtDetails.Rows[e.RowIndex]["KalemKodu"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["KalemAdi"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["Barkod"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["OlcuBirimi"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["DepoMiktar"].ToString());
                    list.Add(dtDetails.Rows[e.RowIndex]["Miktar"].ToString());
                    list.Add(Giris.genelParametreler.DepoYeriCalisir == "Y"? dtDetails.Rows[e.RowIndex]["DepoYeriId"].ToString():"");
                    list.Add(Giris.genelParametreler.DepoYeriCalisir == "Y" ? dtDetails.Rows[e.RowIndex]["DepoYeriAdi"].ToString():"");

                    SipariseBagliTeslimat_3 n = new SipariseBagliTeslimat_3("17", list, "SİPARİŞE BAĞLI TESLİMAT");
                    n.ShowDialog();
                    n.Dispose();
                    GC.Collect();

                    var quantity = DeliveryBatches.Where(x => x.DocEntry == DocEntry && x.LineNumber == currentRow).Sum(y => y.BatchQuantity);

                    dtDetails.Rows[currentRow]["ToplananMiktar"] = quantity;
                }
            }
        }

        public static DeliveryDetails deliveryDetails = new DeliveryDetails();

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
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("BELGE KAYDEDİLECEKTİR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                    return;
                }
                if (deliveryDetails.CarPlate == "" || deliveryDetails.CarPlate == null)
                {
                    CustomMsgBox.Show("LÜTFEN PLAKA GİRİNİZ.", "UYARI", "TAMAM", "");
                    return;
                }
                if (deliveryDetails.DriverName == "" || deliveryDetails.DriverName == null)
                {
                    CustomMsgBox.Show("LÜTFEN SÜRÜCÜ ADI GİRİNİZ.", "UYARI", "TAMAM", "");
                    return;
                }

                if (deliveryDetails.CarTemp == 0 || deliveryDetails.CarTemp == null)
                {
                    CustomMsgBox.Show("LÜTFEN SICAKLIK GİRİNİZ.", "UYARI", "TAMAM", "");
                    return;
                }
                if (deliveryDetails.PostType == "" || deliveryDetails.PostType == null)
                {
                    CustomMsgBox.Show("LÜTFEN GÖNDERİ TİPİ GİRİNİZ.", "UYARI", "TAMAM", "");
                    return;
                }
                Orders orders = new Orders();
                OrderDetails orderlines = new OrderDetails();
                List<OrderDetails> orderlines1 = new List<OrderDetails>();
                List<OrderBatchList> orderBatchList = new List<OrderBatchList>();

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                int i = 1;
                orders.CarCode = txtCardCode.Text;
                orders.DocDate = dtpOrderTaxDate.Value.ToString("yyyyMMdd");
                orders.DocDueDate = dtpOrderTaxDate.Value.ToString("yyyyMMdd");
                //inventoryGenEntry..DocDueDate = dtpTransferDate.Value.ToString("yyyyMMdd");
                orders.WayBillNo = txtWayBillNo.Text;

                foreach (DataRow items in dtDetails.Rows)
                {
                    if (items["ToplananMiktar"].ToString() == "0" || items["ToplananMiktar"].ToString() == "")
                    {
                        continue;
                    }

                    orderBatchList = new List<OrderBatchList>();
                    foreach (var aifx in DeliveryBatches.Where(x => x.ItemCode == items["KalemKodu"].ToString() && x.SAPLineNum == Convert.ToInt32(items["SiraNo"]) && x.DocEntry == Convert.ToInt32(items["BelgeNumarasi"])))
                    {
                        orderBatchList.Add(new OrderBatchList
                        {
                            BatchNumber = aifx.BatchNumber,
                            BatchQuantity = aifx.BatchQuantity,
                            DepoyYeriId = Giris.genelParametreler.DepoYeriCalisir == "Y" ? aifx.DepoYeriId :"",
                            DepoyYeriAdi = Giris.genelParametreler.DepoYeriCalisir == "Y" ? aifx.DepoYeriAdi:""
                        });
                    }

                    orderlines1.Add(new OrderDetails
                    {
                        BatchLists = orderBatchList.ToArray(),
                        ItemCode = items["KalemKodu"].ToString(),
                        Quantity = Math.Round(Convert.ToDouble(items["ToplananMiktar"]), Giris.genelParametreler.OndalikMiktar),
                        BaseEntry = Convert.ToInt32(items["BelgeNumarasi"]),
                        BaseType = 17,
                        BaseLine = Convert.ToInt32(items["SiraNo"]),
                        DepoyYeriId = Giris.genelParametreler.DepoYeriCalisir == "Y" ? items["DepoYeriId"].ToString() : "",
                        WareHouse = items["DepoKodu"].ToString(),
                    });

                    i++;
                }

                orders.DriverName = deliveryDetails.DriverName;
                orders.CarPlate = deliveryDetails.CarPlate;
                orders.CarTemp = deliveryDetails.CarTemp;
                orders.PostType = deliveryDetails.PostType;

                orders.OrderDetails = orderlines1.ToArray();

                if (orders.OrderDetails.Count() == 0)
                {
                    CustomMsgBox.Show("TÜM SATIRLARIN MİKTARI 0 OLAMAZ.", "Uyarı", "Tamam", "");
                    txtBarCode.Focus();
                    return;
                }

                var resp1 = aIFTerminalServiceSoapClient1.AddOrUpdateOrders(Giris._dbName, Convert.ToInt32(Giris._userCode), orders);

                CustomMsgBox.Show(resp1.Desc, "Uyarı", "Tamam", "");

                if (resp1.Val == 0)
                {
                    SipariseBagliTeslimat_1.formAciliyor = true;
                    SipariseBagliTeslimat_1.dialogresult = "Ok";
                    DeliveryBatches = new List<DeliveryBatch>();
                    Close();
                    //buttonListele.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("HATA" + ex.Message, "Uyarı", "Tamam", "");
            }
        }

        private string partino = "";

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();

                if (txtBarCode.Text != "")
                {
                    partino = Giris.UrunKoduBarkod(txtBarCode.Text, "Parti");
                    txtBarCode.Text = Giris.UrunKoduBarkod(txtBarCode.Text, "Barkod");
                    var exits = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).ToList();
                    bool secildi = false;
                    if (exits.Count > 0)
                    {
                        foreach (DataRow item in exits)
                        {
                            //var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();

                            object value = item["ToplananMiktar"];

                            if (value == DBNull.Value)
                            {
                                //if (Convert.ToDouble(value) > 0)
                                //{
                                var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, item.Field<int>("dtgSira"));
                                dtgDetails_CellClick(dtgDetails, arg);

                                dtgDetails.ClearSelection();

                                dtgDetails.Rows[item.Field<int>("dtgSira")].Cells[0].Selected = true;
                                btnDetails.PerformClick();
                                secildi = true;
                                break;
                                //}
                            }
                        }

                        if (!secildi)
                        {
                            var dtgSira = dtDetails.AsEnumerable().Where(x => x.Field<string>("Barkod") == txtBarCode.Text).Select(x => x.Field<int>("dtgSira")).FirstOrDefault();

                            var arg = new DataGridViewCellEventArgs(dtDetails.Rows.Count, dtgSira);
                            dtgDetails_CellClick(dtgDetails, arg);

                            dtgDetails.ClearSelection();

                            dtgDetails.Rows[dtgSira].Cells[0].Selected = true;
                            btnDetails.PerformClick();
                        }
                    }
                    else
                    {
                        CustomMsgBox.Show("BARKOD BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtBarCode.Focus();
                        txtBarCode.Select(0, txtBarCode.Text.Length);
                        return;
                    }
                    if (partili != "Y")
                    {
                        CustomMsgBox.Show("PARTİLİ OLMAYAN ÜRÜNÜN DETAYINA GİDİLEMEZ.", "Uyarı", "Tamam", "");
                        txtBarCode.Focus();
                        txtBarCode.Select(0, txtBarCode.Text.Length);

                        return;
                    }
                }
            }
        }

        private void dtgDetails_DoubleClick(object sender, EventArgs e)
        {
            //if (partili == "Y")
            //{
            btnDetails.PerformClick();
            partili = "";
            barcode = "";
            return;
            //}
            //else
            //{
            //    List<dynamic> list = new List<dynamic>();

            //    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //    Response resp = null;

            //    if (barcode != "")
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByBarCodeWithWareHouse(Giris._dbName, barcode, warehouse.ToString());
            //    }
            //    else if (itemCode != "")
            //    {
            //        resp = aIFTerminalServiceSoapClient.GetProductByItemCodeWithWareHouse(Giris._dbName, itemCode, warehouse.ToString());
            //    }

            //    if (resp._list != null)
            //    {
            //        list.Add(resp._list.Rows[0]["Kalem Kodu"]);
            //        list.Add(resp._list.Rows[0]["Kalem Tanımı"]);
            //        list.Add(resp._list.Rows[0]["Barkod"].ToString() == "" ? "Tanımsız" : resp._list.Rows[0]["Barkod"].ToString());

            //        list.Add(resp._list.Rows[0]["Ölçü Birimi"]);
            //        list.Add(Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), 4));
            //        list.Add(Math.Round(orderqty, 4).ToString());

            //        if (Math.Round(Convert.ToDouble(resp._list.Rows[0]["Depo Miktari"]), 4) == 0) //3 e gitmeden önce depo miktarı kontrolü
            //        {
            //            CustomMsgBox.Show("DEPODA OLMAYAN ÜRÜN İÇİN İŞLEM YAPILAMAZ.", "Uyarı", "Tamam", "");
            //            return;
            //        }

            //        PartisizKalemSecimi partisizKalemSecimi = new PartisizKalemSecimi("17", list, "SİPARİŞE BAĞLI TESLİMAT");
            //        partisizKalemSecimi.ShowDialog();
            //        txtBarCode.Focus();

            //        //this.Hide();

            //        if (PartisizKalemSecimi.dialogresult == "Ok")
            //        {
            //            dtDetails.Rows[currentRow]["ToplananMiktar"] = PartisizKalemSecimi.quantity;
            //            //dtDetails.AcceptChanges();
            //            if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["Miktar"].Value), 4) == Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), 4))
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.LimeGreen;
            //            }
            //            else if (Math.Round(Convert.ToDouble(dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Value), 4) == 0)
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = defaultColor;

            //            }
            //            else
            //            {
            //                dtgDetails.Rows[currentRow].Cells["ToplananMiktar"].Style.BackColor = Color.OrangeRed;

            //            }
            //            //SipariseBagliTeslimat_3.dialogResult = "";
            //        }
            //        dtgDetails.Rows[currentRow].Selected = false;
            //    }
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
            }
        }

        private void dtgDetails_Scroll(object sender, ScrollEventArgs e)
        {
            //vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //try
            //{
            //    dtgDetails.FirstDisplayedScrollingRowIndex = e.NewValue;
            //}
            //catch (Exception)
            //{
            //}
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
                        dtgDetails.Columns["ToplananMiktar"].HeaderText = "TOPLANAN MİKTAR";
                        dtgDetails.Columns["Barkod"].HeaderText = "BARKOD";
                        dtgDetails.Columns["Miktar"].HeaderText = "MİKTAR";

                        dtgDetails.Columns["Partili"].Visible = false;
                        dtgDetails.Columns["DepoKodu"].Visible = false;
                        dtgDetails.Columns["SiraNo"].Visible = false;
                        dtgDetails.Columns["DepoMiktar"].Visible = false;
                        dtgDetails.Columns["Barkod"].Visible = false;
                        dtgDetails.Columns["btnDetail"].Visible = false;
                        //new
                        dtgDetails.Columns["BelgeNumarasi"].Visible = false;
                        dtgDetails.Columns["KalemKodu"].Visible = false;
                        //new
                        btnDetails.PerformClick();
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

        private void btnBarkodGoster_Click(object sender, EventArgs e)
        {
            ListParties = new List<Parties>();

            List<dynamic> list = new List<dynamic>();
            var partiler = DeliveryBatches.Where(x => x.ItemCode == itemCode && x.SAPLineNum == Convert.ToInt32(sapLineNum) && x.DocEntry == Convert.ToInt32(DocEntry)).ToList();
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
                        #region BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                        //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });

                        #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                        if (Val == "Tanımsız")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            if (barcode == "")
                            {
                                ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                            }
                            else
                            {
                                ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = item.BatchNumber, DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                            }
                        }
                    }
                }
                else
                {
                    #region BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                    //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });

                    #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                    if (Val == "Tanımsız")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        if (barcode == "")
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                        }
                        else
                        {
                            ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                        }
                    }
                }
            }
            else
            {
                #region BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                //ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = Val == itemCode ? "Tanımsız" : barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });

                #endregion BarCode = Val == itemCode ? "Tanımsız" : barcode hataya sebep oluyordu kapattım

                if (Val == "Tanımsız")
                {
                    ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = "Tanımsız", BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                }
                else
                {
                    if (barcode == "")
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = itemCode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                    }
                    else
                    {
                        ListParties.Add(new Parties { ItemCode = itemCode, ItemName = itemName, BarCode = barcode, BatchNumber = "", DocEntry = Convert.ToInt32(DocEntry), PaletIciKoliAD = Convert.ToDouble(paletIciKoliAD), KoliIciAD = Convert.ToDouble(koliIciAD), PaletIciAD = Convert.ToDouble(paletIciAD), MusteriSipNo = musteriSipNo, SevkiyatAdresi = sevkiyatAdresi, TopMik = Convert.ToDouble(topMik) });
                    }
                }
            }

            txtBarCode.Text = "";
            BarkodGoruntule barkodGoruntule = new BarkodGoruntule("17", ListParties, "BARKOD GÖRÜNTÜLEME");
            barkodGoruntule.ShowDialog();
            barkodGoruntule.Dispose();
            GC.Collect();

            if (dtgDetails.Rows.Count > 0)
            {
                dtgDetails.Rows[currentRow - 1].Selected = false;
            }
            ListParties = new List<Parties>();
        }

        public static List<Parties> ListParties = new List<Parties>();

        private void btnEkBilgi_Click(object sender, EventArgs e)
        {
            SipariseBagliTeslimat_Detay sipariseBagliTeslimat_Detay = new SipariseBagliTeslimat_Detay("EK BİLGİLER");
            sipariseBagliTeslimat_Detay.ShowDialog();
            sipariseBagliTeslimat_Detay.Dispose();
            GC.Collect();
        }
    }
}