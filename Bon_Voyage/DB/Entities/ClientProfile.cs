using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class ClientProfile
    {
        [Key]
        public string Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual BaseProfile BaseProfile { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
