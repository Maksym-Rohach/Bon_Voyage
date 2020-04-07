using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.ViewModels
{
    public class HomeTicketViewModel
    {
        public string Id { get; set; }
        public int PriceFrom { get; set; }
        public int CountsOfNight { get; set; }  
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
