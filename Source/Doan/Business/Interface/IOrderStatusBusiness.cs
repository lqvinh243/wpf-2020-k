using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business.Interface
{
    public interface IOrderStatusBusiness
    {
        BindingList<OrderStatu> getAll();
    }
}
