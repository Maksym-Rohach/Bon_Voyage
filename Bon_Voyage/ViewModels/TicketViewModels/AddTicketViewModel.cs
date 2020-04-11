using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.ViewModels.TicketViewModels
{
    public class AddTicketViewModel
    {
        public int PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CountsOfPlaces { get; set; }
        public int Discount { get; set; }
        public int HotelId { get; set; }
        public int AirportId { get; set; }
        public int RoomTypeId { get; set; }
    }
}
