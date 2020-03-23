using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.Services;
using Bon_Voyage.ViewModels.RegistrationViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Bon_Voyage.Controllers.RegistrationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IJwtTokenService _IJwtTokenService;

        public RegistrationController(EFDbContext context, UserManager<DbUser> userManager, SignInManager<DbUser> signInManager, IJwtTokenService IJwtTokenService)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _IJwtTokenService = IJwtTokenService;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody]RegistrationViewModels model)
        {
            var roleName = "Client";
            if (!ModelState.IsValid)
            {
                var userReg = _context.Users.FirstOrDefault(x => x.Email == model.Email);
                if (userReg != null)
                {
                    return BadRequest("Bad Model (цей емейл вже зареєстровано)");
                }

                if (model.Name == null)
                {
                    return BadRequest("Bad Model (поле вводу пусте)");
                }
                else
                {
                    var nameANDsurnameREGEX = new Regex(@"[A-Za-z0-9._()\[\]-]{3,15}$");

                    if (!nameANDsurnameREGEX.IsMatch(model.Name))
                    {
                        return BadRequest("Bad Model (мінімум 3 символи максимум 15 символів)");
                    }
                }

                if (model.Surname == null)
                {
                    return BadRequest("Bad Model (поле вводу пусте)");
                }
                else
                {
                    var nameANDsurnameREGEX = new Regex(@"[A-Za-z0-9._()\[\]-]{3,15}$");

                    if (!nameANDsurnameREGEX.IsMatch(model.Name))
                    {
                        return BadRequest("Bad Model (мінімум 3 символи максимум 15 символів)"); ;
                    }
                }

                if (model.Telefon == null)
                {
                    //return BadRequest("Bad Model (номер телефону не вказано)");
                }

                if (model.DateofBirth == null)
                {
                    //return BadRequest("Bad Model (номер телефону не вказано)");
                }

                ClientProfile clientPro = new ClientProfile
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Photo = "",
                    DateOfBirth = model.DateofBirth
                };
                DbUser dbClient = new DbUser
                {
                    Email = model.Email,
                    UserName = model.Name,
                    ClientProfile = clientPro
                };
                var resault = await _userManager.CreateAsync(dbClient, model.Password);
                resault = _userManager.AddToRoleAsync(dbClient, roleName).Result;

                if (resault.Succeeded)
                {
                    await _signInManager.SignInAsync(userReg, isPersistent: false);
                    return Ok(
                 new
                 {
                     token = _IJwtTokenService.CreateToken(userReg)
                 });
                }
                else
                {
                    foreach (var error in resault.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return null;
        }
    }
}


//***********************************************************************************************
//var EMAIL = "bonvoyagevirus@gmail.com";
//var EMAILPASSWORD = "bon123456-";
//***********************************************************************************************