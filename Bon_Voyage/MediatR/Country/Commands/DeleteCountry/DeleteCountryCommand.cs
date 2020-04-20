using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Country.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<ResponseViewModel>
    {
        public string Id { get; set; }

        public class DeleteCountryCommandHandler : BaseMediator, IRequestHandler<DeleteCountryCommand, ResponseViewModel>
        {
            public DeleteCountryCommandHandler(EFDbContext context) : base(context)
            {
            }
           
            public async Task<ResponseViewModel> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                if (_context.Country.FirstOrDefault(x => x.Id == request.Id) == null) return new ResponseViewModel
                {
                    Status = false,
                    ErrorMessage = "Країни не знайдено"
                };

                if(_context.Country.FirstOrDefault(x => x.Id == request.Id).Cities != null)
                {
                    if (_context.Country.FirstOrDefault(x => x.Id == request.Id).Cities.Count > 0) return new ResponseViewModel
                    {
                        Status = false,
                        ErrorMessage = "У країни є міста.Видаліть спочатку їх"
                    };

                }

                _context.Remove(_context.Country.FirstOrDefault(x => x.Id == request.Id));
                _context.SaveChanges();

                return new ResponseViewModel { Status = true };
            }
        }
    }
}
