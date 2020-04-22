using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Manager.Commands.CreateManager;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using Bon_Voyage.MediatR.Manager.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : ApiController
    { 
        [HttpGet("GetAllManagers")]
        public async Task<ActionResult<ICollection<ManagerViewModel>>> GetAllManagers()
        {
            var res = await Mediator.Send(new GetAllManagersQuery());//calls a mediator's command
            return Ok(res);
        }
    }
}