using Doan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.DAO
{
    public class ProductDAO
    {
        private MyShopEntities conn;
        public ProductDAO()
        {
            conn = dbConnection.getInstance();
        }

        public IQueryable<Product> getAll()
        {
            var query = conn.Products.Where(tg => tg.DeletedAt == null && tg.Category.DeletedAt == null);
            return (IQueryable<Product>)query;
        }

        public ProductPagination getAll(int skip, int limit)
        {
            var query = conn.Products.Where(tg => tg.DeletedAt == null && tg.Category.DeletedAt == null);
            var count = query.Count();
            query = query.OrderBy(t => t.CreatedAt).Skip(skip).Take(limit);
            return new ProductPagination(count, query);
        }

        public ProductPagination getProducts(int skip, int limit,string name)
        {
            var query = conn.Products.Where(tg => tg.DeletedAt == null && tg.Category.DeletedAt == null && tg.Name_Slug.Contains(name));
            var count = query.Count();
            query = query.OrderBy(t => t.CreatedAt).Skip(skip).Take(limit);
            return new ProductPagination(count, query);
        }

        public ProductPagination getProducts(int skip, int limit, string name , int categoryId)
        {
            var query = conn.Products.Where(tg => tg.DeletedAt == null && tg.Category.DeletedAt == null && tg.Name_Slug.Contains(name) && tg.Category.DeletedAt == null && tg.CatID == categoryId);
            var count = query.Count();
            query = query.OrderBy(t => t.CreatedAt).Skip(skip).Take(limit);
            return new ProductPagination(count, query);
        }

        public Product checkNameExist(string name)
        {
            var nameSlug = FunctionHelper.ConvertToSlug(name);
            var query = conn.Products.Where(co => co.Name_Slug.Equals(nameSlug) && co.DeletedAt == null && co.Category.DeletedAt == null).FirstOrDefault();
            return query;
        }

        public ProductPagination getProductsByCategoryId(int skip, int limit, int id)
        {
            var query = conn.Products.Where(tg => tg.DeletedAt == null && tg.CatID == id && tg.Category.DeletedAt == null);
            var count = query.Count();
            query = query.OrderBy(t => t.CreatedAt).Skip(skip).Take(limit);

            return new ProductPagination(count, query);
        }

        public Product insert(Product product)
        {
            var query = conn.Products.Add(product);
            conn.SaveChanges();
            return query;
        }

        public bool update(int id, Product product)
        {
            try
            {
                var query = conn.Products.Where(co => co.ID == id).FirstOrDefault();
                query.Name = product.Name;
                query.ImagePath = product.ImagePath;
                query.Price = product.Price;
                query.Quantity = product.Quantity;
                query.CatID = product.CatID;

                conn.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete(Product product)
        {
            product.DeletedAt = DateTime.Now;
            conn.SaveChanges();
            return true;
        }
    }

    public class ProductPagination
    {
        public int count;
        public IQueryable<Product> products;

        public ProductPagination(int count, IQueryable<Product> products)
        {
            this.count = count;
            this.products = products;
        }
    }
}
