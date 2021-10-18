using Domen;
using Microsoft.AspNetCore.Mvc;
using Podaci.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Filteri;
using Logika.Servisi;
using Microsoft.AspNetCore.SignalR;
using Biblioteka.Hubs;

namespace Biblioteka.Controllers
{
    [LoggedUserFilter]
    public class ZahtevController : Controller
    {

        private ZahtevServis servis;
        //private BibliotekaHub hub;
        private IHubContext<BibliotekaHub> hub;
        public ZahtevController(IUnitOfWork unitOfWork, IHubContext<BibliotekaHub> hub)
        {
            this.hub = hub;
            servis = new ZahtevServis(unitOfWork);
       
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Zahtevi()
        {
            List<Zahtev> zahtevi = servis.VratiSveZahteve();
            return View("Zahtevi", zahtevi);
           
        }
        [HttpPost]
        public IActionResult Prihvati(Zahtev z,DateTime datumDo)
        {
            
            try
            {
                Rezervacija r=servis.Prihvati(z, datumDo);
                z.Korisnik = r.Korisnik;
                z.usernameKorisnik = r.KorisnikUsername;
                
                     int br = ViewBag.TipKorisnika;
                hub.Clients.All.SendAsync("prihvatiZahtev", z.knjigaId,z.usernameKorisnik,z.Knjiga.Ime,z.Korisnik.ImeIPrezime,r.DatumIzdavanja,r.DatumVracanja,r.Id, datumDo,br);

            }
            catch (Exception)
            {

                
            }

            return RedirectToAction("Rezervacije", "Rezervacija");

        }
      
       
    }
}
