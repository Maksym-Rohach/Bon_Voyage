using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Ticket.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetCardsTickets
{
    public class GetCardsTicketsQuery : IRequest<ICollection<CardsTicketViewModel>>
    {
        public string ClientId { get; set; }

        public class GetCardsTicketsQueryHandler : BaseMediator, IRequestHandler<GetCardsTicketsQuery, ICollection<CardsTicketViewModel>>
        {
            public GetCardsTicketsQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<CardsTicketViewModel>> Handle(GetCardsTicketsQuery request, CancellationToken cancellationToken)
            {
                return null;
            }
        }
    }
}
