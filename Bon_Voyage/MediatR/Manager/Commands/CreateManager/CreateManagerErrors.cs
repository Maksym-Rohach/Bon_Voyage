using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Manager.Commands.CreateManager
{
    public class CreateManagerErrors
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string ServerResponse { get; set; }
        public bool Status { get; set; }
    }
}
