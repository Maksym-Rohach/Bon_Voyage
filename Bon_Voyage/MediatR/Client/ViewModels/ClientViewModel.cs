using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Client.ViewModels
{
    public class ClientViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }
}
