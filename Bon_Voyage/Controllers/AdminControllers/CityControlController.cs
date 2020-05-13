//using Bon_Voyage.MediatR.Cities.Commands.AddCity;
//using Bon_Voyage.MediatR.Cities.Queries.GetAllCities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Bon_Voyage.Controllers.AdminControllers
//{
//        [Authorize(Roles = "Admin")]
//        public class CityControlController : ApiController
//        {
//            [HttpGet("GetCitiesData")]
//            public async Task<IActionResult> GetCitiesData()
//            {
//                var res = await Mediator.Send(new GetAllCitiesQuery());
//                if (res == null)
//                {
//                    return BadRequest("Something went wrong");
//                }
//                return Ok(res);
//            }

//            [HttpPost("CreateCity")]
//            public async Task<IActionResult> Create([FromBody] AddCityCommand command)
//            {
//                var res = await Mediator.Send(command);
//                if (res.Status)
//                {
//                    return Ok();
//                }
//                else
//                {
//                    return BadRequest(res);
//                }
//            }
//        }
    
//}
