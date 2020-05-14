using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters.Views;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters
{
    public class GetTicketsWithFiltersCommand : IRequest<FiltredTicketsViewModel>
    {
        public int StartIndex { get; set; }
        public TicketFilters Filters { get; set; }

        public class GetTicketsWithFiltersCommandHandler : BaseMediator, IRequestHandler<GetTicketsWithFiltersCommand, FiltredTicketsViewModel>
        {
            public GetTicketsWithFiltersCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<FiltredTicketsViewModel> Handle(GetTicketsWithFiltersCommand request, CancellationToken cancellationToken)
            {
                int take = 20;
                var query = _context.Tickets
                    .OrderBy(x => x.Id)
                    .Where(x=>!x.IsBought&&x.Cart==null)
                    .Include(x => x.Hotel)
                    .AsQueryable();
                if (request.Filters != null)
                {
                    
                    int skip = request.StartIndex * take;
                    int indx = request.StartIndex + skip;
                    query = Filter(query, request.Filters);
                    var res = await query
                        .Skip(skip)
                        .Take(take)
                        .Select(x => new TicketViewModel
                        {
                            Id = x.Id,
                            CountsOfNight = x.CountsOfNight,
                            CountsOfPlaces = x.CountsOfPlaces,
                            DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                            DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                            PriceFrom = x.PriceFrom,
                            Discount = x.Discount,
                            Hotel = new HotelView
                            {
                                Id = x.HotelId,
                                Name = x.Hotel.Name,
                                Stars = x.Hotel.Stars,
                                Photo = "50_" + x.Hotel.PhotosToHotels.First().PhotoLink
                            },
                            RoomType = new RoomTypeViewModel
                            {
                                Id = x.RoomTypeId,
                                Name = x.RoomType.Name
                            },
                            City = new CityViewModel
                            {
                                Id = x.Hotel.CityId,
                                Name = x.Hotel.City.Name
                            },
                            Comforts = x.TicketToComforts.Select(y => new ComfortViewModel
                            {
                                Id = y.ComfortId,
                                Name = y.Comfort.Name
                            }).ToList()
                        })
                        .ToListAsync();
                    return (new FiltredTicketsViewModel
                    {
                        Count = query.Count(),
                        Index = indx,
                        Tickets=res
                    });
                }
                else
                {
                    int skip = request.StartIndex * take;
                    int indx = request.StartIndex + skip;
                    var res= await query
                        .Skip(skip)
                        .Take(take)
                        .Select(x => new TicketViewModel
                        {
                            Id = x.Id,
                            CountsOfNight = x.CountsOfNight,
                            CountsOfPlaces = x.CountsOfPlaces,
                            DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                            DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                            PriceFrom = x.PriceFrom,
                            Discount = x.Discount,
                            Hotel = new HotelView
                            {
                                Id = x.HotelId,
                                Name = x.Hotel.Name,
                                Stars = x.Hotel.Stars,
                                Photo = "1280_" + x.Hotel.PhotosToHotels.First().PhotoLink
                            },
                            RoomType = new RoomTypeViewModel
                            {
                                Id = x.RoomTypeId,
                                Name = x.RoomType.Name
                            },
                            City = new CityViewModel
                            {
                                Id = x.Hotel.CityId,
                                Name = x.Hotel.City.Name
                            },
                            Comforts = x.TicketToComforts.Select(y => new ComfortViewModel
                            {
                                Id = y.ComfortId,
                                Name = y.Comfort.Name
                            }).ToList()
                        }).ToListAsync();
                    return (new FiltredTicketsViewModel
                    {
                        Count = query.Count(),
                        Index = indx,
                        Tickets = res
                    });
                }
            }

            public IQueryable<DB.Entities.Ticket> Filter(IQueryable<DB.Entities.Ticket> query, TicketFilters filters)
            {
                if (filters.MaxPrice != null && filters.MaxPrice > 0)
                {
                    query = query.Where(x => x.PriceFrom < filters.MaxPrice);
                }
                if ((filters.DateFrom != null && filters.DateTo != null) && (filters.DateFrom != "" && filters.DateTo != ""))
                {
                    DateTime dateFrom, dateTo;
                    dateFrom = DateTime.Parse(filters.DateFrom);
                    dateTo = DateTime.Parse(filters.DateTo);
                    query = query.Where(x => x.DateFrom >= dateFrom && x.DateTo <= x.DateTo);
                }
                if (filters.CountOfNights != null && filters.CountOfNights > 0)
                {
                    query = query.Where(x => x.CountsOfNight == filters.CountOfNights);
                }
                if (filters.CountOfPlaces != null && filters.CountOfPlaces > 0)
                {
                    query = query.Where(x => x.CountsOfPlaces == filters.CountOfPlaces);
                }
                if (filters.HotelStars != null && filters.HotelStars > 0)
                {
                    query = query.Where(x => x.Hotel.Stars >= filters.HotelStars);
                }
                if (filters.WithDiscount)
                {
                    query = query.Where(x => x.Discount != null && x.Discount > 0);
                }
                if (filters.CountryId != "" && filters.CountryId != null)
                {
                    query = query.Where(x => x.Hotel.City.CountryId == filters.CountryId);
                }
                if (filters.HotelId != "" && filters.HotelId != null)
                {
                    query = query.Where(x => x.HotelId == filters.HotelId);
                }
                if (filters.RoomTypeId != "" && filters.RoomTypeId != null)
                {
                    query = query.Where(x => x.RoomTypeId == filters.RoomTypeId);
                }
                if (filters.ComfortId != null && filters.ComfortId != "")
                {
                    query = query.Where(x => x.TicketToComforts.Any(y => y.ComfortId==filters.ComfortId));
                }
                return query;
            }
        }
    }
}
