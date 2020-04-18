using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Cities.Queries.GetCitiesByCountry;
using Bon_Voyage.MediatR.Cities.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Cities.Queries.GetAllCities
{
    public class GetAllCitiesQuery : IRequest<ICollection<HomeCityViewModel>>
    {

        public class GetAllCitiesQueryHandler : BaseMediator, IRequestHandler<GetAllCitiesQuery, ICollection<HomeCityViewModel>>
        {
            public GetAllCitiesQueryHandler(EFDbContext context) : base(context)
            {
            }



            public async Task<ICollection<HomeCityViewModel>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
            {
                var cities = _context.Cities.Select(x => new HomeCityViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                return cities;
            }
        }

    }
}
