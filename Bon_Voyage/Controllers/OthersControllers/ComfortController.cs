using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.OthersControllers
{
    public class ComfortController : ApiController
    {
        [HttpGet("GetAllComforts")]
        public async Task<IActionResult> GetAllComforts()
        {
            return Ok();
        }
    }
}