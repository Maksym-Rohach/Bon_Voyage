using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetAllHotels
{
    public class GetAllHotels : IRequest<ICollection<HotelViewModel>>
    {
        public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotels, ICollection<HotelViewModel>>
        {
            private readonly EFDbContext _context;

            public GetAllHotelsQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<ICollection<HotelViewModel>> Handle(GetAllHotels request, CancellationToken cancellationToken)
            {
                var hotels = _context.Hotels.Select(x => new HotelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stars=x.Stars,
                    IsClosed=x.IsClosed?"Не працює":"Працює",
                    City=new CityViewModel
                    {
                        Id=x.City.Id,
                        Name=x.City.Name
                    }
                }).ToList();
                return hotels;
            }
        }
    }
}
