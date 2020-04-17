using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetHotDealTicketsQuery
{
    public class GetHotDealTicketsQuery : IRequest<ICollection<HotDealTicketsViewModel>>
    {
        public class GetHotDealTicketsQueryHandler : BaseMediator, IRequestHandler<GetHotDealTicketsQuery, ICollection<HotDealTicketsViewModel>>
        {
            public GetHotDealTicketsQueryHandler(EFDbContext context) : base(context)
            {

            }
            public async Task<ICollection<HotDealTicketsViewModel>> Handle(GetHotDealTicketsQuery request, CancellationToken cancellationToken)
            {
                var res = await _context
                    .Tickets
                    //.Where(x => ((x.DateFrom-DateTime.Now).TotalDays<=10))
                    .Select(x => new HotDealTicketsViewModel
                    {
                        Id = x.Id,
                        Price = x.PriceFrom,
                        Discount=x.Discount,
                        DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                        DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                        CountOfPlaces = x.CountsOfPlaces,
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
