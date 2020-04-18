using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Queries.GetBoughtTicketsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bon_Voyage.MediatR.Ticket.Queries.GetHotDealTicketsQuery;
using Bon_Voyage.MediatR.Ticket.Commands.CreateTicket;

namespace Bon_Voyage.Controllers.ManagerControllers
{
     public class TicketControlController : ApiController
    {
        [HttpGet("getBoughtsTickets")] 
        [Authorize]
        public async Task<IActionResult> GetBoughtTickets()
        {
            var res = await Mediator.Send(new GetBoughtTicketsQuery());
            if (res!=null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("Щось не так!");
            }
        }

        [HttpGet("getHotDealTickets")]
        [Authorize]
        public async Task<IActionResult> GetHotDealTickets()
        {
            var res = await Mediator.Send(new GetHotDealTicketsQuery());
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("Щось не так!");
            }
        }

        [HttpPost("CreateTicket")]
        [Authorize]
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var res = await Mediator.Send(command);
                if (res.Status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}