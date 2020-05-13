using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Cities.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Bon_Voyage.DB;

namespace Bon_Voyage.MediatR.Cities.Queries.GetCitiesByCountry
{
    public class GetCitiesByCountryQuery : IRequest<ICollection<HomeCityViewModel>>
    {
        public string CountryId { get; set; }

        public class GetCitiesByCountryQueryHandler : BaseMediator, IRequestHandler<GetCitiesByCountryQuery, ICollection<HomeCityViewModel>>
        {
            public GetCitiesByCountryQueryHandler(EFDbContext context) : base(context)
            {
            }
            
            public async Task<ICollection<HomeCityViewModel>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
            {
                var cities = _context.Cities.Where(x => x.CountryId == request.CountryId).Select(x => new HomeCityViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();               

                return cities;
            }
        }
    }
}
