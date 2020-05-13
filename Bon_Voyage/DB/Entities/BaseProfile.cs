using Bon_Voyage.DB.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class BaseProfile
    {
        [Key,ForeignKey("User")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }


        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ManagerProfile ManagerProfile { get; set; }
        public virtual AdminProfile AdminProfile { get; set; }
        public virtual BlockedProfile BlockedProfile { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual DbUser User { get; set; }
    }
}
