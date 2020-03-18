﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.Services;
using Bon_Voyage.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bon_Voyage.Controllers.AuthControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IJwtTokenService _IJwtTokenService;

        public AuthController(EFDbContext context,
           UserManager<DbUser> userManager,
           SignInManager<DbUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errrors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest("Bad Model");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if(user == null)
            {
                return BadRequest(new { invalid = "Користувача із вказаними обліковими даними не знайдено" });
            }

            var result = _signInManager
                .PasswordSignInAsync(user, model.Password, false, false).Result;

            if (!result.Succeeded)
            {
                return BadRequest(new { invalid = "Користувача із вказаними обліковими даними не знайдено" });
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(
                 new
                 {
                     token = _IJwtTokenService.CreateToken(user)
                 });
        }
    }
}