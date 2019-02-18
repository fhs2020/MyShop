using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public ProductCategoryRepository()
        {
            categories = cache["categories"] as List<ProductCategory>;

            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory p)
        {
            categories.Add(p);
        }


        public void Update(ProductCategory productCategory)
        {
            ProductCategory categoryToUpdate = categories.Find(p => p.Id == productCategory.Id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory category = categories.Find(p => p.Id == Id);

            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Catoegory not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }


        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = categories.Find(p => p.Id == Id);

            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
