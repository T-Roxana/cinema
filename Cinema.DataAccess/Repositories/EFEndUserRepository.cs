using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFEndUserRepository : EFBaseRepository<EndUser>, IEndUserRepository
    {
        public EFEndUserRepository(CinemaDbContext dbContext) : base(dbContext)
        {
        }

        public EndUser GetByUserId(string userId)
        {
            return this.dbContext.EndUsers.Where(endUser => endUser.UserId == userId).SingleOrDefault();
        }
    }
}
