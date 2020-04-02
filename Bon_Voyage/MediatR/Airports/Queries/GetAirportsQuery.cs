using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Airports.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Queries
{
    public class GetAirportsQuery : IRequest<ICollection<AirportViewModel>>
    {
        public class GetAirportsQueryHandler : IRequestHandler<GetAirportsQuery, ICollection<AirportViewModel>>
        {
            private readonly EFDbContext _context;

            public GetAirportsQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<ICollection<AirportViewModel>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
            {
                var airports = await _context.Airports.Select(x => new AirportViewModel
                {
                    Id = x.Id,
                    CityName = x.City.Name,
                    Name = x.Name,
                    ShortName = x.ShortName
                }).ToListAsync();

                if (airports != null)
                {
                    return airports;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
