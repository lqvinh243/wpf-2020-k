using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.State
{
    //Action: 1-view,2-update,3-create
    public static class OrderState
    {
        public static BindingList<Order> ordersState = new BindingList<Order>();
        public static BindingList<OrderStatu> ordersStatus = new BindingList<OrderStatu>();
        public static int Action = 1;
        public static Pagination pagination = new Pagination();

        public class Pagination : INotifyPropertyChanged
        {
            public int total { get; set; }
            public int limit { get; set; }
            public int skip { get; set; }
            public bool next { get; set; }
            public bool previus { get; set; }

            public Pagination()
            {
                this.skip = 0;
                this.limit = 6;
                this.next = false;
                this.previus = false;
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
