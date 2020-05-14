using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Tickets.ViewModel
{
    public class TicketViewModel
    {
        public string Id { get; set; }
        public float Price { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CountOfNights { get; set; }
        public int CountOfPlaces { get; set; }
        public HotelForTicketViewModel Hotel { get; set; }
        public AirportForTicketViewModel Airport { get; set; }
        public RoomTypeForTicketViewModel RoomType { get; set; }
        public CountryForTicketViewModel Country { get; set; }
        public ICollection<ComfortsForTicketViewModel> Comforts { get; set; }
    }
}
