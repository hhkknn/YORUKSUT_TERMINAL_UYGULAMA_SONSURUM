using AIF.TERMINAL.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class form_Base : Form
    {
        public form_Base()
        {
            InitializeComponent();
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
        private void baseBackButton_Click(object sender, EventArgs e)
        {
            if (this.Name != "Giris" && this.Name != "Menu" && this.Name != "BarkodGoruntule" && this.Name != "BarkodOlusturma" && this.Name != "CekmeListesi" && this.Name != "DepodakiPartiler" && this.Name != "DepoSayimi_2" && this.Name != "DepoSayimi_3" && this.Name != "DepoSayimi_4" && this.Name != "DepoSayimi_5" && this.Name != "IadeIrsaliyeGirisi_2" && this.Name != "KonteynerYapma_1" && this.Name != "KonteynerYapma_3" && this.Name != "MusteriFaturaIadesi_1" && this.Name != "PaletYapma_1" && this.Name != "PaletYapma_3" && this.Name != "PartiHareketRaporu" && this.Name != "PartisizKalemSecimi" && this.Name != "PartiSorgulama" && this.Name != "RaporForm" && this.Name != "Raporlar" && this.Name != "SatisVeTeslimatPartiSecim" && this.Name != "SayiKlavyesi" && this.Name != "SelectList" && this.Name != "SipariseBagliTeslimat_1" && this.Name != "SipariseBagliTeslimat_3" && this.Name != "SipariseBagliTeslimat_Detay" && this.Name != "SiparisliMalGirisi_1" && this.Name != "SiparisliMalGirisi_3" && this.Name != "TalebeBagliDepoNakli_1" && this.Name != "TalebeBagliDepoNakli_1_Kabul" && this.Name != "TalebeBagliDepoNakli_3" && this.Name != "TalebeBagliDepoNakli_3_Kabul" && this.Name != "TeslimatIadesi_1" && this.Name != "UrunSorgulama" && this.Name != "SubeSecim" && this.Name != "MagazaDepoMalKabul_1" && this.Name != "MagazaDepoMalKabul_3" && this.Name != "MagazaTransfer_1" && this.Name != "MagazacilikIslemleri" && this.Name != "IadeTalebi_1" && this.Name != "DepoSorgulama")
            {
                DialogResult dialogResult = CustomMsgBoxQuestion.Show("Bir Önceki Ekrana Dön", "UYARI", "EVET", "HAYIR", "Back");
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                //var menus = (Menu)sender;
                //Menu menu = new Forms.Menu(null, null);
                //menu.Show();  

                //this.Close();

            }
            if (this.Name == "Giris")
            {
                return;
            }
            this.Close(); //old

        }

        private void baseExitButton_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            CustomMsgBoxQuestion.Show("UYGULAMA KAPATILACAKTIR.DEVAM ETMEK İSTİYOR MUSUNUZ?", "Uyarı", "Evet", "Hayır");
        }

        private void form_Base_Load(object sender, EventArgs e)
        {
            if (Giris.mKodValue == "10TRMN")
            {
                //lblGirisBaslik.Text = "TUNÇMATİK BAYİ YÖNETİM SİSTEMİ";
                this.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "30TRMN")
            {
                //pictureEdit1.Image = Properties.Resources.AIFTeam2;
                //this.BackgroundImage = Properties.Resources.Arkaplan_gri_jpeg;
                this.BackgroundImage = Properties.Resources.ANATOLYA_ARKAPLAN_jpeg;
            }
            else if (Giris.mKodValue == "20TRMN")
            {
                this.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }
        }
        bool formresize = false;
        private void form_Base_Resize(object sender, EventArgs e)
        {
            //if (formresize)
            //{
            //    return;
            //}
            //if (WindowState == FormWindowState.Minimized)
            //{
            //    foreach (Form form in Application.OpenForms)
            //    {
            //        formresize = true;
            //        form.WindowState = FormWindowState.Minimized;
            //    }

            //}
            //else if (WindowState == FormWindowState.Maximized)
            //{
            //    foreach (Form form in Application.OpenForms)
            //    {
            //        form.WindowState = FormWindowState.Maximized;
            //    }
            //}

            //formresize = false;
        }

        private void buttonBaseMinimized_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

    }
}
