using Bon_Voyage.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.ViewModel
{
    public class HomeInfoViewModel
    {
        public List<Bon_Voyage.DB.Entities.Country> Countries { get; set; }
        //public string Top3Photos { get; set; }
        public List<Ticket> TopTickets { get; set; }
        public List<Ticket> TopHotTickets { get; set; }
    }
}
