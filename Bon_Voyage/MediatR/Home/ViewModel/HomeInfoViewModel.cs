using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Ticket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.ViewModel
{
    public class HomeInfoViewModel
    {
        public List<CountryViewModel> Countries { get; set; }
        public List<string> Random3Photos { get; set; }
        public List<HomeHotelViewModel> TopHotels { get; set; }
        public List<HomeTicketViewModel> HotTickets { get; set; }
    }
}
