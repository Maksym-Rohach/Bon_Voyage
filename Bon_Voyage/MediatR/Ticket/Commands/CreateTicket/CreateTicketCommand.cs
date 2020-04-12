using Bon_Voyage.ViewModels.TicketViewModels.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<AddTicketRequest>
    {
        public int PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CountsOfPlaces { get; set; }
        public int Discount { get; set; }
        public int HotelId { get; set; }
        public int AirportId { get; set; }
        public int RoomTypeId { get; set; }

        public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, AddTicketRequest>
        {
            public Task<AddTicketRequest> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
