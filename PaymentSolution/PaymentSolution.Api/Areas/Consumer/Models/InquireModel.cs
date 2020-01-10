using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSolution.Api.Areas.Consumer.Models
{
    public class InquireModel
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Description { get; set; }
    }
}
