using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Comfort.ViewModels;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetDataForFilters
{
    public class DataForFilterViewModel
    {
        public ICollection<CountryViewModel> Countries { get; set; }
        public ICollection<Comfort.ViewModels.ComfortViewModel> Comforts { get; set; }
        public ICollection<RoomTypeViewModel> RoomTypes { get; set; }
    }
}
