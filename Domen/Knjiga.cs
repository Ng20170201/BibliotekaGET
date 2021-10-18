using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Knjiga
    {
        public int Id { get; set; }
        public string Ime { get; set; }

        public int Kolicina { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public List<Zahtev> Zahtevi { get; set; }

    }
}
