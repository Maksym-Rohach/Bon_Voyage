using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Manager.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery
{
    public class GetAllManagersQuery : IRequest<ICollection<ManagerViewModel>>
    {
        public class GetAllManagersQueryHandler : IRequestHandler<GetAllManagersQuery, ICollection<ManagerViewModel>>
        {
            private readonly EFDbContext _context;

            public GetAllManagersQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<ICollection<ManagerViewModel>> Handle(GetAllManagersQuery request, CancellationToken cancellationToken)
            {
                var managers = _context.ManagerProfiles.Select(x => new ManagerViewModel
                {
                    Id = x.Id,
                    Name = x.BaseProfile.Name,
                    Email = x.BaseProfile.User.Email,
                    DateOfRegister = x.DateOfRegister.Date.ToString("dd.MM.yyyy"),
                    Photo = x.BaseProfile.Photo,
                    Surname = x.BaseProfile.Surname
                }).ToList();
                return managers;
            }
        }
    }
}
