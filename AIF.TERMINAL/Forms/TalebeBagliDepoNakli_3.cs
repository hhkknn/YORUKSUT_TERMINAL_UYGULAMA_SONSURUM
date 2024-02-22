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
    public partial class TalebeBagliDepoNakli_3 : form_Base
    {
        private int rowIndex = 0;

        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        private List<dynamic> list = null;
        public static double onaydabekleyenMik = 0;

        public TalebeBagliDepoNakli_3(string _type, List<dynamic> _list, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = frmName.Font.Size;
            frmName.Resize += Form_Resize;
            //end font

            formName = _formName;
            list = _list;
            type = _type;

            if (type == "1250000001")//talebe bagli
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = "0";
                txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;

                onaydabekleyenMik = Convert.ToDouble(list[7]);
                if (onaydabekleyenMik > 0)
                {
                    double toplanmayan = Convert.ToDouble(txtUnAccepted.Value) - Convert.ToDouble(onaydabekleyenMik);
                    txtUnAccepted.Text = Convert.ToDouble(toplanmayan).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                }

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtBatchNumber.Text = list[8];
                }

                txtOnEkrandaSecilenDepo.Text = list[9].ToString();
                txtOnEkrandanHedefDepo.Text = list[10].ToString();
            }
            else if (type == "Tlpsz1250000001")
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtOnOrder.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtOnOrder.Value = 0;
                txtAccepted.Text = "0";
                //txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;

                if (Giris.genelParametreler.BarkodKalemBirlesikOku == "Y")
                {
                    txtBatchNumber.Text = Giris.UrunKoduBarkod(list[8], "Parti");
                }

                txtOnEkranKaynakDepoId.Text = list[9].ToString();
                txtOnEkrandaSecilenDepo.Text = list[10].ToString();
                txtOnEkrandanHedefDepo.Text = list[11].ToString();
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

            txtBatchNumber.Font = new Font(txtBatchNumber.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBatchNumber.Font.Style);

            txtPartyBarcode.Font = new Font(txtPartyBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyBarcode.Font.Style);

            txtBatchQty.Font = new Font(txtBatchQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBatchQty.Font.Style);

            btnShowBatchWhs.Font = new Font(btnShowBatchWhs.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnShowBatchWhs.Font.Style);

            btnCollect.Font = new Font(btnCollect.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCollect.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgParties.Font.Style);

            btnRowDel.Font = new Font(btnRowDel.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnRowDel.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtBatchNumber.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBatchQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //end yükseklik-genislik
            //end font
        }

        public static string dialogresult = "";
        public static string secilenpartinumarasinindepoyeridsi = "";
        public static string secilenpartinumarasinindepoyeriAdi = "";

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

        public static DataTable dtParties = new DataTable();

        private void btnCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "1250000001" || type == "Tlpsz1250000001")
                {
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

                        Response resp1 = null;

                        resp1 = aIFTerminalServiceSoapClient1.getDepoYerleri(Giris._dbName, txtOnEkrandanHedefDepo.Text, Giris.mKodValue);

                        if (resp1.Val == 0)
                        {
                            if (resp1._list.Rows.Count > 0)
                            {
                                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtHedefDepoYeriId, txtHedefDepoYeriAdi, txtOnEkrandanHedefDepo, null);
                                nesne.ShowDialog();
                                nesne.Dispose();
                                GC.Collect();

                                if (SelectList.dialogResult == "Ok")
                                {
                                    SelectList.dialogResult = "";
                                }

                                if (txtHedefDepoYeriId.Text == "")
                                {
                                    CustomMsgBox.Show("DEPO YERI SEÇİLMEDEN İŞLEME DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                                    return;
                                }
                            }
                        }
                    }

                    #region onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                    if (Giris.genelParametreler.CekmeListesiFazlaMiktarGirer != "Y")
                    {
                        if (type == "1250000001" && (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "30TRMN" || Giris.mKodValue == "20TRMN"))
                        {
                            double girilebilir = 0;
                            girilebilir = onaydabekleyenMik + Convert.ToDouble(txtBatchQty.Value);
                            if (girilebilir > Convert.ToDouble(txtOnOrder.Value))
                            {
                                CustomMsgBox.Show("FAZLA MİKTAR GİRİŞİ YAPTINIZ.", "Uyarı", "Tamam", "");
                                txtBatchQty.Focus();
                                txtBatchQty.Select(0, txtBatchQty.Text.Length);
                                return;
                            }
                        }
                    }

                    #endregion onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    var resp = aIFTerminalServiceSoapClient.GetBatchQuantity(Giris._dbName, warehouse, txtBatchNumber.Text, txtItemCode.Text, Giris.mKodValue);

                    if (resp.Val == 0)
                    {
                        if (txtBatchNumber.Text == "")
                        {
                            CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                            txtBatchNumber.Text = "";
                            txtBatchNumber.Focus();
                            return;
                        }
                        else if (resp._list.Rows[0].ItemArray[0].ToString() == "")
                        {
                            CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                            txtBatchNumber.Focus();
                            txtBatchNumber.Select(0, txtBatchNumber.Text.Length);
                            return;
                        }
                        txtWhsQuantity.Text = Convert.ToDouble(resp._list.Rows[0].ItemArray[0]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                        txtWhsQuantity.BackColor = Color.LimeGreen;

                        double UnacceptedQty = Convert.ToDouble(txtUnAccepted.Text) > Convert.ToDouble(txtWhsQuantity.Text) ? Convert.ToDouble(txtWhsQuantity.Text) : Convert.ToDouble(txtUnAccepted.Text);

                        //txtBatchQty.Text = UnacceptedQty.ToString();
                        txtBatchQty.Focus();
                        txtBatchQty.Select(0, txtBatchQty.Text.Length);
                    }

                    if (txtBatchQty.Text == "" || Convert.ToDouble(txtBatchQty.Value) == 0)
                    {
                        CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                        txtBatchQty.Focus();
                        txtBatchQty.Select(0, txtBatchQty.Text.Length);
                        return;
                    }

                    //if (type == "1250000001")
                    //{
                    if (txtBatchQty.Value > Convert.ToDecimal(txtWhsQuantity.Text))
                    {
                        CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                        txtBatchQty.Focus();
                        txtBatchQty.Select(0, txtBatchQty.Text.Length);
                        return;
                    }
                    //}

                    //if (Convert.ToDouble(txtUnAccepted.Text) == 0) //CHN
                    //{
                    //    CustomMsgBox.Show("Bütün ürünler toplanmıştır.", "Uyarı", "Tamam", "");
                    //    return;
                    //}

                    //if (txtUnAccepted.Text != "")
                    //{
                    //    if (Convert.ToDouble(txtUnAccepted.Text) == 0)
                    //    {
                    //        MessageBox.Show("Bütün ürünler toplanmıştır.");
                    //        return;
                    //    }

                    //}

                    if (type == "1250000001")
                    {
                        double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                        double accepted = Convert.ToDouble(txtAccepted.Text);
                        double currentvalue = Convert.ToDouble(txtBatchQty.Text);

                        //if (currentvalue > Convert.ToDouble(txtWhsQuantity.Text))
                        //{
                        //    CustomMsgBox.Show("DEPO MİKTARINDAN FAZLA MİKTAR GİRİLEMEZ" +
                        //        ".", "Uyarı", "Tamam", "");
                        //    txtBatchQty.Focus();
                        //    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                        //    return;
                        //}

                        accepted = accepted + currentvalue;
                        Unaccepted = Unaccepted - currentvalue;

                        txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                        txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    }
                    else if (type == "Tlpsz1250000001")
                    {
                        double currentvalue = Convert.ToDouble(txtBatchQty.Text);
                        double accepted = Convert.ToDouble(txtAccepted.Text);

                        //if (currentvalue > Convert.ToDouble(txtWhsQuantity.Text))
                        //{
                        //    CustomMsgBox.Show("DEPO MİKTARINDAN FAZLA MİKTAR GİRİLEMEZ" +
                        //        ".", "Uyarı", "Tamam", "");
                        //    txtBatchQty.Focus();
                        //    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                        //    return;
                        //}

                        accepted = accepted + currentvalue;
                        txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    }

                    DataRow dr = dtParties.NewRow();
                    dr["Parti No"] = txtBatchNumber.Text.ToString();
                    dr["Parti Miktarı"] = Convert.ToDouble(txtBatchQty.Text);
                    dr["DepoYeriId"] = txtSecilenDepoYeriId.Text;
                    dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text;
                    dr["HedefDepoYeriId"] = txtHedefDepoYeriId.Text;
                    dr["HedefDepoYeriAdi"] = txtHedefDepoYeriAdi.Text;

                    dtParties.Rows.Add(dr);

                    txtBatchNumber.Text = "";
                    txtBatchQty.Text = "";
                    txtPartyBarcode.Text = "";
                }

                //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgParties.AutoResizeRows();
                txtBatchNumber.Focus();

                if (dtgParties.Rows.Count > 0)
                {
                    dtgParties.Rows[0].Selected = false;
                }

                txtWhsQuantity.BackColor = txtItemCode.BackColor;
                txtWhsQuantity.Text = "";
            }
            catch (Exception)
            {
            }
        }

        private string warehouse = "";
        private string formName = "";

        private void TalebeBagliDepoNakli_3_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;

            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtBatchQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;
            styles[10].SizeType = SizeType.Absolute;
            styles[10].Height = 0;
            dtgParties.RowTemplate.Height = 55;
            dtgParties.ColumnHeadersHeight = 60;
            try
            {
                dtParties = new DataTable();
                dtParties.Columns.Add("Parti No", typeof(string));
                dtParties.Columns.Add("Parti Miktarı", typeof(double));
                dtParties.Columns.Add("DepoYeriId", typeof(string));
                dtParties.Columns.Add("DepoYeriAdi", typeof(string));
                dtParties.Columns.Add("HedefDepoYeriId", typeof(string));
                dtParties.Columns.Add("HedefDepoYeriAdi", typeof(string));
            }
            catch (Exception ex)
            {
            }

            if (type == "1250000001")
            {
                var existrecord = TalebeBagliDepoNakli_2.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2.DocEntry && x.LineNumber == TalebeBagliDepoNakli_2.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = TalebeBagliDepoNakli_2.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2.DocEntry && x.LineNumber == TalebeBagliDepoNakli_2.currentRow).Sum(y => y.BatchQuantity);

                var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

                var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtBatchQty.Value = Convert.ToDecimal(res);
                warehouse = TalebeBagliDepoNakli_2.warehouse;
            }
            else if (type == "Tlpsz1250000001")
            {
                var existrecord = TalepsizDepoNakli_1.StokTransferBatches.Where(x => x.LineNumber == TalepsizDepoNakli_1.currentRow).ToList();

                if (existrecord.Count > 0)
                {
                    foreach (var item in existrecord)
                    {
                        DataRow dr = dtParties.NewRow();
                        dr["Parti No"] = item.BatchNumber.ToString();
                        dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                        dr["DepoYeriId"] = item.DepoYeriId;
                        dr["DepoYeriAdi"] = item.DepoYeriAdi;
                        dr["HedefDepoYeriId"] = item.HedefDepoYeriId;
                        dr["HedefDepoYeriAdi"] = item.HedefDepoYeriAdi;

                        dtParties.Rows.Add(dr);
                    }
                }

                var sum = TalebeBagliDepoNakli_2.inventoryGenEntryBatches.Where(x => x.DocEntry == TalebeBagliDepoNakli_2.DocEntry && x.LineNumber == TalebeBagliDepoNakli_2.currentRow).Sum(y => y.BatchQuantity);

                //var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

                //var res = unaccepted - sum;
                txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                warehouse = TalepsizDepoNakli_1.fromWhsCode;
            }

            dtgParties.DataSource = dtParties;

            //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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

            dtgParties.EnableHeadersVisualStyles = false;
            dtgParties.RowTemplate.Height = 55;

            DataTable BatchDt = new DataTable();

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

            Response resp = null;

            if (Giris.genelParametreler.DepoYeriCalisir == "Y")
            {
                if (type == "Tlpsz1250000001" || type == "1250000001")
                {
                    resp = aIFTerminalServiceSoapClient.GetBatchQuantity_DepoYeri(Giris._dbName, warehouse, txtItemCode.Text, txtOnEkranKaynakDepoId.Text, Giris.mKodValue);
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
                //CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
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
            txtBatchNumber.Focus();
            vScrollBar1.Maximum = dtgParties.RowCount;

            if (Giris.genelParametreler.DepoYeriCalisir != "Y")
            {
                dtgParties.Columns["DepoYeriId"].Visible = false;
                dtgParties.Columns["DepoYeriAdi"].Visible = false;
                dtgParties.Columns["HedefDepoYeriId"].Visible = false;
                dtgParties.Columns["HedefDepoYeriAdi"].Visible = false; 
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (dtParties.Rows.Count == 0)
            //{
            //    CustomMsgBox.Show("SATIR DOLU OLMADAN İŞLEM YAPILAMAZ.", "Uyarı", "Tamma", "");
            //    return;
            //}
            if (type == "1250000001")
            {
                //if (Convert.ToDouble(txtUnAccepted.Text) != 0)
                //{
                //    MessageBox.Show("Toplanmayan miktar varken işleme devam edilemez.");
                //    return;
                //}

                TalebeBagliDepoNakli_2.inventoryGenEntryBatches.RemoveAll(x => x.LineNumber == TalebeBagliDepoNakli_2.currentRow && x.DocEntry == TalebeBagliDepoNakli_2.DocEntry);

                foreach (DataRow item in dtParties.Rows)
                {
                    TalebeBagliDepoNakli_2.inventoryGenEntryBatches.Add(new Models.InventoryGenEntryBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = TalebeBagliDepoNakli_2.currentRow,
                        DocEntry = TalebeBagliDepoNakli_2.DocEntry,
                        SAPLineNum = TalebeBagliDepoNakli_2.sapLineNum,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                        HedefDepoYeriId = item["HedefDepoYeriId"].ToString(),
                        HedefDepoYeriAdi = item["HedefDepoYeriAdi"].ToString(),
                    }); ;
                }

                dialogresult = "Ok";

                Close();
            }
            else if (type == "Tlpsz1250000001")
            {
                //if (Convert.ToDouble(txtUnAccepted.Text) != 0)
                //{
                //    MessageBox.Show("Toplanmayan miktar varken işleme devam edilemez.");
                //    return;
                //}

                TalepsizDepoNakli_1.StokTransferBatches.RemoveAll(x => x.LineNumber == TalepsizDepoNakli_1.currentRow);

                foreach (DataRow item in dtParties.Rows)
                {
                    TalepsizDepoNakli_1.StokTransferBatches.Add(new Models.StokTransferBatch
                    {
                        BatchNumber = item["Parti No"].ToString(),
                        BatchQuantity = Convert.ToDouble(item["Parti Miktarı"]),
                        ItemCode = txtItemCode.Text,
                        LineNumber = TalepsizDepoNakli_1.currentRow,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                        HedefDepoYeriId = item["HedefDepoYeriId"].ToString(),
                        HedefDepoYeriAdi = item["HedefDepoYeriAdi"].ToString(),
                    });
                }

                dialogresult = "Ok";

                Close();
            }
        }

        private DataTable BatchInWarehouseDt = new DataTable();

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnShowBatchWhs_Click(object sender, EventArgs e)
        {
            //DepodakiPartiler n = new DepodakiPartiler("67", BatchInWarehouseDt, txtWhsQuantity, txtBatchNumber,"TALEBE BAĞLI DEPO NAKLİ");
            //n.ShowDialog();

            //if (dialogresult == "Ok")
            //{
            //    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
            //    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

            //    double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

            //    txtBatchQty.Text = UnacceptedQty.ToString("N" + Giris.genelParametreler.OndalikMiktar);

            //    dialogresult = "";

            //    txtBatchNumber.Focus();
            //}

            if (type == "1250000001")
            {
                DepodakiPartiler n = new DepodakiPartiler("1250000001", BatchInWarehouseDt, txtWhsQuantity, txtBatchNumber, "TALEBE BAĞLI DEPO NAKLİ");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                if (dialogresult == "Ok")
                {
                    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                    double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                    txtBatchQty.Text = UnacceptedQty.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    dialogresult = "";

                    txtBatchNumber.Focus();
                    txtBatchNumber.Select(0, txtBatchNumber.Text.Length);

                    txtSecilenDepoYeriId.Text = secilenpartinumarasinindepoyeridsi;
                    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                    secilenpartinumarasinindepoyeridsi = "";
                    secilenpartinumarasinindepoyeriAdi = "";
                }
            }
            else if (type == "Tlpsz1250000001")
            {
                DepodakiPartiler n = new DepodakiPartiler("Tlpsz1250000001", BatchInWarehouseDt, txtWhsQuantity,txtBatchNumber, "TALEPSİZ DEPO NAKLİ");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                if (dialogresult == "Ok")
                {
                    var txtWhsQuantityVal = txtWhsQuantity.Text == "" ? 0 : Convert.ToDouble(txtWhsQuantity.Text);
                    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                    //double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                    txtBatchQty.Text = txtWhsQuantityVal.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                    dialogresult = "";

                    txtBatchNumber.Focus();
                    txtBatchNumber.Select(0, txtBatchNumber.Text.Length);

                    txtSecilenDepoYeriId.Text = secilenpartinumarasinindepoyeridsi;
                    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                    secilenpartinumarasinindepoyeridsi = "";
                    secilenpartinumarasinindepoyeriAdi = "";
                }
            }
        }

        private void cmbBatch_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private DataView dtview = new DataView();

        private void cmbBatch_TextChanged(object sender, EventArgs e)
        {
            //dtview.RowFilter = "BatchNum like '%" + cmbBatch.Text + "%'";

            //cmbBatch.DataSource = null;
            //cmbBatch.DisplayMember = "BatchNum";
            //cmbBatch.ValueMember = "Quantity";
            //cmbBatch.DataSource = dtview;

            //cmbBatch.DroppedDown = true;
        }

        private void txtBatchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtBatchQty.Text = txtUnAccepted.Text;//chn

                string warehouse = "";

                if (type == "Tlpsz1250000001")
                {
                    warehouse = TalepsizDepoNakli_1.fromWhsCode;
                }
                else
                {
                    warehouse = TalebeBagliDepoNakli_2.warehouse;
                }

                AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                var resp = aIFTerminalServiceSoapClient.GetBatchQuantity(Giris._dbName, warehouse, txtBatchNumber.Text, txtItemCode.Text, Giris.mKodValue);

                if (resp.Val == 0)
                {
                    if (txtBatchNumber.Text == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BOŞ BIRAKILAMAZ.", "Uyarı", "Tamam", "");
                        txtBatchNumber.Text = "";
                        txtBatchNumber.Focus();

                        return;
                    }
                    else if (resp._list.Rows[0].ItemArray[0].ToString() == "")
                    {
                        CustomMsgBox.Show("PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtBatchNumber.Focus();
                        txtBatchNumber.Select(0, txtBatchNumber.Text.Length);

                        return;
                    }

                    txtWhsQuantity.Text = resp._list.Rows[0].ItemArray[0].ToString() == "" ? "0" : Convert.ToDouble(resp._list.Rows[0].ItemArray[0]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    txtWhsQuantity.BackColor = Color.LimeGreen;

                    double UnacceptedQty = Convert.ToDouble(txtUnAccepted.Text) > Convert.ToDouble(txtWhsQuantity.Text) ? Convert.ToDouble(txtWhsQuantity.Text) : Convert.ToDouble(txtUnAccepted.Text);

                    txtBatchQty.Text = UnacceptedQty.ToString();
                    txtBatchQty.Focus();
                    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                }
                else
                    CustomMsgBox.Show(resp.Desc, "Uyarı", "Tamam", "");
            }
        }

        private void dtgParties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtBatchQty_MouseDown(object sender, MouseEventArgs e)
        {
            txtBatchQty.Select(0, txtBatchQty.Text.Length);
        }

        private void txtBatchQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBatchQty.Text == "" || Convert.ToDouble(txtBatchQty.Value) == 0)
                {
                    CustomMsgBox.Show("MİKTAR GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtBatchQty.Focus();
                    txtBatchQty.Select(0, txtBatchQty.Text.Length);
                }
                else
                {
                    btnCollect.PerformClick();
                }
                //if (txtBatchQty.Text != "")
                //{
                //    if (Convert.ToDouble(txtBatchQty.Value) > 0)
                //    {
                //        btnCollect.PerformClick();
                //    }
                //}
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
            if (type == "1250000001")
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

        private void txtBatchQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtBatchQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}