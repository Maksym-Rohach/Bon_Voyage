using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.Application.Manager.ViewModel
{
    public class ManagerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime DateOfRegister { get; set; }
    }
}
