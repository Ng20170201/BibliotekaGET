using Domen;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Hubs
{
    public class BibliotekaHub : Hub 
    {
        internal void PrihvatiZahtev(Domen.Zahtev z, DateTime datumDo)
        {
            Clients.All.SendAsync("prihvatiZahtev",z,datumDo);
        }

 

        internal void PosaljiZahtev(Zahtev z)
        {
            Clients.All.SendAsync("posaljiZahtev", z);
        }
    }
}
