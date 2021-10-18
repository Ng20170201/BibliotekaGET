using Biblioteka.Filteri;
using Biblioteka.Hubs;
using Biblioteka.Models;
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
    
    public class KnjigaController : Controller
    {
        private KnjigaServis servis;
        //private BibliotekaHub hub;
        private IHubContext<BibliotekaHub> hub;
        public KnjigaController(IUnitOfWork unitOfWork,IHubContext<BibliotekaHub> hub)
        {
            this.hub = hub;
            servis = new KnjigaServis(unitOfWork);
            
        }

        // GET: KnjigaCotroller
        public ActionResult CreateKnjiga()
        {
            
            return View();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Knjige()
        {
            var knjige = servis.VratiSveKnjige();
          
            return View("Knjige",knjige);
        }
            
        [HttpPost]
        public ActionResult CreateKnjiga(CreateKnjigaModel model)
        {
           
            if (model.Knjiga.Kolicina > 0)
            {
                try
                {
                    servis.CreateKnjiga(model.Knjiga);


                }
                catch (Exception)
                {

                    throw new Exception("Greska prilikom dodavanja nove knjige");
                } 
            }
            
            return RedirectToAction("CreateKnjiga");
        }
        [HttpPost]
        public void Rezervisi(int id)
        {
            Zahtev z = new Zahtev();
            z.knjigaId = id;
  
            z.usernameKorisnik = HttpContext.Session.GetString("Username");
            servis.Rezervisi(z);
            hub.Clients.All.SendAsync("posaljiZahtev", z);
           
            //return RedirectToAction("Knjige");

        }
        

        


    }

}
