using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Manager.Commands.CreateManager;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using Bon_Voyage.MediatR.Manager.ViewModel;
using Bon_Voyage.MediatR.Seeder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : ApiController
    {
        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager (CreateManagerCommand command)
        {
            var result = await Mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllManagers")]
        public async Task<ActionResult<ICollection<ManagerViewModel>>> GetAllManagers()
        {
            var res = await Mediator.Send(new GetAllManagersQuery());//calls a mediator's command
            return Ok(res);
        }

        [HttpPost("GenerateHotelPhotoSeeder")]
        public async Task<IActionResult> GenerateHotelPhotoSeeder([FromBody]GenerateHotelPhotoSeederCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }
    }
}