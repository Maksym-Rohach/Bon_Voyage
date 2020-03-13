using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class PhotosToHotel
    {
        [Key]
        public string Id { get; set; }
        public string PhotoLink { get; set; }
        public string HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
