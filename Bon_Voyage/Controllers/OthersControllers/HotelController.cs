using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Hotel.Queries.GetAllHotelInfo;
using Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCity;
using Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCountry;
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
        [HttpGet("GetHotelInfo/{HotelId}")]
        public async Task<IActionResult> GetHotelInfo(string HotelId)
        {
            var result = await Mediator.Send(new GetAllHotelInfo { HotelId = HotelId });
            if(result==null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("GetHotelByCountry/{CountryId}")]
        public async Task<IActionResult> GetHotelsByCountry(string CountryId)
        {
            var res = await Mediator.Send(new GetHotelsByCountryQuery { CountryId = CountryId });
            return Ok(res);
        }
    }
}