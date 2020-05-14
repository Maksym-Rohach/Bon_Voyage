using Bon_Voyage.DB;
using Bon_Voyage.MediatR.Helpers;
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
        public string PriceFrom { get; set; } // int
        public string CountsOfNight { get; set; } // int
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string CountsOfPlaces { get; set; } // int
        public int Discount { get; set; } // int
        public string HotelId { get; set; }
        public string AirportId { get; set; }
        public string RoomTypeId { get; set; }
        public List<string> ComfortsId { get; set; }

        public class CreateTicketCommandHandler : BaseMediator, IRequestHandler<CreateTicketCommand, AddTicketRequest>
        {
            public CreateTicketCommandHandler(EFDbContext context) : base(context)
            {
            }

            public async Task<AddTicketRequest> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
            {
                var res = Validation(request);
                if (!res.Status) return res;

                var ticket = new DB.Entities.Ticket
                {
                    PriceFrom = Convert.ToInt32(request.PriceFrom),
                    CountsOfNight = Convert.ToInt32(request.CountsOfNight),
                    DateFrom = DateTime.Parse(DateTime.Parse(request.DateFrom).ToString("dd.MM.yyyy")),
                    DateTo = DateTime.Parse(DateTime.Parse(request.DateTo).ToString("dd.MM.yyyy")),
                    CountsOfPlaces = Convert.ToInt32(request.CountsOfPlaces),
                    Discount = Convert.ToInt32(request.Discount),
                    HotelId = request.HotelId,
                    AirportId = request.AirportId,
                    RoomTypeId = request.RoomTypeId,
                    IsBought = false
                };

                _context.Add(ticket);
                _context.SaveChanges();

                if (request.ComfortsId.Count > 0)
                {
                    var comfortTicket = _context.Tickets.FirstOrDefault(x => x == ticket);

                    var comforts = new List<DB.Entities.TicketsToComforts>();
                    request.ComfortsId.ForEach(x =>
                    comforts.Add(new DB.Entities.TicketsToComforts
                    {
                        TicketId = comfortTicket.Id,
                        ComfortId = x,
                    })
                    );


                    _context.AddRange(comforts);
                    _context.SaveChanges();
                }





                return new AddTicketRequest { Status = true };
            }


            private AddTicketRequest Validation(CreateTicketCommand request)
            {
                if (Convert.ToInt32(request.PriceFrom) <= 0)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Стартова ціна не може бути менше одиниці"
                    };
                }

                if (Convert.ToInt32(request.CountsOfNight) <= 0)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Кількість ночей не може бути менше однієї ночі"
                    };
                }
                if (DateTime.Parse(request.DateFrom) <= DateTime.Now)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Дата відльоту не підходить"
                    };
                }

                if (DateTime.Parse(request.DateTo) <= DateTime.Now)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Дата прильоту не підходить"
                    };
                }

                if (Convert.ToInt32(request.CountsOfPlaces) <= 0)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Кількість місць не може бути менше одного"
                    };
                }

                if (_context.Hotels.FirstOrDefault(x => x.Id == request.HotelId) == null)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Готель не знайдено"
                    };
                }

                if (_context.Airports.FirstOrDefault(x => x.Id == request.AirportId) == null)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Аеропорт не знайдено"
                    };
                }

                if (_context.RoomTypes.FirstOrDefault(x => x.Id == request.RoomTypeId) == null)
                {
                    return new AddTicketRequest
                    {
                        Status = false,
                        ErrorMessage = "Тип кімнати не знайдено"
                    };
                }

                foreach (var comfort in request.ComfortsId)
                {
                    if (_context.Comforts.FirstOrDefault(x => x.Id == comfort) == null)
                    {
                        return new AddTicketRequest
                        {
                            Status = false,
                            ErrorMessage = "Комфорт не знайдено"
                        };
                    }
                }


                return new AddTicketRequest { Status = true };
            }
        }
    }
}
