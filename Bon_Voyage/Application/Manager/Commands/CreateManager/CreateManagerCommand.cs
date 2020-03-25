using Bon_Voyage.Application.Manager.ViewModel;
using Bon_Voyage.DB;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.Application.Manager.Commands.CreateManager
{
    public class CreateManagerCommand : IRequest<ManagerViewModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ManagerViewModel>
        {
            private readonly EFDbContext _context;
            public CreateManagerCommandHandler(EFDbContext context)
            {
                context = _context;
            }

            public Task<ManagerViewModel> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
