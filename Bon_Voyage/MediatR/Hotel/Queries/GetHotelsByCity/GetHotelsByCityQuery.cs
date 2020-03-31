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
    public class GetHotelsByCityQuery : IRequest<ICollection<HotelViewModel>>
    {
        public string CityId { get; set; }


        public class GetHotelsByCityQueryHandler : BaseMediator, IRequestHandler<GetHotelsByCityQuery, ICollection<HotelViewModel>>
        {
            public GetHotelsByCityQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<HotelViewModel>> Handle(GetHotelsByCityQuery request, CancellationToken cancellationToken)
            {
                var hotels = _context.Hotels.Where(x => x.CityId == request.CityId).Select(x => new HotelViewModel
                {
                    City = x.City.Name,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Stars = x.Stars
                }).ToList();

                return hotels;
            }
        }
    }
}
