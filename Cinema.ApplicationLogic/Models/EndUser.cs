using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Models
{
    public class EndUser : DataEntity
    {
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public static EndUser Create(string userId, string name, string email, string phone)
        {
            return new EndUser
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = name,
                Email = email,
                Phone = phone
            };
        }

        public EndUser Update(string name, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            return this;
        }
    }
}
