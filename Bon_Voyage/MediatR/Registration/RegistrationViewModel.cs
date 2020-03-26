using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Registration
{
    public class RegistrationViewModel
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Tokken { get; set; }
    }
}
