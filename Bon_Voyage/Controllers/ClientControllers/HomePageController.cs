using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.MediatR.Cities.Queries.GetCitiesByCountry;
using Bon_Voyage.MediatR.Home.Queries;
using Bon_Voyage.MediatR.Hotel.Queries.GetAllHotelsPhotos;
using Bon_Voyage.MediatR.Hotel.Queries.GetHotelsByCity;
using Bon_Voyage.MediatR.Manager.Queries.GetAllManagersQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.ClientControllers
{
    //[Authorize(Roles = "Client")]
    public class HomePageController : ApiController
    {
        [HttpGet("GetHomeInformation")]
        public async Task<IActionResult> GetHomeInformation()
        {
            var result = await Mediator.Send(new GetHomeInformationQuery());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetGalleryPhoto")]
        public async Task<IActionResult> GetGalleryPhoto()
        {
            var result = await Mediator.Send(new GetAllHotelsPhotosQuery());
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}