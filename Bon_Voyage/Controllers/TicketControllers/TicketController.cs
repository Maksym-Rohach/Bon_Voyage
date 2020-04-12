using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Commands.CreateTicket;
using Bon_Voyage.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.TicketControllers
{
    public class TicketController : ApiController
    {
        [HttpPost("CreateTicket")]
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
                    return BadRequest(res.ErrorMessage);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}