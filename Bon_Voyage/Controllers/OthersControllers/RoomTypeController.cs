using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.RoomType.Queries.GetAllRoomTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class RoomTypeController : ApiController
    {
        [HttpGet("GetAllRoomTypes")]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var result = await Mediator.Send(new GetAllRoomTypesQuery());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}