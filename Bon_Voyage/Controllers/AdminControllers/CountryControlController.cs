using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Country.Commands.AddCountry;
using Bon_Voyage.MediatR.Country.Commands.ChangeCountry;
using Bon_Voyage.MediatR.Country.Commands.DeleteCountry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class CountryControlController : ApiController
    {
        // DONE
        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddCountry([FromBody]AddCountryCommand command)
        {
            var res = await Mediator.Send(command);
            if (res.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }


        // DONE
        [HttpPost("ChangeCountry")]
        public async Task<IActionResult> ChangeCountry([FromBody]ChangeCountryCommand command)
        {
            var res = await Mediator.Send(command);
            if (res.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }

        // DONE
        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody]DeleteCountryCommand command)
        {
            var res = await Mediator.Send(command);
            if (res.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}