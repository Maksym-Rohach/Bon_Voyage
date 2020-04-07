using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Change;
using Bon_Voyage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ChangeControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ChangeController : ApiController
    {
        [HttpPost("changePassword")]
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
                    return Ok(res);
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