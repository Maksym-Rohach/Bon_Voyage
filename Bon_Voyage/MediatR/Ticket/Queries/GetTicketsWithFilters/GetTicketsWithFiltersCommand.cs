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
    public class GetTicketsWithFiltersCommand : IRequest<ICollection<TicketsViewModel>>
    {
        public int StartIndex { get; set; }
        public TicketFilters Filters { get; set; }

        public class GetTicketsWithFiltersCommandHandler : BaseMediator, IRequestHandler<GetTicketsWithFiltersCommand, ICollection<TicketsViewModel>>
        {
            public GetTicketsWithFiltersCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<TicketsViewModel>> Handle(GetTicketsWithFiltersCommand request, CancellationToken cancellationToken)
            {
                int take = 20;
                var query = _context.Tickets
                    .OrderBy(x => x.Id)
                    .Include(x => x.Hotel)
                    .AsQueryable();
                if (request.Filters != null)
                {
                    int count = _context.Tickets.Count();
                    int skip = request.StartIndex * take;
                    int indx = request.StartIndex + skip;
                    return await Filter(query, request.Filters)
                        .Skip(skip)
                        .Take(take)
                        .Select(x => new TicketsViewModel
                        {
                            Id = x.Id,
                            Count = count,
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
                                Photo = x.Hotel.PhotosToHotels.First().PhotoLink
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
                            }).ToList(),
                            Index=indx
                        })
                        .ToListAsync();
                }
                else
                {                    
                    int count = _context.Tickets.Count();
                    int skip = request.StartIndex * take;
                    int indx = request.StartIndex + skip;
                    return await query
                        .Skip(skip)
                        .Take(take)
                        .Select(x => new TicketsViewModel
                        {
                            Id = x.Id,
                            Count = count,
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
                                Photo = x.Hotel.PhotosToHotels.First().PhotoLink
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
                            }).ToList(),
                            Index = indx
                        }).ToListAsync();
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
                if (filters.CityId != "" && filters.CityId != null)
                {
                    query = query.Where(x => x.Hotel.CityId == filters.CityId);
                }
                if (filters.HotelId != "" && filters.HotelId != null)
                {
                    query = query.Where(x => x.HotelId == filters.HotelId);
                }
                if (filters.RoomTypeId != "" && filters.RoomTypeId != null)
                {
                    query = query.Where(x => x.RoomTypeId == filters.RoomTypeId);
                }
                if (filters.ComfortIds != null && filters.ComfortIds.Count() > 0)
                {
                    query = query.Where(x => x.TicketToComforts.Any(y => filters.ComfortIds.Contains(y.ComfortId)));
                }
                return query;
            }
        }
    }
}
