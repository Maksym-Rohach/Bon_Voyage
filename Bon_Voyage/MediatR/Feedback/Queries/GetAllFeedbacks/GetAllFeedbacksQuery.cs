using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Feedback.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Feedback.Queries.GetAllFeedbacks
{
    public class GetAllFeedbacksQuery : IRequest<ICollection<GetAllFeedbackViewModel>>
    {
        public class GetAllFeedbacksQueryHandler : BaseMediator, IRequestHandler<GetAllFeedbacksQuery, ICollection<GetAllFeedbackViewModel>>
        {
            public GetAllFeedbacksQueryHandler(EFDbContext context) : base(context)
            {
            }
            public async Task<ICollection<GetAllFeedbackViewModel>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
            {
                var feedbacks = _context.Feedbacks.Where(x=>x.IsAnwsered!=true).Select(x => new GetAllFeedbackViewModel
                {
                   Date = x.Data,
                   Description = x.Description,
                   Id = x.Id,
                   Theme = x.Theme,
                   UserEmail = _context.Users.FirstOrDefault(u => u.Id == x.UserId).Email
                }).ToList();

                return feedbacks;
            }
        }

    }
}
