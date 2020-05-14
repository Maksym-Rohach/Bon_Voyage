using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Ticket.Queries.GetCardsTickets;
using Bon_Voyage.MediatR.User.Command.ChangeInfo;
using Bon_Voyage.MediatR.User.Command.FeedbackCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ClientControllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : ApiController
    {
        [HttpPost("addFeedback")]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackCommand command)
        {
            var id = User.Claims.ToList()[0].Value;
            command.Id = id;
            var res = await Mediator.Send(command);
            if (res.Status)
                return Ok();
            else
                return BadRequest(res);
        }

        [HttpGet("GetCardsTickets")]
        public async Task<IActionResult> GetCardsTickets()
        {
            var id = User.Claims.ToList()[0].Value;

            var res = await Mediator.Send(new GetCardsTicketsQuery { ClientId = id });

            return Ok(res);
        }
    }
}