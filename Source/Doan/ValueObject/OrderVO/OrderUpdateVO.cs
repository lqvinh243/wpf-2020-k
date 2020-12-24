using Doan.ValueObject.OrderProductVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.ValueObject.OrderVO
{
    public class OrderUpdateVO
    {
        public string Code { get; set; }

        public DateTime UpdatedAt { get; set; }
        public double TotalAmount { get; set; }

        public BindingList<OrderProductUpdateVO> orderProductVOs = new BindingList<OrderProductUpdateVO>();

        public Order toOrder()
        {
            var order = new Order()
            {
                TotalAmount = this.TotalAmount,
                UpdatedAt = this.UpdatedAt
            };

            var orderProducts = new List<OrderProduct>();

            for (int i = 0; i < this.orderProductVOs.Count(); i++)
            {
                var orderProduct = new OrderProduct()
                {
                    ID = this.orderProductVOs[i].ID,
                    Amount = this.orderProductVOs[i].Amount,
                    ProductID = this.orderProductVOs[i].ProductID,
                    Name = this.orderProductVOs[i].Name,
                    TotalAmount = this.orderProductVOs[i].TotalAmount,
                    Quantity = this.orderProductVOs[i].Quantity
                };

                order.OrderProducts.Add(orderProduct);
            }

            return order;
        }
    }
}
