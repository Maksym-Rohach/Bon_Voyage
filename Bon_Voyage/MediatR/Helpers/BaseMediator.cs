using Bon_Voyage.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Helpers
{
    // Abstract class, for get EFDbContext
    public abstract class BaseMediator
    {
        public readonly EFDbContext _context;

        public BaseMediator(EFDbContext context)
        {
            _context = context;
        }
    }
}
