using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public interface IRepositoryZahtev : IRepository<Zahtev>
    {
        Zahtev VratiSveZaKorisnika(int knjigaId, string usernameKorisnik);
    }
}
