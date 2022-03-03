using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalsResto.Data;

namespace SalsResto.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private SalsApplicationDbContext _salsappDbContext;
        private ICustomerRepository _customerRepository;
        private IBookingRepository _bookingRepository;
        public RepositoryManager(SalsApplicationDbContext salsappDbContext)
        {
            _salsappDbContext = salsappDbContext;
        }


        public ICustomerRepository CustomerRepo
        {
            get
            {
                if (_customerRepository == null) return _customerRepository= new CustomerRepository(_salsappDbContext);

                return _customerRepository;
            }
        }

        public IBookingRepository BookingRepo
        {
            get
            {
                if (_bookingRepository == null) return _bookingRepository= new BookingRepository(_salsappDbContext);

                return _bookingRepository;
            }
        }

      
        public void Save()
        {
            _salsappDbContext.SaveChanges();
        }
    }
}
