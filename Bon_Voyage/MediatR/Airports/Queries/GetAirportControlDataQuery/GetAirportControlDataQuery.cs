using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Airports.Queries.GetAirportControlDataQuery;
using Bon_Voyage.MediatR.Airports.ViewModel;
using Bon_Voyage.MediatR.Country.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Queries.GetAirportsQuery
{
    public class GetAirportControlDataQuery : IRequest<AirportsControlDataViewModel>
    {
        public class GetAirportControlDataQueryHandler : IRequestHandler<GetAirportControlDataQuery, AirportsControlDataViewModel>
        {
            private readonly EFDbContext _context;

            public GetAirportControlDataQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<AirportsControlDataViewModel> Handle(GetAirportControlDataQuery request, CancellationToken cancellationToken)
            {
                var airports = await _context.Airports.Select(x => new AirportViewModel
                {
                    Id = x.Id,
                    CityName = x.City.Name,
                    Name = x.Name,
                    ShortName = x.ShortName
                }).ToListAsync();
                var countries = await _context.Country.Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                var res = new AirportsControlDataViewModel
                {
                    Airports = airports,
                    Countries = countries
                };
                return res;
            }
        }
    }
}
