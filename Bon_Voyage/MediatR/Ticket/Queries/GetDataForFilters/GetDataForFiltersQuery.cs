using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Comfort.ViewModels;
using Bon_Voyage.MediatR.Country.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters.Views;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Queries.GetDataForFilters
{
    public class GetDataForFiltersQuery : IRequest<DataForFilterViewModel>
    {

        public class GetDataForFiltersQueryHandler : BaseMediator, IRequestHandler<GetDataForFiltersQuery, DataForFilterViewModel>
        {
            public GetDataForFiltersQueryHandler(EFDbContext context) : base(context)
            {

            }

            public async Task<DataForFilterViewModel> Handle(GetDataForFiltersQuery request, CancellationToken cancellationToken)
            {
                var comforts = _context.Comforts.Select(x => new Comfort.ViewModels.ComfortViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                var countries = _context.Country.Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                var roomType = _context.RoomTypes.Select(x => new RoomTypeViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                return new DataForFilterViewModel { Comforts = comforts, Countries = countries, RoomTypes = roomType };
            }
        } 
    }
}
