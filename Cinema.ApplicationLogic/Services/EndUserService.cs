using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Services
{
    public class EndUserService
    {
        private readonly IEndUserRepository endUserRepository;

        public EndUserService(IEndUserRepository endUserRepository)
        {
            this.endUserRepository = endUserRepository;
        }

        public EndUser GetById(Guid id)
        {
            return endUserRepository.GetById(id);
        }

        public EndUser GetByUserId(string userId)
        {
            return endUserRepository.GetByUserId(userId);
        }

        public EndUser Add(string userId, string name, string email, string phone)
        {
            var endUserToAdd = EndUser.Create(userId, name, email, phone);
            return endUserRepository.Add(endUserToAdd);
        }

        public EndUser Update(Guid id, string name, string email, string phone)
        {
            var endUserToUpdate = GetById(id);
            endUserToUpdate.Update(name, email, phone);
            return endUserRepository.Update(endUserToUpdate);
        }
    }
}
