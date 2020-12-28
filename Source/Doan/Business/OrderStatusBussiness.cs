using Doan.Business.Interface;
using Doan.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business
{
    class OrderStatusBussiness : IOrderStatusBusiness
    {
        private OrderStatusDAO _orderStatusDAO;

        public OrderStatusBussiness()
        {
            _orderStatusDAO = new OrderStatusDAO();
        }
        public BindingList<OrderStatu> getAll()
        {
            return new BindingList<OrderStatu>(this._orderStatusDAO.getAll().ToList());
        }
    }
}
