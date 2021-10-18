using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Rezervacija
    {
        
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumVracanja { get; set; }

        public string KorisnikUsername { get; set; }
        public int IDKnjige { get; set; }

        public Korisnik Korisnik { get; set; }
        public Knjiga Knjiga { get; set; }

    }
}
