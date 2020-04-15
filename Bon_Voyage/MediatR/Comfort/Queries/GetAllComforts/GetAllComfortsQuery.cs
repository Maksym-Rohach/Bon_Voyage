using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Comfort.ViewModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Comfort.Queries.GetAllComforts
{
    public class GetAllComfortsQuery : IRequest<ICollection<ComfortViewModel>>
    {
        public class GetAllComfortsQueryHandler : BaseMediator, IRequestHandler<GetAllComfortsQuery, ICollection<ComfortViewModel>>
        {
            public GetAllComfortsQueryHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<ICollection<ComfortViewModel>> Handle(GetAllComfortsQuery request, CancellationToken cancellationToken)
            {
                var comforts = _context.Comforts.Select(x => new ComfortViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                return comforts;
            }
        }
    }
}
