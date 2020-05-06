using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Feedback
    {
        [Key]
        public string Id { get; set; }
        public string Theme { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual BaseProfile User { get; set; }
    }
}
