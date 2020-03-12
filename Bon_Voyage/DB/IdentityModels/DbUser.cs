using Bon_Voyage.DB.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.IdentityModels
{
    public class DbUser : IdentityUser
    {
        public ICollection<DbUserRole> UserRoles { get; set; }
        public virtual BaseProfile UserProfile { get; set; }
    }
}
