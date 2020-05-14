using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Feedback.Commands.AnswerFeedBackCommand
{
    public partial class AnswerFeedBackCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }

        public class AnswerFeedBackComandHandler : BaseMediator, IRequestHandler<AnswerFeedBackCommand, bool>
        {
            public AnswerFeedBackComandHandler(EFDbContext context):base(context)
            {
                    
            }
            public async Task<bool> Handle(AnswerFeedBackCommand request, CancellationToken cancellationToken)
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(request.UserEmail, request.Message, "Відповідь на ваше звернення");
                _context.Feedbacks.FirstOrDefault(x => x.Id == request.Id).IsAnwsered = true;
                _context.SaveChanges();
                return true;
            }
        }
    }    
}
