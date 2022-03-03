using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsResto.Data;
using SalsResto.Data.Models;

namespace SalsResto.Repository
{
    public class CustomerRepository:RepositoryBase<Customer> ,ICustomerRepository
    {
        public CustomerRepository(SalsApplicationDbContext RepoSalsApplicationDbContext) :base(RepoSalsApplicationDbContext)
        {
            
        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
                                                                        FindAll(trackChanges)
                                                                        .OrderBy(c => c.lastname)
                                                                        .ToList();

    }
}
