using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.ViewModels
{
    public class CardsTicketViewModel
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string HotelId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public float Price { get; set; }
        public int CountOfPlaces { get; set; }
    }
}
