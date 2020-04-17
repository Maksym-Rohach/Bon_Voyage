using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Queries.GetInfoQuery
{
    public class GetInfoQuery: IRequest<InfoViewModel>
    {
        public string Id { get; set; }

        public class GetImageQueryHandler : BaseMediator, IRequestHandler<GetInfoQuery, InfoViewModel>
        {
            private readonly IConfiguration _configuration;
            public GetImageQueryHandler(EFDbContext context, IConfiguration configuration) : base(context)
            {
                _configuration = configuration;
            }

            public async Task<InfoViewModel> Handle(GetInfoQuery request, CancellationToken cancellationToken)
            {
                var user = _context.BaseProfiles.Include(x=>x.User).FirstOrDefault(u => u.Id == request.Id);

                var info = new InfoViewModel
                {
                    
                    Name = user.Name,
                    SurName = user.Surname,
                    Email = user.User.Email,
                    PhoneNumber = user.User.PhoneNumber
                };
                return info;
            }
        }
    }
}
