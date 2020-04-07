using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Home.ViewModel;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using Bon_Voyage.MediatR.Ticket.ViewModels;
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

                result.Countries = _context.Country.Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                result.TopTickets = _context.Tickets
                    .OrderBy(x => x.PriceFrom)
                    .Take(topTickets)
                    .Select(x => new HomeTicketViewModel
                {
                        Id = x.Id,
                        City = x.Hotel.City.Name,
                        Country = x.Hotel.City.Country.Name,
                        CountsOfNight = x.CountsOfNight,
                        Description = x.Hotel.Description,
                        Photo = "null",
                        PriceFrom = Convert.ToInt32(x.PriceFrom)
                }).ToList();

                result.TopHotTickets = _context.Tickets.Where(x => x.Discount != null)
                .Take(maxHotTickets)
                .Select(x => new HomeTicketViewModel
                {
                    Id = x.Id,
                    City = x.Hotel.City.Name,
                    Country = x.Hotel.City.Country.Name,
                    CountsOfNight = x.CountsOfNight,
                    Description = x.Hotel.Description,
                    Photo = "null",
                    PriceFrom = Convert.ToInt32(x.PriceFrom)
                })
                .ToList();             
               
                return result;
            }
        }
    }
}
