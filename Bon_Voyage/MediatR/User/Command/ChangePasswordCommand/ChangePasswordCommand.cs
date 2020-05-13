using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Change
{
    public class ChangePasswordCommand : IRequest<ChangePasswordViewModel>
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommandHandler : BaseMediator, IRequestHandler<ChangePasswordCommand, ChangePasswordViewModel>
        {
            private readonly UserManager<DbUser> _userManager;

            public ChangePasswordCommandHandler(EFDbContext context, UserManager<DbUser> userManager): base(context)
            {
                _userManager = userManager;
            }

            public async Task<ChangePasswordViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
                    if (result.Succeeded)
                    {
                        return new ChangePasswordViewModel { Status = true };
                    }
                    else
                    {
                        return new ChangePasswordViewModel { Status = false, ErrorMessage="Перевірте правильність введення данних"};
                    }
                }
                return new ChangePasswordViewModel { Status = false, ErrorMessage="заплати 20$ !!! :)" };
            }

        }
    }
}
