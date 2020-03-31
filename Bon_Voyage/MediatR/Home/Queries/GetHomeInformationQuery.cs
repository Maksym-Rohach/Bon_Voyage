using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Home.ViewModel;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.Queries
{
    public class GetHomeInformationQuery : IRequest<HomeInfoViewModel>
    {
        public class GetHomeInformationQueryHandler : BaseMediator, IRequestHandler<GetHomeInformationQuery, HomeInfoViewModel>
        {
            public GetHomeInformationQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<HomeInfoViewModel> Handle(GetHomeInformationQuery request, CancellationToken cancellationToken)
            {
                //int topHotelsPhoto = 3;
                int topTickets = 3;
                int maxHotTickets = 8;

                var result = new HomeInfoViewModel();
                var currentData = DateTime.Now;

                result.Countries = _context.Country.ToList();
                result.TopTickets = _context.Tickets.OrderBy(x => x.PriceFrom).Take(topTickets).ToList();
                result.TopHotTickets = _context.Tickets.Where(x =>
                x.DateFrom.Subtract(currentData).Days <=  3)
                .Take(maxHotTickets)
                .ToList();             
               
                return result;
            }
        }
    }
}
