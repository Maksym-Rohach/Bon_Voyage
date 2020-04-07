using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Queries.GetImageQuery
{
    public class GetImageQuery: IRequest<string>
    {
        public string Id { get; set; }

        public class GetImageQueryHandler : BaseMediator, IRequestHandler<GetImageQuery, string>
        {
            private readonly IConfiguration _configuration;
            public GetImageQueryHandler(EFDbContext context, IConfiguration configuration): base(context)
            {
                _configuration = configuration;
            }
            public async Task<string> Handle(GetImageQuery request, CancellationToken cancellationToken)
            {
                var user = _context.BaseProfiles.FirstOrDefault(u => u.Id == request.Id);

                string path = $"{_configuration.GetValue<string>("UserUrlImages")}/250_";
                string imagePath = user.Photo != null ? path + user.Photo :
                        path + _configuration.GetValue<string>("DefaultImage");

                return imagePath;

            }
        }
    }
}
