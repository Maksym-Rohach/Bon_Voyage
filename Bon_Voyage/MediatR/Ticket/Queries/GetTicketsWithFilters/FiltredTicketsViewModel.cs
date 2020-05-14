using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters
{
    public class FiltredTicketsViewModel
    {
        public int Count { get; set; }
        public int Index { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
