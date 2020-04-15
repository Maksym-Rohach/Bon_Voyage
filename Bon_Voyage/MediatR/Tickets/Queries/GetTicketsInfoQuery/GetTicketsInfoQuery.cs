using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Tickets.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Tickets.Queries.GetTicketsInfoQuery
{
    public class GetTicketsInfoQuery:IRequest<ICollection<TicketViewModel>>
    {
        public class GetTicketsInfoQueryHandler : BaseMediator, IRequestHandler<GetTicketsInfoQuery, ICollection<TicketViewModel>>
        {
            public GetTicketsInfoQueryHandler(EFDbContext context) : base(context)
            {

            }
            public async Task<ICollection<TicketViewModel>> Handle(GetTicketsInfoQuery request, CancellationToken cancellationToken)
            {
                var tickets = _context.Tickets.Select(x => new TicketViewModel
                //var tickets = _context.Tickets.Where(x=>x.IsBought).Select(x => new TicketViewModel
                {
                    Id = x.Id,
                    CountOfNights = x.CountsOfNight,
                    CountOfPlaces = x.CountsOfPlaces,
                    DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                    DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                    Price = x.PriceFrom,
                    Airport = new AirportForTicketViewModel
                    {
                        Id = x.AirportId,
                        Name = x.Airport.Name,
                        ShortName = x.Airport.ShortName
                    },
                    Country = new CountryForTicketViewModel
                    {
                        Id = x.Airport.City.CountryId,
                        Name = x.Airport.City.Country.Name
                    },
                    RoomType = new RoomTypeForTicketViewModel
                    {
                        Id = x.RoomTypeId,
                        Name = x.RoomType.Name
                    },
                    Hotel = new HotelForTicketViewModel
                    {
                        Id = x.HotelId,
                        Name = x.Hotel.Name,
                        Description = x.Hotel.Description,
                        Stars = x.Hotel.Stars
                    },
                    Comforts = x.TicketToComforts.Select(y => new ComfortsForTicketViewModel
                    {
                        Id = y.ComfortId,
                        Name = y.Comfort.Name
                    }).ToList()
                }).ToList();
                return tickets;
            }
        }
    }
}
