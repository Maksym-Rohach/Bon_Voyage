using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Commands.AddTicketToCart
{
    public class AddTicketToCart : IRequest<bool>
    {
        public string TicketId { get; set; }
        public string ClientId { get; set; }

        public class AddTicketToCartHandler : BaseMediator, IRequestHandler<AddTicketToCart, bool>
        {
            public AddTicketToCartHandler(EFDbContext context) : base(context)
            {

            }

            public async Task<bool> Handle(AddTicketToCart request, CancellationToken cancellationToken)
            {
                if (request.ClientId != null && request.ClientId != "")
                {
                    _context.Carts.Add(new DB.Entities.Cart
                    {
                        ClientId = request.ClientId,
                        TicketId = request.TicketId
                    });
                    return true;
                }
                return false;
            }
        }
    }
}
