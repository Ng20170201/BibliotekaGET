using System;
using System.Collections.Generic;

namespace Podaci
{
    public interface IRepository<T>
    {
        void Dodaj(T t);
        List<T> VratiSve();
        List<T> VratiSveKorisnika(string s);
        void Kreiraj(T t);
        void Obrisi(T t);
    }
}
