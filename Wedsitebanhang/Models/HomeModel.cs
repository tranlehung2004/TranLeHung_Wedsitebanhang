using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedsitebanhang.Context;

namespace Wedsitebanhang.Models
{
    public class HomeModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
    }
}