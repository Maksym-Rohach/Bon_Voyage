using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Hotel.Commands.CreateHotel;
using Bon_Voyage.MediatR.Hotel.Commands.UpdateHotel;
using Bon_Voyage.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class HotelControlController : ApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddHotel([FromBody]CreateHotelCommand command)
        {
            var res = await Mediator.Send(command);
            if (res.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateHotel([FromBody]UpdateHotelCommand command)
        {
            var res = await Mediator.Send(command);
            if (res.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }
    }
}