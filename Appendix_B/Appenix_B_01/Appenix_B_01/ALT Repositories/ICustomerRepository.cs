using Appenix_B_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer Search(string searchString);

        public IEnumerable<Customer> GetAllWhitLimit(int offset, int limit);


               
    }
}
