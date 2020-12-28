using Doan.Business.Interface;
using Doan.DAO;
using Doan.ValueObject.ClientVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Business
{
    class ClientBusiness : IClientBusiness
    {
        private ClientDAO _clientDAO;

        public ClientBusiness()
        {
            _clientDAO = new ClientDAO();
        }

        public Client getByPhoneNumber(string PhoneNumber)
        {
            return _clientDAO.findByPhoneNumber(PhoneNumber);
        }

        public Client insertData(ClientCreateVO data)
        {
            var client = new Client()
            {
                PhoneNumber = data.PhoneNumber,
                Name = data.Name,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt
            };

            return _clientDAO.insert(client);
        }
    }
}
