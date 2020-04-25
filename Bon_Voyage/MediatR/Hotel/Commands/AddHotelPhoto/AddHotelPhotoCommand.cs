using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Commands.AddHotelPhoto
{
    public class AddHotelPhotoCommand : IRequest<string>
    {
        public string HotelId { get; set; }
        public List<string> PhotosBase64 { get; set; }

        public class AddHotelPhotoHandler : BaseMediator, IRequestHandler<AddHotelPhotoCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly IHostingEnvironment _env;

            public AddHotelPhotoHandler(EFDbContext context, IConfiguration configuration,
                IHostingEnvironment env) : base(context)
            {
                _configuration = configuration;
                _env = env;
            }

            public async Task<string> Handle(AddHotelPhotoCommand request, CancellationToken cancellationToken)
            {
                string res = string.Empty;
                var hotel = _context.Hotels.FirstOrDefault(x => x.Id == request.HotelId);

                if (hotel != null)
                {
                    var hotelPhotos = _context.PhotosToHotels.Where(x => x.HotelId == request.HotelId);
                    //string initNumber = hotelPhotos == null || hotelPhotos.Count() < 1 ? "1" : (hotelPhotos.Count() + 1).ToString();

                    for (int i = 0; i < request.PhotosBase64.Count; i++)
                    {
                        string imageName = Guid.NewGuid().ToString() + ".jpg";
                        string pathSaveImages = InitStaticFiles  // 2. Save photo
                            .CreateImageByFileName(_env, _configuration,
                            new string[] { "ImagesPath", "ImagesPathHotel" }, // 3. Send path
                            imageName, request.PhotosBase64[i]); // 4. Send imageName and photo


                        if (pathSaveImages != null) // 5. If photo is created
                        {
                            _context.PhotosToHotels.Add(new DB.Entities.PhotosToHotel
                            {
                                HotelId = request.HotelId,
                                PhotoLink = imageName,
                            });
                            _context.SaveChanges(); // 6. Add photo to user
                        }
                    }
                }
                return "";
            }
        }
    }
}
