using Doan.Common;
using Doan.ValueObject.OrderProductVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.ValueObject.OrderVO
{
    public class OrderCreateVO : INotifyPropertyChanged
    {
        public string Code { get; set; }

        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BindingList<OrderProductCreateVO> orderProductVOs = new BindingList<OrderProductCreateVO>();

        public OrderCreateVO()
        {
            Code = FunctionHelper.RandomString(8);
            TotalAmount = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void PassValue(Order order)
        {
            this.Id = order.ID;
            this.CreatedAt = order.CreatedAt;
            this.Code = order.Code;
            this.TotalAmount = order.TotalAmount;
            orderProductVOs.Clear();
            var listOrder = order.OrderProducts.ToList();
            for (int i = 0; i < order.OrderProducts.Count(); i++)
            {
                orderProductVOs.Add(new OrderProductCreateVO(listOrder[i]));
            }
        }

        public void reset()
        {
            CreatedAt = DateTime.Now;
            Code = FunctionHelper.RandomString(8);
            TotalAmount = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            orderProductVOs.Clear();
        }

        public void PassValue(OrderCreateVO order)
        {
            this.Id = order.Id;
            this.CreatedAt = order.CreatedAt;
            this.Code = order.Code;
            this.TotalAmount = order.TotalAmount;
            orderProductVOs.Clear();
            var listOrder = order.orderProductVOs.ToList();
            for (int i = 0; i < order.orderProductVOs.Count(); i++)
            {
                orderProductVOs.Add(new OrderProductCreateVO(listOrder[i]));
            }
        }

        public OrderUpdateVO toOrderUpdateVO()
        {
            var ordU = new OrderUpdateVO()
            {
                TotalAmount = this.TotalAmount,
                UpdatedAt = this.UpdatedAt
            };

            for (int i = 0; i < this.orderProductVOs.Count(); i++)
            {
                var orderProduct = new OrderProductUpdateVO()
                {
                    ID = this.orderProductVOs[i].ID,
                    Amount = this.orderProductVOs[i].Amount,
                    ProductID = this.orderProductVOs[i].ProductID,
                    Name = this.orderProductVOs[i].Name,
                    TotalAmount = this.orderProductVOs[i].TotalAmount,
                    Quantity = this.orderProductVOs[i].Quantity
                };

                ordU.orderProductVOs.Add(orderProduct);
            }

            return ordU;
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
