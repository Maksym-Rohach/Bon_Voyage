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
                var tickets = _context.Carts
                    .Where(x => x.ClientId == request.ClientId)
                    .Select(t => new CardsTicketViewModel
                    {
                        Id = t.Ticket.Id,
                        City = t.Ticket.Hotel.City.Name,
                        Country = t.Ticket.Hotel.City.Country.Name,
                        Hotel = t.Ticket.Hotel.Name,
                        CountOfPlaces = t.Ticket.CountsOfPlaces,
                        DateTo = t.Ticket.DateTo.ToString("dd.MM.yyyy"),
                        DateFrom = t.Ticket.DateFrom.ToString("dd.MM.yyyy"),
                        Price = t.Ticket.PriceFrom
                    }).ToList();

                return tickets;
            }
        }
    }
}
