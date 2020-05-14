using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCountry
{
    public class GetHotelsByCountryQuery : IRequest<ICollection<HotelShortViewModel>>
    {
        public string CountryId { get; set; }

        public class GetHotelsByCountryQueryHandler : BaseMediator, IRequestHandler<GetHotelsByCountryQuery, ICollection<HotelShortViewModel>>
        {
            public GetHotelsByCountryQueryHandler(EFDbContext context) : base(context)
            {

            }

            public async Task<ICollection<HotelShortViewModel>> Handle(GetHotelsByCountryQuery request, CancellationToken cancellationToken)
            {
                return _context.Hotels
                    .Where(x => x.City.CountryId == request.CountryId)
                    .Select(x => new HotelShortViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
            }
        }

    }
}
