using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.Implementacija
{
  
    public class RepositoryKnjiga : IRepositoryKnjiga
    {
        private BibliotekaContext context;

        public RepositoryKnjiga(BibliotekaContext context)
        {
            this.context = context;
        }

      

        public void Dodaj(Knjiga k)
        {
            
            
                context.Knjiga.Add(k);
            
          
        }

        public void Kreiraj(Knjiga t)
        {
            throw new NotImplementedException();
        }

        public void Obrisi(Knjiga t)
        {
            throw new NotImplementedException();
        }

        public void PovecajBroj(int idKnjige)
        {
            Knjiga k=context.Knjiga.Find(idKnjige);
            k.Kolicina++;
            context.Knjiga.Update(k);
        }

        public void SmanjiBroj(int idKnjige)
        {
            Knjiga k = context.Knjiga.Find(idKnjige);
            k.Kolicina--;
            context.Knjiga.Update(k);
        }

        public Knjiga Vrati(int id)
        {
            throw new NotImplementedException();
        }

        public Knjiga VratiKnjigu(int iDKnjige)
        {

            return context.Knjiga.Find(iDKnjige);
        }

        public List<Knjiga> VratiSve()
        {
            return context.Knjiga.ToList();
        
        }

        public List<Knjiga> VratiSve(string usernameKorisnik)
        {
            throw new NotImplementedException();
        }

        public List<Knjiga> VratiSveKorisnika(string s)
        {
            throw new NotImplementedException();
        }
    }
}
