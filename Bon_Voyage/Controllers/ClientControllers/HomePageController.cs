using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ClientControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class HomePageController : ControllerBase
    {
        [HttpGet("GetHomeInformation")]
        public async Task<IActionResult> GetHomeInformation()
        {
            //var result = await Mediator.Send(command);
            //if (result)
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}

            return Ok();
        }
    }
}