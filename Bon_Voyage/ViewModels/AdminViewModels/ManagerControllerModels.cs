using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.ViewModels.AdminViewModels
{
    public class AddManagerModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public bool State { get; set; }
        public DateTime DateOfRegister { get; set; }
        public float Salary { get; set; }
    }
    public class DeleteManagerModel
    {
        public string id { get; set; }
    }

    public class UpdateManagerModel
    {
        public string id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public bool State { get; set; }
        public DateTime DateOfRegister { get; set; }
        public float Salary { get; set; }
    }
}
