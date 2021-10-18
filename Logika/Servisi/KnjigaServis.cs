using Domen;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika.Servisi
{
    public class KnjigaServis
    {
        public  KnjigaServis(IUnitOfWork uow)
        {
            
            this.uow = uow;
        }

        private IUnitOfWork uow { get; set; }

        public List<Knjiga> VratiSveKnjige()
        {
            return uow.Knjiga.VratiSve();
        }

        public void CreateKnjiga(Knjiga knjiga)
        {
           
            uow.Knjiga.Dodaj(knjiga);
            uow.Commit();
        }

        public void Rezervisi(Zahtev z)
        {
            int brojrezervacija = uow.Rezervacija.VratiSveKorisnika(z.usernameKorisnik).Count()
                + uow.Zahtev.VratiSveKorisnika(z.usernameKorisnik).Count();
            if (brojrezervacija >= 5)
            {
                return;
            }
            try
            {
                uow.Zahtev.Kreiraj(z);

                uow.Commit();
            }
            catch (Exception)
            {

                Console.WriteLine("vec je poslan zahtev za tu knjigu");




            }
        }

        public Zahtev VratiSveZaZahtev(Zahtev z)
        {
            return uow.Zahtev.VratiSveZaKorisnika(z.knjigaId, z.usernameKorisnik);
        }
    }
}
