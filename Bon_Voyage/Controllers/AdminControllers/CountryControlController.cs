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
        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody]AddCountryCommand command)
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
                    return BadRequest(res);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DONE
        [HttpPost("ChangeCountry")]
        public async Task<IActionResult> ChangeCountry([FromBody]ChangeCountryCommand command)
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
                    return BadRequest(res);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DONE
        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody]DeleteCountryCommand command)
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
                    return BadRequest(res);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}