using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.ViewModels
{
    public class HotelViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string IsClosed { get; set; }
        public CityViewModel City { get; set; }
    }
}
