using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Airports.Commands;
using Bon_Voyage.MediatR.Airports.Commands.CreateAirportCommand;
using Bon_Voyage.MediatR.Airports.Queries.GetAirportsQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{

    public class AirportControlController : ApiController
    {
        [HttpGet("GetAirportsData")]
        public async Task<IActionResult> GetAirportsData()
        {
            var res = await Mediator.Send(new GetAirportControlDataQuery());
            if (res == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(res);
        }

        [HttpPost("CreateAirport")]
        public async Task<IActionResult> Create([FromBody] CreateAirportCommand command)
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