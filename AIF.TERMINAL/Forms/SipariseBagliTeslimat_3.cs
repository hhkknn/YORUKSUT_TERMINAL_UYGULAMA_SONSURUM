using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using System;
using System.Activities.Expressions;
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
    public partial class SipariseBagliTeslimat_3 : form_Base

    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //end font

        private string type = "";
        private List<dynamic> list = null;

        public SipariseBagliTeslimat_3(string _type, List<dynamic> _list, string _formName)
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
            list = _list;
            type = _type;

            if (type == "17")//SİPARİSE BAGLİ
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = "0";
                txtUnAccepted.Text = "0";
                //txtOnOrder.Text = "0";
                txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtPartyNo.Text = list[7];
                }
            }
            else if (type == "Sprssz17")//siparissiz tes
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.Text = "0";
                txtOnOrder.Text = "0";
                txtUnAccepted.ReadOnly = true;

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtPartyNo.Text = list[8];
                }
            }
            else if (type == "60")
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.Text = "0";
                txtOnOrder.Text = "0";
                txtUnAccepted.ReadOnly = true;

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtPartyNo.Text = Giris.UrunKoduBarkod(list[8], "Parti");
                }

                txtOnEkrandanSecilenDepo.Text = list[9].ToString();
                txtOnEkrandanSecilenDepoYeri.Text = list[10].ToString();
            }
            else if (type == "PALET")
            {
                btnCollect.Enabled = false;
                btnComplete.Enabled = false;
                btnRowDel.Enabled = false;
                txtPartyQty.ReadOnly = true;
                button1.Enabled = false;

                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.Text = "0";
                txtOnOrder.Text = "0";
                txtUnAccepted.ReadOnly = true;

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtPartyNo.Text = Giris.UrunKoduBarkod(list[8], "Parti");
                }

                txtOnEkrandanSecilenDepo.Text = list[9].ToString();
                txtOnEkrandanSecilenDepoYeri.Text = list[10].ToString();
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

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label9.Font.Style);

            label10.Font = new Font(label10.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label10.Font.Style);

            label12.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label12.Font.Style);

            label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label13.Font.Style);

            label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label14.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtBarCode.Font = new Font(txtBarCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarCode.Font.Style);

            txtItemCode.Font = new Font(txtItemCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemCode.Font.Style);

            txtItemName.Font = new Font(txtItemName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtItemName.Font.Style);

            txtWhsQuantity.Font = new Font(txtWhsQuantity.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtWhsQuantity.Font.Style);

            txtUomCode.Font = new Font(txtUomCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUomCode.Font.Style);

            txtOnOrder.Font = new Font(txtOnOrder.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtOnOrder.Font.Style);

            txtAccepted.Font = new Font(txtAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAccepted.Font.Style);

            txtUnAccepted.Font = new Font(txtUnAccepted.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUnAccepted.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyNo.Font.Style);

            txtPartyBarcode.Font = new Font(txtPartyBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyBarcode.Font.Style);

            txtPartyQty.Font = new Font(txtPartyQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyQty.Font.Style);

            btnCollect.Font = new Font(btnCollect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCollect.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgParties.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);
            ResumeLayout();

            //start yükseklik-genislik
            txtPartyNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartyQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        public static string secilenpartinumarasinindepoyeridsi = "";
        public static string secilenpartinumarasinindepoyeriAdi = "";
        public static string dialogResult = "";

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

        private DataTable BatchInWarehouseDt = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            ////chn txtPartyNo.Text depodaki miktarlar ,çindeki parti no(BatxhNumber) ya eşit değilse txtpartno yu seçsin hata versin

            //if (txtPartyNo.Text != "")
            //{
            //    var party = BatchInWarehouseDt.AsEnumerable().Where(x => x.Field<string>("BatchNum") == txtPartyNo.Text).ToList();

            //    if (party.Count == 0)
            //    {
            //        CustomMsgBox.Show(txtPartyNo.Text + " NUMARALI PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
            //        txtPartyNo.Focus();
            //        txtPartyNo.Select(0, txtPartyNo.Text.Length);
            //        return;
            //    }

            //}

            //DepodakiPartiler n = new DepodakiPartiler("17", BatchInWarehouseDt, txtWhsQuantity, txtPartyNo, "DEPODAKİ PARTİLER");
            //n.ShowDialog();

            //if (dialogResult == "Ok")
            //{
            //    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
            //    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

            //    double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

            //    txtPartyQty.Text = UnacceptedQty.ToString();

            //    dialogResult = "";

            //    txtPartyQty.Focus();
            //    txtPartyQty.Select(0, txtPartyQty.Text.Length);
            //}

            if (type == "17")
            {
                DepodakiPartiler n = new DepodakiPartiler("17", BatchInWarehouseDt, txtWhsQuantity, txtPartyNo, "SİPARİŞE BAĞLI TESLİMAT");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                if (dialogResult == "Ok")
                {
                    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                    double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                    txtPartyQty.Text = UnacceptedQty.ToString();

                    dialogResult = "";

                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);

                    txtSecilenDepoYeri.Text = secilenpartinumarasinindepoyeridsi;
                    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                    secilenpartinumarasinindepoyeridsi = "";
                    secilenpartinumarasinindepoyeriAdi = "";
                }
            }
            else if (type == "Sprssz17")
            {
                DepodakiPartiler n = new DepodakiPartiler("Sprssz17", BatchInWarehouseDt, txtWhsQuantity, txtPartyNo, "SİPARİŞSİZ TESLİMAT");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                if (dialogResult == "Ok")
                {
                    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                    //double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                    txtPartyQty.Text = txtWhsQuantityVal.ToString();

                    dialogResult = "";

                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);

                    txtSecilenDepoYeri.Text = secilenpartinumarasinindepoyeridsi;
                    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                    secilenpartinumarasinindepoyeridsi = "";
                    secilenpartinumarasinindepoyeriAdi = "";
                }
            }
            else if (type == "60")
            {
                DepodakiPartiler n = new DepodakiPartiler("60", BatchInWarehouseDt, txtWhsQuantity, txtPartyNo, "BELGESİZ MAL ÇIKIŞI");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                if (dialogResult == "Ok")
                {
                    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                    //double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                    txtPartyQty.Text = txtWhsQuantityVal.ToString();

                    dialogResult = "";

                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);

                    txtSecilenDepoYeri.Text = secilenpartinumarasinindepoyeridsi;
                    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                    secilenpartinumarasinindepoyeridsi = "";
                    secilenpartinumarasinindepoyeriAdi = "";
                }
            }
            //}
        }

        public static DataTable dtParties = new DataTable();
        public static DataTable dtAllParties = new DataTable();
        private string formName = "";
        private int maxHeight = 130;

        private void SipariseBagliTeslimat_3_Load(object sender, EventArgs e)
        {
            frmName.Text = formName.ToUpper();
            dtgParties.RowTemplate.Height = 55;
            dtgParties.ColumnHeadersHeight = 60;

            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtPartyQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
            styles[10].SizeType = SizeType.Absolute;
            styles[10].Height = 0;

            dtParties = new DataTable();
            dtParties.Columns.Add("Parti No", typeof(string));
            dtParties.Columns.Add("Parti Miktarı", typeof(double));
            dtParties.Columns.Add("DepoYeriId", typeof(string));
            dtParties.Columns.Add("DepoYeriAdi", typeof(string));

            dtAllParties = new DataTable();
            dtAllParties.Columns.Add("Parti No", typeof(string));
            dtAllParties.Columns.Add("Parti Miktarı", typeof(double));
            dtAllParties.Columns.Add("DepoYeriId", typeof(string));
            dtAllParties.Columns.Add("DepoYeriAdi", typeof(string));

            txtPartyQty.Value = txtUnAccepted.Value;

            string warehouse = "";
            if (type == "17")
            {
                var existrecord = SipariseBagliTeslimat_2.DeliveryBatches.Where(x => x.DocEntry == SipariseBagliTeslimat_2.DocEntry && x.LineNumber == SipariseBagliTeslimat_2.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId.ToString();
                        dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();


                        dtParties.Rows.Add(dr);
                    }
                }

                foreach (var item in SipariseBagliTeslimat_2.DeliveryBatches)
                {
                    DataRow dr = dtAllParties.NewRow();
                    dr["Parti No"] = item.BatchNumber.ToString();
                    dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                    dr["DepoYeriId"] = item.DepoYeriId.ToString();
                    dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();
                    dtAllParties.Rows.Add(dr);
                }

                var sum = SipariseBagliTeslimat_2.DeliveryBatches.Where(x => x.DocEntry == SipariseBagliTeslimat_2.DocEntry && x.LineNumber == SipariseBagliTeslimat_2.currentRow).Sum(y => y.BatchQuantity);

                var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

                var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtPartyQty.Value = Convert.ToDecimal(res);
                warehouse = SipariseBagliTeslimat_2.warehouse;
                txtOnEkrandanSecilenDepo.Text = warehouse;
            }
            else if (type == "Sprssz17")
            {
                var existrecord = SiparissizTesilmat_1.DeliveryBatches.Where(x => x.LineNumber == SiparissizTesilmat_1.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId.ToString();
                        dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = SiparissizTesilmat_1.DeliveryBatches.Where(x => x.LineNumber == SiparissizTesilmat_1.currentRow).Sum(y => y.BatchQuantity);
                //var unaccepted = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                //var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtPartyQty.Value = Convert.ToDecimal(res);

                warehouse = SiparissizTesilmat_1.wareHouse;

                txtOnEkrandanSecilenDepo.Text = warehouse;
                txtOnEkrandanSecilenDepoYeri.Text = SiparissizTesilmat_1.staticdepoYeriId;
            }
            else if (type == "60")
            {
                var existrecord = BelgesizMalCikisi_1.inventoryGenExitBatches.Where(x => x.LineNumber == BelgesizMalCikisi_1.currentRow && (x.Palet == null || x.Palet == false)).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId.ToString();
                        dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = BelgesizMalCikisi_1.inventoryGenExitBatches.Where(x => x.LineNumber == BelgesizMalCikisi_1.currentRow && (x.Palet == null || x.Palet == false)).Sum(y => y.BatchQuantity);

                //var unaccepted = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                //var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                //txtUnAccepted.Text = res.ToString("N"+Giris.genelParametreler.OndalikMiktar);
                warehouse = BelgesizMalCikisi_1.wareHouse;
            }
            else if (type == "PALET")
            {
                var existrecord = BelgesizMalCikisi_1.inventoryGenExitBatches.Where(x => x.LineNumber == BelgesizMalCikisi_1.detaySatirNo && (x.Palet != null && x.Palet == true)).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId.ToString();
                        dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = BelgesizMalCikisi_1.inventoryGenExitBatches.Where(x => x.LineNumber == BelgesizMalCikisi_1.detaySatirNo && (x.Palet != null && x.Palet == true)).Sum(y => y.BatchQuantity);

                //var unaccepted = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                //var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                //txtUnAccepted.Text = res.ToString("N"+Giris.genelParametreler.OndalikMiktar);
                warehouse = BelgesizMalCikisi_1.wareHouse;
            }

            dtgParties.DataSource = dtParties;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                dtgParties.Columns["DepoYeriId"].Visible = false;
                dtgParties.Columns["DepoYeriAdi"].Visible = false;
            }

            //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgParties.EnableHeadersVisualStyles = false;
            dtgParties.RowTemplate.Height = 55;

            foreach (DataGridViewColumn column in dtgParties.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }

            dtgParties.Columns["Parti No"].HeaderText = "PARTİ NO";
            dtgParties.Columns["Parti Miktarı"].HeaderText = "PARTİ MİKTARI";

            DataTable BatchDt = new DataTable();

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                if (type == "60" || type == "17" || type == "Sprssz17")
                {
                    resp = aIFTerminalServiceSoapClient.GetBatchQuantity_DepoYeri(Giris._dbName, warehouse, txtItemCode.Text, txtOnEkrandanSecilenDepoYeri.Text, Giris.mKodValue);
                }
                else
                {
                    resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, warehouse, txtItemCode.Text, Giris.mKodValue);
                }
            }
            else
            {
                resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, warehouse, txtItemCode.Text, Giris.mKodValue);
            }

            if (resp.Val != 0)
            {
                //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");//
            }
            else
            {
                BatchInWarehouseDt = resp._list;
                //dtview = new DataView(resp._list);
                //BatchInWarehouseDt = resp._list;
                //BatchDt = resp._list.DefaultView.ToTable(false, "Quantity", "BatchNum");
                //txtBatchNumber.DataSource = BatchDt;

                //txtBatchNumber.DisplayMember = "BatchNum";
                //txtBatchNumber.ValueMember = "Quantity";
            }

            dtgParties.Columns["Parti Miktarı"].DefaultCellStyle.Format = "N" + Giris.genelParametreler.OndalikMiktar;
            txtPartyNo.Focus();
            vScrollBar1.Maximum = dtgParties.RowCount;
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartyNo.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASINI GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartyNo.Focus();
                    txtPartyNo.Select(0, txtPartyNo.Text.Length);
                    return;
                }
                if (txtPartyNo.Text != "")
                {
                    #region parti sorgula

                    //if (type == "17")
                    //{
                    //DepodakiPartiler n = new DepodakiPartiler("17", BatchInWarehouseDt, txtWhsQuantity, txtPartyNo, "SİPARİŞE BAĞLI TESLİMAT");
                    //n.ShowDialog();

                    if (BatchInWarehouseDt.Rows.Count > 0)
                    {
                        foreach (DataRow item in BatchInWarehouseDt.Rows)
                        {
                            var batchNumber = item["BatchNum"].ToString(); 
                            double listedekimik = parseNumber_Seperator.ConvertToDouble(item["Quantity"].ToString());
                            double toplanan = parseNumber_Seperator.ConvertToDouble(txtAccepted.Value.ToString());
                            double girilen = parseNumber_Seperator.ConvertToDouble(txtPartyQty.Value.ToString());
                            double toplamGirilen = girilen + toplanan;
                            double siparisMik = parseNumber_Seperator.ConvertToDouble(txtOnOrder.Value.ToString());

                            if (txtPartyNo.Text == batchNumber)
                            {
                                if (girilen > listedekimik)
                                {
                                    CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                                    txtPartyQty.Focus();
                                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                                    return;
                                }
                                if (toplamGirilen > siparisMik)
                                {
                                    CustomMsgBox.Show("MİKTAR, TOPLANMASI GEREKEN MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                                    txtPartyQty.Focus();
                                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                                    return;
                                }
                            }
                        }
                    }
                    //}

                    #endregion parti sorgula

                    var party = BatchInWarehouseDt.AsEnumerable().Where(x => x.Field<string>("BatchNum") == txtPartyNo.Text).ToList();

                    if (party.Count == 0)
                    {
                        CustomMsgBox.Show(txtPartyNo.Text + " NUMARALI PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtPartyNo.Focus();
                        txtPartyNo.Select(0, txtPartyNo.Text.Length);
                        return;
                    }
                    else
                    {
                        //txtWhsQuantity.Text = Convert.ToDouble(party[0].ItemArray[4]).ToString("N"+Giris.genelParametreler.OndalikMiktar);//acınca ana ekrana atıyor
                        txtWhsQuantity.BackColor = Color.LimeGreen;
                    }
                }

                if (txtPartyQty.Text == "" || Convert.ToInt32(txtPartyQty.Value) == 0)
                {
                    CustomMsgBox.Show("PARTİ MİKTARI GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                    return;
                }
                //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                //var resp = aIFTerminalServiceSoapClient.GetBatchQuantity(Giris._dbName, warehouse, txtPartyQty.Text, txtItemCode.Text);

                //if (resp.Val == 0)
                //{
                //    if (txtPartyNo.Text == "")
                //    {
                //        CustomMsgBox.Show("Parti Numarası Boş Bırakılamaz.", "Uyarı", "Tamam", "");
                //        txtPartyNo.Text = "";
                //        txtPartyNo.Focus();
                //        return;
                //    }
                //    else if (resp._list.Rows[0].ItemArray[0].ToString() == "")
                //    {
                //        CustomMsgBox.Show("Parti Numarası Bulunamadı.", "Uyarı", "Tamam", "");
                //        txtPartyNo.Focus();
                //        txtPartyNo.Select(0, txtPartyNo.Text.Length);
                //        return;
                //    }
                //    txtWhsQuantity.Text = resp._list.Rows[0].ItemArray[0].ToString() == "" ? "0" : Convert.ToDouble(resp._list.Rows[0].ItemArray[0]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //    txtWhsQuantity.BackColor = Color.Green;

                //    double UnacceptedQty = Convert.ToDouble(txtUnAccepted.Text) > Convert.ToDouble(txtWhsQuantity.Text) ? Convert.ToDouble(txtWhsQuantity.Text) : Convert.ToDouble(txtUnAccepted.Text);

                //    txtPartyQty.Text = UnacceptedQty.ToString();
                //    txtPartyQty.Focus();
                //    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                //}

                if (type == "17")
                {
                    if (txtPartyNo.Text == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI GİRİNİZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    if (txtPartyQty.Text == "")
                    {
                        CustomMsgBox.Show("PARTİ MİKTARI GİRİNİZ.", "Uyarı", "Tamam", "");
                        return;
                    }

                    //if (Convert.ToDouble(txtUnAccepted.Text) == 0)
                    //{
                    //    CustomMsgBox.Show("BÜTÜN ÜRÜNLER TOPLANMIŞTIR.", "Uyarı", "Tamam", "");
                    //    return;
                    //}

                    if (txtPartyQty.Value > Convert.ToDecimal(txtWhsQuantity.Text))
                    {
                        CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                        txtPartyQty.Focus();
                        txtPartyQty.Select(0, txtPartyQty.Text.Length);
                        return;
                    }

                    double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                    double accepted = Convert.ToDouble(txtAccepted.Text);
                    double currentvalue = Convert.ToDouble(txtPartyQty.Text);
                    var partyqty = Convert.ToDouble(txtPartyQty.Text);
                    var warehousqty = Convert.ToDouble(txtWhsQuantity.Text);

                    accepted = accepted + currentvalue;
                    Unaccepted = Unaccepted - currentvalue;

                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = txtPartyNo.Text.ToString();
                    dr["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtParties.Rows.Add(dr);

                    DataRow dr2 = dtAllParties.NewRow();
                    dr2["Parti No"] = txtPartyNo.Text.ToString();
                    dr2["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr2["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr2["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtAllParties.Rows.Add(dr2);

                    txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    txtPartyNo.Text = "";
                    txtPartyQty.Text = "";
                    txtPartyBarcode.Text = "";
                }
                else if (type == "Sprssz17")
                {
                    if (txtPartyQty.Text == "")
                    {
                        return;
                    }

                    if (txtPartyQty.Value > Convert.ToDecimal(txtWhsQuantity.Text))
                    {
                        CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                        txtPartyQty.Focus();
                        txtPartyQty.Select(0, txtPartyQty.Text.Length);
                        return;
                    }

                    double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                    double accepted = Convert.ToDouble(txtAccepted.Text);
                    double currentvalue = Convert.ToDouble(txtPartyQty.Text);
                    var partyqty = Convert.ToDouble(txtPartyQty.Text);
                    var warehousqty = Convert.ToDouble(txtWhsQuantity.Text);

                    accepted = accepted + currentvalue;
                    Unaccepted = Unaccepted - currentvalue;

                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = txtPartyNo.Text.ToString();
                    dr["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtParties.Rows.Add(dr);

                    DataRow dr2 = dtAllParties.NewRow();
                    dr2["Parti No"] = txtPartyNo.Text.ToString();
                    dr2["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr2["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr2["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtAllParties.Rows.Add(dr2);

                    txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    txtPartyNo.Text = "";
                    txtPartyQty.Text = "";
                    txtPartyBarcode.Text = "";
                }
                else if (type == "60")
                {
                    if (txtPartyQty.Text == "")
                    {
                        return;
                    }

                    if (txtPartyQty.Value > Convert.ToDecimal(txtWhsQuantity.Text))
                    {
                        CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                        txtPartyQty.Focus();
                        txtPartyQty.Select(0, txtPartyQty.Text.Length);
                        return;
                    }

                    double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                    double accepted = Convert.ToDouble(txtAccepted.Text);
                    double currentvalue = Convert.ToDouble(txtPartyQty.Text);
                    var partyqty = Convert.ToDouble(txtPartyQty.Text);
                    var warehousqty = Convert.ToDouble(txtWhsQuantity.Text);

                    accepted = accepted + currentvalue;
                    Unaccepted = Unaccepted - currentvalue;

                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = txtPartyNo.Text.ToString();
                    dr["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtParties.Rows.Add(dr);

                    DataRow dr2 = dtAllParties.NewRow();
                    dr2["Parti No"] = txtPartyNo.Text.ToString();
                    dr2["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                    dr2["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                    dr2["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                    dtAllParties.Rows.Add(dr2);

                    txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    txtPartyNo.Text = "";
                    txtPartyQty.Text = "";
                    txtPartyBarcode.Text = "";
                }

                //txtPartyNo.Text = "";
                //txtPartyQty.Text = "";
                //txtOnOrder.Value = 0;
                //txtAccepted.Value = 0;
                //txtUnAccepted.Value = 0;

                if (dtgParties.Rows.Count > 0)
                {
                    dtgParties.Rows[0].Selected = false;
                }
                //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgParties.AutoResizeRows();
                txtPartyNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA ", ex.Message);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (dtParties.Rows.Count == 0)
            //{
            //    CustomMsgBox.Show("SATIR DOLU OLMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamma", "");
            //    return;
            //}

            if (type == "17")
            {
                if (txtAccepted.Value > txtOnOrder.Value)
                {
                    CustomMsgBox.Show("MİKTAR, TALEP EDİLEN MİKTARDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                    return;
                }

                SipariseBagliTeslimat_2.DeliveryBatches.RemoveAll(x => x.LineNumber == SipariseBagliTeslimat_2.currentRow && x.DocEntry == SipariseBagliTeslimat_2.DocEntry);

                foreach (DataRow item in dtParties.Rows)
                {

                    SipariseBagliTeslimat_2.DeliveryBatches.Add(new Models.DeliveryBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = SipariseBagliTeslimat_2.currentRow,
                        DocEntry = SipariseBagliTeslimat_2.DocEntry,
                        SAPLineNum = SipariseBagliTeslimat_2.sapLineNum,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString()
                    });
                }

                dialogResult = "Ok";

                Close();
            }
            else if (type == "Sprssz17")
            {
                SiparissizTesilmat_1.DeliveryBatches.RemoveAll(x => x.LineNumber == SiparissizTesilmat_1.currentRow);

                foreach (DataRow item in dtParties.Rows)
                {
                    SiparissizTesilmat_1.DeliveryBatches.Add(new DeliveryBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = SiparissizTesilmat_1.currentRow,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString()
                    });
                }

                dialogResult = "Ok";

                Close();
            }
            else if (type == "60")
            {
                BelgesizMalCikisi_1.inventoryGenExitBatches.RemoveAll(x => x.LineNumber == BelgesizMalCikisi_1.currentRow && (x.Palet == null || x.Palet == false));

                foreach (DataRow item in dtParties.Rows)
                {
                    BelgesizMalCikisi_1.inventoryGenExitBatches.Add(new InventoryGenExitBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = BelgesizMalCikisi_1.currentRow,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                        Palet = false
                    });
                }

                dialogResult = "Ok";

                Close();
            }
        }

        private void txtPartyNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPartyNo.Text != "")
                    {
                        var party = BatchInWarehouseDt.AsEnumerable().Where(x => x.Field<string>("BatchNum") == txtPartyNo.Text).ToList();

                        if (party.Count == 0)
                        {
                            CustomMsgBox.Show(txtPartyNo.Text + " NUMARALI PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                            txtPartyNo.Focus();
                            txtPartyNo.Select(0, txtPartyNo.Text.Length);
                            return;
                        }
                        else
                        {
                            txtWhsQuantity.Text = Convert.ToDouble(party[0].ItemArray[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                            txtWhsQuantity.BackColor = Color.LimeGreen;
                        }
                    }

                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtPartyQty_MouseDown(object sender, MouseEventArgs e)
        {
            txtPartyQty.Select(0, txtPartyQty.Text.Length);
        }

        private void txtPartyQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartyQty.Text == "" || Convert.ToDouble(txtPartyQty.Value) == 0)
                {
                    CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartyQty.Focus();
                    txtPartyQty.Select(0, txtPartyQty.Text.Length);
                }
                else
                {
                    btnCollect.PerformClick();
                }
            }
        }

        private int currentRow = -1;

        private void btnRowDel_Click(object sender, EventArgs e)
        {
            if (dtgParties.DataSource == null)
            {
                return;
            }
            if (currentRow == -1)
            {
                CustomMsgBox.Show("SİLMEK İÇİN SATIR SEÇİNİZ.", "Uyarı", "Tamam", "");
                return;
            }

            var satirdasilinenMiktar = Convert.ToDouble(dtParties.Rows[currentRow]["Parti Miktarı"]);

            dtgParties.Rows.RemoveAt(currentRow);
            currentRow = -1;

            var sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

            double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
            double accepted = Convert.ToDouble(txtAccepted.Text);

            accepted = sum;
            Unaccepted = Unaccepted + satirdasilinenMiktar;

            txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            if (type == "17")
            {
                txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            }

            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;
            }
        }

        private void dtgParties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;

            try
            {
                var partino = dtgParties.Rows[e.RowIndex].Cells[0].Value.ToString();
                var partiMiktar = Convert.ToDouble(dtgParties.Rows[e.RowIndex].Cells[1].Value);

                txtPartyNo.Text = partino;
                txtPartyQty.Value = Convert.ToDecimal(partiMiktar);
            }
            catch (Exception ex)
            {
            }
        }

        private void dtgParties_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgParties.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception)
            {
            }
        }

        private void txtPartyQty_Click(object sender, EventArgs e)
        {
            if (type != "PALET")
            {
                SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPartyQty, null, false);
                sayiKlavyesi.ShowDialog();
                sayiKlavyesi.Dispose();
                GC.Collect();
            }
        }
    }
}