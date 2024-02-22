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
    public partial class Menu : form_Base
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public Menu(string _userName, string _dbName)
        {
            InitializeComponent();

            //font start.
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = btnSiparissizMalGiris.Font.Size;
            btnSiparissizMalGiris.Resize += Form_Resize;

            //initialFontSize = btnBelgesizMalGiris.Font.Size;
            //btnBelgesizMalGiris.Resize += Form_Resize;

            //initialFontSize = btnTalepsizDepoNakli.Font.Size;
            //btnTalepsizDepoNakli.Resize += Form_Resize;

            //initialFontSize = btnTalebeBagliDepoNakli.Font.Size;
            //btnTalebeBagliDepoNakli.Resize += Form_Resize;

            //initialFontSize = btnDepoSayimi.Font.Size;
            //btnDepoSayimi.Resize += Form_Resize;

            //initialFontSize = btnPaletYapma.Font.Size;
            //btnPaletYapma.Resize += Form_Resize;

            //initialFontSize = btnBelgesizMalCikis.Font.Size;
            //btnBelgesizMalCikis.Resize += Form_Resize;

            //initialFontSize = btnSipariseBagliTeslimat.Font.Size;
            //btnSipariseBagliTeslimat.Resize += Form_Resize;

            //initialFontSize = btnSiparissizTeslimat.Font.Size;
            //btnSiparissizTeslimat.Resize += Form_Resize;

            //initialFontSize = btnUretimeMalCikis.Font.Size;
            //btnUretimeMalCikis.Resize += Form_Resize;

            //initialFontSize = btnUretimdenMalGiris.Font.Size;
            //btnUretimdenMalGiris.Resize += Form_Resize;

            //initialFontSize = btnSiparisliMalGiris.Font.Size;
            //btnSiparisliMalGiris.Resize += Form_Resize;

            //initialFontSize = btnReports.Font.Size;
            //btnReports.Resize += Form_Resize;

            //initialFontSize = btnTalepKabul.Font.Size;
            //btnTalepKabul.Resize += Form_Resize;

            //initialFontSize = btnIadeIrsaliyeGirisi.Font.Size;
            //btnIadeIrsaliyeGirisi.Resize += Form_Resize;
            //font end

            userName = _userName;
            dbName = _dbName;

            TableLayoutRowStyleCollection styles = this.tableLayoutPanel1.RowStyles;

            AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            Response resp = aIFTerminalServiceSoapClient.GetButtonAuthorization(userName, dbName, Giris.mKodValue);

            if (resp._list.Rows.Count > 0)
            {
                string siparisliMalGirisi = resp._list.Rows[0]["Siparişli Mal Girişi"].ToString();
                string siparissizMalGirisi = resp._list.Rows[0]["Siparişsiz Mal Girişi"].ToString();
                string belgesizMalGirisi = resp._list.Rows[0]["Belgesiz Mal Girişi"].ToString();
                string talepsizdepoNakli = resp._list.Rows[0]["Talepsiz Depo Nakli"].ToString();
                string talebeBagliDepoNakli = resp._list.Rows[0]["Talebe Bağlı Depo Nakli"].ToString();
                string talepKabul = resp._list.Rows[0]["Talep Kabul"].ToString();
                string depoSayimi = resp._list.Rows[0]["Depo Sayımı"].ToString();
                string belgesizMalCikis = resp._list.Rows[0]["Belgesiz Mal Çıkışı"].ToString();
                string sipariseBagliTeslimat = resp._list.Rows[0]["Siparişe Bağlı Teslimat"].ToString();
                string siparissizTeslimat = resp._list.Rows[0]["Siparişsiz Teslimat"].ToString();
                string uretimeMalCikis = resp._list.Rows[0]["Üretime Mal Çıkış"].ToString();
                string uretimdenMalGiris = resp._list.Rows[0]["Üretimden Mal Giriş"].ToString();
                string musterifaturaIade = resp._list.Rows[0]["Müşteri Fatura İadesi"].ToString();
                string teslimatIade = resp._list.Rows[0]["Teslimat İadesi"].ToString();
                string satistanIade = resp._list.Rows[0]["Satıştan İade"].ToString();//SATIŞTAN İADE YAPIALCAK
                string raporlar = resp._list.Rows[0]["Raporlar"].ToString();
                string barkodOlustur = resp._list.Rows[0]["Barkod Oluştur"].ToString();
                string cekmeListesi = resp._list.Rows[0]["Çekme Listesi"].ToString();
                string paletYapma = resp._list.Rows[0]["Palet Yapma"].ToString();
                string konteynerYapma = resp._list.Rows[0]["Konteyner Yapma"].ToString();
                string magazacilikIslemleri = resp._list.Rows[0]["Mağazacılık İşlemleri"].ToString();
                string iadeTalebi = resp._list.Rows[0]["İade Talep"].ToString();

                if (siparisliMalGirisi != "Y")
                {
                    styles[1].SizeType = SizeType.Absolute;
                    styles[1].Height = 0;
                }

                if (siparissizMalGirisi != "Y")
                {
                    styles[2].SizeType = SizeType.Absolute;
                    styles[2].Height = 0;
                }

                if (belgesizMalGirisi != "Y")
                {
                    styles[3].SizeType = SizeType.Absolute;
                    styles[3].Height = 0;
                }

                if (talepsizdepoNakli != "Y")
                {
                    styles[4].SizeType = SizeType.Absolute;
                    styles[4].Height = 0;
                }

                if (talebeBagliDepoNakli != "Y")
                {
                    styles[5].SizeType = SizeType.Absolute;
                    styles[5].Height = 0;
                }

                if (talepKabul != "Y")
                {
                    styles[6].SizeType = SizeType.Absolute;
                    styles[6].Height = 0;
                }

                if (cekmeListesi != "Y")
                {
                    styles[7].SizeType = SizeType.Absolute;
                    styles[7].Height = 0;
                }

                if (paletYapma != "Y")
                {
                    styles[8].SizeType = SizeType.Absolute;
                    styles[8].Height = 0;
                }

                if (konteynerYapma != "Y")
                {
                    styles[9].SizeType = SizeType.Absolute;
                    styles[9].Height = 0;
                }

                if (depoSayimi != "Y")
                {
                    styles[10].SizeType = SizeType.Absolute;
                    styles[10].Height = 0;
                }

                if (belgesizMalCikis != "Y")
                {
                    styles[11].SizeType = SizeType.Absolute;
                    styles[11].Height = 0;
                }

                if (sipariseBagliTeslimat != "Y")
                {
                    styles[12].SizeType = SizeType.Absolute;
                    styles[12].Height = 0;
                }

                if (siparissizTeslimat != "Y")
                {
                    styles[13].SizeType = SizeType.Absolute;
                    styles[13].Height = 0;
                }

                if (uretimeMalCikis != "Y")
                {
                    styles[14].SizeType = SizeType.Absolute;
                    styles[14].Height = 0;
                }
                if (uretimdenMalGiris != "Y")
                {
                    styles[15].SizeType = SizeType.Absolute;
                    styles[15].Height = 0;
                }
                if (musterifaturaIade != "Y")
                {
                    styles[16].SizeType = SizeType.Absolute;
                    styles[16].Height = 0;
                }
                if (teslimatIade != "Y")
                {
                    styles[17].SizeType = SizeType.Absolute;
                    styles[17].Height = 0;
                }
                if (satistanIade != "Y")
                {
                    styles[18].SizeType = SizeType.Absolute;
                    styles[18].Height = 0;
                }
                if (iadeTalebi != "Y")
                {
                    styles[19].SizeType = SizeType.Absolute;
                    styles[19].Height = 0;
                }
                if (raporlar != "Y")
                {
                    styles[20].SizeType = SizeType.Absolute;
                    styles[20].Height = 0;
                }
                if (barkodOlustur != "Y")
                {
                    styles[21].SizeType = SizeType.Absolute;
                    styles[21].Height = 0;
                }
                if (magazacilikIslemleri != "Y")
                {
                    styles[22].SizeType = SizeType.Absolute;
                    styles[22].Height = 0;
                }
            }
        }

        private string userName = "";
        private string dbName = "";

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            btnSiparissizMalGiris.Font = new Font(btnSiparissizMalGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSiparissizMalGiris.Font.Style);

            btnBelgesizMalGiris.Font = new Font(btnBelgesizMalGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBelgesizMalGiris.Font.Style);

            btnTalepsizDepoNakli.Font = new Font(btnTalepsizDepoNakli.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTalepsizDepoNakli.Font.Style);

            btnTalebeBagliDepoNakli.Font = new Font(btnTalebeBagliDepoNakli.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTalebeBagliDepoNakli.Font.Style);

            btnDepoSayimi.Font = new Font(btnDepoSayimi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDepoSayimi.Font.Style);

            btnBelgesizMalCikis.Font = new Font(btnBelgesizMalCikis.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBelgesizMalCikis.Font.Style);

            btnSipariseBagliTeslimat.Font = new Font(btnSipariseBagliTeslimat.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSipariseBagliTeslimat.Font.Style);

            btnSiparissizTeslimat.Font = new Font(btnSiparissizTeslimat.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSiparissizTeslimat.Font.Style);

            btnUretimeMalCikis.Font = new Font(btnUretimeMalCikis.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnUretimeMalCikis.Font.Style);

            btnUretimdenMalGiris.Font = new Font(btnUretimdenMalGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnUretimdenMalGiris.Font.Style);

            btnSiparisliMalGiris.Font = new Font(btnSiparisliMalGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnSiparisliMalGiris.Font.Style);

            btnReports.Font = new Font(btnReports.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnReports.Font.Style);

            btnBarcode.Font = new Font(btnBarcode.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarcode.Font.Style);

            btnMusteriFatIade.Font = new Font(btnMusteriFatIade.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnMusteriFatIade.Font.Style);

            btnTeslimatIade.Font = new Font(btnTeslimatIade.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTeslimatIade.Font.Style);

            btnTalepKabul.Font = new Font(btnTalepKabul.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTalepKabul.Font.Style);

            btnIadeIrsaliyeGirisi.Font = new Font(btnIadeIrsaliyeGirisi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnIadeIrsaliyeGirisi.Font.Style);

            btnCekmeListesi.Font = new Font(btnCekmeListesi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnCekmeListesi.Font.Style);

            btnPaletYapma.Font = new Font(btnPaletYapma.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPaletYapma.Font.Style);

            btnKonteyner.Font = new Font(btnKonteyner.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnKonteyner.Font.Style);

            btnMagazacilikIslemleri.Font = new Font(btnMagazacilikIslemleri.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnMagazacilikIslemleri.Font.Style);

            btnIadeTalebi.Font = new Font(btnIadeTalebi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnIadeTalebi.Font.Style);
            ResumeLayout();
            ////font end
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

        private void Menu_Load(object sender, EventArgs e)
        {
            //SuspendLayout();

            //ResumeLayout();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
            Giris g = new Giris();
            g.ShowDialog();
            g.Dispose();
            GC.Collect();
        }

        private void btnSiparissizMalGiris_Click(object sender, EventArgs e)
        {
            //AIFTerminalServiceSoapClient aIFTerminalServiceSoapClient = new AIFTerminalServiceSoapClient();
            //aIFTerminalServiceSoapClient.AddGoodRecieptWithoutOrder(Giris._dbName);
            SiparissizMalGirisi_1.goodRecieptPOBatches = new List<Models.GoodRecieptPOBatch>();
            SiparissizMalGirisi_1 siparissizMalGirisi_1 = new SiparissizMalGirisi_1("SİPARİŞSİZ MAL GİRİŞİ");
            siparissizMalGirisi_1.ShowDialog();
            siparissizMalGirisi_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnBelgesizMalGiris_Click(object sender, EventArgs e)
        {
            BelgesizMalGirisi_1.inventoryGenEntryBatches = new List<Models.InventoryGenEntryBatch>();
            BelgesizMalGirisi_1 belgesizMalGirisi_1 = new BelgesizMalGirisi_1("BELGESİZ MAL GİRİŞİ");
            belgesizMalGirisi_1.ShowDialog();
            belgesizMalGirisi_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnSiparisliMalGiris_Click(object sender, EventArgs e)
        {
            SiparisliMalGirisi_1 siparisliMalGirisi_1 = new SiparisliMalGirisi_1("SİPARİŞLİ MAL GİRİŞİ");
            siparisliMalGirisi_1.ShowDialog();
            siparisliMalGirisi_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnTalepsizDepoNakli_Click(object sender, EventArgs e)
        {
            TalepsizDepoNakli_1.StokTransferBatches = new List<Models.StokTransferBatch>();
            TalepsizDepoNakli_1 talepsizDepoNakli_1 = new TalepsizDepoNakli_1(null, "TALEPSİZ DEPO NAKLİ");
            talepsizDepoNakli_1.ShowDialog();
            talepsizDepoNakli_1.Dispose();
            GC.Collect();
        }

        private void btnTalebeBagliDepoNakli_Click(object sender, EventArgs e)
        {
            TalebeBagliDepoNakli_1 talebeBagliDepoNakli_1 = new TalebeBagliDepoNakli_1("TALEBE BAĞLI DEPO NAKLİ");
            talebeBagliDepoNakli_1.ShowDialog();
            talebeBagliDepoNakli_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnDepoSayimi_Click(object sender, EventArgs e)
        {
            DepoSayimi_1 depoSayimi_1 = new DepoSayimi_1("DEPO SAYIMI");
            depoSayimi_1.ShowDialog();
            depoSayimi_1.Dispose();
            GC.Collect();
        }

        private void btnBelgesizMalCikis_Click(object sender, EventArgs e)
        {
            BelgesizMalCikisi_1.inventoryGenExitBatches = new List<Models.InventoryGenExitBatch>();
            BelgesizMalCikisi_1 belgesizMalCikisi_1 = new BelgesizMalCikisi_1("BELGESİZ MAL ÇIKIŞI");
            belgesizMalCikisi_1.ShowDialog();
            belgesizMalCikisi_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnSipariseBagliTeslimat_Click(object sender, EventArgs e)
        {
            SipariseBagliTeslimat_1 sipariseBagliTeslimat_1 = new SipariseBagliTeslimat_1("SİPARİŞE BAĞLI TESLİMAT");
            sipariseBagliTeslimat_1.ShowDialog();
            sipariseBagliTeslimat_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnSiparissizTeslimat_Click(object sender, EventArgs e)
        {
            SiparissizTesilmat_1.DeliveryBatches = new List<Models.DeliveryBatch>();
            SiparissizTesilmat_1 siparissizTesilmat_1 = new SiparissizTesilmat_1("SİPARİŞSİZ TESLİMAT");
            siparissizTesilmat_1.ShowDialog();
            siparissizTesilmat_1.Dispose();
            GC.Collect();
            //this.Hide();
        }

        private void btnUretimeMalCikis_Click(object sender, EventArgs e)
        {
            //SiparissizMalGirisiNew siparissizMalGirisiNew = new SiparissizMalGirisiNew();
            //siparissizMalGirisiNew.ShowDialog();
        }

        private void btnUretimdenMalGiris_Click(object sender, EventArgs e)
        {
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Raporlar raporlar = new Raporlar("RAPORLAR");
            raporlar.ShowDialog();
            raporlar.Dispose();
            GC.Collect();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            BarkodOlusturma barkodOlusturma = new BarkodOlusturma("BARKOD OLUŞTURMA");
            barkodOlusturma.ShowDialog();
            barkodOlusturma.Dispose();
            GC.Collect();
        }

        private void btnMusteriFatIade_Click(object sender, EventArgs e)
        {
            MusteriFaturaIadesi_1 musteriFaturaIadesi_1 = new MusteriFaturaIadesi_1("MÜŞTERİ FATURA İADESİ");
            musteriFaturaIadesi_1.ShowDialog();
            musteriFaturaIadesi_1.Dispose();
            GC.Collect();
        }

        private void btnTeslimatIade_Click(object sender, EventArgs e)
        {
            TeslimatIadesi_1 teslimatIadesi_1 = new TeslimatIadesi_1("TESLİMAT İADESİ");
            teslimatIadesi_1.ShowDialog();
            teslimatIadesi_1.Dispose();
            GC.Collect();
        }

        private void btnTalepKabul_Click(object sender, EventArgs e)
        {
            TalebeBagliDepoNakli_1_Kabul talebeBagliDepoNakli_1_Kabul = new TalebeBagliDepoNakli_1_Kabul("TALEP KABUL");
            talebeBagliDepoNakli_1_Kabul.ShowDialog();
            talebeBagliDepoNakli_1_Kabul.Dispose();
            GC.Collect();
        }

        private void btnIadeIrsaliyeGirisi_Click(object sender, EventArgs e)
        {
            IadeIrsaliyeGirisi_1.waybillReturnBatches = new List<Models.WaybillReturnBatch>();
            IadeIrsaliyeGirisi_1 iadeIrsaliyeGirisi_1 = new IadeIrsaliyeGirisi_1("SATIŞTAN İADE");
            iadeIrsaliyeGirisi_1.ShowDialog();
            iadeIrsaliyeGirisi_1.Dispose();
            GC.Collect();
        }

        private void btnCekmeListesi_Click(object sender, EventArgs e)
        {
            CekmeListesi cekmeListesi = new CekmeListesi("ÇEKME LİSTESİ");
            cekmeListesi.ShowDialog();
            cekmeListesi.Dispose();
            GC.Collect();
        }

        private void btnPaletYapma_Click(object sender, EventArgs e)
        {
            PaletYapma_1 paletYapma = new PaletYapma_1("PALET YAPMA");
            paletYapma.ShowDialog();
            paletYapma.Dispose();
            GC.Collect();
        }

        private void btnKonteyner_Click(object sender, EventArgs e)
        {
            KonteynerYapma_1 konteynerYapma = new KonteynerYapma_1("KONTEYNER YAPMA");
            konteynerYapma.ShowDialog();
            konteynerYapma.Dispose();
            GC.Collect();
        }

        private void btnMagazacilikIslemleri_Click(object sender, EventArgs e)
        {
            MagazacilikIslemleri magazacilikIslemleri = new MagazacilikIslemleri("MAĞAZACILIK İŞLEMLERİ");
            magazacilikIslemleri.ShowDialog();
            magazacilikIslemleri.Dispose();
            GC.Collect();
        }

        private void btnIadeTalebi_Click(object sender, EventArgs e)
        {
            IadeTalebi_1 iadeTalebi_1 = new IadeTalebi_1("İADE TALEPLERİ");
            iadeTalebi_1.ShowDialog();
            iadeTalebi_1.Dispose();
            GC.Collect();
        }
    }
}