using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters
{
    public class TicketsViewModel
    {
        public string Id { get; set; }        
        public float PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CountsOfPlaces { get; set; }
        public int Discount { get; set; }

        public int Count { get; set; }
        public int Index { get; set; }

        public List<ComfortViewModel> Comforts { get; set; }
        public CityViewModel City { get; set; }
        public HotelView Hotel { get; set; }
        public RoomTypeViewModel RoomType { get; set; }
    }
}
