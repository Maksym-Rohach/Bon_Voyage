using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.ViewModel
{
    public class TicketViewModel
    {
        public string Id { get; set; }
        public float PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CountsOfPlaces { get; set; }
        public int Discount { get; set; }
        

        //цена, страна, время отправки, время прибытия, количество мест, юзер 

        //public string HotelId { get; set; }
        //public virtual Hotel Hotel { get; set; }
        //public string AirportId { get; set; }
        //public virtual Airport Airport { get; set; }
        //public string RoomTypeId { get; set; }
        //public virtual RoomType RoomType { get; set; }
        //public string ClientId { get; set; }
        //public virtual ClientProfile Client { get; set; }
        //public virtual ICollection<TicketsToComforts> TicketToComforts { get; set; }
    }
}
