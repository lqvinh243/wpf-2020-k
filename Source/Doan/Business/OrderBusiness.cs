using Doan.Business.Interface;
using Doan.DAO;
using Doan.ValueObject.OrderProductVO;
using Doan.ValueObject.OrderVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private OrderDAO _orderDAO;

        public OrderBusiness()
        {
            _orderDAO = new OrderDAO();
        }
        public BindingList<Order> getAll()
        {
            var t = _orderDAO.getAll();
            return new BindingList<Order>(t.ToList());
        }

        public OrderPaginationBus getAll(int skip, int limit)
        {
            var t = _orderDAO.getAll(skip, limit);
            return new OrderPaginationBus(t.count, t.orders.ToList());
        }

        public OrderPaginationBus getAll(int skip, int limit, string code)
        {
            var t = _orderDAO.getAll(skip, limit);
            return new OrderPaginationBus(t.count, t.orders.ToList());
        }

        public Order InsertData(OrderCreateVO data, List<OrderProductCreateVO> products)
        {
            throw new NotImplementedException();
        }

        public Order InsertData(OrderCreateVO data)
        {
            var order = new Order()
            {
                Code = data.Code,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
                TotalAmount = data.TotalAmount
            };

            var orderInsert = _orderDAO.insert(order);
            var orderProducts = new List<OrderProduct>();

            for (int i = 0; i < data.orderProductVOs.Count(); i++)
            {
                var orderProduct = new OrderProduct()
                {
                    Amount = data.orderProductVOs[i].Amount,
                    ProductID = data.orderProductVOs[i].ProductID,
                    Name = data.orderProductVOs[i].Name,
                    TotalAmount = data.orderProductVOs[i].TotalAmount,
                    CreatedAt = data.orderProductVOs[i].CreatedAt,
                    UpdatedAt = data.orderProductVOs[i].UpdatedAt,
                    Quantity = data.orderProductVOs[i].Quantity,
                    OrderID = orderInsert.ID
                };

                orderInsert.OrderProducts.Add(orderProduct);
            }

            var orderUpdate = _orderDAO.update(orderInsert);
            return orderUpdate;
        }

        public Order update(int id,OrderUpdateVO data)
        {
            return _orderDAO.update(id,data.toOrder());
        }

        public Order update(OrderCreateVO data)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderPaginationBus
    {
        public int count;
        public List<Order> orders;

        public OrderPaginationBus(int count, List<Order> orders)
        {
            this.count = count;
            this.orders = orders;
        }
    }
}
