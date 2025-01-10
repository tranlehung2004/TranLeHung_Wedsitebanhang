using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedsitebanhang.Controllers;
using Wedsitebanhang.Context;

namespace Wedsitebanhang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        WebsiteEcomEntities context = new WebsiteEcomEntities();
        public ActionResult Index()
        {
            var brand = context.Brands.ToList();
            return View(brand);
        }
        public ActionResult Detail(int id)
        {
            var brand = context.Brands.Find(id);
            return View(brand);
        }
        public ActionResult Create()
        {


            return View();
        }
       
      
       

    }
}