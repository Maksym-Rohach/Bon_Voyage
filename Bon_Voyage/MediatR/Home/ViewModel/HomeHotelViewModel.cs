using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.ViewModel
{
    public class HomeHotelViewModel
    {
        public string Id { get; set; }
        public int Stars { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
