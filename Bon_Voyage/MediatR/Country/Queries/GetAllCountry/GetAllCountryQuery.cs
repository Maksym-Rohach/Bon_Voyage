using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Country.Queries.GetAllCountry
{
    public class GetAllCountryQuery : IRequest<ICollection<CountryViewModel>>
    {
        public class GetAllCountryQueryHandler :BaseMediator, IRequestHandler<GetAllCountryQuery, ICollection<CountryViewModel>>
        {
            public GetAllCountryQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<CountryViewModel>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                var countries = _context.Country.Select(x=> new CountryViewModel {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                return countries;
            }
        }

    }
}
