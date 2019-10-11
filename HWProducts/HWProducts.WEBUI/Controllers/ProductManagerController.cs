using HWProducts.Core.Model;
using HWProducts.Core.Model.ViewModel;
using HWProducts.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWProducts.WEBUI.Controllers
{
    public class ProductManagerController : Controller
    {

        ProductRepository context;
        ProductCategoryRepository productCategories;

        public ProductManagerController()
        {
            context = new ProductRepository();
            productCategories = new ProductCategoryRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List() 
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.productCategories = productCategories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product) 
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else 
            {
                context.Insert(product);
                context.Commit(); // Like Save Chnages Method in Entity Framework
                return RedirectToAction("list");
            }
        }

        [HttpGet]
        public ActionResult Edit(string id) 
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else 
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.productCategories = productCategories.Collection();
                return View(viewModel);
            }
        }

        public ActionResult Edit(Product product, string id) 
        {
            Product productToEdit = context.Find(id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else 
            {
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                context.Commit();
                return RedirectToAction("list");
            }
        }

        public ActionResult Delete(string id) 
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
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