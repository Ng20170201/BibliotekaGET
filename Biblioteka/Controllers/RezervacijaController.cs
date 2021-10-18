using Biblioteka.Filteri;
using Biblioteka.Hubs;
using Domen;
using Logika.Servisi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{
    [LoggedUserFilter]
    public class RezervacijaController : Controller
    {
        
        private RezervacijaServis servis;
        //private BibliotekaHub hub;
        private IHubContext<BibliotekaHub> hub;
        public RezervacijaController(IUnitOfWork unitOfWork, IHubContext<BibliotekaHub> hub)
        {
            this.hub = hub;
            servis = new RezervacijaServis(unitOfWork);
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rezervacije(int idKnjige)
        {
            ViewBag.TipKorisnika = HttpContext.Session.GetInt32("TipKorisnika");
            string username = HttpContext.Session.GetString("Username");
        
            if (ViewBag.TipKorisnika == 1)
            {
                List<Rezervacija> rezervacijeKorisnika = servis.VratiRezervacijeKorsinka(username);
                //hub.RezervacijeKorisnika(username);
                return View("Rezervacije", rezervacijeKorisnika);
            }
            else
            {
                List<Rezervacija> rezervacijeKorisnika = servis.VratiSve();
                //hub.SveRezervacije();
                return View("Rezervacije", rezervacijeKorisnika);
            }
         
        }
        
        public IActionResult VratiKnjigu(int id,string username,int idKnjige)
        {
            try
            {
                servis.VratiKnjigu(id,username,idKnjige);
           
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Rezervacije");
        }

    
    }
}
