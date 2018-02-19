using System;
using System.Collections.Generic;

namespace PIN_projekt.Model
{
    public partial class Grupa
    {
        public Grupa()
        {
            Clanovi = new HashSet<Clanovi>();
        }

        public int GrupaId { get; set; }
        public string GrupaNaziv { get; set; }
        public DateTime? GrupaDatumOd { get; set; }
        public int? GrupaAktivan { get; set; }

        public ICollection<Clanovi> Clanovi { get; set; }
    }
}
