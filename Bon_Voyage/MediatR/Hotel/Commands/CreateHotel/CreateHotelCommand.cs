using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public City City { get; set; }

        public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, bool>
        {
            private readonly EFDbContext _context;

            public CreateHotelCommandHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
            {
                DB.Entities.Hotel hotel = new DB.Entities.Hotel
                {
                    Name = request.Name,
                    City = request.City,
                    Description = request.Description,
                    Stars = request.Stars
                };
                var res = _context.Hotels.AddAsync(hotel).IsCompletedSuccessfully;
                return res;
            }
        }
    }
}
