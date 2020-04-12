using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.RoomType.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.RoomType.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesQuery : IRequest<ICollection<AddTicketRoomTypeViewModel>>
    {
        public class GetAllRoomTypesQueryHandler : BaseMediator,IRequestHandler<GetAllRoomTypesQuery, ICollection<AddTicketRoomTypeViewModel>>
        {
            public GetAllRoomTypesQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<AddTicketRoomTypeViewModel>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
            {
                var roomTypes = _context.RoomTypes
                     .Select(x => new AddTicketRoomTypeViewModel
                     {
                         Id = x.Id,
                         Name = x.Name
                     }).ToList();

                return roomTypes;
            }
        }
    }
}
