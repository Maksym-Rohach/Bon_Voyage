using Bon_Voyage.DB;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Commands.DeleteHotel
{
    //public class DeleteHotelCommand : IRequest<bool>
    //{
    //    public string Id { get; set; }

    //    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, bool>
    //    {
    //        private readonly EFDbContext _context;

    //        public DeleteHotelCommandHandler(EFDbContext context)
    //        {
    //            _context = context;
    //        }

    //        public async Task<bool> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    //        {
    //            var res = _context.Hotels.Remove(_context.Hotels.FirstOrDefault(x => x.Id == request.Id)).State;

    //            if (res == Microsoft.EntityFrameworkCore.EntityState.Deleted)
    //                return true;
    //            else
    //                return false;
    //        }
    //    }
    //}
}
