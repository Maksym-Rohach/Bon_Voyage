using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class TicketsToComforts
    {
        [Key]
        public string Id { get; set; }
        public string TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string ComfortId { get; set; }
        public virtual Comfort Comfort { get; set; }
    }
}
