using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }


}