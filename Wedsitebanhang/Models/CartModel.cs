using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Wedsitebanhang.Context;

namespace Wedsitebanhang.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}