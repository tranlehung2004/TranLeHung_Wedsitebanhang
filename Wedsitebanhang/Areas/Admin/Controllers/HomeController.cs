using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Wedsitebanhang.Context;
namespace Wedsitebanhang.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WebsiteEcomEntities context = new WebsiteEcomEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var count = 0;
            var order = context.Orders.Where(o => DbFunctions.TruncateTime(o.created_at) == DateTime.Today).ToList();
            count = order.Count;
            return View(count);
        }

    }
}