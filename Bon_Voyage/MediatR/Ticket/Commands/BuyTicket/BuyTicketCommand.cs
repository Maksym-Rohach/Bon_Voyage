using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Commands.BuyTicket
{
    public class BuyTicketCommand : IRequest<string>
    {
        public string ClientId { get; set; }
        public string TicketId { get; set; }

        public class BuyTicketCommandHandler : BaseMediator, IRequestHandler<BuyTicketCommand, string>
        {
            public BuyTicketCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<string> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
            {
                if(_context.Users.FirstOrDefault(x => x.Id == request.ClientId) == null)
                {
                    return "false";
                }
                if(_context.Tickets.FirstOrDefault(x => x.Id == request.TicketId) == null)
                {
                    return "false";
                }

                _context.Remove(_context.Carts.FirstOrDefault(x => x.ClientId == request.ClientId));
                _context.Tickets.FirstOrDefault(x => x.Id == request.TicketId).IsBought = true;
                _context.Tickets.FirstOrDefault(x => x.Id == request.TicketId).ClientId = request.ClientId;
                _context.SaveChanges();

                return "true";
            }
        }
    }
}
