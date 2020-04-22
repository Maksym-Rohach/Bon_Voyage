using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Country.Queries.GetAllCountryWithCityCount
{
    public class GetAllCountryWithCityCountQuery : IRequest<ICollection<CountryControlViewModel>>
    {
        public class GetAllCountryWithCityCountQueryHandler : BaseMediator, IRequestHandler<GetAllCountryWithCityCountQuery, ICollection<CountryControlViewModel>>
        {
            public GetAllCountryWithCityCountQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<CountryControlViewModel>> Handle(GetAllCountryWithCityCountQuery request, CancellationToken cancellationToken)
            {
                var res = _context.Country.Select(x => new CountryControlViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityCount = x.Cities.Count
                }).ToList();

                return res;
            }
        }

    }
}
