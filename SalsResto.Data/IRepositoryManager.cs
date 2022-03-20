﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsResto.Data
{
    public interface IRepositoryManager
    {
        IBookingRepository BookingRepo {get; }
        ICustomerRepository CustomerRepo {get; }
        Task SaveAsync();
    }
}
