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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class BarkodGoruntule : form_Base
    {
        //start font.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //end font
        private string type = "";

        private List<Parties> list = null;

        public BarkodGoruntule(string _type, List<Parties> _list, string _formName)
        {
            InitializeComponent();

            //start font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = lblProductCode.Font.Size;
            lblProductCode.Resize += Form_Resize;

            //end font
            formName = _formName;

            list = _list;
            type = _type;

            if (type == "20")//siparissiz mal g
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "22")//siparisli mal girisi
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "59")//belgesi mal g
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "1250000001")//talebe bagli depo n
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "Tlpsz1250000001")//talpsiz depo n
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "Sprssz17")//siparissiz teslimat
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;

                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "60")//belgesiz mal çıkış
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    cikisMiktari = list[0].TopMik;
                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }
            else if (type == "17")//siparise bagli tesl
            {
                if (list.Count > 0)
                {
                    txtProductCode.Text = list[0].ItemCode;
                    txtProductName.Text = list[0].ItemName;
                    txtBarcodeNo.Text = list[0].BarCode;
                    belgeNo = list[0].DocEntry;
                    paletIciKoliAD = list[0].PaletIciKoliAD;
                    koliIciAD = list[0].KoliIciAD;
                    paletIciAD = list[0].PaletIciAD;
                    musteriSipNo = list[0].MusteriSipNo;
                    sevkiyatAdresi = list[0].SevkiyatAdresi;
                    cikisMiktari = list[0].TopMik;
                    //cmbPartyNo.Items.Add(list[3]);

                    foreach (var item in list)
                    {
                        if (item.BatchNumber != "")
                        {
                            cmbPartyNo.Items.Add(item.BatchNumber);
                        }
                    }
                }
            }

            #region Barkodu oluşturulmak istenen kalemin son satınalma belgesi numarası getirliyor.

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient1 = new AIFTerminalServiceSoapClient();

            Response respSonSatinalmaBelgesi = aIFTerminalServiceSoapClient1.getSonSatinalmaBelgesiNo(Giris._dbName, txtProductCode.Text, Giris.mKodValue);

            if (respSonSatinalmaBelgesi == null && respSonSatinalmaBelgesi._list.Rows.Count == 0)
            {
                CustomMsgBox.Show(respSonSatinalmaBelgesi.Desc, "Uyarı", "TAMAM", "");
                return;
            }
            else
            {
                txtSonSatinalmaBelgeNo.Text = respSonSatinalmaBelgesi._list.Rows[0][0].ToString();
            }

            #endregion Barkodu oluşturulmak istenen kalemin son satınalma belgesi numarası getirliyor.
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //start font
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            lblProductCode.Font = new Font(lblProductCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblProductCode.Font.Style);

            lblProductName.Font = new Font(lblProductName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblProductName.Font.Style);

            lblBarcodeNo.Font = new Font(lblBarcodeNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBarcodeNo.Font.Style);

            lblPartyNo.Font = new Font(lblPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPartyNo.Font.Style);

            lblDespcription.Font = new Font(lblDespcription.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblDespcription.Font.Style);

            frmName.Font = new Font(frmName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                frmName.Font.Style);

            txtProductCode.Font = new Font(txtProductCode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtProductCode.Font.Style);

            txtProductName.Font = new Font(txtProductName.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtProductName.Font.Style);

            txtBarcodeNo.Font = new Font(txtBarcodeNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtBarcodeNo.Font.Style);

            richDespcription.Font = new Font(richDespcription.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                richDespcription.Font.Style);

            cmbPartyNo.Font = new Font(cmbPartyNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPartyNo.Font.Style);

            btnCreate.Font = new Font(btnCreate.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCreate.Font.Style);

            btnPrint.Font = new Font(btnPrint.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPrint.Font.Style);

            pictureBarcode.Font = new Font(pictureBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                pictureBarcode.Font.Style);

            lblBarcodeSize.Font = new Font(lblBarcodeSize.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblBarcodeSize.Font.Style);

            cmbBarcodeSize.Font = new Font(cmbBarcodeSize.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbBarcodeSize.Font.Style);

            lblPrintMik.Font = new Font(lblPrintMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblPrintMik.Font.Style);

            txtPrintMik.Font = new Font(txtPrintMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPrintMik.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPrinter.Font.Style);

            btnBirinciBarkod.Font = new Font(btnBirinciBarkod.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBirinciBarkod.Font.Style);

            btnIkinciBarkod.Font = new Font(btnIkinciBarkod.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnIkinciBarkod.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            dtpKaliteKntTarihi.Font = new Font(dtpKaliteKntTarihi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtpKaliteKntTarihi.Font.Style);
            ResumeLayout();
            //start yükseklik-genislik
            txtProductCode.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtProductName.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtBarcodeNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            txtSonSatinalmaBelgeNo.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            cmbPartyNo.Font = new Font("Microsoft Sans Serif", 26, FontStyle.Bold);
            txtPrintMik.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 26, FontStyle.Regular);
            txtMiktar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            dtpKaliteKntTarihi.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            //end yükseklik-genislik
            //end font
        }

        private string formName = "";
        private int belgeNo = 0;
        private double paletIciKoliAD = 0;
        private double koliIciAD = 0;
        private double paletIciAD = 0;
        private string musteriSipNo = "";
        private string sevkiyatAdresi = "";

        private double cikisMiktari = 0;

        private void BarkodGoruntule_Load(object sender, EventArgs e)
        {
            frmName.Text = formName;

            cmbBarcodeSize.DisplayMember = "Text";
            cmbBarcodeSize.ValueMember = "Value";

            cmbBarcodeSize.Items.Add(new { Text = "3X5", Value = "3X5" });
            cmbBarcodeSize.Items.Add(new { Text = "6X10", Value = "6X10" });

            txtPrintMik.Text = "1";

            listAllPrinters();

            dtpKaliteKntTarihi.Value = DateTime.Now;

            if (Giris.genelParametreler.CrystalKullan == "Y")
            {
                pictureBarcode.Visible = false;
            }

            txtMiktar.Text = "1";
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
            e.Graphics.DrawImage(pictureBarcode.Image, 2, 2);

            return;

            if (cmbBarcodeSize.Text == "3X5")
            {
                e.Graphics.DrawImage(pictureBarcode.Image, 3, 5);
            }
            else if (cmbBarcodeSize.Text == "6X10")
            {
                e.Graphics.DrawImage(pictureBarcode.Image, 2, 2);
            }
            //e.Graphics.DrawImage(pictureBarcode.Image, 6, 10);
            //e.Graphics.DrawImage(pictureBox2.Image, 10, 10);
        }

        private class BarkodMiktarlari
        {
            public double PaletIciKoliMik { get; set; }

            public double PaletIciUrunMik { get; set; }

            public double CikisMiktari { get; set; }

            public int YazdirmaMiktari { get; set; }
        }

        private List<BarkodMiktarlari> barkodMiktarlaris = new List<BarkodMiktarlari>();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (list[0].PaletIciKoliAD != -1 && list[0].KoliIciAD != -1 && list[0].PaletIciAD != -1)
            {
                barkodMiktarlaris = new List<BarkodMiktarlari>();
                txtPrintMik.Text = "";
                cikisMiktari = 0;
                paletIciKoliAD = list[0].PaletIciKoliAD;
                koliIciAD = list[0].KoliIciAD;
                paletIciAD = list[0].PaletIciAD;
                //int cikissayisi = 19750;
                double cikissayisi = list[0].TopMik;

                cikisMiktari = cikissayisi;
                double a, b;

                //a = Convert.ToDouble(cikissayisi);
                a = Convert.ToDouble(cikisMiktari);
                b = Convert.ToDouble(paletIciAD);

                if (a == 0 || b == 0)
                {
                    return;
                }

                double etiketsayisi = a / b;

                double etiketsayisi2 = 0;

                int number;
                bool result = int.TryParse(etiketsayisi.ToString(), out number);

                if (result)
                {
                    etiketsayisi2 = 1;
                }
                else
                {
                    etiketsayisi2 = Math.Ceiling(etiketsayisi);
                }

                if (etiketsayisi2 == 1)
                {
                    if (number > 0)
                    {
                        paletIciAD = cikisMiktari / number;
                    }
                    else
                    {
                        paletIciAD = cikisMiktari;
                    }
                    paletIciKoliAD = Convert.ToInt32(paletIciAD) / Convert.ToInt32(koliIciAD);

                    Barkod();

                    if (number > 0)
                    {
                        txtPrintMik.Text = number.ToString();
                    }
                    else
                    {
                        txtPrintMik.Text = "1";
                    }
                }
                else if (etiketsayisi2 > 1)
                {
                    btnBirinciBarkod.Visible = true;
                    btnIkinciBarkod.Visible = true;

                    double orjPaletIciKoliAdedi = paletIciAD;
                    //double orjCikisSayisi = cikisMiktari;

                    while (cikisMiktari > 0)
                    {
                        Barkod();
                        if (barkodMiktarlaris.Count == 0)
                        {
                            barkodMiktarlaris.Add(new BarkodMiktarlari { CikisMiktari = cikisMiktari, PaletIciKoliMik = paletIciKoliAD, PaletIciUrunMik = paletIciAD, YazdirmaMiktari = Convert.ToInt32(etiketsayisi2 - 1) });

                            txtPrintMik.Text = Convert.ToInt32(etiketsayisi2 - 1).ToString();
                        }
                        else
                        {
                            barkodMiktarlaris.Add(new BarkodMiktarlari { CikisMiktari = cikisMiktari, PaletIciKoliMik = paletIciKoliAD, PaletIciUrunMik = paletIciAD });
                        }

                        cikisMiktari = Convert.ToInt32(cikisMiktari) - Convert.ToInt32(paletIciAD);

                        if (cikisMiktari > orjPaletIciKoliAdedi)
                        {
                            //paletIciAD = Convert.ToInt32(cikisMiktari) - Convert.ToInt32(paletIciAD);
                            paletIciAD = orjPaletIciKoliAdedi;
                        }
                        else
                        {
                            paletIciAD = Convert.ToInt32(paletIciAD);
                        }
                        paletIciKoliAD = Convert.ToInt32(paletIciAD) / Convert.ToInt32(koliIciAD);
                    }
                }
            }
            else
            {
                Barkod();
            }
        }

        private void btnBirinciBarkod_Click(object sender, EventArgs e)
        {
            paletIciKoliAD = barkodMiktarlaris[0].PaletIciKoliMik;
            paletIciAD = barkodMiktarlaris[0].PaletIciUrunMik;

            Barkod();

            txtPrintMik.Text = barkodMiktarlaris[0].YazdirmaMiktari.ToString();
        }

        private void btnIkinciBarkod_Click(object sender, EventArgs e)
        {
            paletIciAD = barkodMiktarlaris[barkodMiktarlaris.Count - 1].CikisMiktari;

            paletIciKoliAD = Convert.ToInt32(paletIciAD) / Convert.ToInt32(koliIciAD);
            Barkod();

            txtPrintMik.Text = "1";
        }

        private void Barkod()
        {
            //if (cmbPartyNo.Items.Count > 0)
            //{
            //    if (cmbPartyNo.Text == "")
            //    {
            //        CustomMsgBox.Show("PARTİ NO SEÇİMİ YAPILMADAN BARKOD OLUŞTURULAMAZ.", "Uyarı", "TAMAM", "");
            //        return;
            //    }
            //}

            string urunKodu = "Ürün Kodu            :";
            string urunTanimi = "Ürün Tanımı:";
            string barkodNo = "Barkod No            :";
            string partiNo = "Parti No:";
            string aciklama = "Açıklama:";

            string siparisNo = "Sipariş No              :";
            string MusteriSipNo = "Müşteri Sip. No     :";
            string paletIciKoliAdedi = "Palet İçi Koli Adet :";
            string koliIciAdedi = "Koli İçi Adet           :";
            string paletIciAdedi = "Palet İçi Adet         :";

            string barkodDeger = ""; //QR KALDIRILDI
            string barkodDeger1 = "";
            string partiNoDeger = "";
            partiNoDeger = cmbPartyNo.Text;

            Graphics g;

            Font fnt = new Font("Calibri", 12, FontStyle.Bold);
            Bitmap bmp = new Bitmap(600, 600);
            Brush brush = new SolidBrush(Color.Black);
            g = Graphics.FromImage(bmp);

            if (type == "17")
            {
                //QR KOD KALDIRILDI
                /*
                barkodDeger = urunKodu + ":" + txtProductCode.Text + Environment.NewLine;
                barkodDeger += urunTanimi + ":" + txtProductName.Text + Environment.NewLine;
                barkodDeger += barkodNo + ":" + txtBarcodeNo.Text + Environment.NewLine;
                barkodDeger += partiNo + ":" + cmbPartyNo.Text + Environment.NewLine;
                barkodDeger += aciklama + ":" + richDespcription.Text + Environment.NewLine;
                */
                //QR KOD KALDIRILDI
                if (txtBarcodeNo.Text != "Tanımsız" && txtBarcodeNo.Text != "")
                {
                    //if (aciklama != "")
                    //{
                    //    if (aciklama.Length >= 10)
                    //    {
                    //        aciklama = aciklama.Substring(0, 10);
                    //    }
                    //}

                    if (cmbPartyNo.Text != "")
                    {
                        Zen.Barcode.Code128BarcodeDraw barcodeV = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                        //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                        //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                            LineAlignment = StringAlignment.Far
                        })
                        {
                            //g.Clear(Color.White);
                            partiNoDeger = StringReplace(cmbPartyNo.Text);
                            g.DrawImage(barcodeV.Draw(partiNoDeger, 60, 1), new Point(390, 295)); //400,410
                            g.DrawString(cmbPartyNo.Text, fnt, brush, 490, 380, format);//465
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }
                    //QR KOD KALDIRILDI
                    /*
                    Zen.Barcode.CodeQrBarcodeDraw barcodeQr = Zen.Barcode.BarcodeDrawFactory.CodeQr;

                    //Etiketler
                    //g.DrawString(urunTanimi, fnt, brush, 15, 15);
                    g.DrawString(urunKodu, fnt, brush, 55, 45);
                    g.DrawString(aciklama, fnt, brush, 55, 65);
                    g.DrawString(aciklama, fnt, brush, 55, 85);
                    g.DrawString(aciklama, fnt, brush, 55, 105);

                    //g.DrawString(barkodNo, fnt, brush, 15, 36);
                    //g.DrawString(partiNo, fnt, brush, 15, 48);

                    //Değerler
                    g.DrawString(txtProductName.Text, fnt, brush, 15, 15);
                    g.DrawString(txtProductCode.Text, fnt, brush, 140, 45);
                    g.DrawString(richDespcription.Text, fnt, brush, 140, 65);
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 140, 85);
                    g.DrawString(cmbPartyNo.Text, fnt, brush, 140, 105);

                    barkodDeger = StringReplace(barkodDeger);
                    if (barkodDeger != "")
                    {
                        if (barkodDeger.Length >= 20)
                        {
                            barkodDeger = barkodDeger.Substring(0, 20);
                        }
                    }
                    g.DrawImage(barcodeQr.Draw(barkodDeger, 15, 1), new Point(15, 140));
                    */
                    //QR KOD KALDIRILDI

                    //code128
                    Zen.Barcode.Code128BarcodeDraw barcodeH = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    //barkodDeger = urunKodu + ":" + txtProductCode.Text + Environment.NewLine;
                    //barkodDeger += urunTanimi + ":" + txtProductName.Text + Environment.NewLine;
                    barkodDeger1 = txtBarcodeNo.Text;
                    //barkodDeger += partiNo + ":" + cmbPartyNo.Text + Environment.NewLine;
                    //barkodDeger += aciklama + ":" + richDespcription.Text + Environment.NewLine;

                    #region resimsiz - orjinal barkod oluşturma

                    //Etiketler
                    g.DrawString(MusteriSipNo, fnt, brush, 35, 5);
                    //g.DrawString(urunKodu, fnt, brush, 35, 30);
                    g.DrawString(koliIciAdedi, fnt, brush, 35, 75);
                    g.DrawString(paletIciKoliAdedi, fnt, brush, 35, 95);
                    g.DrawString(paletIciAdedi, fnt, brush, 35, 115);
                    //g.DrawString(barkodNo, fnt, brush, 15, 36);
                    //g.DrawString(partiNo, fnt, brush, 15, 48);

                    //PRODUCT NAME YAZI KAYDIRMA
                    float x = 10.0F; //x konum başl.
                    float y = 35.0F; //y konum başl.
                    float width = 280.0F;//kesilecek genişlik
                    float height = 40.0F;
                    RectangleF drawRect = new RectangleF(x, y, width, height);
                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;//yazıları ortala
                                                                  //PRODUCT NAME YAZI KAYDIRMA

                    //SEVKİYAT ADRESİ YAZI KAYDIRMA
                    float xS = 10.0F; //x konum başl.
                    float yS = 20.0F; //y konum başl.
                    float widthS = 280.0F;//kesilecek genişlik
                    float heightS = 40.0F;
                    RectangleF drawRectS = new RectangleF(xS, yS, widthS, heightS);
                    // Set format of string.
                    StringFormat drawFormatS = new StringFormat();
                    drawFormatS.Alignment = StringAlignment.Center;//yazıları ortala
                                                                   //SEVKİYAT ADRESİ YAZI KAYDIRMA

                    //Değerler
                    g.DrawString(musteriSipNo == "-1" ? "-" : musteriSipNo.ToString(), fnt, brush, 170, 5);
                    g.DrawString(sevkiyatAdresi == "" ? "-" : sevkiyatAdresi, fnt, brush, drawRectS, drawFormatS);
                    g.DrawString(txtProductName.Text, fnt, brush, drawRect, drawFormat);
                    //g.DrawString(txtProductCode.Text, fnt, brush, 170, 50);
                    //g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 50);
                    g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 170, 75);
                    g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 170, 95);
                    g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 170, 115);

                    barkodDeger1 = StringReplace(barkodDeger1);
                    if (barkodDeger1 != "")
                    {
                        if (barkodDeger1.Length >= 20)
                        {
                            barkodDeger1 = barkodDeger1.Substring(0, 20);
                        }
                    }
                    g.DrawImage(barcodeH.Draw(barkodDeger1, 60, 2), new Point(15, 140));
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 80, 200);
                    pictureBarcode.Image = bmp;

                    #endregion resimsiz - orjinal barkod oluşturma

                    #region resimli barkod oluşturma

                    ////Etiketler
                    //g.DrawString(MusteriSipNo, fnt, brush, 15, 5);
                    ////g.DrawString(urunKodu, fnt, brush, 35, 30);
                    //g.DrawString(koliIciAdedi, fnt, brush, 15, 75);
                    //g.DrawString(paletIciKoliAdedi, fnt, brush, 15, 95);
                    //g.DrawString(paletIciAdedi, fnt, brush, 15, 115);
                    ////g.DrawString(barkodNo, fnt, brush, 15, 36);
                    ////g.DrawString(partiNo, fnt, brush, 15, 48);

                    ////PRODUCT NAME YAZI KAYDIRMA
                    //float x = 10.0F; //x konum başl.
                    //float y = 35.0F; //y konum başl.
                    //float width = 280.0F;//kesilecek genişlik
                    //float height = 40.0F;
                    //RectangleF drawRect = new RectangleF(x, y, width, height);
                    //// Set format of string.
                    //StringFormat drawFormat = new StringFormat();
                    //drawFormat.Alignment = StringAlignment.Center;//yazıları ortala
                    //                                              //PRODUCT NAME YAZI KAYDIRMA

                    ////SEVKİYAT ADRESİ YAZI KAYDIRMA
                    //float xS = 10.0F; //x konum başl.
                    //float yS = 20.0F; //y konum başl.
                    //float widthS = 280.0F;//kesilecek genişlik
                    //float heightS = 40.0F;
                    //RectangleF drawRectS = new RectangleF(xS, yS, widthS, heightS);
                    //// Set format of string.
                    //StringFormat drawFormatS = new StringFormat();
                    //drawFormatS.Alignment = StringAlignment.Center;//yazıları ortala
                    //                                               //SEVKİYAT ADRESİ YAZI KAYDIRMA

                    ////Değerler
                    //g.DrawString(musteriSipNo == "-1" ? "-" : musteriSipNo.ToString(), fnt, brush, 150, 5);
                    //g.DrawString(sevkiyatAdresi == "" ? "-" : sevkiyatAdresi, fnt, brush, drawRectS, drawFormatS);
                    //g.DrawString(txtProductName.Text, fnt, brush, drawRect, drawFormat);
                    ////g.DrawString(txtProductCode.Text, fnt, brush, 170, 50);
                    ////g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 50);
                    //g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 150, 75);
                    //g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 150, 95);
                    //g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 150, 115);

                    //barkodDeger1 = StringReplace(barkodDeger1);
                    //if (barkodDeger1 != "")
                    //{
                    //    if (barkodDeger1.Length >= 20)
                    //    {
                    //        barkodDeger1 = barkodDeger1.Substring(0, 20);
                    //    }
                    //}
                    //g.DrawImage(barcodeH.Draw(barkodDeger1, 60, 2), new Point(15, 140));
                    //g.DrawString(txtBarcodeNo.Text, fnt, brush, 60, 200);

                    //var file = Application.StartupPath + "\\disli_72x74.png";
                    //g.DrawImage(Image.FromFile(file), new Point(200, 65)); //1
                    //pictureBarcode.Image = bmp;

                    #endregion resimli barkod oluşturma
                }
                else if (txtBarcodeNo.Text == "Tanımsız")
                {
                    if (cmbPartyNo.Text != "")
                    {
                        Zen.Barcode.Code128BarcodeDraw barcodeV = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                        //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                        //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                            LineAlignment = StringAlignment.Far
                        })
                        {
                            //g.Clear(Color.White);
                            partiNoDeger = StringReplace(cmbPartyNo.Text);

                            g.DrawImage(barcodeV.Draw(partiNoDeger, 60, 1), new Point(390, 295)); //400,410

                            g.DrawString(cmbPartyNo.Text, fnt, brush, 490, 380, format);//465
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }

                    g = Graphics.FromImage(bmp);

                    #region resimsiz - orjinal barkod oluşturma

                    //Etiketler
                    g.DrawString(MusteriSipNo, fnt, brush, 35, 5);
                    //g.DrawString(urunKodu, fnt, brush, 35, 30);
                    g.DrawString(koliIciAdedi, fnt, brush, 35, 75);
                    g.DrawString(paletIciKoliAdedi, fnt, brush, 35, 95);
                    g.DrawString(paletIciAdedi, fnt, brush, 35, 115);
                    g.DrawString(barkodNo, fnt, brush, 35, 160);

                    if (aciklama != "")
                    {
                        if (aciklama.Length >= 10)
                        {
                            aciklama = aciklama.Substring(0, 10);
                        }
                    }

                    //PRODUCT NAME YAZI KAYDIRMA
                    float x = 10.0F; //x konum başl.
                    float y = 35.0F; //y konum başl.
                    float width = 280.0F;//kesilecek genişlik
                    float height = 40.0F;
                    RectangleF drawRect = new RectangleF(x, y, width, height);
                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;//yazıları ortala
                    //PRODUCT NAME YAZI KAYDIRMA

                    //SEVKİYAT ADRESİ YAZI KAYDIRMA
                    float xS = 10.0F; //x konum başl.
                    float yS = 20.0F; //y konum başl.
                    float widthS = 280.0F;//kesilecek genişlik
                    float heightS = 40.0F;
                    RectangleF drawRectS = new RectangleF(xS, yS, widthS, heightS);
                    // Set format of string.
                    StringFormat drawFormatS = new StringFormat();
                    drawFormatS.Alignment = StringAlignment.Center;//yazıları ortala
                    //SEVKİYAT ADRESİ YAZI KAYDIRMA

                    //Değerler
                    g.DrawString(musteriSipNo == "-1" ? "-" : musteriSipNo.ToString(), fnt, brush, 170, 5);
                    g.DrawString(sevkiyatAdresi == "" ? "-" : sevkiyatAdresi, fnt, brush, drawRectS, drawFormatS);
                    g.DrawString(txtProductName.Text, fnt, brush, drawRect, drawFormat);
                    //g.DrawString(txtProductCode.Text, fnt, brush, 170, 50);
                    //g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 50);
                    g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 170, 75);
                    g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 170, 95);
                    g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 170, 115);
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 170, 160);
                    //g.DrawString(txtBarcodeNo.Text, new Font("Calibri", 16, FontStyle.Bold), brush, 170, 160);

                    //pictureBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
                    //pictureBarcode.BorderStyle = BorderStyle.Fixed3D;
                    pictureBarcode.Image = bmp;

                    #endregion resimsiz - orjinal barkod oluşturma

                    #region resimli barkod oluşturma

                    ////Etiketler
                    //g.DrawString(MusteriSipNo, fnt, brush, 15, 5);
                    ////g.DrawString(urunKodu, fnt, brush, 35, 30);
                    //g.DrawString(koliIciAdedi, fnt, brush, 15, 75);
                    //g.DrawString(paletIciKoliAdedi, fnt, brush, 15, 95);
                    //g.DrawString(paletIciAdedi, fnt, brush, 15, 115);
                    //g.DrawString(barkodNo, fnt, brush, 15, 160);

                    //if (aciklama != "")
                    //{
                    //    if (aciklama.Length >= 10)
                    //    {
                    //        aciklama = aciklama.Substring(0, 10);
                    //    }
                    //}

                    ////PRODUCT NAME YAZI KAYDIRMA
                    //float x = 10.0F; //x konum başl.
                    //float y = 35.0F; //y konum başl.
                    //float width = 280.0F;//kesilecek genişlik
                    //float height = 40.0F;
                    //RectangleF drawRect = new RectangleF(x, y, width, height);
                    //// Set format of string.
                    //StringFormat drawFormat = new StringFormat();
                    //drawFormat.Alignment = StringAlignment.Center;//yazıları ortala
                    ////PRODUCT NAME YAZI KAYDIRMA

                    ////SEVKİYAT ADRESİ YAZI KAYDIRMA
                    //float xS = 10.0F; //x konum başl.
                    //float yS = 20.0F; //y konum başl.
                    //float widthS = 280.0F;//kesilecek genişlik
                    //float heightS = 40.0F;
                    //RectangleF drawRectS = new RectangleF(xS, yS, widthS, heightS);
                    //// Set format of string.
                    //StringFormat drawFormatS = new StringFormat();
                    //drawFormatS.Alignment = StringAlignment.Center;//yazıları ortala
                    ////SEVKİYAT ADRESİ YAZI KAYDIRMA

                    ////Değerler
                    //g.DrawString(musteriSipNo == "-1" ? "-" : musteriSipNo.ToString(), fnt, brush, 150, 5);
                    //g.DrawString(sevkiyatAdresi == "" ? "-" : sevkiyatAdresi, fnt, brush, drawRectS, drawFormatS);
                    //g.DrawString(txtProductName.Text, fnt, brush, drawRect, drawFormat);
                    ////g.DrawString(txtProductCode.Text, fnt, brush, 170, 50);
                    ////g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 50);
                    //g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 150, 75);
                    //g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 150, 95);
                    //g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 150, 115);
                    //g.DrawString(txtBarcodeNo.Text, fnt, brush, 150, 160);
                    ////g.DrawString(txtBarcodeNo.Text, new Font("Calibri", 16, FontStyle.Bold), brush, 170, 160);

                    ////pictureBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
                    ////pictureBarcode.BorderStyle = BorderStyle.Fixed3D;
                    //var file = Application.StartupPath + "\\disli_72x74.png";
                    //g.DrawImage(Image.FromFile(file), new Point(200, 75)); //2
                    //pictureBarcode.Image = bmp;

                    #endregion resimli barkod oluşturma
                }
            }
            else
            {
                //QR KOD KALDIRILDI
                /*
                barkodDeger = urunKodu + ":" + txtProductCode.Text + Environment.NewLine;
                barkodDeger += urunTanimi + ":" + txtProductName.Text + Environment.NewLine;
                barkodDeger += barkodNo + ":" + txtBarcodeNo.Text + Environment.NewLine;
                barkodDeger += partiNo + ":" + cmbPartyNo.Text + Environment.NewLine;
                barkodDeger += aciklama + ":" + richDespcription.Text + Environment.NewLine;
                */
                //QR KOD KALDIRILDI
                if (txtBarcodeNo.Text != "Tanımsız" && txtBarcodeNo.Text != "")
                {
                    //if (aciklama != "")
                    //{
                    //    if (aciklama.Length >= 10)
                    //    {
                    //        aciklama = aciklama.Substring(0, 10);
                    //    }
                    //}

                    if (cmbPartyNo.Text != "")
                    {
                        Zen.Barcode.Code128BarcodeDraw barcodeV = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                        //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                        //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                            LineAlignment = StringAlignment.Far
                        })
                        {
                            //g.Clear(Color.White);
                            partiNoDeger = StringReplace(cmbPartyNo.Text);
                            g.DrawImage(barcodeV.Draw(partiNoDeger, 60, 1), new Point(390, 295)); //400,410
                            g.DrawString(cmbPartyNo.Text, fnt, brush, 490, 380, format);//465
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }
                    //QR KOD KALDIRILDI
                    /*
                    Zen.Barcode.CodeQrBarcodeDraw barcodeQr = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    //Etiketler
                    //g.DrawString(urunTanimi, fnt, brush, 15, 15);
                    g.DrawString(urunKodu, fnt, brush, 55, 45);
                    g.DrawString(aciklama, fnt, brush, 55, 65);
                    g.DrawString(aciklama, fnt, brush, 55, 85);
                    g.DrawString(aciklama, fnt, brush, 55, 105);
                    //g.DrawString(barkodNo, fnt, brush, 15, 36);
                    //g.DrawString(partiNo, fnt, brush, 15, 48);

                    //Değerler
                    g.DrawString(txtProductName.Text, fnt, brush, 15, 15);
                    g.DrawString(txtProductCode.Text, fnt, brush, 140, 45);
                    g.DrawString(richDespcription.Text, fnt, brush, 140, 65);
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 140, 85);
                    g.DrawString(cmbPartyNo.Text, fnt, brush, 140, 105);
                    barkodDeger = StringReplace(barkodDeger);
                    if (barkodDeger != "")
                    {
                        if (barkodDeger.Length >= 20)
                        {
                            barkodDeger = barkodDeger.Substring(0, 20);
                        }
                    }
                    g.DrawImage(barcodeQr.Draw(barkodDeger, 15, 1), new Point(15, 140));
                    */
                    //QR KOD KALDIRILDI

                    //code128
                    Zen.Barcode.Code128BarcodeDraw barcodeH = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    //barkodDeger = urunKodu + ":" + txtProductCode.Text + Environment.NewLine;
                    //barkodDeger += urunTanimi + ":" + txtProductName.Text + Environment.NewLine;
                    barkodDeger1 = txtBarcodeNo.Text;
                    //barkodDeger += partiNo + ":" + cmbPartyNo.Text + Environment.NewLine;
                    //barkodDeger += aciklama + ":" + richDespcription.Text + Environment.NewLine;

                    #region resimsiz -orjinal barkod oluşturma

                    //Etiketler
                    //g.DrawString(urunTanimi, fnt, brush, 15, 15);
                    g.DrawString(urunKodu, fnt, brush, 35, 35);
                    g.DrawString(siparisNo, fnt, brush, 35, 55);
                    g.DrawString(paletIciKoliAdedi, fnt, brush, 35, 75);
                    g.DrawString(koliIciAdedi, fnt, brush, 35, 95);
                    g.DrawString(paletIciAdedi, fnt, brush, 35, 115);

                    //g.DrawString(barkodNo, fnt, brush, 15, 36);
                    //g.DrawString(partiNo, fnt, brush, 15, 48);

                    //PRODUCT NAME YAZI KAYDIRMA
                    float xP = 15.0F; //x konum başl.
                    float yP = 5.0F; //y konum başl.
                    float widthP = 280.0F;//kesilecek genişlik
                    float heightP = 40.0F;
                    RectangleF drawRectP = new RectangleF(xP, yP, widthP, heightP);
                    // Set format of string.
                    StringFormat drawFormatP = new StringFormat();
                    drawFormatP.Alignment = StringAlignment.Center;//yazıları ortala
                                                                   //PRODUCT NAME YAZI KAYDIRMA

                    //Değerler
                    g.DrawString(txtProductName.Text, fnt, brush, drawRectP, drawFormatP);
                    g.DrawString(txtProductCode.Text, fnt, brush, 170, 35);
                    g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 55);
                    g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 170, 75);
                    g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 170, 95);
                    g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 170, 115);

                    barkodDeger1 = StringReplace(barkodDeger1);
                    if (barkodDeger1 != "")
                    {
                        if (barkodDeger1.Length >= 20)
                        {
                            barkodDeger1 = barkodDeger1.Substring(0, 20);
                        }
                    }
                    g.DrawImage(barcodeH.Draw(barkodDeger1, 60, 2), new Point(15, 140));
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 80, 200);
                    pictureBarcode.Image = bmp;

                    #endregion resimsiz -orjinal barkod oluşturma

                    #region resimli barkod oluşturma

                    ////Etiketler
                    ////g.DrawString(urunTanimi, fnt, brush, 15, 15);
                    //g.DrawString(urunKodu, fnt, brush, 15, 35);
                    //g.DrawString(siparisNo, fnt, brush, 15, 55);
                    //g.DrawString(paletIciKoliAdedi, fnt, brush, 15, 75);
                    //g.DrawString(koliIciAdedi, fnt, brush, 15, 95);
                    //g.DrawString(paletIciAdedi, fnt, brush, 15, 115);

                    ////g.DrawString(barkodNo, fnt, brush, 15, 36);
                    ////g.DrawString(partiNo, fnt, brush, 15, 48);

                    ////PRODUCT NAME YAZI KAYDIRMA
                    //float xP = 15.0F; //x konum başl.
                    //float yP = 5.0F; //y konum başl.
                    //float widthP = 280.0F;//kesilecek genişlik
                    //float heightP = 40.0F;
                    //RectangleF drawRectP = new RectangleF(xP, yP, widthP, heightP);
                    //// Set format of string.
                    //StringFormat drawFormatP = new StringFormat();
                    //drawFormatP.Alignment = StringAlignment.Center;//yazıları ortala
                    //                                               //PRODUCT NAME YAZI KAYDIRMA

                    ////Değerler
                    //g.DrawString(txtProductName.Text, fnt, brush, drawRectP, drawFormatP);
                    //g.DrawString(txtProductCode.Text, fnt, brush, 150, 35);
                    //g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 150, 55);
                    //g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 150, 75);
                    //g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 150, 95);
                    //g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 150, 115);

                    //barkodDeger1 = StringReplace(barkodDeger1);
                    //if (barkodDeger1 != "")
                    //{
                    //    if (barkodDeger1.Length >= 20)
                    //    {
                    //        barkodDeger1 = barkodDeger1.Substring(0, 20);
                    //    }
                    //}
                    //g.DrawImage(barcodeH.Draw(barkodDeger1, 60, 2), new Point(15, 140));
                    //g.DrawString(txtBarcodeNo.Text, fnt, brush, 60, 200);
                    //var file = Application.StartupPath + "\\disli_72x74.png";
                    //g.DrawImage(Image.FromFile(file), new Point(200, 60)); //3
                    //pictureBarcode.Image = bmp;

                    #endregion resimli barkod oluşturma
                }
                else if (txtBarcodeNo.Text == "Tanımsız")
                {
                    if (cmbPartyNo.Text != "")
                    {
                        Zen.Barcode.Code128BarcodeDraw barcodeV = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                        //var barcodeImage = barcode.Draw(txtPartyNo.Text, 50);
                        //var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                            LineAlignment = StringAlignment.Far
                        })
                        {
                            //g.Clear(Color.White);
                            partiNoDeger = StringReplace(cmbPartyNo.Text);

                            g.DrawImage(barcodeV.Draw(partiNoDeger, 60, 1), new Point(390, 295)); //400,410

                            g.DrawString(cmbPartyNo.Text, fnt, brush, 490, 380, format);//465
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }

                    g = Graphics.FromImage(bmp);

                    #region resimsiz - orjinal barkod oluşturma

                    //Etiketler
                    g.DrawString(urunKodu, fnt, brush, 35, 35);
                    g.DrawString(siparisNo, fnt, brush, 35, 55);
                    g.DrawString(paletIciKoliAdedi, fnt, brush, 35, 75);
                    g.DrawString(koliIciAdedi, fnt, brush, 35, 95);
                    g.DrawString(paletIciAdedi, fnt, brush, 35, 115);
                    g.DrawString(barkodNo, fnt, brush, 35, 160);
                    //g.DrawString(barkodNo, new Font("Calibri", 16, FontStyle.Bold), brush, 25, 160);

                    if (aciklama != "")
                    {
                        if (aciklama.Length >= 10)
                        {
                            aciklama = aciklama.Substring(0, 10);
                        }
                    }

                    //PRODUCT NAME YAZI KAYDIRMA
                    float xP = 15.0F; //x konum başl.
                    float yP = 5.0F; //y konum başl.
                    float widthP = 280.0F;//kesilecek genişlik
                    float heightP = 40.0F;
                    RectangleF drawRectP = new RectangleF(xP, yP, widthP, heightP);
                    // Set format of string.
                    StringFormat drawFormatP = new StringFormat();
                    drawFormatP.Alignment = StringAlignment.Center;//yazıları ortala
                    //PRODUCT NAME YAZI KAYDIRMA

                    //Değerler
                    g.DrawString(txtProductName.Text, fnt, brush, drawRectP, drawFormatP);
                    g.DrawString(txtProductCode.Text, fnt, brush, 170, 35);
                    g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 170, 55);
                    g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 170, 75);
                    g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 170, 95);
                    g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 170, 115);
                    g.DrawString(txtBarcodeNo.Text, fnt, brush, 170, 160);
                    //g.DrawString(txtBarcodeNo.Text, new Font("Calibri", 16, FontStyle.Bold), brush, 170, 160);

                    //pictureBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
                    //pictureBarcode.BorderStyle = BorderStyle.Fixed3D;
                    pictureBarcode.Image = bmp;

                    #endregion resimsiz - orjinal barkod oluşturma

                    #region resimli barkod oluşturma

                    ////Etiketler
                    //g.DrawString(urunKodu, fnt, brush, 15, 35);
                    //g.DrawString(siparisNo, fnt, brush, 15, 55);
                    //g.DrawString(paletIciKoliAdedi, fnt, brush, 15, 75);
                    //g.DrawString(koliIciAdedi, fnt, brush, 15, 95);
                    //g.DrawString(paletIciAdedi, fnt, brush, 15, 115);
                    //g.DrawString(barkodNo, fnt, brush, 15, 160);
                    ////g.DrawString(barkodNo, new Font("Calibri", 16, FontStyle.Bold), brush, 25, 160);

                    //if (aciklama != "")
                    //{
                    //    if (aciklama.Length >= 10)
                    //    {
                    //        aciklama = aciklama.Substring(0, 10);
                    //    }
                    //}

                    ////PRODUCT NAME YAZI KAYDIRMA
                    //float xP = 15.0F; //x konum başl.
                    //float yP = 5.0F; //y konum başl.
                    //float widthP = 280.0F;//kesilecek genişlik
                    //float heightP = 40.0F;
                    //RectangleF drawRectP = new RectangleF(xP, yP, widthP, heightP);
                    //// Set format of string.
                    //StringFormat drawFormatP = new StringFormat();
                    //drawFormatP.Alignment = StringAlignment.Center;//yazıları ortala
                    ////PRODUCT NAME YAZI KAYDIRMA

                    ////Değerler
                    //g.DrawString(txtProductName.Text, fnt, brush, drawRectP, drawFormatP);
                    //g.DrawString(txtProductCode.Text, fnt, brush, 150, 35);
                    //g.DrawString(belgeNo == -1 ? "-" : belgeNo.ToString(), fnt, brush, 150, 55);
                    //g.DrawString(paletIciKoliAD == -1 ? "-" : paletIciKoliAD.ToString(), fnt, brush, 150, 75);
                    //g.DrawString(koliIciAD == -1 ? "-" : koliIciAD.ToString(), fnt, brush, 150, 95);
                    //g.DrawString(paletIciAD == -1 ? "-" : paletIciAD.ToString(), fnt, brush, 150, 115);
                    //g.DrawString(txtBarcodeNo.Text, fnt, brush, 150, 160);
                    ////g.DrawString(txtBarcodeNo.Text, new Font("Calibri", 16, FontStyle.Bold), brush, 170, 160);

                    ////pictureBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
                    ////pictureBarcode.BorderStyle = BorderStyle.Fixed3D;
                    //var file = Application.StartupPath + "\\disli_72x74.png";
                    //g.DrawImage(Image.FromFile(file), new Point(200, 65)); //4
                    //pictureBarcode.Image = bmp;

                    #endregion resimli barkod oluşturma
                }
            }
        }

        private int yazdirMik = 0;

        private void Print()
        {
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                string path = "";

                path = System.AppDomain.CurrentDomain.BaseDirectory + "Ant_105_70_mm.rpt";

                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);

                string server = @"ANATOLYA-SAP\SAPB1";

                cryRpt.SetDatabaseLogon("sa", "Eropa2018!", server, Giris._dbName);

                cryRpt.VerifyDatabase();

                cryRpt.SetParameterValue(0, txtProductCode.Text);
                cryRpt.SetParameterValue(1, dtpKaliteKntTarihi.Value);
                cryRpt.SetParameterValue(2, txtSonSatinalmaBelgeNo.Text == "" ? "0" : txtSonSatinalmaBelgeNo.Text);
                cryRpt.SetParameterValue(3, txtMiktar.Text == "" ? "1" : txtMiktar.Text);

                cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : Convert.ToInt32(txtPrintMik.Text), false, 0, 1);

                cryRpt.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
                }
                catch (Exception ex)
                {
                    CustomMsgBox.Show("HATA OLUŞTU." + ex.Message, "Uyarı", "TAMAM", "");
                    return;
                }
            }
        }

        private void cmbBarcodeSize_SelectedValueChanged(object sender, EventArgs e)
        {
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

        private void txtPrintMik_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtPrintMik, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }

        private void txtMiktar_Click(object sender, EventArgs e)
        {
            SayiKlavyesi sayiKlavyesi = new SayiKlavyesi(txtMiktar, null, false);
            sayiKlavyesi.ShowDialog();
            sayiKlavyesi.Dispose();
            GC.Collect();
        }
    }
}