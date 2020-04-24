using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Comfort.Queries.GetAllComforts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class ComfortController : ApiController
    {
        [HttpGet("GetAllComforts")]
        public async Task<IActionResult> GetAllComforts()
        {
            var result = await Mediator.Send(new GetAllComfortsQuery());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}