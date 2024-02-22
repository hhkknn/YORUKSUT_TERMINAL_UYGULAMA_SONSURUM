using AIF.TERMINAL.AIFTerminalService;
using AIF.TERMINAL.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class PartisizKalemSecimi : form_Base
    {
        //start font
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        private List<dynamic> list = null;
        //List<PartiliPartisizEkranList> partiliPartisizEkranLists = new List<PartiliPartisizEkranList>();

        //public PartisizKalemSecimi(string _type, List<PartiliPartisizEkranList> _partiliPartisizEkranLists, string _formName)
        public PartisizKalemSecimi(string _type, List<dynamic> _list, string _formName)
        {
            InitializeComponent();
            //start font
            AutoScaleMode = AutoScaleMode.None;
            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            //end font

            list = _list;
            //partiliPartisizEkranLists = _partiliPartisizEkranLists;
            type = _type;
            formName = _formName;

            if (type == "20")//siparissiz
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.ReadOnly = true;
                txtPartyQty.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;

                    txtDepoKodu.Text = list[10].ToString();
                    txtDepoTanim.Text = list[9].ToString();
                    txtDepoYeriId.Text = list[7].ToString();
                    txtDepoYeri.Text = list[8].ToString();
                }
            }
            else if (type == "22")//siparisli
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtDepoTanim.Text = list[7].ToString();
                txtDepoKodu.Text = list[8].ToString();
                txtDepoYeriId.Text = list[9].ToString();
                txtDepoYeri.Text = list[10].ToString();

                var accept = Convert.ToDouble(txtAccepted.Text);
                var unaccept = Convert.ToDouble(txtUnAccepted.Text);

                var toplanmayan = unaccept - accept;

                txtUnAccepted.Text = toplanmayan.ToString();

                txtOnOrder.ReadOnly = true;
                txtPartyQty.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;
                }
            }
            else if (type == "59") //belgesiz mal girisi
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtAccepted.Text = "0";
                txtUnAccepted.ReadOnly = true;
                txtPartyQty.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;

                    txtDepoKodu.Text = list[10].ToString();
                    txtDepoTanim.Text = list[9].ToString();
                    txtDepoYeriId.Text = list[7].ToString();
                    txtDepoYeri.Text = list[8].ToString();
                }
            }
            else if (type == "1250000001")//talebe bagli
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N"+Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                txtAccepted.Text = "0";
                //txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N"+Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtPartyQty.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;
                    label19.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;
                    txtHedefDepoYeri.Visible = true;
                    txtHedefDepoYeriId.Visible = true;
                    txtHedefDepoAdi.Visible = true;
                    txtHedefDepoKodu.Visible = true;
                    cmbPrinter.Visible = false;

                    txtDepoKodu.Text = list[7].ToString();
                    txtDepoTanim.Text = list[8].ToString();
                    txtDepoYeriId.Text = list[9].ToString();
                    txtDepoYeri.Text = list[10].ToString();
                    txtHedefDepoAdi.Text = list[12].ToString();
                    txtHedefDepoKodu.Text = list[11].ToString();
                    txtHedefDepoYeri.Text = list[14].ToString();
                    txtHedefDepoYeriId.Text = list[13].ToString();
                }

                txtAccepted.Text = Convert.ToDouble(list[15]).ToString("N" + Giris.genelParametreler.OndalikMiktar);
                //txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N"+Giris.genelParametreler.OndalikMiktar);

                var accept = Convert.ToDouble(txtAccepted.Text);
                var sipmik = Convert.ToDouble(txtOnOrder.Text);

                var toplanmayan = sipmik - accept;

                txtUnAccepted.Text = toplanmayan.ToString();
                onaydabekleyenMik = Convert.ToDouble(list[15]);
            }
            else if (type == "Tlpsz1250000001")
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString();
                //txtWhsQuantity.Text = Convert.ToDouble(list[4]).ToString("N"+Giris.genelParametreler.OndalikMiktar);
                //txtOnOrder.Text = Convert.ToDouble(list[4]).ToString("N"+Giris.genelParametreler.OndalikMiktar);
                //txtOnOrder.Value = 0;
                txtAccepted.Text = "0";
                //txtUnAccepted.Text = Convert.ToDouble(list[5]).ToString("N"+Giris.genelParametreler.OndalikMiktar);
                txtOnOrder.ReadOnly = true;
                txtPartyQty.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;
                    label19.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;
                    txtHedefDepoYeri.Visible = true;
                    txtHedefDepoYeriId.Visible = true;
                    txtHedefDepoAdi.Visible = true;
                    txtHedefDepoKodu.Visible = true;

                    txtDepoKodu.Text = list[9].ToString();
                    txtDepoTanim.Text = list[8].ToString();
                    txtDepoYeriId.Text = list[6].ToString();
                    txtDepoYeri.Text = list[7].ToString();
                    txtHedefDepoAdi.Text = list[12].ToString();
                    txtHedefDepoKodu.Text = list[13].ToString();
                    txtHedefDepoYeri.Text = list[11].ToString();
                    txtHedefDepoYeriId.Text = list[10].ToString();
                }
            }
            else if (type == "60") //begesz mal cksii
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
                txtPartyQty.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;

                    txtDepoKodu.Text = list[10].ToString();
                    txtDepoTanim.Text = list[9].ToString();
                    txtDepoYeriId.Text = list[7].ToString();
                    txtDepoYeri.Text = list[8].ToString();
                }
            }
            else if (type == "17")//SİPARİSE BAGLİ
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
                txtPartyQty.Text = Convert.ToDouble(list[6]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;

                    txtDepoKodu.Text = list[7].ToString();
                    txtDepoTanim.Text = list[8].ToString();
                    txtDepoYeriId.Text = list[9].ToString();
                    txtDepoYeri.Text = list[10].ToString();
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
                txtPartyQty.Text = Convert.ToDouble(list[5]).ToString("N" + Giris.genelParametreler.OndalikMiktar);

                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    txtDepoKodu.Visible = true;
                    txtDepoTanim.Visible = true;
                    txtDepoYeri.Visible = true;
                    txtDepoYeriId.Visible = true;

                    txtDepoKodu.Text = list[9].ToString();
                    txtDepoTanim.Text = list[8].ToString();
                    txtDepoYeriId.Text = list[6].ToString();
                    txtDepoYeri.Text = list[7].ToString();
                }
            }
            else if (type == "AIF_CEKMELISTESI")
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtOnOrder.Text = list[3].ToString();
                txtAccepted.Text = list[4].ToString();

                if (list[3] != "0" && list[4] != "0")
                {
                    txtUnAccepted.Text = Convert.ToString(Convert.ToDouble(list[3]) - Convert.ToDouble(list[4]));
                }
                txtPartyQty.Text = list[4].ToString();
                txtPaletNo.Text = list[6];
                txtSatirKaynagi.Text = list[8].ToString();

                label20.Visible = true;
                txtPaletNo.Visible = true;
                btnPaletOlustur.Visible = true;
                btnKoliGirisi.Visible = true;
                label21.Visible = true;
                btnYzdrPalet.Visible = true;
                cmbPrinter.Visible = true;

                txtPartyQty.ReadOnly = true;
                listAllPrinters();
            }
            else if (type == "16")//iade irsaliye
            {
                txtItemCode.Text = list[0].ToString();
                txtItemName.Text = list[1].ToString();
                txtBarCode.Text = list[2].ToString();
                txtUomCode.Text = list[3].ToString(); //birim
                txtWhsQuantity.Text = list[4].ToString(); //depo miktarı
                txtAccepted.Text = list[5].ToString(); //toplanan mik
                //txtUnAccepted.Text = list[6].ToString(); //toplanymayan miktar ??????
            }
        }

        public static string dialogresult = "";
        public static double quantity = 0;
        public static string paletNo = "";
        public static string depoYeriId = "";
        public static string depoYeriAdi = "";
        public static string depoKodu = "";
        public static string depoAdi = "";
        public static string hedefDepoYeriId = "";
        public static string hedefDepoYeriAdi = "";
        public static string hedefDepoAdi = "";
        public static string hedefDepoKodu = "";
        public static string satirkaynagi = "";
        public static double onaydabekleyenMik = 0;

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

            label11.Font = new Font(label11.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label11.Font.Style);

            label12.Font = new Font(label12.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label12.Font.Style);

            label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label13.Font.Style);

            label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label14.Font.Style);

            label15.Font = new Font(label15.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label15.Font.Style);

            label16.Font = new Font(label16.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label16.Font.Style);

            label17.Font = new Font(label17.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label17.Font.Style);

            label18.Font = new Font(label18.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label18.Font.Style);

            label19.Font = new Font(label19.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label19.Font.Style);

            label20.Font = new Font(label20.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label20.Font.Style);

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

            txtPartyQty.Font = new Font(txtPartyQty.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartyQty.Font.Style);

            btnComplete.Font = new Font(btnComplete.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnComplete.Font.Style);

            txtDepoKodu.Font = new Font(txtDepoKodu.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtDepoKodu.Font.Style);

            txtDepoTanim.Font = new Font(txtDepoTanim.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtDepoTanim.Font.Style);

            txtDepoYeri.Font = new Font(txtDepoYeri.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtDepoYeri.Font.Style);

            txtDepoYeriId.Font = new Font(txtDepoYeriId.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtDepoYeriId.Font.Style);

            txtHedefDepoAdi.Font = new Font(txtHedefDepoAdi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtHedefDepoAdi.Font.Style);

            txtHedefDepoKodu.Font = new Font(txtHedefDepoKodu.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtHedefDepoKodu.Font.Style);

            txtHedefDepoYeri.Font = new Font(txtHedefDepoYeri.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtHedefDepoYeri.Font.Style);

            txtHedefDepoYeriId.Font = new Font(txtHedefDepoYeriId.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtHedefDepoYeriId.Font.Style);

            txtPaletNo.Font = new Font(txtPaletNo.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtPaletNo.Font.Style);

            btnKoliGirisi.Font = new Font(btnKoliGirisi.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             btnKoliGirisi.Font.Style);

            btnPaletOlustur.Font = new Font(btnPaletOlustur.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             btnPaletOlustur.Font.Style);

            label21.Font = new Font(label21.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             label21.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             cmbPrinter.Font.Style);

            btnYzdrPalet.Font = new Font(btnYzdrPalet.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             btnYzdrPalet.Font.Style);

            ResumeLayout();
            //start yükseklik-genislik
            txtPartyQty.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtPaletNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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
        private DataTable dtParties = new DataTable();

        private void PartisizKalemSecimi_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;
            txtPartyQty.Focus();
            txtPartyQty.Select(0, txtPartyQty.Text.Length);

            txtOnOrder.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtUnAccepted.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;
            txtPartyQty.DecimalPlaces = Giris.genelParametreler.OndalikMiktar;

            if (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "20TRMN")
            {
                txtPaletNo.Visible = false;
            }
            else if (Giris.mKodValue == "30TRMN")
            {
                txtPaletNo.Visible = true;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (type == "20" || type == "22" || type == "59" || type == "Tlpsz1250000001" || type == "1250000001" || type == "60" || type == "17" || type == "Sprssz17" || type == "AIF_CEKMELISTESI" || type == "16")
            {
                if (type == "AIF_CEKMELISTESI")
                {
                    if (Giris.genelParametreler.CekmeListesiFazlaMiktarGirer != "Y")
                    {
                        if (Convert.ToDouble(txtPartyQty.Value) > Convert.ToDouble(txtOnOrder.Value))
                        {
                            CustomMsgBox.Show("SİPARİŞ EDİLEN MİKTARDAN FAZLA GİRİLEMEZ.", "Uyarı", "Tamam", "");
                            return;
                        }
                    }

                    if (txtPaletNo.Text == "")
                    {
                        CustomMsgBox.Show("PALET NO GİRİLMEDEN DEVAM EDİLEMEZ.", "Uyarı", "Tamam", "");
                        return;
                    }
                }

                #region onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                if (Giris.genelParametreler.CekmeListesiFazlaMiktarGirer != "Y")
                {
                    if (type == "1250000001" && (Giris.mKodValue == "10TRMN" || Giris.mKodValue == "30TRMN" || Giris.mKodValue == "20TRMN"))
                    {
                        double girilebilir = 0;
                        girilebilir = onaydabekleyenMik + Convert.ToDouble(txtPartyQty.Value);
                        if (girilebilir > Convert.ToDouble(txtOnOrder.Value))
                        {
                            CustomMsgBox.Show("FAZLA MİKTAR GİRİŞİ YAPTINIZ.", "Uyarı", "Tamam", "");
                            txtPartyQty.Focus();
                            txtPartyQty.Select(0, txtPartyQty.Text.Length);
                            return;
                        }
                    }
                }

                #endregion onaydaki miktarve toplanna miktar toplamından fazla miktar girişi yapılmaması için eklendi

                dialogresult = "Ok";
                quantity = txtPartyQty.Text == "" ? 0 : Convert.ToDouble(txtPartyQty.Value);
                if (Giris.genelParametreler.DepoYeriCalisir == "Y")
                {
                    depoYeriId = txtDepoYeriId.Text;
                    depoYeriAdi = txtDepoYeri.Text;
                    hedefDepoYeriAdi = txtHedefDepoYeri.Text;
                    hedefDepoYeriId = txtHedefDepoYeriId.Text;

                }
                depoKodu = txtDepoKodu.Text;
                depoAdi = txtDepoTanim.Text;
                hedefDepoAdi = txtHedefDepoAdi.Text;
                hedefDepoKodu = txtHedefDepoKodu.Text;

                paletNo = txtPaletNo.Text;
                Close();
            }
        }

        private void txtDepoYeri_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtDepoYeriId, txtDepoYeri, txtDepoKodu);
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

        private void txtDepoKodu_Click(object sender, EventArgs e)
        {
        }

        private void txtDepoTanim_TextChanged(object sender, EventArgs e)
        {
            txtDepoYeriId.Text = "";
            txtDepoYeri.Text = "";
        }

        private void txtDepoTanim_Click(object sender, EventArgs e)
        {
            try
            {
                if (type != "59")
                {
                    SelectList nesne = new SelectList("DepoSecimi", "DepoAra", "DEPO ARAMA", txtDepoKodu, txtDepoTanim);
                    nesne.ShowDialog();
                    nesne.Dispose();
                    GC.Collect();

                    if (SelectList.dialogResult == "Ok")
                    {
                        SelectList.dialogResult = "";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtHedefDepoAdi_TextChanged(object sender, EventArgs e)
        {
            txtHedefDepoYeriId.Text = "";
            txtHedefDepoYeri.Text = "";
        }

        private void txtHedefDepoAdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (type != "59")
                {
                    SelectList nesne = new SelectList("DepoSecimi", "DepoAra", "DEPO ARAMA", txtHedefDepoKodu, txtHedefDepoAdi);
                    nesne.ShowDialog();
                    nesne.Dispose();
                    GC.Collect();

                    if (SelectList.dialogResult == "Ok")
                    {
                        SelectList.dialogResult = "";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtHedefDepoYeri_Click(object sender, EventArgs e)
        {
            try
            {
                SelectList nesne = new SelectList("", "DepoYerleri", "DEPO YERLERİ", txtHedefDepoYeriId, txtHedefDepoYeri, txtHedefDepoKodu);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtPartyQty_Click(object sender, EventArgs e)
        {
            if (type == "AIF_CEKMELISTESI")
            {
                return;
            }
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPartyQty, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        public static string dialogResult = "";

        private void btnKoliGirisi_Click(object sender, EventArgs e)
        {
            try
            {
                int sipsatirno = -1;
                int siparisNumarasi = -1;

                //var sipsatirno = list[5] == "" || list[5] == null ? -1 : Convert.ToInt32(list[5]);
                //var siparisNumarasi = list[7] == "" || list[7] == null ? -1 : Convert.ToInt32(list[7]);

                sipsatirno = list[5] == null ? -1 : Convert.ToInt32(list[5]);
                siparisNumarasi = list[7] == null ? -1 : Convert.ToInt32(list[7]);

                list[5] = sipsatirno;
                list[7] = siparisNumarasi;

                KoliGirisi koliGirisi = new KoliGirisi("KOLİ GİRİŞİ", txtPartyQty, null, Convert.ToInt32(list[5]), Convert.ToInt32(list[7]), txtItemCode.Text, txtSatirKaynagi.Text);
                koliGirisi.ShowDialog();
                koliGirisi.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPaletOlustur_Click(object sender, EventArgs e)
        {
            if (CekmeListesi_2.paletVar)
            {
                DialogResult dialog = new DialogResult();
                dialog = CustomMsgBtn.Show("DAHA ÖNCE OLUŞTURULMUŞ PALET BULUNMAKTADIR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "UYARI", "EVET", "HAYIR");

                if (dialog == DialogResult.No)
                {
                tekrar:
                    Random rnd = new Random();
                    string sayi = rnd.Next(100000, 999999).ToString();

                    string paletNo = "A" + sayi;

                    AIFTerminalService.AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalService.AIFTerminalServiceSoapClient();
                    Response resp = aIFTerminalServiceSoapClient.getPaletNoVarmi(Giris._dbName, paletNo, Giris.mKodValue);

                    if (resp._list.Rows.Count > 0)
                    {
                        goto tekrar;
                    }
                    txtPaletNo.Text = paletNo;
                    return;
                }
                else
                {
                    SelectList nesne = new SelectList("PaletSorgulama", "PaletNoArama", "Palet ARAMA", txtPaletNo, null);
                    nesne.ShowDialog();
                    nesne.Dispose();
                    GC.Collect();

                    if (SelectList.dialogResult == "Ok")
                    {
                        SelectList.dialogResult = "";
                    }
                }
            }
            else
            {
            tekrar:
                Random rnd = new Random();
                string sayi = rnd.Next(100000, 999999).ToString();

                string paletNo = "A" + sayi;

                AIFTerminalService.AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalService.AIFTerminalServiceSoapClient();
                Response resp = aIFTerminalServiceSoapClient.getPaletNoVarmi(Giris._dbName, paletNo, Giris.mKodValue);

                if (resp._list.Rows.Count > 0)
                {
                    goto tekrar;
                }
                txtPaletNo.Text = paletNo;
            }
        }

        private void txtPaletNo_DoubleClick(object sender, EventArgs e)
        {
            SelectList nesne = new SelectList("PaletSorgulama", "PaletNoArama", "PALET ARAMA", txtPaletNo, null);
            nesne.ShowDialog();
            nesne.Dispose();
            GC.Collect();

            if (SelectList.dialogResult == "Ok")
            {
                SelectList.dialogResult = "";
            }
        }

        private void btnYzdrPalet_Click(object sender, EventArgs e)
        {
            RafPrint();
        }

        private void RafPrint()
        {
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                string path = "";

                //path = System.AppDomain.CurrentDomain.BaseDirectory + "Plt_105_70_mm_1.rpt";

                if (Giris._dbName == "ZTEST2")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "ZTest2_Plt_105_70_mm_1.rpt";
                }
                else if (Giris._dbName == "ANATOLYA_DB")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "Plt_105_70_mm_1.rpt";
                }

                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);

                string server = @"ANATOLYA-SAP\SAPB1";

                cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                cryRpt.VerifyDatabase();

                cryRpt.SetParameterValue(0, txtPaletNo.Text);

                cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                //cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : Convert.ToInt32(txtPrintMik.Text), false, 0, 1);
                cryRpt.PrintToPrinter(1, false, 0, 0);

                cryRpt.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            #endregion Crystal reports işlemlerinin yapıldığı yer
        }

        private void listAllPrinters()
        {
            cmbPrinter.Items.Clear();
            cmbPrinter.Items.Add("");

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(item);
            }
            //default
            PrintDocument printDocument = new PrintDocument();
            string defaultPrinter = printDocument.PrinterSettings.PrinterName;
            cmbPrinter.SelectedItem = defaultPrinter;
        }
    }
}