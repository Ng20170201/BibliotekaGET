using Domen;
using Podaci.Implementacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.UnitOfWork
{
    public class BibliotekaUnitOfWork : IUnitOfWork
    {
        private BibliotekaContext context;

       

        public BibliotekaUnitOfWork(BibliotekaContext context)
        {
            this.context = context;

            Knjiga = new RepositoryKnjiga(this.context);
            Rezervacija = new RepositoryRezervacija(this.context);
            Korisnik = new RepositoryKorisnik(this.context);
            Zahtev = new RepositoryZahtev(this.context);


        }
        public IRepositoryKnjiga Knjiga { get; set; }
        public IRepositoryKorisnik Korisnik { get; set; }
        public IRepositoryRezervacija Rezervacija { get; set; }
        public IRepositoryZahtev  Zahtev { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
