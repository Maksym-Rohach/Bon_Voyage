using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Registration
{
    public class RegistrationCommand : IRequest<RegistrationViewModel>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationViewModel>
        {
            private readonly EFDbContext _context;
            private readonly UserManager<DbUser> _userManager;
            private readonly SignInManager<DbUser> _signInManager;
            private readonly IJwtTokenService _IJwtTokenService;

            public RegistrationCommandHandler(EFDbContext context, UserManager<DbUser> userManager, SignInManager<DbUser> signInManager, IJwtTokenService IJwtTokenService)
            {
                _userManager = userManager;
                _context = context;
                _signInManager = signInManager;
                _IJwtTokenService = IJwtTokenService;
            }

            public async Task<RegistrationViewModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
            {               
                var roleName = "Client";
                var userReg = _context.Users.FirstOrDefault(x => x.Email == request.Email);
                if (userReg != null)
                {
                    return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (цей емейл вже зареєстровано)") };
                }

                if (request.Name == null)
                {
                    return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (поле вводу пусте)") };
                }
                else
                {
                    var nameANDsurnameREGEX = new Regex(@"[A-Za-z0-9._()\[\]-]{3,15}$");

                    if (!nameANDsurnameREGEX.IsMatch(request.Name))
                    {
                        return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (мінімум 3 символи максимум 15 символів)") };
                    }
                }

                if (request.Surname == null)
                {
                    return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (поле вводу пусте)") };
                }
                else
                {
                    var nameANDsurnameREGEX = new Regex(@"[A-Za-z0-9._()\[\]-]{3,15}$");
                    if (!nameANDsurnameREGEX.IsMatch(request.Name))
                    {
                        return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (мінімум 3 символи максимум 15 символів)") };
                    }
                }
                if (request.Email == null)
                {
                    return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (Вкажіть пошту)") };
                }
                else
                {
                    var testmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (!testmail.IsMatch(request.Email))
                    {
                        return new RegistrationViewModel { Status = false, ErrorMessage = ("Bad Model (Невірно вказана почта)") };
                    }
                }

                BaseProfile baseProfile = new BaseProfile
                {
                    Name = request.Name,
                    Surname = request.Surname
                };

                ClientProfile clientPro = new ClientProfile
                {
                    BaseProfile = baseProfile
                };
                DbUser dbClient = new DbUser
                {
                    Email = request.Email,
                    UserName = request.Name,
                    BaseProfile = baseProfile   
                };
                var res = await _userManager.CreateAsync(dbClient, request.Password);
                res = _userManager.AddToRoleAsync(dbClient, roleName).Result;

                if (res.Succeeded)
                {
                    _context.ClientProfiles.Add(clientPro);
                    _context.SaveChanges();
                    await _signInManager.SignInAsync(dbClient, isPersistent: false);
                    return new RegistrationViewModel { Status = true, Tokken = _IJwtTokenService.CreateToken(dbClient) };
                }
                return new RegistrationViewModel { Status = false, ErrorMessage = ("") };
            }
        }
    }
}
