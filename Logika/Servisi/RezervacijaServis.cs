using Domen;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logika.Servisi
{
    public class RezervacijaServis
    {
        public RezervacijaServis(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        private IUnitOfWork uow
        {
            get; set;
        }

        public List<Rezervacija> VratiRezervacijeKorsinka(string username)
        {
            return uow.Rezervacija.VratiSveKorisnika(username);
        }

        public List<Rezervacija> VratiSve()
        {
            return uow.Rezervacija.VratiSve();
        }

        public void VratiKnjigu(int id, string username, int idKnjige)
        {
            uow.Rezervacija.Delete(id);
            uow.Knjiga.PovecajBroj(idKnjige);
            uow.Commit();
        }
    }
}
