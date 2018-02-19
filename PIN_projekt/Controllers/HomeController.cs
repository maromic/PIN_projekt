using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIN_projekt.Models;
using PIN_projekt.Model;

namespace PIN_projekt.Controllers
{
    public class HomeController : Controller
    {
		PIN_clanoviContext db = new PIN_clanoviContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClanoviView()
        {
            ViewData["Message"] = "Članovi FAZM";

			List<Clanovi> clanovi = findClanovi();
			ViewBag.Clanovi = clanovi;

			return View();
        }

        public IActionResult Unos_novog()
        {
            ViewData["Message"] = "Unos novog člana.";

			List<Svojstvo> svojstva = findSvojstva();
			ViewBag.Svojstva = svojstva;

			List<Grupa> grupe = findGrupa();
			ViewBag.Grupe = grupe;

            return View();
        }

		[HttpPost]
		public IActionResult Unos_novog(Clanovi clanovi)
		{
			Clanovi c = clanovi;
			if (c.ClanId.Equals(null))
			{

			}
			if (ModelState.IsValid)
			{
				db.Clanovi.Add(c);
				db.SaveChanges();

				List<Clanovi> clanoviList = findClanovi();
				ViewBag.Clanovi = clanoviList;

				return ClanoviView();
			}
			List<Svojstvo> svojstva = findSvojstva();
			ViewBag.Svojstva = svojstva;

			List<Grupa> grupe = findGrupa();
			ViewBag.Grupe = grupe;

			return View(c);
		}

		/*[HttpPost]
		public IActionResult Unos_novog(int clanId)
		{
			var clanZaAzuriranje = from clan in db.Clanovi where clan.ClanId == clanId  select clan;
			Clanovi clan_ = (Clanovi) clanZaAzuriranje;

			List<Svojstvo> svojstva = findSvojstva();
			ViewBag.Svojstva = svojstva;

			List<Grupa> grupe = findGrupa();
			ViewBag.Grupe = grupe;

			return View(clan_);
		}*/

			public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		private List<Clanovi> findClanovi()
		{
			var clanovi = from clan in db.Clanovi select clan;
			return (clanovi.ToList());
		}

		private List<Svojstvo> findSvojstva()
		{
			var clanovi = from clan in db.Svojstvo select clan;
			return (clanovi.ToList());
		}

		private List<Grupa> findGrupa()
		{
			var grupe = from grupa in db.Grupa select grupa;
			return (grupe.ToList());
		}
	}
}
