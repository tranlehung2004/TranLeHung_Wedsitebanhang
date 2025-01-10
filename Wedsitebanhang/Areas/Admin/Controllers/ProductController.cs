using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Wedsitebanhang.Context;

namespace Wedsitebanhang.Areas.Admin.Controllers
{
   
    public class ProductAdminController : Controller
    {
        WebsiteEcomEntities context = new WebsiteEcomEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var product = context.Products.ToList();
            return View(product);
        }
        public ActionResult Detail(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(context.Categories, "id", "name");
            ViewBag.BrandList = new SelectList(context.Brands, "id", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            var product = new Product();
            try
            {
                if (objProduct.ImageUpload != null)
                {

                    product.name = objProduct.name;
                    product.description = objProduct.description;
                    product.price = objProduct.price;
                    product.salePrice = objProduct.salePrice;
                    product.category_id = objProduct.category_id;
                    product.brand_id = objProduct.brand_id;
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
            }


            ViewBag.CategoryList = new SelectList(context.Categories, "id", "name");
            ViewBag.BrandList = new SelectList(context.Brands, "id", "name");
            return View();
        }
        public ActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.CategoryList = new SelectList(context.Categories, "id", "name");
            ViewBag.BrandList = new SelectList(context.Brands, "id", "name");
            return View(product);
        }
        [HttpPost]
        
        
        public ActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public static string GenerateSlug(string input)
        {
            // Chuyển chuỗi sang chữ thường
            string slug = input.ToLowerInvariant();

            // Loại bỏ các ký tự không hợp lệ
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // Thay thế khoảng trắng và các ký tự không hợp lệ bằng dấu gạch ngang
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');

            // Loại bỏ các dấu gạch ngang thừa
            slug = Regex.Replace(slug, @"-+", "-");

            // Cắt chuỗi nếu cần (ví dụ: giới hạn 200 ký tự)
            if (slug.Length > 200)
            {
                slug = slug.Substring(0, 200).Trim('-');
            }

            return slug;
        }
    }
}