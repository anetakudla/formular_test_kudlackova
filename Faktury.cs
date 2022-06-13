using System;

namespace FakturyKudlackova
{
    public class Faktury
    {
        public int id { get; set; }
        public DateTime datum { get; set; }
        public int cislo { get; set; }
        public string odberatel { get; set; }
        public string nazev { get; set; }
        public int pocet { get; set; }
        public float cena { get; set; }
        public float celkem { get; set; }
        public float DPH { get; set; }
        public float cenaDPH { get; set; }
    }
}
