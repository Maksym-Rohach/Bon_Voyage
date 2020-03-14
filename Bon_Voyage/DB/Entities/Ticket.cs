using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Ticket
    {
        public string Id { get; set; }
        public float PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsBought { get; set; }
        public int CountsOfPlaces { get; set; }

        public string HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public string AirportId { get; set; }
        public virtual Airport Airport { get; set; }
        public string RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        public string ClientId { get; set; }
        public virtual ClientProfile Client { get; set; }

        public virtual ICollection<TicketsToComforts> TicketToComforts { get; set; }
    }
}
