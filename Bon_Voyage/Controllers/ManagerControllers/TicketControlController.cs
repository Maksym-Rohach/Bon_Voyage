using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Queries.GetBoughtTicketsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bon_Voyage.MediatR.Ticket.Queries.GetHotDealTicketsQuery;

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
    }
}