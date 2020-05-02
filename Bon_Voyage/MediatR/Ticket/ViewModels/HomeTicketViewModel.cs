using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.ViewModels
{
    public class HomeTicketViewModel
    {
        public string Id { get; set; }
        public float Price { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
