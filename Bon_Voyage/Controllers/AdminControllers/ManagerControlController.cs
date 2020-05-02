using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Manager.Commands.CreateManager;
using Bon_Voyage.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ManagerControlController : ApiController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateManager(CreateManagerCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.Status)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.ErrorsMessages);
            }
        }
        [HttpPost("delete")]
        public IActionResult DeleteManager([FromBody]DeleteManagerModel model)
        {

            return Ok();
        }

        [HttpPost("update")]
        public IActionResult UpdateManager([FromBody]UpdateManagerModel model)
        {

            return Ok();
        }
    }
}