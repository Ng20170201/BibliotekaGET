using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.Implementacija
{
  
    public class RepositoryZahtev : IRepositoryZahtev
    {
        private BibliotekaContext context;

        public RepositoryZahtev(BibliotekaContext context)
        {
            this.context = context;
        }

        public void Dodaj(Zahtev t)
        {
            throw new NotImplementedException();
        }

        public void Kreiraj(Zahtev z)
        {
            context.Zahtev.Add(z);
        }

        public void Obrisi(Zahtev t)
        {
            context.Zahtev.Remove(t);
        }

        public List<Zahtev> VratiSve()
        {
            return context.Zahtev.Include(r => r.Korisnik).Include(r => r.Knjiga).ToList();
        }

       

        public List<Zahtev> VratiSveKorisnika(string usernameKorisnik)
        {
            return context.Zahtev.Include(r => r.Korisnik).Include(r => r.Knjiga).ToList().FindAll(z => z.usernameKorisnik == usernameKorisnik);
        }
    }
}
