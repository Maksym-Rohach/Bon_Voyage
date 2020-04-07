using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Commands.UpdateHotel
{
    public class UpdateHotelCommand : IRequest<UpdateHotelViewModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string CityId { get; set; }
        //public ICollection<string> Photolinks { get; set; }

        public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, UpdateHotelViewModel>
        {
            private readonly EFDbContext _context;

            public UpdateHotelCommandHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<UpdateHotelViewModel> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
            {
                //List<PhotosToHotel> photos=new List<PhotosToHotel>();

                //foreach (var item in request.Photolinks)
                //{
                //    photos.Add(new PhotosToHotel
                //    {
                //        Hotel = _context.Hotels.FirstOrDefault(x => x.Id == request.id),
                //        PhotoLink = item
                //    });
                //}

                var city = _context.Cities.FirstOrDefault(x => x.Id == request.CityId);
                if (city != null)
                {
                    try
                    {
                        DB.Entities.Hotel hotel = new DB.Entities.Hotel
                        {
                            Id = request.Id,
                            Name = request.Name,
                            Stars = request.Stars,
                            Description = request.Description,
                            City = city,
                            //PhotosToHotels=photos
                        };
                        _context.Hotels.Update(hotel);
                        await _context.SaveChangesAsync();
                        return new UpdateHotelViewModel { Status = true };
                    }
                    catch (Exception e)
                    {
                        return new UpdateHotelViewModel { Status = false, ErrorMessage = e.Message };
                    }
                }
                return new UpdateHotelViewModel { Status = false, ErrorMessage = "Місто не знайдено" };
            }
        }
    }
}
