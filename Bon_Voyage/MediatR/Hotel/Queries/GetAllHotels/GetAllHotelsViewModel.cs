using Bon_Voyage.MediatR.Hotel.ViewModels;
using Bon_Voyage.MediatR.Country.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetAllHotels
{
    public class GetAllHotelsViewModel
    {
        public ICollection<CountryViewModel> Countries { get; set; }
        public ICollection<HotelViewModel> Hotels { get; set; }
    }
}
