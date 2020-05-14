using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetAllHotels
{
    public class GetAllHotels : IRequest<GetAllHotelsViewModel>
    {
        public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotels, GetAllHotelsViewModel>
        {
            private readonly EFDbContext _context;

            public GetAllHotelsQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<GetAllHotelsViewModel> Handle(GetAllHotels request, CancellationToken cancellationToken)
            {
                var hotels = await _context.Hotels.Select(x => new HotelViewModel
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
                }).ToListAsync();
                var countries = await _context.Country.Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                var res = new GetAllHotelsViewModel
                {
                    Hotels = hotels,
                    Countries = countries
                };
                return res;
            }
        }
    }
}
