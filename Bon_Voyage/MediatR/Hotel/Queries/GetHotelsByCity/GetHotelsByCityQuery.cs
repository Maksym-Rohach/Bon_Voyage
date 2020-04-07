using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCity
{
    public class GetHotelsByCityQuery : IRequest<ICollection<HomeHotelViewModel>>
    {
        public string CityId { get; set; }


        public class GetHotelsByCityQueryHandler : BaseMediator, IRequestHandler<GetHotelsByCityQuery, ICollection<HomeHotelViewModel>>
        {
            public GetHotelsByCityQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<HomeHotelViewModel>> Handle(GetHotelsByCityQuery request, CancellationToken cancellationToken)
            {
                var hotels = _context.Hotels.Where(x => x.CityId == request.CityId).Select(x => new HomeHotelViewModel
                {
                    CityId = x.City.Id,                
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

                return hotels;
            }
        }
    }
}
