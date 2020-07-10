using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.ApplicationLogic.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetById(Guid id)
        {
            return customerRepository.GetById(id);
        }

        public Customer GetByUserId(string userId)
        {
            return customerRepository.GetByUserId(userId);
        }

        public Customer Add(string userId, string name, string email, string phone)
        {
            var customerToAdd = Customer.Create(userId, name, email, phone);
            return customerRepository.Add(customerToAdd);
        }

        public Customer Update(Guid id, string name, string email, string phone)
        {
            var customerToUpdate = GetById(id);
            customerToUpdate.Update(name, email, phone);
            return customerRepository.Update(customerToUpdate);
        }
    }
}
