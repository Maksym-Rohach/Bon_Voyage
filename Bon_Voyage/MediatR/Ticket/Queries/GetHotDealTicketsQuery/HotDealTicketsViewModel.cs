using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetHotDealTicketsQuery
{
    public class HotDealTicketsViewModel
    {
        public string Id { get; set; }
        public int CountOfPlaces { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
