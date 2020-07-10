using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFCustomerRepository : EFBaseRepository<Customer>, ICustomerRepository
    {
        public EFCustomerRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }

        public Customer GetByUserId(string userId)
        {
            return this.dbContext.Customers.Where(customer => customer.UserId == userId).SingleOrDefault();
        }
    }
}
