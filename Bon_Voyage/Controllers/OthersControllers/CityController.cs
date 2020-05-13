using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Cities.Commands.AddCity;
using Bon_Voyage.MediatR.Cities.Queries.GetAllCities;
using Bon_Voyage.MediatR.Cities.Queries.GetCitiesByCountry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{

    public class CityController : ApiController
    {
        [HttpGet("GetCitiesByCountry/{CountryId}")]
        public async Task<IActionResult> GetCitiesByCountry(string CountryId)
        {
            var result = await Mediator.Send(new GetCitiesByCountryQuery { CountryId = CountryId });
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await Mediator.Send(new GetAllCitiesQuery());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(AddCityCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}