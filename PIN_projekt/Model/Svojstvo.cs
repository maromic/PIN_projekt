using System;
using System.Collections.Generic;

namespace PIN_projekt.Model
{
    public partial class Svojstvo
    {
        public Svojstvo()
        {
            Clanovi = new HashSet<Clanovi>();
        }

        public int SvojstvoId { get; set; }
        public string SvojstvoNaziv { get; set; }
        public int? SvojstvoAktivan { get; set; }

        public ICollection<Clanovi> Clanovi { get; set; }
    }
}
