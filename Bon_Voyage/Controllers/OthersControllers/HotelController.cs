using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class HotelController : ApiController
    {
        [HttpGet("GetHotelByCity/{CityId}")]
        public async Task<IActionResult> GetHotelsByCity(string CityId)
        {
            var result = await Mediator.Send(new GetHotelsByCityQuery { CityId = CityId });
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}