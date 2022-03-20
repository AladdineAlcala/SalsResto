using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsResto.Data.Models;

namespace SalsResto.Data
{
    public interface ICustomerRepository
    {
       Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges);
       Task<Customer> GetCustomerInfoByIdAsync(Guid id,bool trackChanges);
        void CreateCustomer(Customer customer);


    }
}
