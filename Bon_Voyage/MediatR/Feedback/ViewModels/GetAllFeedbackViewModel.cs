using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.MediatR.Feedback.ViewModels
{
    public class GetAllFeedbackViewModel
    {
        public string Id { get; set; }
        public string Theme { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
    }
}
