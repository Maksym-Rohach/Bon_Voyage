using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Manager.Commands.CreateManager
{
    public class CreateManagerCommand : IRequest<CreateManagerViewModel>//class each we gets from frontend
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }
        
        public class CreateManagerCommandHandler : BaseMediator, IRequestHandler<CreateManagerCommand, CreateManagerViewModel>//class with logic when we execute it
        {
            private readonly UserManager<DbUser> _userManager;

            public CreateManagerCommandHandler(UserManager<DbUser> userManager, EFDbContext context):base(context)
            {
                _userManager = userManager;
            }

            public async Task<CreateManagerViewModel> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
            {
                var userDb = _context.BaseProfiles.FirstOrDefault(x => x.User.Email == request.Email);
                if (userDb != null)
                {
                    BaseProfile baseProfile = new BaseProfile
                    {
                        Name = request.Name,
                        Surname = request.Surname
                    };

                    ManagerProfile managerProfile = new ManagerProfile
                    {
                        BaseProfile = baseProfile,
                        Salary = request.Salary,
                        State = true,
                        DateOfRegister = DateTime.Now
                    };
                    DbUser user = new DbUser
                    {
                        UserName = request.Email,
                        Email = request.Email,
                        BaseProfile = baseProfile
                    };
                    
                    var res = await _userManager.CreateAsync(user, "QWerty-1");
                    res = _userManager.AddToRoleAsync(user, "Manager").Result;
                    if (res.Succeeded)
                    {
                        _context.ManagerProfiles.Add(managerProfile);
                        _context.SaveChanges();
                        return new CreateManagerViewModel { Status = true };
                    }
                    else
                    {
                        return new CreateManagerViewModel { Status = true, ErrorsMessages = new CreateManagerErrors { ServerResponse = "Something went wrong" } };
                    }
                }
                else
                {
                    return new CreateManagerViewModel
                    {
                        Status = false,
                        ErrorsMessages = new CreateManagerErrors
                        {
                            Email = "Користувач с таким емейлом вже існує"
                        }
                    };
                }
                
            }
        }
    }
}
