using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Commands.CreateAirportCommand
{
    public class CreateAirportViewModel
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
