using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.User.Command.ForgotPasswordCommand
{
    public class ForgotPasswordViewModel
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
