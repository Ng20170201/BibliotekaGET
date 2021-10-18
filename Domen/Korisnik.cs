using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Korisnik
    {
        public string ImeIPrezime { get; set; }
        public string Username { get; set; }
        public string Passsword { get; set; }
        
        public TipKorisnika TipKorisnika { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }

        public List<Zahtev> Zahtevi { get; set; }
    }
}
