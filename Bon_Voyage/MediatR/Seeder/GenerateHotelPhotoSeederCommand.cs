using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Seeder
{
    public class GenerateHotelPhotoSeederCommand : IRequest<List<string>>
    {
        public string HotelId { get; set; }
        public List<string> PhotosBase64 { get; set; }

        public class AddHotelPhotoSeederCommandHandler : BaseMediator, IRequestHandler<GenerateHotelPhotoSeederCommand, List<string>>
        {
            public AddHotelPhotoSeederCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<List<string>> Handle(GenerateHotelPhotoSeederCommand request, CancellationToken cancellationToken)
            {
                List<string> res = new List<string>();
                string buf = "";
                request.PhotosBase64.ForEach(x =>
                {
                    buf += "photos.Add(new AddHotelPhotoCommand\n";
                    buf += "{\n";
                    buf += $"HotelId = \"{request.HotelId}\",\n";
                    buf += "PhotosBase64 = new List<string>\n";
                    buf += "{\n";
                    buf += $"\"{x}\"\n";
                    buf += "},\n";
                    buf += "});\n";
                    res.Add(buf);
                });

                return res;
            }
        }

    }
}
