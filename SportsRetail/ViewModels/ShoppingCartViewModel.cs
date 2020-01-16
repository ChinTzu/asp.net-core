using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.ViewModels
{
    public class ShoppingCartViewModel
    {
        //to know which shopping cart item belongs
        public ShoppingCart ShoppingCart { get; set; }

        //total value of this shopping cart
        public decimal ShoppingCartTotal { get; set; }
    }
}
