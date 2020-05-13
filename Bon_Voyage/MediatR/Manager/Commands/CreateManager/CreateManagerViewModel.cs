using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Manager.Commands.CreateManager
{
    public class CreateManagerViewModel
    {
        public bool Status { get; set; }
        public CreateManagerErrors ErrorsMessages {get;set;}
    }
}
