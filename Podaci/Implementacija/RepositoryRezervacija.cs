using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.Implementacija
{

    public class RepositoryRezervacija : IRepositoryRezervacija
    {
        private BibliotekaContext context;

        public RepositoryRezervacija(BibliotekaContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            List<Rezervacija> rezervacije = context.Rezervacija.ToList();
            Rezervacija r = rezervacije.Find(k => k.Id == id );
            context.Rezervacija.Remove(r);
            
        }

        public void Kreiraj(Rezervacija r)
        {
            context.Rezervacija.Add(r);
        }

       

      

        public List<Rezervacija> VratiSve()
        {
            return context.Rezervacija.Include(r => r.Korisnik).Include(r => r.Knjiga).ToList();
        }

        public void Dodaj(Rezervacija t)
        {
            throw new NotImplementedException();
        }

        public List<Rezervacija> VratiSveKorisnika(string s)
        {
            return context.Rezervacija.Include(r => r.Korisnik).Include(r => r.Knjiga).ToList().FindAll(r => r.KorisnikUsername == s);
        }

        public void Obrisi(Rezervacija t)
        {
            context.Rezervacija.Remove(t);
        }

        public Korisnik VratiKorisnika(string username)
        {
            return context.Korisnik.ToList().Find(r=>r.Username==username);
        }
    }
}
