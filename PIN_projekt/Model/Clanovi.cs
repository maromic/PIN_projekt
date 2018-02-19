using System;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PIN_projekt.Model
{
	public partial class Clanovi
	{
		public int ClanId { get; set; }
		[Required(ErrorMessage = "Ime je obavezno.")]
		public string ClanIme { get; set; }
		[Required(ErrorMessage = "Prezime je obavezno.")]
		public string ClanPrezime { get; set; }
		public string ClanEmail { get; set; }
		public string ClanTelefon { get; set; }
		public DateTime? ClanDatumRodenja { get; set; }
		public int? ClanVisina { get; set; }
		public int? ClanBrojNoge { get; set; }
		[Required(ErrorMessage = "Datum upisa je obavezan.")]
		public DateTime ClanClanOd { get; set; }
		public int ClanSvojstvo { get; set; }
		public int ClanAktivan { get; set; }
		[Required(ErrorMessage = "Grupa je obavezna.")]
		public int? ClanGrupa { get; set; }

		public Grupa ClanGrupaNavigation { get; set; }
		public Svojstvo ClanSvojstvoNavigation { get; set; }

		[XmlIgnore]
		public Boolean ConvertAktivan
		{
			get { return ClanAktivan == 0 ? false : true; }
		}
    }
}

