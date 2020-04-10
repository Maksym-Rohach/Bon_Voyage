using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ChangeControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ChangeController : ApiController
    {
        [HttpGet("get-image")]
        public async Task<IActionResult> GetImage()
        {
            var id = User.Claims.ToList()[0].Value;
            var res = await Mediator.Send(new GetImageQuery { Id = id });
            return Ok(res);
        }

        [HttpPost("change-image")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        public async Task<IActionResult> ChangeImage([FromBody] ChangeImageCommand command)
        {
            var id = User.Claims.ToList()[0].Value;
            var res = await Mediator.Send(new ChangeImageCommand { Photo = command.Photo, Id = id });
            return Ok(res);
        }
    }
}