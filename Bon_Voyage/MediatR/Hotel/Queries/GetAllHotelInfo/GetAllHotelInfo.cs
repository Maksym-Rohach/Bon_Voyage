using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetAllHotelInfo
{
    public class GetAllHotelInfo : IRequest<HotelInfoViewModel>

    {
        public string HotelId { get; set; }
        public class GetAllHotelsInfoQueryHandler : BaseMediator, IRequestHandler<GetAllHotelInfo,HotelInfoViewModel>
        {
            public GetAllHotelsInfoQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<HotelInfoViewModel> Handle(GetAllHotelInfo request, CancellationToken cancellationToken)
            {
                HotelInfoViewModel returnHotel=new HotelInfoViewModel();
                returnHotel.HotelPhotos = new List<string>();

                var hotel = _context.Hotels.Include(x => x.City).
                    Include(x=>x.City.Country).
                    Include(x=>x.PhotosToHotels).
                    FirstOrDefault(x => x.Id == request.HotelId);

                if(hotel == null)
                {
                    return null;
                }

                returnHotel.Id = hotel.Id;
                returnHotel.Description = hotel.Description;
                returnHotel.Name = hotel.Name;
                returnHotel.Stars = hotel.Stars;
                returnHotel.MainPhoto = "1280_" + hotel.PhotosToHotels.ToList()[0].PhotoLink;
                returnHotel.Country = hotel.City.Country.Name;
                returnHotel.City = hotel.City.Name;
                returnHotel.CountryPhoto = "1280_" + _context.Hotels.
                       FirstOrDefault(c => c.City.Country.Id == hotel.City.Country.Id).
                       PhotosToHotels.ToList()[0].
                       PhotoLink;
                returnHotel.HotelPhotos = hotel.PhotosToHotels.Take(5).Select(x => x.PhotoLink).ToList();
            

                return returnHotel;
            }
            
        
        }
        
    }
}
