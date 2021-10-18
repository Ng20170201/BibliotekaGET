using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.Implementacija
{
   
    public class RepositoryKorisnik : IRepositoryKorisnik
    {
        private BibliotekaContext context;

        public RepositoryKorisnik(BibliotekaContext context)
        {
            this.context = context;
        }

        public void Dodaj(Korisnik t)
        {
            throw new NotImplementedException();
        }

        public void Kreiraj(Korisnik t)
        {
            throw new NotImplementedException();
        }

        public void Obrisi(Korisnik t)
        {
            throw new NotImplementedException();
        }

        public Korisnik Vrati(string usernameKorisnik)
        {
            return context.Korisnik.Find(usernameKorisnik);
        }

        public List<Korisnik> VratiSve()
        {
            return context.Korisnik.ToList();
        }

     

        public List<Korisnik> VratiSveKorisnika(string s)
        {
            throw new NotImplementedException();
        }
    }
}
