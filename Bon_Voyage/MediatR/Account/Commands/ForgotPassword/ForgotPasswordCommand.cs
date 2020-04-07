using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Account.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<ForgotPasswordViewModel>
    {
        public string Email { get; set; }

        public class ForgotPasswordCommandHandler : BaseMediator, IRequestHandler<ForgotPasswordCommand, ForgotPasswordViewModel>
        {
            public ForgotPasswordCommandHandler(EFDbContext context) : base(context)
            {

            }
            public async Task<ForgotPasswordViewModel> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (user == null)
                {
                    return new ForgotPasswordViewModel { Status = false, ErrorMessage = "Цей Емейл вже існує" };
                }

                var userName = user.Email;

                EmailService emailService = new EmailService();
                string url = "http://localhost:57206/Account/ChangePassword/" + user.Id;

                await emailService.SendEmailAsync(request.Email, "ForgotPassword",
                    $" Dear {userName}," +
                    $" <br/>" +
                    $" To change your password" +
                    $" <br/>" +
                    $" Зміна паролю <a href='{url}'>press</a>");
                return new ForgotPasswordViewModel { Status = true };
            }
        }
    }
}
