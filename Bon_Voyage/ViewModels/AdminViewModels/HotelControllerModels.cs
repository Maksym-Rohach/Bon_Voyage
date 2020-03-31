using Bon_Voyage.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.ViewModels.AdminViewModels
{
    public class AddHotelModel
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
    }
    public class DeleteHotelModel
    {
        public string id { get; set; }
    }
    public class UpdateHotelModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public ICollection<string> Photolink { get; set; }
    }
}
