using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Commands.AddTicketToCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.TicketControllers
{
    public class TicketController : ApiController
    {
       [HttpPost("AddTicketToCart")]
       public async Task<IActionResult> AddTicketToCart(string ticketId)
       {           
            var userId = User.Claims.ToList()[0].Value;
            var res = await Mediator.Send(new AddTicketToCart
            {
                ClientId = userId,
                TicketId = ticketId
            });
            if (res)
            {
                return (Ok(res));
            }
            return BadRequest("Будь ласка авторизуйтесь");
       }
    }
}