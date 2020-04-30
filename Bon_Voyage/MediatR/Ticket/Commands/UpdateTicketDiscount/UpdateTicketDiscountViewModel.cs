using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Commands.UpdateTicketDiscount
{
    public class UpdateTicketDiscountViewModel
    {
        public bool Status { get; internal set; }
        public string ErrorMessage { get; set; }
    }
}
