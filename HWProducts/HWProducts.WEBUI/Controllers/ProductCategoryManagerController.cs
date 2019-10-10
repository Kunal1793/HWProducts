using HWProducts.Core.Model;
using HWProducts.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWProducts.WEBUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryRepository context;

        // GET: ProductCategoryManager
        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<ProductCategory> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create() 
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit(); // Like Save Chnages Method in Entity Framework
                return RedirectToAction("List");
            }
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductCategory productCategory = context.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        public ActionResult Edit(ProductCategory productCategory, string id)
        {
            ProductCategory productCategoryToEdit = context.Find(id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                productCategoryToEdit.Category = productCategory.Category;
                context.Commit();
                return RedirectToAction("list");
            }
        }

        public ActionResult Delete(string id)
        {
            ProductCategory productCategoryToDelete = context.Find(id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("list");
            }
        }
    }
}