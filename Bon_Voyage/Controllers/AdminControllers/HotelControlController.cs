using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HotelControlController : Controller
    {
        [HttpPost("add")]
        public IActionResult AddHotel([FromBody]AddHotelModel model)
        {


            return Ok();
        }
        [HttpPost("delete")]
        public IActionResult DeleteHotel([FromBody]DeleteHotelModel model)
        {

            return Ok();
        }

        [HttpPost("update")]
        public IActionResult UpdateHotel([FromBody]UpdateHotelModel model)
        {

            return Ok();
        }
    }
}