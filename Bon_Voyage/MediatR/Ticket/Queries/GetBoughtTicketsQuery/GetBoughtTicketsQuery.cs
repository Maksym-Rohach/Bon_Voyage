using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetBoughtTicketsQuery
{
    public class GetBoughtTicketsQuery : IRequest<ICollection<BoughtTicketsViewModel>>
    {
        public class GetBoughtTicketsQueryHandler : BaseMediator, IRequestHandler<GetBoughtTicketsQuery, ICollection<BoughtTicketsViewModel>>
        {
            public GetBoughtTicketsQueryHandler(EFDbContext context) : base(context)
            {

            }
            public async Task<ICollection<BoughtTicketsViewModel>> Handle(GetBoughtTicketsQuery request, CancellationToken cancellationToken)
            {
                var res = await _context
                    .Tickets
                    .Where(x => x.IsBought)
                    .Select(x => new BoughtTicketsViewModel
                    {
                        Id = x.Id,
                        Price = x.PriceFrom,
                        DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                        DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                        CountOfPlaces = x.CountsOfPlaces,
                        Client = new ClientViewModel
                        {
                            Id = x.ClientId,
                            FullName = x.Client.BaseProfile.Name + x.Client.BaseProfile.Surname
                        },
                        Country = new CountryViewModel
                        {
                            Id = x.Hotel.City.CountryId,
                            Name = x.Hotel.City.Country.Name
                        }
                    }).ToListAsync();
                return res;
            }
        }
    }
}
