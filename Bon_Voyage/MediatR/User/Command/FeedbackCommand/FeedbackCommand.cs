using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.DB.Entities;

namespace Bon_Voyage.MediatR.User.Command.FeedbackCommand
{
    public class FeedbackCommand : IRequest<FeedbackViewModel>
    {
        public string Id { get; set; }
        public string Theme { get; set; }
        public string Message { get; set; }
        public DateTime Data { get; set; }

        public class FeedbackCommandHandler : BaseMediator, IRequestHandler<FeedbackCommand, FeedbackViewModel>
        {
            private readonly IJwtTokenService _IJwtTokenService;
            private readonly UserManager<DbUser> _userManager;

            public FeedbackCommandHandler(EFDbContext context, IJwtTokenService jwtToken, UserManager<DbUser> userManager) : base(context)
            {
                _IJwtTokenService = jwtToken;
                _userManager = userManager;
            }
            async Task<FeedbackViewModel> IRequestHandler<FeedbackCommand, FeedbackViewModel>.Handle(FeedbackCommand request, CancellationToken cancellationToken)
            {
                var user = _context.BaseProfiles.FirstOrDefault(x => x.Id == request.Id);
                if (user != null)
                {
                    var usetable = new Feedback();
                    if (request.Theme != "")
                    {
                        usetable.Theme = request.Theme;
                    }
                    if (request.Message != "")
                    {
                        usetable.Description = request.Message;
                    }

                    usetable.Data = DateTime.Now.ToString("dd.MM.yyyy");
                    usetable.UserId = user.Id;

                    _context.Add(usetable);
                    _context.SaveChanges();

                    return new FeedbackViewModel { Status = true };
                }
                return new FeedbackViewModel { Status = false, ErrorMessage = "Щось пішло не так" };
            }
        }
    }
}


