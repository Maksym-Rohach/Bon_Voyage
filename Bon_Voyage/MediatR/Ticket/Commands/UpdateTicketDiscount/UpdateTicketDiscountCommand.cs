using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Ticket.Queries.GetHotDealTicketsQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Commands.UpdateTicketDiscount
{
    public class UpdateTicketDiscountCommand : IRequest<ICollection<HotDealTicketsViewModel>>
    {
        public string Id { get; set; }
        public int NewDiscount { get; set; }

        public class UpdateTicketDiscountCommandHandler : BaseMediator, IRequestHandler<UpdateTicketDiscountCommand, ICollection<HotDealTicketsViewModel>>
        {

            public UpdateTicketDiscountCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<HotDealTicketsViewModel>> Handle(UpdateTicketDiscountCommand request, CancellationToken cancellationToken)
            {
                var ticket = _context.Tickets.FirstOrDefault(x => x.Id == request.Id);
                if (ticket != null)
                {
                    ticket.Discount = request.NewDiscount;
                    _context.Update(ticket);
                    _context.SaveChanges();
                }
                var res = await _context
                    .Tickets
                    //.Where(x => ((x.DateFrom-DateTime.Now).TotalDays<=10))
                    .Select(x => new HotDealTicketsViewModel
                    {
                        Id = x.Id,
                        Price = x.PriceFrom,
                        Discount = x.Discount,
                        DateTo = x.DateTo.ToString("dd.MM.yyyy"),
                        DateFrom = x.DateFrom.ToString("dd.MM.yyyy"),
                        CountOfPlaces = x.CountsOfPlaces,
                        Country = new CountryViewModel
                        {
                            Id = x.Hotel.City.CountryId,
                            Name = x.Hotel.City.Country.Name
                        }
                    }).ToListAsync();
                return res;


            }
        }
    }
}
