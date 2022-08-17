using Appenix_B_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    /// <summary>
    /// Extends interface of IRepository.
    /// Adds a few more specific methods to hande data
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer Search(string searchString);

        public IEnumerable<Customer> GetAllWithLimit(int offset, int limit);

        public IEnumerable<CustomerCountry> GetNumberOfCountries();

        public IEnumerable<CustomerSpender> HighestSpenders();

        public IEnumerable<CustomerGenre> MostPopularGenre(int id);


    }
}
