using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Command.NewPasswordCommand
{
    public class NewPasswordCommand : IRequest<NewPasswordViewModel>
    {
        public string Id { get; set; }
        public string NewPassword { get; set; }

        public class NewPasswordCommandHandler : BaseMediator, IRequestHandler<NewPasswordCommand, NewPasswordViewModel>
        {
            private readonly UserManager<DbUser> _userManager;            

            public NewPasswordCommandHandler(EFDbContext context, UserManager<DbUser> userManager) : base(context)
            {
                _userManager = userManager;
              
            }

            public async Task<NewPasswordViewModel> Handle(NewPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);
                if (user != null)
                {
                    var hash_password = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
                    user.PasswordHash = hash_password;
                    var result = await _userManager.UpdateAsync(user);

                    return new NewPasswordViewModel{Status = true};
                }
                else
                {
                    return new NewPasswordViewModel { Status = false, ErrorMessage = "Щось пішло не так" };
                }
            }
        }
    }
}
