using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ManagerControlController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult AddManager([FromBody]AddManagerModel model)
        {


            return Ok();
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