using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bon_Voyage.DB;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.User.Command.ForgotPasswordCommand;
using Bon_Voyage.MediatR.User.Command.NewPasswordCommand;
using Bon_Voyage.Services;
using Bon_Voyage.ViewModels.AuthViewModels;
using Bon_Voyage.ViewModels.ForgotPasswordViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bon_Voyage.Controllers.AuthControllers
{
    [Produces("application/json")]
    public class AuthController : ApiController
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IJwtTokenService _IJwtTokenService;

        public AuthController(EFDbContext context,
           UserManager<DbUser> userManager,
           SignInManager<DbUser> signInManager,
           IJwtTokenService IJwtTokenService)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _IJwtTokenService = IJwtTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errrors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest("Bad Model");
            }

            var user = _context.Users.Include(u=>u.BaseProfile)
                .FirstOrDefault(u => u.Email == model.Email);
            if(user == null)
            {
                return BadRequest(new { invalid = "Даний користувач не знайденний" });
            }

            var result = _signInManager
                .PasswordSignInAsync(user, model.Password, false, false).Result;

            if (!result.Succeeded)
            {
                return BadRequest(new { invalid = "Невірно введений пароль" });
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(
                 new
                 {
                     token = _IJwtTokenService.CreateToken(user)
                 });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordCommand command)
        {
            if (ModelState.IsValid)
            {
               var res= await Mediator.Send(command);
                if(res.Status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res.ErrorMessage);
                }
            }

            else
            {
                return BadRequest("щось не так");
            }
        }
        [HttpPost("new-password")]
        public async Task<IActionResult> NewPassword([FromBody]NewPasswordCommand command)
        {
            if (ModelState.IsValid)
            {
                var res = await Mediator.Send(command);
                if (res.Status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res.ErrorMessage);
                }
            }

            else
            {
                return BadRequest("щось не так");
            }
        }

    }
}
