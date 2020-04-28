using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Seeder
{
    public class GenerateHotelPhotoSeederCommand : IRequest<string>
    {
        public List<string> PhotosBase64 { get; set; }

        public class AddHotelPhotoSeederCommandHandler : BaseMediator, IRequestHandler<GenerateHotelPhotoSeederCommand, string>
        {
            public AddHotelPhotoSeederCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<string> Handle(GenerateHotelPhotoSeederCommand request, CancellationToken cancellationToken)
            {
                string res = "var photosBase64 = new List<string>\n{\n";
                for (int i = 0; i < request.PhotosBase64.Count(); i++)
                {
                    res += $"\"{request.PhotosBase64[i]}\",\n";
                }

                res += "};\n";
                File.WriteAllText(@"C:\Users\Vlad\Desktop\res.txt", res);
                return string.Empty;
            }
        }

    }
}
