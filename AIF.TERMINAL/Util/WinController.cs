using AIF.TERMINAL.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Util
{
    public class WinController
    {
        private static Forms.form_Base formGiris;
        private static Forms.form_Base formTopMost;
        private static Forms.form_Base formMenu;
        private static Forms.form_Base formMusteriFaturaIadesi_1;
        private static Forms.form_Base formMusteriFaturaIadesi_2;
        private static Forms.form_Base formTeslimatIadesi_1;
        private static Forms.form_Base formTeslimatIadesi_2;
        private static Forms.form_Base formPartisizKalemSecimi;
        private static Forms.form_Base formRaporlar;
        private static Forms.form_Base formSipariseBagliTeslimat_1;
        private static Forms.form_Base formSipariseBagliTeslimat_2;
        private static Forms.form_Base formSipariseBagliTeslimat_3;
        private static Forms.form_Base formBelgesizMalGirisi_1;
        private static Forms.form_Base formBarkodGoruntule;
        private static Forms.form_Base formBarkodOlusturma;
        private static Forms.form_Base formBelgesizMalCikisi_1;
        private static Forms.form_Base formSiparisliMalGirisi_1;
        private static Forms.form_Base formSiparisliMalGirisi_2;
        private static Forms.form_Base formSiparisliMalGirisi_3;
        private static Forms.form_Base formSiparissizMalGirisi_1;
        private static Forms.form_Base formSiparissizTeslimat_1;
        private static Forms.form_Base formTalebeBagliDepoNakli_1;
        private static Forms.form_Base formTalebeBagliDepoNakli_2;
        private static Forms.form_Base formTalebeBagliDepoNakli_3;
        private static Forms.form_Base formTalepsizDepoNakli_1;
        private static Forms.form_Base formUrunSorgulama;
        private static Forms.form_Base formPartiSorgulama;
        private static Forms.form_Base formDepoSorgulama;
        private static Forms.form_Base formSelectList;
        private static Forms.form_Base formSayiKlavyesi;
        private static Forms.form_Base formCekmeListesi;
        private static Forms.form_Base formCekmeListesi_2;
        private static Forms.form_Base formDepoSayimi_1;

        #region Giris

        public static void LaunchFormGiris()
        {
            formGiris = new Giris();
            formTopMost = formGiris;
            formGiris.Show();
        }

        public static System.Windows.Forms.Form GetFormGiris()
        {
            return formGiris;
        }

        #endregion

        #region Menu

        public static void LaunchFormMenu()
        {
            if (formMenu != null)
                CloseFormMenu();

            formMenu = new Forms.Menu(null, null);
            formMenu.Show();
            formTopMost = formMenu;
        }

        public static void CloseFormMenu()
        {
            if (formMenu == null)
                return;

            formMenu.Close();
            formMenu.Dispose();
            formMenu = null;
        }
        #endregion

        #region MusteriFaturaIadesi_1

        public static void LaunchFormMusteriFaturaIadesi_1()
        {
            if (formMusteriFaturaIadesi_1 != null)
                CloseFormMusteriFaturaIadesi_1();

            formMusteriFaturaIadesi_1 = new Forms.MusteriFaturaIadesi_1("");
            formMusteriFaturaIadesi_1.Show();
            formTopMost = formMusteriFaturaIadesi_1;
        }

        public static void CloseFormMusteriFaturaIadesi_1()
        {
            if (formMusteriFaturaIadesi_1 == null)
                return;

            formMusteriFaturaIadesi_1.Close();
            formMusteriFaturaIadesi_1.Dispose();
            formMusteriFaturaIadesi_1 = null;
        }
        #endregion

        #region MusteriFaturaIadesi_2

        public static void LaunchFormMusteriFaturaIadesi_2()
        {
            if (formMusteriFaturaIadesi_2 != null)
                CloseFormMusteriFaturaIadesi_2();

            formMusteriFaturaIadesi_2 = new Forms.MusteriFaturaIadesi_2(null,"");
            formMusteriFaturaIadesi_2.Show();
            formTopMost = formMusteriFaturaIadesi_2;
        }

        public static void CloseFormMusteriFaturaIadesi_2()
        {
            if (formMusteriFaturaIadesi_2 == null)
                return;

            formMusteriFaturaIadesi_2.Close();
            formMusteriFaturaIadesi_2.Dispose();
            formMusteriFaturaIadesi_2 = null;
        }
        #endregion

        #region TeslimatIadesi_1

        public static void LaunchFormTeslimatIadesi_1()
        {
            if (formTeslimatIadesi_1 != null)
                CloseFormTeslimatIadesi_1();

            formTeslimatIadesi_1 = new Forms.TeslimatIadesi_1(null);
            formTeslimatIadesi_1.Show();
            formTopMost = formTeslimatIadesi_1;
        }

        public static void CloseFormTeslimatIadesi_1()
        {
            if (formTeslimatIadesi_1 == null)
                return;

            formTeslimatIadesi_1.Close();
            formTeslimatIadesi_1.Dispose();
            formTeslimatIadesi_1 = null;
        }
        #endregion

        #region TeslimatIadesi_2

        public static void LaunchFormTeslimatIadesi_2()
        {
            if (formTeslimatIadesi_2 != null)
                CloseFormTeslimatIadesi_2();

            formTeslimatIadesi_2 = new Forms.TeslimatIadesi_2(null,"");
            formTeslimatIadesi_2.Show();
            formTopMost = formTeslimatIadesi_2;
        }

        public static void CloseFormTeslimatIadesi_2()
        {
            if (formTeslimatIadesi_2 == null)
                return;

            formTeslimatIadesi_2.Close();
            formTeslimatIadesi_2.Dispose();
            formTeslimatIadesi_2 = null;
        }
        #endregion

        #region PartisizKalemSecimi

        public static void LaunchFormPartisizKalemSecimi()
        {
            if (formPartisizKalemSecimi != null)
                CloseFormPartisizKalemSecimi();

            formPartisizKalemSecimi = new Forms.PartisizKalemSecimi(null, null, "");
            formPartisizKalemSecimi.Show();
            formTopMost = formPartisizKalemSecimi;
        }

        public static void CloseFormPartisizKalemSecimi()
        {
            if (formPartisizKalemSecimi == null)
                return;

            formPartisizKalemSecimi.Close();
            formPartisizKalemSecimi.Dispose();
            formPartisizKalemSecimi = null;
        }
        #endregion

        #region Raporlar

        public static void LaunchFormRaporlar()
        {
            if (formRaporlar != null)
                CloseFormRaporlar();

            formRaporlar = new Forms.Raporlar("");
            formRaporlar.Show();
            formTopMost = formRaporlar;
        }

        public static void CloseFormRaporlar()
        {
            if (formRaporlar == null)
                return;

            formRaporlar.Close();
            formRaporlar.Dispose();
            formRaporlar = null;
        }
        #endregion

        #region BelgesizMalGirisi_1

        public static void LaunchFormBelgesizMalGirisi_1()
        {
            if (formBelgesizMalGirisi_1 != null)
                CloseFormMenu();

            formBelgesizMalGirisi_1 = new Forms.BelgesizMalGirisi_1("");
            formBelgesizMalGirisi_1.Show();
            formTopMost = formBelgesizMalGirisi_1;
        }

        public static void CloseFormBelgesizMalGirisi_1()
        {
            if (formBelgesizMalGirisi_1 == null)
                return;

            formBelgesizMalGirisi_1.Close();
            formBelgesizMalGirisi_1.Dispose();
            formBelgesizMalGirisi_1 = null;
        }
        #endregion

        #region BarkodGoruntule

        public static void LaunchFormBarkodGoruntule()
        {
            if (formBarkodGoruntule != null)
                CloseFormBarkodGoruntule();

            formBarkodGoruntule = new Forms.BarkodGoruntule(null, null, "");
            formBarkodGoruntule.Show();
            formTopMost = formBarkodGoruntule;
        }

        public static void CloseFormBarkodGoruntule()
        {
            if (formBarkodGoruntule == null)
                return;

            formBarkodGoruntule.Close();
            formBarkodGoruntule.Dispose();
            formBarkodGoruntule = null;
        }
        #endregion

        #region BarkodOlusturma

        public static void LaunchFormBarkodOlusturma()
        {
            if (formBarkodOlusturma != null)
                CloseFormBarkodOlusturma();

            formBarkodOlusturma = new Forms.BarkodOlusturma("");
            formBarkodOlusturma.Show();
            formTopMost = formBarkodOlusturma;
        }

        public static void CloseFormBarkodOlusturma()
        {
            if (formBarkodOlusturma == null)
                return;

            formBarkodOlusturma.Close();
            formBarkodOlusturma.Dispose();
            formBarkodOlusturma = null;
        }
        #endregion

        #region SipariseBagliTeslimat_1
        public static void LaunchFormSipariseBagliTeslimat_1()
        {
            if (formSipariseBagliTeslimat_1 != null)
                CloseFormMenu();

            formSipariseBagliTeslimat_1 = new Forms.SipariseBagliTeslimat_1("");
            formSipariseBagliTeslimat_1.Show();
            formTopMost = formSipariseBagliTeslimat_1;
        }

        public static void CloseFormSipariseBagliTeslimat_1()
        {
            if (formSipariseBagliTeslimat_1 == null)
                return;

            formSipariseBagliTeslimat_1.Close();
            formSipariseBagliTeslimat_1.Dispose();
            formSipariseBagliTeslimat_1 = null;
        }
        #endregion

        #region SipariseBagliTeslimat_2
        public static void LaunchFormSipariseBagliTeslimat_2()
        {
            if (formSipariseBagliTeslimat_2 != null)
                CloseFormMenu();

            formSipariseBagliTeslimat_2 = new Forms.SipariseBagliTeslimat_2(null, null, "");
            formSipariseBagliTeslimat_2.Show();
            formTopMost = formSipariseBagliTeslimat_2;
        }

        public static void CloseFormSipariseBagliTeslimat_2()
        {
            if (formSipariseBagliTeslimat_2 == null)
                return;

            formSipariseBagliTeslimat_2.Close();
            formSipariseBagliTeslimat_2.Dispose();
            formSipariseBagliTeslimat_2 = null;
        }
        #endregion

        #region SipariseBagliTeslimat_3
        public static void LaunchFormSipariseBagliTeslimat_3()
        {
            if (formSipariseBagliTeslimat_3 != null)
                CloseFormMenu();

            formSipariseBagliTeslimat_3 = new Forms.SipariseBagliTeslimat_3("", null, "");
            formSipariseBagliTeslimat_3.Show();
            formTopMost = formSipariseBagliTeslimat_3;
        }

        public static void CloseFormSipariseBagliTeslimat_3()
        {
            if (formSipariseBagliTeslimat_3 == null)
                return;

            formSipariseBagliTeslimat_3.Close();
            formSipariseBagliTeslimat_3.Dispose();
            formSipariseBagliTeslimat_3 = null;
        }
        #endregion

        #region BelgesizMalCikisi_1
        public static void LaunchFormBelgesizMalCikisi_1()
        {
            if (formBelgesizMalCikisi_1 != null)
                CloseFormMenu();

            formBelgesizMalCikisi_1 = new Forms.BelgesizMalCikisi_1("");
            formBelgesizMalCikisi_1.Show();
            formTopMost = formBelgesizMalCikisi_1;
        }

        public static void CloseFormBelgesizMalCikisi_1()
        {
            if (formBelgesizMalCikisi_1 == null)
                return;

            formBelgesizMalCikisi_1.Close();
            formBelgesizMalCikisi_1.Dispose();
            formBelgesizMalCikisi_1 = null;
        }
        #endregion

        #region SiparisliMalGirisi_1

        public static void LaunchFormSiparisliMalGirisi_1()
        {
            if (formSiparisliMalGirisi_1 != null)
                CloseFormMenu();

            formSiparisliMalGirisi_1 = new Forms.SiparisliMalGirisi_1("");
            formSiparisliMalGirisi_1.Show();
            formTopMost = formSiparisliMalGirisi_1;
        }

        public static void CloseFormSiparisliMalGirisi_1()
        {
            if (formSiparisliMalGirisi_1 == null)
                return;

            formSiparisliMalGirisi_1.Close();
            formSiparisliMalGirisi_1.Dispose();
            formSiparisliMalGirisi_1 = null;
        }
        #endregion

        #region SiparisliMalGirisi_2

        public static void LaunchFormSiparisliMalGirisi_2()
        {
            if (formSiparisliMalGirisi_2 != null)
                CloseFormMenu();

            formSiparisliMalGirisi_2 = new Forms.SiparisliMalGirisi_2(null, "");
            formSiparisliMalGirisi_2.Show();
            formTopMost = formSiparisliMalGirisi_2;
        }

        public static void CloseFormSiparisliMalGirisi_2()
        {
            if (formSiparisliMalGirisi_2 == null)
                return;

            formSiparisliMalGirisi_2.Close();
            formSiparisliMalGirisi_2.Dispose();
            formSiparisliMalGirisi_2 = null;
        }
        #endregion

        #region SiparisliMalGirisi_3

        public static void LaunchFormSiparisliMalGirisi_3()
        {
            if (formSiparisliMalGirisi_3 != null)
                CloseFormMenu();

            formSiparisliMalGirisi_3 = new Forms.SiparisliMalGirisi_3(null, null, "");
            formSiparisliMalGirisi_3.Show();
            formTopMost = formSiparisliMalGirisi_2;
        }

        public static void CloseFormSiparisliMalGirisi_3()
        {
            if (formSiparisliMalGirisi_3 == null)
                return;

            formSiparisliMalGirisi_3.Close();
            formSiparisliMalGirisi_3.Dispose();
            formSiparisliMalGirisi_3 = null;
        }
        #endregion

        #region SiparissizMalGirisi_1

        public static void LaunchFormSiparissizMalGirisi_1()
        {
            if (formSiparissizMalGirisi_1 != null)
                CloseFormMenu();

            formSiparissizMalGirisi_1 = new Forms.SiparissizMalGirisi_1("");
            formSiparissizMalGirisi_1.Show();
            formTopMost = formSiparissizMalGirisi_1;
        }

        public static void CloseFormSiparissizMalGirisi_1()
        {
            if (formSiparissizMalGirisi_1 == null)
                return;

            formSiparissizMalGirisi_1.Close();
            formSiparissizMalGirisi_1.Dispose();
            formSiparissizMalGirisi_1 = null;
        }
        #endregion

        #region SiparissizTeslimat_1

        public static void LaunchFormSiparissizTeslimat_1()
        {
            if (formSiparissizTeslimat_1 != null)
                CloseFormMenu();

            formSiparissizTeslimat_1 = new Forms.SiparissizTesilmat_1("");
            formSiparissizTeslimat_1.Show();
            formTopMost = formSiparissizTeslimat_1;
        }

        public static void CloseFormSiparissizTeslimat_1()
        {
            if (formSiparissizTeslimat_1 == null)
                return;

            formSiparissizTeslimat_1.Close();
            formSiparissizTeslimat_1.Dispose();
            formSiparissizTeslimat_1 = null;
        }
        #endregion

        #region TalebeBagliDepoNakli_1

        public static void LaunchFormTalebeBagliDepoNakli_1()
        {
            if (formTalebeBagliDepoNakli_1 != null)
                CloseFormMenu();

            formTalebeBagliDepoNakli_1 = new Forms.TalebeBagliDepoNakli_1("");
            formTalebeBagliDepoNakli_1.Show();
            formTopMost = formTalebeBagliDepoNakli_1;
        }

        public static void CloseFormTalebeBagliDepoNakli_1()
        {
            if (formTalebeBagliDepoNakli_1 == null)
                return;

            formTalebeBagliDepoNakli_1.Close();
            formTalebeBagliDepoNakli_1.Dispose();
            formTalebeBagliDepoNakli_1 = null;
        }
        #endregion

        #region TalebeBagliDepoNakli_2

        public static void LaunchFormTalebeBagliDepoNakli_2()
        {
            if (formTalebeBagliDepoNakli_2 != null)
                CloseFormMenu();

            formTalebeBagliDepoNakli_2 = new Forms.TalebeBagliDepoNakli_2(null, null, "");
            formTalebeBagliDepoNakli_2.Show();
            formTopMost = formTalebeBagliDepoNakli_2;
        }

        public static void CloseFormTalebeBagliDepoNakli_2()
        {
            if (formTalebeBagliDepoNakli_2 == null)
                return;

            formTalebeBagliDepoNakli_2.Close();
            formTalebeBagliDepoNakli_2.Dispose();
            formTalebeBagliDepoNakli_2 = null;
        }
        #endregion

        #region TalebeBagliDepoNakli_3

        public static void LaunchFormTalebeBagliDepoNakli_3()
        {
            if (formTalebeBagliDepoNakli_3 != null)
                CloseFormMenu();

            formTalebeBagliDepoNakli_3 = new Forms.TalebeBagliDepoNakli_3(null, null, "");
            formTalebeBagliDepoNakli_3.Show();
            formTopMost = formTalebeBagliDepoNakli_3;
        }

        public static void CloseFormTalebeBagliDepoNakli_3()
        {
            if (formTalebeBagliDepoNakli_3 == null)
                return;

            formTalebeBagliDepoNakli_3.Close();
            formTalebeBagliDepoNakli_3.Dispose();
            formTalebeBagliDepoNakli_3 = null;
        }
        #endregion

        #region TalepsizDepoNakli_1

        public static void LaunchFormTalepsizDepoNakli_1()
        {
            if (formTalepsizDepoNakli_1 != null)
                CloseFormMenu();

            formTalepsizDepoNakli_1 = new Forms.TalepsizDepoNakli_1(null, "");
            formTalepsizDepoNakli_1.Show();
            formTopMost = formTalepsizDepoNakli_1;
        }

        public static void CloseFormTalepsizDepoNakli_1()
        {
            if (formTalepsizDepoNakli_1 == null)
                return;

            formTalepsizDepoNakli_1.Close();
            formTalepsizDepoNakli_1.Dispose();
            formTalepsizDepoNakli_1 = null;
        }
        #endregion

        #region UrunSorgulama

        public static void LaunchFormUrunSorgulama()
        {
            if (formUrunSorgulama != null)
                CloseFormUrunSorgulama();

            formUrunSorgulama = new Forms.UrunSorgulama("");
            formUrunSorgulama.Show();
            formTopMost = formUrunSorgulama;
        }

        public static void CloseFormUrunSorgulama()
        {
            if (formUrunSorgulama == null)
                return;

            formUrunSorgulama.Close();
            formUrunSorgulama.Dispose();
            formUrunSorgulama = null;
        }
        #endregion

        #region PartiSorgulama

        public static void LaunchFormPartiSorgulama()
        {
            if (formPartiSorgulama != null)
                CloseFormPartiSorgulama();

            formPartiSorgulama = new Forms.PartiSorgulama("");
            formPartiSorgulama.Show();
            formTopMost = formPartiSorgulama;
        }

        public static void CloseFormPartiSorgulama()
        {
            if (formPartiSorgulama == null)
                return;

            formPartiSorgulama.Close();
            formPartiSorgulama.Dispose();
            formPartiSorgulama = null;
        }
        #endregion

        #region DepoSorgulama

        public static void LaunchFormDepoSorgulama()
        {
            if (formDepoSorgulama != null)
                CloseFormDepoSorgulama();

            formDepoSorgulama = new Forms.DepoSorgulama("");
            formDepoSorgulama.Show();
            formTopMost = formDepoSorgulama;
        }

        public static void CloseFormDepoSorgulama()
        {
            if (formDepoSorgulama == null)
                return;

            formDepoSorgulama.Close();
            formDepoSorgulama.Dispose();
            formDepoSorgulama = null;
        }
        #endregion

        #region SelectList

        public static void LaunchFormSelectList()
        {
            if (formSelectList != null)
                CloseFormSelectList();

            formSelectList = new Forms.SelectList(null, null, "", null, null);
            formSelectList.Show();
            formTopMost = formSelectList;
        }

        public static void CloseFormSelectList()
        {
            if (formSelectList == null)
                return;

            formSelectList.Close();
            formSelectList.Dispose();
            formSelectList = null;
        }
        #endregion

        #region SayiKlavyesi
        public static void LaunchFormSayiKlavyesi()
        {
            if (formSayiKlavyesi != null)
                CloseFormSayiKlavyesi();

            formSayiKlavyesi = new Forms.SayiKlavyesi(null, null, false);
            formSayiKlavyesi.Show();
            formTopMost = formSayiKlavyesi;
        }

        public static void CloseFormSayiKlavyesi()
        {
            if (formSayiKlavyesi == null)
                return;

            formSayiKlavyesi.Close();
            formSayiKlavyesi.Dispose();
            formSayiKlavyesi = null;
        }
        #endregion

        #region CekmeListesi
        public static void LaunchCekmeListesi()
        {
            if (formCekmeListesi != null)
                CloseFormCekmeListesi();

            formCekmeListesi = new Forms.CekmeListesi("");
            formCekmeListesi.Show();
            formTopMost = formCekmeListesi;
        }

        public static void CloseFormCekmeListesi()
        {
            if (formCekmeListesi == null)
                return;

            formCekmeListesi.Close();
            formCekmeListesi.Dispose();
            formCekmeListesi = null;
        }
        #endregion

        #region CekmeListesi_2
        public static void LaunchCekmeListesi_2()
        {
            if (formCekmeListesi_2 != null)
                CloseFormCekmeListesi_2();

            formCekmeListesi_2 = new Forms.CekmeListesi_2("","","","");
            formCekmeListesi_2.Show();
            formTopMost = formCekmeListesi_2;
        }

        public static void CloseFormCekmeListesi_2()
        {
            if (formCekmeListesi_2 == null)
                return;

            formCekmeListesi_2.Close();
            formCekmeListesi_2.Dispose();
            formCekmeListesi_2 = null;
        }
        #endregion

        #region Deposayimi_1
        public static void LaunchFormDepoSayimi_1()
        {
            if (formDepoSayimi_1 != null)
                CloseFormDepoSayimi_1();

            formDepoSayimi_1 = new Forms.DepoSayimi_1("");
            formDepoSayimi_1.Show();
            formTopMost = formDepoSayimi_1;
        }

        public static void CloseFormDepoSayimi_1()
        {
            if (formDepoSayimi_1 == null)
                return;

            formDepoSayimi_1.Close();
            formDepoSayimi_1.Dispose();
            formDepoSayimi_1 = null;
        }
        #endregion
    }
}