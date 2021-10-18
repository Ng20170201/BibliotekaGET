using Domen;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika.Servisi
{
    public class KorisnikServis
    {
        public KorisnikServis(IUnitOfWork uow)
        {

            this.uow = uow;
        }

        private IUnitOfWork uow { get; set; }

        public Korisnik SingIn(string username, string password)
        {
            List<Korisnik> korisnici = uow.Korisnik.VratiSve();
            return  korisnici.Find(k => username == k.Username && password == k.Passsword);
        }
    }
}
