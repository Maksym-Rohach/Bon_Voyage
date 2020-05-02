using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Home.ViewModel;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using Bon_Voyage.MediatR.Ticket.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.Queries
{
    public class GetHomeInformationQuery : IRequest<HomeInfoViewModel>
    {
        public class GetHomeInformationQueryHandler : BaseMediator, IRequestHandler<GetHomeInformationQuery, HomeInfoViewModel>
        {
            public GetHomeInformationQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<HomeInfoViewModel> Handle(GetHomeInformationQuery request, CancellationToken cancellationToken)
            {
                int HotelsPhotoCount = 3;

                var result = new HomeInfoViewModel();
                result.Random3Photos = new List<string>();
                result.HotTickets = new List<HomeTicketViewModel>();
                result.TopHotels = new List<HomeHotelViewModel>();

                var currentData = DateTime.Now;

                result.Countries = _context.Country.Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                //result.Random3Photos.AddRange(_context.PhotosToHotels
                //    .Take(HotelsPhotoCount)
                //    .Where(x => x.Id == new Random().Next(0, _context.PhotosToHotels.Count() - 1).ToString())
                //    .Select(x => x.id));

                for (int i = 0; i < HotelsPhotoCount; i++)
                {
                    result.Random3Photos.Add("250_" + _context
                        .PhotosToHotels
                        .ToList()
                        [new Random().Next(0, _context.PhotosToHotels.Count() - 1)]
                        .PhotoLink);
                }

                //----------------FOR TEST-----------------
                //_context.Hotels.ToList().ForEach(x => 
                //{
                //    if (_context.PhotosToHotels.FirstOrDefault(y => y.HotelId == x.Id) == null)
                //    {
                //        var res = x;
                //    }
                //});

               
                result.TopHotels.AddRange(
                    _context.Hotels.OrderBy(x => x.Stars).Take(3).Select(x => new HomeHotelViewModel
                    {
                        Id = x.Id,
                        Stars = x.Stars,
                        Name = x.Name,
                        Description = x.Description,
                        Photo = "1280_" + _context.PhotosToHotels.FirstOrDefault(y => y.HotelId == x.Id).PhotoLink
                    })
                    );

                result.HotTickets.AddRange(
                    _context.Tickets
                    .Where(x => x.Discount != 0)
                    .OrderBy(x => x.Hotel.Stars)
                    .Take(3)
                    .Select(x => new HomeTicketViewModel
                    {
                        Id = x.Id,
                        Photo = "1280_" + _context.PhotosToHotels.FirstOrDefault(y => y.HotelId == x.HotelId).PhotoLink,
                        Price = x.PriceFrom,
                        HotelName = x.Hotel.Name,
                        Description = "asdasd",
                    })
                    );

                return result;
            }
        }
    }
}
