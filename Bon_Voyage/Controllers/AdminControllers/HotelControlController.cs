﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Hotel.Commands.CreateHotel;
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
            await Mediator.Send(command);

            return Ok();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteHotel([FromBody]DeleteHotelModel model)
        {

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateHotel([FromBody]UpdateHotelModel model)
        {

            return Ok();
        }
    }
}