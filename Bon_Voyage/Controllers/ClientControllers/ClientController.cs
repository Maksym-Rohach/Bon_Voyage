using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ClientControllers
{
    [Authorize(Roles = "Client")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet("HomeInformation")]
        public async Task<IActionResult> HomeInformation()
        {
            return Ok();
        }
    }
}