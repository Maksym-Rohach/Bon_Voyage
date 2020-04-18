using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Airports.Queries.GetAirportsByCountry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class AirportController : ApiController
    {
        [HttpGet("GetAirportsByCountry/{CountryId}")]
        public async Task<IActionResult> GetAirportsByCountry(string CountryId)
        {
            var result = await Mediator.Send(new GetAirportsByCountryQuery { CountryId = CountryId });
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}