using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class TicketsToComforts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string ComfortId { get; set; }
        public virtual Comfort Comfort { get; set; }
    }
}
