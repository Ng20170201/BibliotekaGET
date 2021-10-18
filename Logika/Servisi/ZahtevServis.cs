using Domen;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logika.Servisi
{
    public class ZahtevServis
    {
        public ZahtevServis(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        private IUnitOfWork uow
        {
            get; set;
        }

        public List<Zahtev> VratiSveZahteve()
        {
            return uow.Zahtev.VratiSve(); 
        }

        public Rezervacija Prihvati(Zahtev z, DateTime datumDo)
        {
            Rezervacija r = new Rezervacija();
            r.DatumIzdavanja = DateTime.UtcNow;
            r.DatumVracanja = datumDo;
            if (datumDo < DateTime.UtcNow)
            {
                throw new Exception("Vreme ne moze biti manje od danasnjeg");
            }
            r.IDKnjige = z.knjigaId;
            r.KorisnikUsername = z.usernameKorisnik;
            r.Korisnik = uow.Rezervacija.VratiKorisnika(r.KorisnikUsername);
            try
            {
                uow.Rezervacija.Kreiraj(r);
                if (uow.Knjiga.VratiKnjigu(r.IDKnjige).Kolicina >= 0)
                {
                    uow.Knjiga.SmanjiBroj(r.IDKnjige);
                }
                else
                {
                    throw new Exception("Nema knjiga");
                }
                uow.Zahtev.Obrisi(z);
                uow.Commit();
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
