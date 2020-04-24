using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Country.ViewModels
{
    public class CountryControlViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CityCount { get; set; }
    }
}
