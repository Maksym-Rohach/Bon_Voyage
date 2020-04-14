using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Command.ChangeInfo
{
    public class ChangeInfoViewModel
    {
        public bool Status { get; internal set; }
        public string ErrorMessage { get; set; }

    }
}
