using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class CreateKnjigaModel
    {
        [Required]
        public Knjiga Knjiga { get; set; }
        public int Greska { get; set; }


    }
}
