using Doan.ValueObject.ProductVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business.Interface
{
    public interface IProductBusiness
    {
        BindingList<Product> getAll();
        ProductPaginationBus getAll(int skip, int limit);
        ProductPaginationBus getProductsByCategoryId(int skip, int limit, int id);
        ProductPaginationBus getProductsByName(int skip, int limit, string name);
        ProductPaginationBus getProductsByCategoryIdAndName(int skip, int limit, string name, int id);
        Product checkNameExist(string name);
        Product insert(ProductCreateVO product);
        bool update(int id, ProductUpdateVO data);
        bool delete(Product product);
    }
}
