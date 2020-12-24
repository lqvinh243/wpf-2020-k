using Doan.ValueObject.OrderProductVO;
using Doan.ValueObject.OrderVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business.Interface
{
    public interface IOrderBusiness
    {
        BindingList<Order> getAll();

        OrderPaginationBus getAll(int skip, int limit);

        OrderPaginationBus getAll(int skip, int limit, string code);

        Order InsertData(OrderCreateVO data);
        Order InsertData(OrderCreateVO data, List<OrderProductCreateVO> products);

        Order update(OrderCreateVO data);

        bool deleteById(int id);

    }
}
