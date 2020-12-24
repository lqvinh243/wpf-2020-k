using Doan.Business.Interface;
using Doan.Common;
using Doan.DAO;
using Doan.State;
using Doan.ValueObject.ProductVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business
{
    public class ProductBusiness : IProductBusiness
    {

        private ProductDAO _productDAO;
        public ProductBusiness()
        {
            _productDAO = new ProductDAO();
        }

        public Product checkNameExist(string name)
        {
            var t = _productDAO.checkNameExist(name);
            return t;
        }

        public bool delete(Product product)
        {
            return _productDAO.delete(product);
        }

        public ProductPaginationBus getAll(int skip, int limit)
        {
            var t = this._productDAO.getAll(skip, limit);
            return new ProductPaginationBus(t.count, t.products.ToList());
        }

        public BindingList<Product> getAll()
        {
            return new BindingList<Product>(this._productDAO.getAll().ToList());
        }

        public ProductPaginationBus getProductsByCategoryId(int skip, int limit, int id)
        {
            var t = this._productDAO.getProductsByCategoryId(skip, limit, id);
            return new ProductPaginationBus(t.count, t.products.ToList());
        }

        public ProductPaginationBus getProductsByCategoryIdAndName(int skip, int limit, string name, int id)
        {
            name = FunctionHelper.ConvertToSlug(name);
            var t = this._productDAO.getProducts(skip, limit, name, id);
            return new ProductPaginationBus(t.count, t.products.ToList());
        }

        public ProductPaginationBus getProductsByName(int skip, int limit, string name)
        {
            name = FunctionHelper.ConvertToSlug(name);
            var t = this._productDAO.getProducts(skip, limit, name);
            return new ProductPaginationBus(t.count, t.products.ToList());
        }

        public Product insert(ProductCreateVO product)
        {
            var productModel = new Product()
            {
                Name = product.name,
                CatID = product.catId,
                Price = product.price,
                Quantity = product.quantity,
                SKU = FunctionHelper.generalSKU("product"),
                Name_Slug = FunctionHelper.ConvertToSlug(product.name),
                ImagePath = product.imagePath,
                CreatedAt = product.createdAt,
                UpdatedAt = product.updatedAt,
                Description = product.description
                
            };

            var t = this._productDAO.insert(productModel);

            return t;
        }

        public bool update(int id, ProductUpdateVO data)
        {
            var product = new Product()
            {
                UpdatedAt = data.updatedAt,
                Name = data.name,
                Price = data.price,
                Quantity = data.quantity,
                ImagePath = data.imagePath,
                CatID = data.catId
            };

            return _productDAO.update(id, product);
        }

        public bool updateQuantityById(int id,int quanity)
        {
            return this._productDAO.updateQuantityById(id, quanity);
        }
    }

    public class ProductPaginationBus
    {
        public int count;
        public List<Product> products;

        public ProductPaginationBus(int count, List<Product> products)
        {
            this.count = count;
            this.products = products;
        }
    }
}
