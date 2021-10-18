using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public interface IRepositoryRezervacija : IRepository<Rezervacija>
    {
      

        void Delete(int id);
        Korisnik VratiKorisnika(string korisnikUsername);
    }
}
