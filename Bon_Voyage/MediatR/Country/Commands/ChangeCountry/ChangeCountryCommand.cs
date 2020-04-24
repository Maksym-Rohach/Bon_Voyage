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

namespace Bon_Voyage.MediatR.Country.Commands.ChangeCountry
{
    public class ChangeCountryCommand : IRequest<ResponseViewModel>
    {
        public string Id { get; set; }
        public string NewName { get; set; }

        public class ChangeCountryCommandHandler : BaseMediator, IRequestHandler<ChangeCountryCommand, ResponseViewModel>
        {
            public ChangeCountryCommandHandler(EFDbContext context) : base(context)
            {
            }          

            public async Task<ResponseViewModel> Handle(ChangeCountryCommand request, CancellationToken cancellationToken)
            {
                if (_context.Country.FirstOrDefault(x => x.Id == request.Id) == null) return new ResponseViewModel
                {
                    Status = false,
                    ErrorMessage = "Країна не знайдена"
                };

                if (_context.Country.FirstOrDefault(x => x.Name == request.NewName) != null) return new ResponseViewModel
                {
                    Status = false,
                    ErrorMessage = "Країна з такою назвою вже існує"
                };

                if (request.NewName == null
                || request.NewName == ""
                || !Regex.IsMatch(request.NewName, @"(?i)^[а-я]+")) return new ResponseViewModel
                {
                    Status = false,
                    ErrorMessage = "Введіть коректну назву"
                };


                _context.Country.FirstOrDefault(x => x.Id == request.Id).Name = request.NewName;
                _context.SaveChanges();

                return new ResponseViewModel { Status = true };
            }
        }
    }
}
