using Doan.ValueObject.ClientVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business.Interface
{
    public interface IClientBusiness
    {
        Client insertData(ClientCreateVO data);
        Client getByPhoneNumber(string PhoneNumber);
    }
}
