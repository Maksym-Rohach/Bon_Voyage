using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Queries.GetDataForFilters;
using Bon_Voyage.MediatR.Ticket.Queries.GetTicketsWithFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ClientControllers
{
    public class TicketFiltringController : ApiController
    {
        [HttpPost("GetFiltredTickets")]
        public async Task<IActionResult> GetFiltredTickets([FromBody]GetTicketsWithFiltersCommand command)
        {
            var res = await Mediator.Send(command);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
        [HttpGet("GetDataForFilter")]
        public async Task<IActionResult> GetDataForFilter()
        {
            var res = await Mediator.Send(new GetDataForFiltersQuery());
            return Ok(res);
        }
    }
}