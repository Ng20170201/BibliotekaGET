using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Zahtev
    {
        
        public int knjigaId { get; set; }
        public string usernameKorisnik { get; set; }
        

        public Knjiga Knjiga { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
