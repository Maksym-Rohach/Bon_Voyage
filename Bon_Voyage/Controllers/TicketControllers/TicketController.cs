using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Commands.BuyTicket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.TicketControllers
{
    public class TicketController : ApiController
    {
        [HttpPost("BuyTicket")]
        public async Task<IActionResult> BuyTicket([FromBody]BuyTicketCommand command)
        {
            var id = User.Claims.ToList()[0].Value;

            command.ClientId = id;

            var res = await Mediator.Send(command);

            if (res == "false")
                BadRequest();

            return Ok(res);
        }
    }
}