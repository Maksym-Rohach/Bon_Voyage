using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Country.Commands.AddCountry
{
    public class AddCountryCommand : IRequest<ResponseViewModel>
    {
        public string Name { get; set; }

        public class AddCountryCommandHandler : BaseMediator, IRequestHandler<AddCountryCommand, ResponseViewModel>
        {
            public AddCountryCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ResponseViewModel> Handle(AddCountryCommand request, CancellationToken cancellationToken)
            {
                if (_context.Country.FirstOrDefault(x => x.Name == request.Name) != null) return new ResponseViewModel
                {
                    Status = false,
                    ErrorMessage = "Така країна вже існує"
                };

                if (request.Name == null
                 || request.Name == ""
                 || !Regex.IsMatch(request.Name, @"(?i)^[a-z]+")) return new ResponseViewModel
                 {
                     Status = false,
                     ErrorMessage = "Введіть коректну назву"
                 };

                _context.Add(new DB.Entities.Country { Name = request.Name });
                _context.SaveChanges();

                return new ResponseViewModel { Status = true };
            }
        }
    }
}
