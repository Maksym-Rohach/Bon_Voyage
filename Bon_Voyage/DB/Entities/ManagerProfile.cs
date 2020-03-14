using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class ManagerProfile : BaseProfile
    {        
        public bool State { get; set; }
        public DateTime DateOfRegister { get; set; }
        public float Salary { get; set; }
    }
}
