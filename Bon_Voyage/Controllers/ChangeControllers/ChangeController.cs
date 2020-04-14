using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Change;
using Bon_Voyage.MediatR.User.Command.ChangeImageCommand;
using Bon_Voyage.MediatR.User.Command.ChangeInfo;
using Bon_Voyage.MediatR.User.Queries.GetImageQuery;
using Bon_Voyage.MediatR.User.Queries.GetInfoQuery;
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

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                command.Id = User.Claims.ToList()[0].Value;
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
        [HttpGet("get-info")]
        public async Task<IActionResult> GetInfo()
        {
            var id = User.Claims.ToList()[0].Value;
            var res = await Mediator.Send(new GetInfoQuery { Id = id });
            return Ok(res);
        }

        [HttpPost("change-info")]
        public async Task<IActionResult> ChangeInfo([FromBody] ChangeInfoCommand command)
        {
            var id = User.Claims.ToList()[0].Value;
            command.Id = id;
            var res = await Mediator.Send(command);
            if (res.Status)
                return Ok();
            else
                return BadRequest(res);
        }
    }
}