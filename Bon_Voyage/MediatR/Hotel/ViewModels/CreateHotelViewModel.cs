using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Commands.CreateHotel
{
    public class CreateHotelViewModel
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
