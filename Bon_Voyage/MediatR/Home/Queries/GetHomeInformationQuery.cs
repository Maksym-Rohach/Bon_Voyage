using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.MediatR.Home.ViewModel;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Home.Queries
{
    public class GetHomeInformationQuery : IRequest<ICollection<HomeInfoViewModel>>
    {
        public class GetHomeInformationQueryHandler : BaseMediator, IRequestHandler<GetHomeInformationQuery, ICollection<HomeInfoViewModel>>
        {
            public GetHomeInformationQueryHandler(EFDbContext context) : base(context)
            {
            }

            public Task<ICollection<HomeInfoViewModel>> Handle(GetHomeInformationQuery request, CancellationToken cancellationToken)
            {
                int topHotelsCount = 3;

                throw new NotImplementedException();
            }
        }
    }
}
