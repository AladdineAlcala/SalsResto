using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SalsResto.Data;
using SalsResto.Data.Models;

namespace SalsResto.Repository
{
    public class BookingRepository:RepositoryBase<Booking> , IBookingRepository
    {
        public BookingRepository(SalsApplicationDbContext RepoSalsApplicationDbContext) :base(RepoSalsApplicationDbContext)
        {
            
        }
    }
}
