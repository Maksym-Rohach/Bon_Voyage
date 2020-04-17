using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Comfort
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TicketsToComforts> TicketToComforts { get; set; }
    }
}
