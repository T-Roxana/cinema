using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Abstractions
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        Customer GetByUserId(string userId);
    }
}
