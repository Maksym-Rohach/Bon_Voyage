using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Hotel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public bool IsClosed { get; set; }

        public string CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<PhotosToHotel> PhotosToHotels { get; set; }
    }
}
