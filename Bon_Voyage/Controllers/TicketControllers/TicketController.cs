using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Commands.BuyTicket;
using Bon_Voyage.MediatR.Ticket.Commands.AddTicketToCart;
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
       [HttpPost("AddTicketToCart")]
       public async Task<IActionResult> AddTicketToCart(AddTicketToCart command)
       {           
            var userId = User.Claims.ToList()[0].Value;
            var res = await Mediator.Send(new AddTicketToCart
            {
                ClientId = userId,
                TicketId = command.TicketId
            });
            if (res)
            {
                return (Ok(res));
            }
            return BadRequest("Будь ласка авторизуйтесь");
       }
    }
}