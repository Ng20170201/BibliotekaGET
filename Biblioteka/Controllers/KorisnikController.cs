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
    
    public class KorisnikController : Controller
    {
        private BibliotekaHub hub;
        private KorisnikServis servis;
        public KorisnikController(IUnitOfWork unitOfWork, BibliotekaHub hub)
        {
            this.hub = hub;
            servis = new KorisnikServis(unitOfWork);
           
        }

        public IActionResult SignIn()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
        
            
            try
            {
                Korisnik ulogovaniKorisnik = servis.SingIn(username, password);
 
                if (ulogovaniKorisnik == null)
                {
                    return View();
                }
                switch (ulogovaniKorisnik.TipKorisnika)
                {
                    case TipKorisnika.Bibliotekar:
                        HttpContext.Session.SetInt32("TipKorisnika", 0);
                        HttpContext.Session.SetString("Username", ulogovaniKorisnik.Username);
                        return RedirectToAction("Zahtevi", "Zahtev");

                    case TipKorisnika.Posetilac:

                        HttpContext.Session.SetInt32("TipKorisnika", 1);
                        HttpContext.Session.SetString("Username", ulogovaniKorisnik.Username);
                        return RedirectToAction("Knjige", "Knjiga");


                    default:

                        return View();
                }
               
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View("Signin");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
