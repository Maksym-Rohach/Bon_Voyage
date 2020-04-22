using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Country.Queries.GetAllCountry;
using Bon_Voyage.MediatR.Country.Queries.GetAllCountryWithCityCount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class CountryController : ApiController
    {
        [HttpGet("GetAllCountry")]
        public async Task<IActionResult> GetAllCountry()
        {
            var result = await Mediator.Send(new GetAllCountryQuery { });
            if (result == null)
            {
                return BadRequest();
            }


            return Ok(result);
        }

        [HttpGet("GetAllCountryWithCityCount")]
        public async Task<IActionResult> GetAllCountryWithCityCount()
        {
            var result = await Mediator.Send(new GetAllCountryWithCityCountQuery { });
            if (result == null)
            {
                return BadRequest();
            }


            return Ok(result);
        }
    }
}