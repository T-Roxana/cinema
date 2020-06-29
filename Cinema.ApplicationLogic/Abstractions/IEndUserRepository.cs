using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Abstractions
{
    public interface IEndUserRepository : IBaseRepository<EndUser>
    {
        EndUser GetByUserId(string userId);
    }
}
