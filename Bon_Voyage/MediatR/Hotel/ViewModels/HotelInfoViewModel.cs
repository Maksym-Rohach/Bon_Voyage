using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.ViewModels
{
    public class HotelInfoViewModel
    {
        public string Id { get; set; }
        public string MainPhoto { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string CountryPhoto { get; set; }

        public List<string> HotelPhotos { get; set; }
  
    }
}
