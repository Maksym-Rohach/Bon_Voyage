using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Feedback.Commands.AnswerFeedBackCommand;
using Bon_Voyage.MediatR.Feedback.Queries.GetAllFeedbacks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ManagerControllers
{    
    public class FeedBackController : ApiController
    {
        [HttpGet("GetAllFeedbacks")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var res = await Mediator.Send(new GetAllFeedbacksQuery());
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("Щось не так!");
            }
        }
        [HttpPost("AnswerFeedBack")]
        public async Task<IActionResult> AnswerFeedBack(AnswerFeedBackCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}