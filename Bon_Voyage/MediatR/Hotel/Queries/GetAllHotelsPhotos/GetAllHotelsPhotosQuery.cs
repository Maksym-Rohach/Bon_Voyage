using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Hotel.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Queries.GetAllHotelsPhotos
{
    public class GetAllHotelsPhotosQuery : IRequest<ICollection<AllHotelPhotosViewModel>>
    {
        public class GetAllHotelsPhotosQueryHandler : BaseMediator,IRequestHandler<GetAllHotelsPhotosQuery, ICollection<AllHotelPhotosViewModel>>
        {
            public GetAllHotelsPhotosQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<AllHotelPhotosViewModel>> Handle(GetAllHotelsPhotosQuery request, CancellationToken cancellationToken)
            {
                var photos = _context.PhotosToHotels
                    .Take(49)
                    .Select(x => new AllHotelPhotosViewModel
                {
                    Id = x.Hotel.Id,
                    Photo = "1280_" + x.PhotoLink
                }).ToList();
                PhotosForGalleryViewModel PhotosForGallery = new PhotosForGalleryViewModel();
                PhotosForGallery.HotelPhotos = photos;
                return photos;
            }
        }
    }
}
