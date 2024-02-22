using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class GenelParametreler
    {
        public string DepoYeriCalisir { get; set; }
        public string TalebeBaglidaOrjinalOlustur { get; set; }
        public string TalepsizDepoNaklindeTaslakBelgeOlustur { get; set; }
        public string TurkceArama { get; set; }
        public string BarkodYolu { get; set; }
        public string CrystalKullan { get; set; }
        public string CekmeListesiFazlaMiktarGirer { get; set; }
        public string CekmeListesiKalemleriniGrupla { get; set; }
        public string SayimMiktariOtomatikOlarakAcilsin { get; set; } //Ekranda ürün seçildikten sonra miktar alanı otomatik bir şekilde açılması için kullanılır.
        public string SayimButonuOtomatikOlarakBasilsin { get; set; }//Ekranda ürün miktarı girişi yapıldıktan sonra otomatik olarak SAY butonuna basması için kullanılır.
        public int OndalikMiktar { get; set; } 
        public string DepoCalismaTipi { get; set; }
        public string BarkodKalemBirlesikOku { get; set; }
        public string TarihBazliPartiOlustur { get; set; }
        public string UygulamaYetkiSifresi { get; set; }
        public string UrunSorguFiyat { get; set; }
        public string UrunSorguFiyatList { get; set; }
        public string SubeSecimiYapilsin { get; set; }
        public string PaletYapmadaDepoSecilsin { get; set; }
        
    }
}
