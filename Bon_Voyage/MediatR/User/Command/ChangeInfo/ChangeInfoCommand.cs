using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Command.ChangeInfo
{
    public class ChangeInfoCommand: IRequest<ChangeInfoViewModel>
    {
        public string Id { get; set; }
        public string NewName { get; set; }
        public string NewSurName { get; set; }
        public string NewEmail { get; set; }
        public string NewPhoneNumber { get; set; }

        public class ChangeInfoCommandHandler : BaseMediator, IRequestHandler<ChangeInfoCommand, ChangeInfoViewModel>
        {
            private readonly UserManager<DbUser> _userManager;
            private readonly IJwtTokenService _IJwtTokenService;

            public ChangeInfoCommandHandler(EFDbContext context, UserManager<DbUser> userManager, IJwtTokenService jwtToken) : base(context)
            {
                _userManager = userManager;
                _IJwtTokenService = jwtToken;
            }

            public async Task<ChangeInfoViewModel> Handle(ChangeInfoCommand request, CancellationToken cancellationToken)
            {

                var user = _context.BaseProfiles.FirstOrDefault(x => x.Id == request.Id);
                if (user != null)
                {
                    var use = _context.Users.FirstOrDefault(x => x.Id == request.Id);
                    if (request.NewPhoneNumber != "")
                    {
                        var result = await _userManager.ChangePhoneNumberAsync(use, request.NewPhoneNumber, _IJwtTokenService.CreateToken(use));
                    }
                    if (request.NewEmail != "")
                    {
                        var testmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        if (testmail.IsMatch(request.NewEmail))
                        {
                            var result = await _userManager.ChangeEmailAsync(use, request.NewEmail, _IJwtTokenService.CreateToken(use));
                        }
                        else
                        {
                            return new ChangeInfoViewModel { Status = false, ErrorMessage = "Перевірте правильністьвведення пошти" };
                        }
                    }
                    if (request.NewName != "" || request.NewSurName != "")
                    {
                        user.Name=request.NewName;
                        user.Surname = request.NewSurName;
                    }
                    
                    _context.Update(user);
                    _context.SaveChanges();
                    return new ChangeInfoViewModel { Status = true };

                }
                return new ChangeInfoViewModel { Status = false, ErrorMessage = "Щось пішло не так" };
            }
        }
    }
}
