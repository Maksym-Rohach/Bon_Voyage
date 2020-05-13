using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.ViewModels.TicketViewModels.Requests
{
    public class AddTicketRequest
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
