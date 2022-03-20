using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalsResto.Data;
using SalsResto.Data.Models;

namespace SalsResto.Repository
{
    public class CustomerRepository:RepositoryBase<Customer> ,ICustomerRepository
    {
        public CustomerRepository(SalsApplicationDbContext RepoSalsApplicationDbContext) :base(RepoSalsApplicationDbContext)
        {
            
        }

        public void CreateCustomer(Customer customer) => Create(customer);


        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges) =>
                                                                      await  FindAll(trackChanges)
                                                                        .OrderBy(c => c.lastname)
                                                                        .ToListAsync();

        public async Task<Customer> GetCustomerInfoByIdAsync(Guid id, bool trackChanges) =>
                                                                    await FindByCondition(c => c.Id == id, trackChanges).FirstOrDefaultAsync();

    }
}
