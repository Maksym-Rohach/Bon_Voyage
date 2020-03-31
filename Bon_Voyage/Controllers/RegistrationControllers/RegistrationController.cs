using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Registration;
using Bon_Voyage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Bon_Voyage.Controllers.RegistrationControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RegistrationController : ApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Registration([FromBody]RegistrationCommand command)
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
                    return Ok(res.Tokken);
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


//***********************************************************************************************
//var EMAIL = "bonvoyagevirus@gmail.com";
//var EMAILPASSWORD = "bon123456-";
//***********************************************************************************************