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
    public partial class PaletYapma_3 : form_Base
    {
        public PaletYapma_3(string _formName, List<string> _list)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblArama.Font.Size;
            lblArama.Resize += Form_Resize;

            formName = _formName;
            list = _list;

            txtPaletNo.Text = list[0].ToString();
            txtUrunKodu.Text = list[1].ToString();
            txtUrunTanim.Text = list[2].ToString();
            txtQty.Text = list[3].ToString();

            if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
            {
                txtSecilenDepoKodu.Text = list[4].ToString();
                txtSecilenDepoAdi.Text = list[5].ToString();
                txtBarcode.Text = list[6].ToString();
                txtSecilenDepoYeriId.Text = list[7].ToString();
                txtSecilenDepoYeriAdi.Text = list[8].ToString();

                label2.Visible = true;
                label3.Visible = true;
                txtPartiNo.Visible = true;
                txtPartiMiktar.Visible = true;
                tableLayoutPanel4.Visible = true;
                btnPartiSec.Visible = true;
                btnSatirSil.Visible = true;
                btnTopla.Visible = true;
                dtgParties.Visible = true;
                vScrollBar1.Visible = true;
                txtSecilenDepoKodu.Visible = true;
                txtSecilenDepoAdi.Visible = true;
                txtSecilenDepoYeriId.Visible = true;
                txtSecilenDepoYeriAdi.Visible = true;
            } 
        }

        private List<string> list = new List<string>();
        public static string dialogresult = "";
        public static double quantity = 0;
        private string formName = "";
        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            lblArama.Font = new Font(lblArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblArama.Font.Style);

            label1.Font = new Font(lblArama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            lblForm.Font = new Font(lblForm.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblForm.Font.Style);

            lblUrunKodu.Font = new Font(lblUrunKodu.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblUrunKodu.Font.Style);

            lblTanim.Font = new Font(lblTanim.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               lblTanim.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label3.Font.Style);

            txtUrunKodu.Font = new Font(txtUrunKodu.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunKodu.Font.Style);

            btnKapat.Font = new Font(btnKapat.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKapat.Font.Style);

            txtPaletNo.Font = new Font(txtPaletNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPaletNo.Font.Style);

            txtUrunTanim.Font = new Font(txtUrunTanim.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUrunTanim.Font.Style);

            txtQty.Font = new Font(txtQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtQty.Font.Style);


            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartiNo.Font.Style);

            txtPartiMiktar.Font = new Font(txtPartiMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartiMiktar.Font.Style);

            btnPartiSec.Font = new Font(btnPartiSec.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPartiSec.Font.Style);

            btnSatirSil.Font = new Font(btnSatirSil.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSatirSil.Font.Style);

            btnTopla.Font = new Font(btnTopla.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTopla.Font.Style);

            dtgParties.Font = new Font(dtgParties.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              dtgParties.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtUrunKodu.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPaletNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtUrunTanim.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartiNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPartiMiktar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        public static DataTable dtParties = new DataTable(); 
        private string type = "";
        private DataTable BatchInWarehouseDt = new DataTable();

        private void btnKapat_Click(object sender, EventArgs e)
        {
            quantity = txtQty.Text == "" ? 0 : Convert.ToDouble(txtQty.Value);

            if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
            {
                #region MİKTAR kontolü
                double sum = 0;

                sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

                double paletmik = Convert.ToDouble(txtQty.Text);

                if (paletmik < sum)
                {
                    CustomMsgBox.Show("PALET MİKTARI, PARTİ MİKTARINDAN AZ OLAMAZ", "Uyarı", "Tamam", "");
                    txtQty.Focus();
                    txtQty.Select(0, txtQty.Text.Length);
                    return;
                }
                #endregion

                PaletYapma_2.paletYapmaPartilers.RemoveAll(x => x.PartiSatirNo == PaletYapma_2.detaySatirNo);

                foreach (DataRow item in dtParties.Rows)
                {
                    PaletYapma_2.paletYapmaPartilers.Add(new PaletYapmaPartiler
                    {
                        PartiNumarasi = item["Parti No"].ToString(),
                        Miktar = Convert.ToDouble(item["Parti Miktarı"]),
                        Barkod = txtBarcode.Text,
                        KalemKodu = txtUrunKodu.Text,
                        KalemTanimi = txtUrunTanim.Text,
                        DepoKodu = txtSecilenDepoKodu.Text,
                        DepoAdi = txtSecilenDepoAdi.Text,
                        PartiSatirNo = PaletYapma_2.detaySatirNo,
                        //DocEntry = SipariseBagliTeslimat_2.DocEntry,
                        //SAPLineNum = SipariseBagliTeslimat_2.sapLineNum,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString()
                    });
                }
            }

            dialogresult = "Ok";

            Close();
        }

        private void PaletYapma_3_Load(object sender, EventArgs e)
        {
            lblForm.Text = formName;

            txtQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
            {
                string warehouse = "";
                
                try
                {
                    dtgParties.RowTemplate.Height = 55;
                    dtgParties.ColumnHeadersHeight = 60;


                    dtParties = new DataTable();
                    dtParties.Columns.Add("Barkod", typeof(string));
                    dtParties.Columns.Add("KalemKodu", typeof(string));
                    dtParties.Columns.Add("KalemAdi", typeof(string));
                    dtParties.Columns.Add("Parti No", typeof(string));
                    dtParties.Columns.Add("Parti Miktarı", typeof(double));
                    dtParties.Columns.Add("DepoYeriId", typeof(string));
                    dtParties.Columns.Add("DepoYeriAdi", typeof(string));
                    dtParties.Columns.Add("DepoKodu", typeof(string));
                    dtParties.Columns.Add("DepoAdi", typeof(string));

                    var existrecord = PaletYapma_2.paletYapmaPartilers.Where(x => x.PartiSatirNo == PaletYapma_2.detaySatirNo).ToList();

                    if (existrecord.Count > 0)
                    {
                        foreach (var item in existrecord)
                        {
                            DataRow dr = dtParties.NewRow();
                            dr["Barkod"] = item.Barkod.ToString();
                            dr["KalemKodu"] = item.KalemKodu.ToString();
                            dr["KalemAdi"] = item.KalemTanimi.ToString();
                            dr["Parti No"] = item.PartiNumarasi.ToString();
                            dr["Parti Miktarı"] = Convert.ToDouble(item.Miktar);
                            dr["DepoYeriId"] = item.DepoYeriId == null ? "" : item.DepoYeriId.ToString();
                            dr["DepoYeriAdi"] = item.DepoYeriAdi == null ? "" : item.DepoYeriAdi.ToString();
                            dr["DepoKodu"] = item.DepoKodu == null ? "" : item.DepoKodu.ToString();
                            dr["DepoAdi"] = item.DepoAdi == null ? "" : item.DepoAdi.ToString();
                            dtParties.Rows.Add(dr);
                        }
                    }

                    //foreach (var item in SipariseBagliTeslimat_2.DeliveryBatches)
                    //{
                    //    DataRow dr = dtAllParties.NewRow();
                    //    dr["Parti No"] = item.BatchNumber.ToString();
                    //    dr["Parti Miktarı"] = Convert.ToDouble(item.BatchQuantity);
                    //    dr["DepoYeriId"] = item.DepoYeriId.ToString();
                    //    dr["DepoYeriAdi"] = item.DepoYeriAdi.ToString();

                    //    dtAllParties.Rows.Add(dr);
                    //}

                    //var sum = PaletYapma_2.paletYapmaPartilers.Where(x => x.PartiSatirNo == PaletYapma_2.currentRow).Sum(y => y.BatchQuantity);

                    //var unaccepted = Convert.ToDouble(txtUnAccepted.Text);

                    //var res = unaccepted - sum;
                    //txtAccepted.Text = sum.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    //txtUnAccepted.Text = res.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                    //txtPartyQty.Value = Convert.ToDecimal(res);
                    //warehouse = SipariseBagliTeslimat_2.warehouse;
                    //txtOnEkrandanSecilenDepo.Text = warehouse;

                    dtgParties.DataSource = dtParties;

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

                        dtgParties.Columns["Parti No"].HeaderText = "PARTİ NO";
                        dtgParties.Columns["Parti Miktarı"].HeaderText = "PARTİ MİKTARI";

                        dtgParties.Columns["DepoKodu"].HeaderText = "DEPO KODU";
                        dtgParties.Columns["DepoAdi"].HeaderText = "DEPO ADI";
                        //dtgParties.Columns["DepoYeriId"].Visible = false;
                        //dtgParties.Columns["DepoYeriAdi"].Visible = false;

                        dtgParties.Columns["Barkod"].Visible = false;
                        dtgParties.Columns["KalemKodu"].Visible = false;
                        dtgParties.Columns["KalemAdi"].Visible = false; 
                    }


                    //DataTable BatchDt = new DataTable();

                    AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();

                    Response resp = null;
                    if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                    {
                        if (Giris.genelParametreler.PaletYapmadaDepoSecilsin == "Y")
                        {
                            resp = aIFTerminalServiceSoapClient.GetBatchQuantity_DepoYeri(Giris._dbName, txtSecilenDepoKodu.Text, txtUrunKodu.Text, txtSecilenDepoYeriId.Text, Giris.mKodValue);
                        }
                        else
                        {
                            resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, txtSecilenDepoKodu.Text, txtUrunKodu.Text, Giris.mKodValue);
                        }
                    }
                    else
                    {
                        resp = aIFTerminalServiceSoapClient.GetBatchByItemCode(Giris._dbName, txtSecilenDepoKodu.Text, txtUrunKodu.Text, Giris.mKodValue);
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
                    txtPartiNo.Focus();
                    vScrollBar1.Maximum = dtgParties.RowCount;
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM", "");
                }
            }
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
        private void btnPartiSec_Click(object sender, EventArgs e)
        {
            try
            {
                DepodakiPartiler n = new DepodakiPartiler("Palet", BatchInWarehouseDt, txtPartiMiktar, txtPartiNo, "PALET PARTİ SEÇİMİ");
                n.ShowDialog();
                n.Dispose();
                GC.Collect();

                //if (dialogResult == "Ok")
                //{
                //    var txtWhsQuantityVal = txtPartiMiktar.Text == "" ? 0 : Convert.ToDouble(txtPartiMiktar.Text);
                //    var txtUnAcceptedVal = txtUnAccepted.Text == "" ? 0 : Convert.ToDouble(txtUnAccepted.Text);

                //    double UnacceptedQty = Convert.ToDouble(txtUnAcceptedVal) > Convert.ToDouble(txtWhsQuantityVal) ? Convert.ToDouble(txtWhsQuantityVal) : Convert.ToDouble(txtUnAcceptedVal);

                //    txtPartyQty.Text = UnacceptedQty.ToString();

                //    dialogResult = "";

                //    txtPartyQty.Focus();
                //    txtPartyQty.Select(0, txtPartyQty.Text.Length);

                //    txtSecilenDepoYeri.Text = secilenpartinumarasinindepoyeridsi;
                //    txtSecilenDepoYeriAdi.Text = secilenpartinumarasinindepoyeriAdi;

                //    secilenpartinumarasinindepoyeridsi = "";
                //    secilenpartinumarasinindepoyeriAdi = "";
                //}
            }
            catch (Exception ex)
            {

            }
        }
        private int currentRow = -1;

        private void btnSatirSil_Click(object sender, EventArgs e)
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

            //var sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

            //double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
            //double accepted = Convert.ToDouble(txtAccepted.Text);

            //accepted = sum;
            //Unaccepted = Unaccepted + satirdasilinenMiktar;

            //txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            //if (type == "1250000001")
            //{
            //    txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
            //}
            if (dtgParties.Rows.Count > 0)
            {
                dtgParties.Rows[0].Selected = false;

                dtgParties.Columns["Parti No"].HeaderText = "PARTİ NO";
                dtgParties.Columns["Parti Miktarı"].HeaderText = "PARTİ MİKTARI";

                //dtgParties.Columns["DepoYeriId"].Visible = false;
                //dtgParties.Columns["DepoYeriAdi"].Visible = false;
            }
        }

        private void btnTopla_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartiNo.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASINI GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartiNo.Focus();
                    txtPartiNo.Select(0, txtPartiNo.Text.Length);
                    return;
                }
                if (txtPartiNo.Text != "")
                {
                    #region parti sorgula 
                    //if (BatchInWarehouseDt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow item in BatchInWarehouseDt.Rows)
                    //    {
                    //        var batchNumber = item["BatchNum"].ToString();
                    //        double batchQty = parseNumber_Seperator.ConvertToDouble(item["Quantity"].ToString());

                    //        if (txtPartiNo.Text == batchNumber)
                    //        {
                    //            double girilen = parseNumber_Seperator.ConvertToDouble(txtPartiMiktar.Value.ToString()) + parseNumber_Seperator.ConvertToDouble(txtAccepted.Value.ToString());
                    //            double listedekimik = parseNumber_Seperator.ConvertToDouble(batchQty.ToString());
                    //            if (girilen > listedekimik)
                    //            {
                    //                CustomMsgBox.Show("MİKTAR, PARTİ MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                    //                txtPartiMiktar.Focus();
                    //                txtPartiMiktar.Select(0, txtPartiMiktar.Text.Length);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //} 
                    #endregion parti sorgula

                    var party = BatchInWarehouseDt.AsEnumerable().Where(x => x.Field<string>("BatchNum") == txtPartiNo.Text).ToList();

                    if (party.Count == 0)
                    {
                        CustomMsgBox.Show(txtPartiNo.Text + " NUMARALI PARTİ NUMARASI BULUNAMADI.", "Uyarı", "Tamam", "");
                        txtPartiNo.Focus();
                        txtPartiNo.Select(0, txtPartiNo.Text.Length);
                        return;
                    }
                    else
                    {
                        //txtWhsQuantity.Text = Convert.ToDouble(party[0].ItemArray[4]).ToString("N"+Giris.genelParametreler.OndalikMiktar);//acınca ana ekrana atıyor
                        //txtPartiMiktar.BackColor = Color.LimeGreen;
                    }
                }

                if (txtPartiMiktar.Text == "")
                {
                    CustomMsgBox.Show("PARTİ MİKTARI GİRİNİZ.", "Uyarı", "Tamam", "");
                    txtPartiMiktar.Focus();
                    txtPartiMiktar.Select(0, txtPartiMiktar.Text.Length);
                    return;
                }

                if (txtPartiNo.Text == "")
                {
                    CustomMsgBox.Show("PARTİ NUMARASI GİRİNİZ.", "Uyarı", "Tamam", "");
                    return;
                }

                if (txtPartiMiktar.Text == "")
                {
                    CustomMsgBox.Show("PARTİ MİKTARI GİRİNİZ.", "Uyarı", "Tamam", "");
                    return;
                }



                double sum = 0;

                sum = dtParties.AsEnumerable().Sum(x => x.Field<double>("Parti Miktarı"));

                double paletmik = Convert.ToDouble(txtQty.Text);
                double partimik = Convert.ToDouble(txtPartiMiktar.Text);

                sum = partimik + sum;

                if (sum > paletmik)
                {
                    CustomMsgBox.Show("PARTİ MİKTARI, PALET MİKTARINDAN FAZLA OLAMAZ", "Uyarı", "Tamam", "");
                    txtPartiMiktar.Focus();
                    txtPartiMiktar.Select(0, txtPartiMiktar.Text.Length);
                    return;
                }

                //double Unaccepted = Convert.ToDouble(txtUnAccepted.Text);
                //double accepted = Convert.ToDouble(txtAccepted.Text);
                //double currentvalue = Convert.ToDouble(txtPartyQty.Text);
                //var partyqty = Convert.ToDouble(txtPartyQty.Text);
                //var warehousqty = Convert.ToDouble(txtWhsQuantity.Text);

                //accepted = accepted + currentvalue;
                //Unaccepted = Unaccepted - currentvalue;

                DataRow dr = dtParties.NewRow();
                dr["Parti No"] = txtPartiNo.Text.ToString();
                dr["Parti Miktarı"] = Convert.ToDouble(txtPartiMiktar.Text);
                dr["DepoYeriId"] = txtSecilenDepoYeriId.Text.ToString();
                dr["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();
                dr["DepoKodu"] = txtSecilenDepoKodu.Text;//txtSecilenDepoYeri.Text.ToString();
                dr["DepoAdi"] = txtSecilenDepoAdi.Text;//txtSecilenDepoYeriAdi.Text.ToString();
                dr["Barkod"] = txtBarcode.Text;//txtSecilenDepoYeri.Text.ToString();
                dr["KalemKodu"] = txtUrunKodu.Text;//txtSecilenDepoYeriAdi.Text.ToString();
                dr["KalemAdi"] = txtUrunTanim.Text;//txtSecilenDepoYeriAdi.Text.ToString();

                dtParties.Rows.Add(dr);

                PaletYapma_2.paletYapmaPartilers.RemoveAll(x => x.PartiSatirNo == PaletYapma_2.detaySatirNo);

                foreach (DataRow item in dtParties.Rows)
                {
                    PaletYapma_2.paletYapmaPartilers.Add(new  PaletYapmaPartiler
                    {
                        PartiNumarasi = item["Parti No"].ToString(),
                        Miktar = Convert.ToDouble(item["Parti Miktarı"]),
                        KalemKodu = txtUrunKodu.Text,
                        DepoKodu = item["DepoKodu"].ToString(),
                        DepoAdi = item["DepoAdi"].ToString(),
                        PartiSatirNo = PaletYapma_2.detaySatirNo,
                        //DocEntry = SipariseBagliTeslimat_2.DocEntry,
                        //SAPLineNum = SipariseBagliTeslimat_2.sapLineNum,
                        DepoYeriId = item["DepoYeriId"].ToString(),
                        DepoYeriAdi = item["DepoYeriAdi"].ToString(),
                        Barkod = txtBarcode.Text,
                        KalemTanimi = txtUrunTanim.Text,
                    });
                }


                //DataRow dr2 = dtAllParties.NewRow();
                //dr2["Parti No"] = txtPartyNo.Text.ToString();
                //dr2["Parti Miktarı"] = Convert.ToDouble(txtPartyQty.Text);
                //dr2["DepoYeriId"] = txtSecilenDepoYeri.Text.ToString();
                //dr2["DepoYeriAdi"] = txtSecilenDepoYeriAdi.Text.ToString();

                //dtAllParties.Rows.Add(dr2);

                //txtAccepted.Text = accepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtUnAccepted.Text = Unaccepted.ToString("N" + Giris.genelParametreler.OndalikMiktar);

                txtPartiNo.Text = "";
                txtPartiMiktar.Text = "";
                //txtDepoKodu.Text = "";
                //txtDepoAdi.Text = "";
                //txtPartyBarcode.Text = ""; 
                if (dtgParties.Rows.Count > 0)
                {
                    dtgParties.Rows[0].Selected = false;

                    dtgParties.Columns["Parti No"].HeaderText = "PARTİ NO";
                    dtgParties.Columns["Parti Miktarı"].HeaderText = "PARTİ MİKTARI";

                    //dtgParties.Columns["DepoYeriId"].Visible = false;
                    //dtgParties.Columns["DepoYeriAdi"].Visible = false;
                }
                //dtgParties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgParties.AutoResizeRows();
                txtPartiNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA ", ex.Message);
            }
        }

        private void txtPartiMiktar_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPartiMiktar, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void dtgParties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
        }

        private void txtQty_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}