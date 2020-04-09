using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetBoughtTicketsQuery
{
    public class BoughtTicketsViewModel
    {
        //цена, страна, время отправки, время прибытия, количество мест, юзер 
        public string Id { get; set; }
        public int CountOfPlaces { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DataTo { get; set; }
        public float Price { get; set; }
        public CountryViewModel Country { get; set; }
        public ClientViewModel Client { get; set; }


    }
}
