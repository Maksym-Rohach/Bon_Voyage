using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ManagerControllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : ApiController
    {

    }
}