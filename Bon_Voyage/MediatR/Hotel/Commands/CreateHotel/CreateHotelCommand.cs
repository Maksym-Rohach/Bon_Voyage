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
    public class CreateHotelCommand : IRequest<CreateHotelViewModel>
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string CityId { get; set; }

        public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, CreateHotelViewModel>
        {
            private readonly EFDbContext _context;

            public CreateHotelCommandHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<CreateHotelViewModel> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
            {
                
                    try
                    {
                        DB.Entities.Hotel hotel = new DB.Entities.Hotel
                        {
                            Name = request.Name,
                            CityId = request.CityId,
                            Description = request.Description,
                            Stars = request.Stars
                        };
                        await _context.Hotels.AddAsync(hotel);
                        _context.SaveChanges();
                        return new CreateHotelViewModel { Status = true };
                    }
                    catch (Exception e)
                    {
                        return new CreateHotelViewModel { Status = false, ErrorMessage = e.Message };
                    }
                
            }
        }
    }
}
