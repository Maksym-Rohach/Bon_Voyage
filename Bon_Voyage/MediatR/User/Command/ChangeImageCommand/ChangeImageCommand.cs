using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Command.ChangeImageCommand
{
    public class ChangeImageCommand: IRequest<string>
    {
        public string Photo { get; set; }
        public string Id { get; set; }

        public class ChangeImageCommandHandler : BaseMediator, IRequestHandler<ChangeImageCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly IHostingEnvironment _env;

            public ChangeImageCommandHandler(EFDbContext context, IConfiguration configuration,
                IHostingEnvironment env) : base(context)
            {
                _configuration = configuration;
                _env = env;
            }
            
            public async Task<string> Handle(ChangeImageCommand request, CancellationToken cancellationToken)
            {
                string image = null;

                var user = _context.BaseProfiles.FirstOrDefault(u => u.Id == request.Id); // Search user
                if (user != null)
                {
                    string imageName = user.Photo ?? Guid.NewGuid().ToString() + ".jpg"; // 1. Create photo name
                    string pathSaveImages = InitStaticFiles  // 2. Save photo
                        .CreateImageByFileName(_env, _configuration,
                        new string[] { "ImagesPath", "ImagesPathUser" }, // 3. Send path
                        imageName, request.Photo); // 4. Send imageName and photo

                    if (pathSaveImages != null) // 5. If photo is created
                    {
                        image = imageName; 
                        user.Photo = image;
                        await _context.SaveChangesAsync(); // 6. Add photo to user
                    }
                    else
                    {
                        image = user.Photo;
                    }
                }

                    string path = $"{_configuration.GetValue<string>("UserUrlImages")}/250_";
                    string imagePath = user.Photo != null ? path + user.Photo :
                            path + _configuration.GetValue<string>("DefaultImage");

                    return imagePath;
                }
            }
        }

    }

