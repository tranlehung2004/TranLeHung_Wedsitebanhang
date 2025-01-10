using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedsitebanhang.Context;

namespace Wedsitebanhang.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        WebsiteEcomEntities context = new WebsiteEcomEntities();
        // GET: Admin/CategoryAdmin
        public ActionResult Index()
        {
            var category = context.Categories.ToList();
            return View(category);
        }
    }
}