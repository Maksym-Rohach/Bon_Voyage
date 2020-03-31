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
    public class UpdateHotelCommand : IRequest<bool>
    {
        public string id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public ICollection<string> Photolinks { get; set; }

        public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, bool>
        {
            private readonly EFDbContext _context;

            public UpdateHotelCommandHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
            {
                List<PhotosToHotel> photos=new List<PhotosToHotel>();

                foreach (var item in request.Photolinks)
                {
                    photos.Add(new PhotosToHotel
                    {
                        Hotel = _context.Hotels.FirstOrDefault(x => x.Id == request.id),
                        PhotoLink = item
                    });
                }

                DB.Entities.Hotel hotel = new DB.Entities.Hotel
                {
                    Id = request.id,
                    Name = request.Name,
                    Stars = request.Stars,
                    Description = request.Description,
                    City = request.City,
                    PhotosToHotels=photos
                };
                var res = _context.Hotels.Update(hotel).State;

                if (res == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
