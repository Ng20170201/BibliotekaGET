using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podaci
{
    public interface IRepositoryKnjiga : IRepository<Knjiga>
    { 
        void SmanjiBroj(int iDKnjige);
        void PovecajBroj(int idKnjige);
        Knjiga VratiKnjigu(int iDKnjige);
    }
}
