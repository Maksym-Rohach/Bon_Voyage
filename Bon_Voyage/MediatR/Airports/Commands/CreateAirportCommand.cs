using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Airports.Commands
{
    public class CreateAirportCommand : IRequest<CreateAirportViewModel>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CityId { get; set; }

        public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, CreateAirportViewModel>        
        {
            private readonly EFDbContext _context;

            public CreateAirportCommandHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<CreateAirportViewModel> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
            {
                var city = _context.Cities.FirstOrDefault(x => x.Id == request.CityId);
                if (city != null)
                {
                    var airports = _context.Airports;
                    if (airports.FirstOrDefault(x => x.Name == request.Name) == null || airports.FirstOrDefault(x => x.ShortName == request.ShortName) == null)
                    {
                        try
                        {
                            var airport = new Airport
                            {
                                Name = request.Name,
                                ShortName = request.ShortName,
                                CityId = city.Id
                            };
                            _context.Airports.Add(airport);
                            _context.SaveChanges();
                            return new CreateAirportViewModel { Status = true };
                        }
                        catch(Exception e)
                        {
                            return new CreateAirportViewModel { Status = false, ErrorMessage = e.Message };
                        }
                    }
                    else
                    {
                        return new CreateAirportViewModel { Status = false, ErrorMessage = "Такий аеропорт вже існує" };
                    }
                }
                return new CreateAirportViewModel { Status = false, ErrorMessage = "Місто не знайдено" };
                
            }
        }
    }
}
