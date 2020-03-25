using Bon_Voyage.Application.Manager.ViewModel;
using Bon_Voyage.DB;
using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bon_Voyage.Application.Manager.Commands.CreateManager
{
    public class CreateManagerCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }

        public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, bool>
        {
            private readonly EFDbContext _context;
            private readonly UserManager<DbUser> _userManager;
            public CreateManagerCommandHandler(EFDbContext context, UserManager<DbUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<bool> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
            {
                ManagerProfile managerProfile = new ManagerProfile
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Salary = request.Salary,
                    State = true,
                    Photo = "",
                    DateOfRegister = DateTime.Now
                };
                DbUser user = new DbUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    ManagerProfile = managerProfile
                };

                var res = await _userManager.CreateAsync(user, "QWerty-1");
                res = _userManager.AddToRoleAsync(user, "Manager").Result;
                return res.Succeeded;
            }
        }
    }
}
