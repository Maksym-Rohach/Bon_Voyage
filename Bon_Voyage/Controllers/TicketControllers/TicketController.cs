using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.TicketControllers
{
  
    public class TicketController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody]AddTicketViewModel model)
        {
            return Ok();
        }
    }
}