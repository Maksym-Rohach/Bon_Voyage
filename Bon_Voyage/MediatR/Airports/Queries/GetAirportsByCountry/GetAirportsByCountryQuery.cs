using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Airports.ViewModel;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Queries.GetAirportsByCountry
{
    public class GetAirportsByCountryQuery : IRequest<ICollection<AddTicketAirportViewModel>>
    {
        public string CountryId { get; set; }

        public class GetAirportsByCountryQueryHandler : BaseMediator, IRequestHandler<GetAirportsByCountryQuery, ICollection<AddTicketAirportViewModel>>
        {
            public GetAirportsByCountryQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<AddTicketAirportViewModel>> Handle(GetAirportsByCountryQuery request, CancellationToken cancellationToken)
            {
                var airports = _context.Airports
                    .Where(x => x.City.Country.Id == request.CountryId)
                    .Select(x => new AddTicketAirportViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();

                return airports;
            }
        }
    }
}
