using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.TERMINAL.Models
{
    public class PartiliPartisizEkranList
    {
        public string UrunKodu { get; set; }
        public string UrunTanimi { get; set; }
        public string Barkod { get; set; }
        public string OlcuBirimi { get; set; }
        public double DepoMiktar { get; set; }
        public double SiparisMiktari { get; set; }
        public double ToplananMiktar { get; set; }
        public double ToplanmayanMiktar { get; set; }
        public double OnayBekleyenMiktar { get; set; }
        public double Miktar { get; set; }
        public string PaletIciKoliAD { get; set; }
        public string KoliIciAD { get; set; }
        public string PaletIciAD { get; set; }
        public string DepoKodu { get; set; }
        public string DepoTanimi { get; set; }
        public string DepoYeriId { get; set; }
        public string DepoYeriAdi { get; set; } 
        public string SiparisSatirNo { get; set; }
        public string SiparisNumarasi { get; set; }
        public string PaletNumarasi { get; set; }
        public string SatirKaynagi { get; set; }
    }
}
