﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Airport
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        
        public string CityId { get; set; }
        public virtual City City { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
