using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Cities.Commands.AddCity
{
    public class AddCityCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string CountryId { get; set; }

        public class AddCityCommandHandler : BaseMediator,IRequestHandler<AddCityCommand, bool>//class with logic when we execute it
        {
            public AddCityCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<bool> Handle(AddCityCommand request, CancellationToken cancellationToken)
            {
                var compare = _context.Cities.FirstOrDefault(x => x.Name == request.Name);
                if(compare != null)
                {
                    return false;
                }

                var id = _context.Country.FirstOrDefault(x => x.Id == request.CountryId);
                if(id == null)
                {
                    return false;
                }

                _context.Cities.Add(new City {
                    Name = request.Name,
                    CountryId = request.CountryId
                });
                _context.SaveChanges();

                return true;
            }
        }
    }
}
