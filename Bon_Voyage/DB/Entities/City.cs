using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
        //public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
