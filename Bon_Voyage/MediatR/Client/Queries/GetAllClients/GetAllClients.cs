using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Client.Queries.GetAllClients
{
    public class GetAllClients : IRequest<ICollection<ClientViewModel>>
    {
        public class GetAllClientsQueryHandler : IRequestHandler<GetAllClients, ICollection<ClientViewModel>>
        {
            private readonly EFDbContext _context;

            public GetAllClientsQueryHandler(EFDbContext context)
            {
                _context = context;
            }

            public async Task<ICollection<ClientViewModel>> Handle(GetAllClients request, CancellationToken cancellationToken)
            {
                var clients = _context.ClientProfiles.Select(x => new ClientViewModel
                {
                    Id = x.Id,
                    Name = x.BaseProfile.Name,
                    Surname = x.BaseProfile.Surname,
                    DateOfBirth = x.DateOfBirth.ToString("dd.MM.yyyy")
                }).ToList();
                return clients;
            }
        }
    }
}
