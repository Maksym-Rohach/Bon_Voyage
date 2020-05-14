using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters
{
    public class TicketFilters
    {
        public string HotelId { get; set; }
        public string CountryId { get; set; }
        public bool WithDiscount { get; set; }
        public int CountOfPlaces { get; set; }
        public int CountOfNights { get; set; }
        public int HotelStars { get; set; }
        public string ComfortId { get; set; }
        public string RoomTypeId { get; set; }
       

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public float MaxPrice { get; set; }
       
    }
}
