using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Models
{
    //Data Transfer Object
    public class Pay
    {
        public string CardName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StripeToken { get; set; }
    }
}
