using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryKnjiga Knjiga { get; set; }
        public IRepositoryKorisnik Korisnik { get; set; }
        public IRepositoryRezervacija Rezervacija { get; set; }
        public IRepositoryZahtev Zahtev { get; set; }
        void Commit();

    }
}
