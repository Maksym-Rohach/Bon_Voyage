using Bon_Voyage.MediatR.Airports.ViewModel;
using Bon_Voyage.MediatR.Country.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Queries.GetAirportControlDataQuery
{
    public class AirportsControlDataViewModel
    {
        public ICollection<CountryViewModel> Countries { get; set; }
        public ICollection<AirportViewModel> Airports { get; set; }
    }
}
