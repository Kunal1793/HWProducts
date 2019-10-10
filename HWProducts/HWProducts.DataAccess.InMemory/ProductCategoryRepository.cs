using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {

            productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory PC)
        {
            productCategories.Add(PC);
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(pc => pc.Id == Id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryUpdate =
                productCategories.Find(pc => pc.Id == productCategory.Id);

            if (productCategoryUpdate != null)
            {
                productCategoryUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }


        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete =
                productCategories.Find(pc => pc.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


    }
}
