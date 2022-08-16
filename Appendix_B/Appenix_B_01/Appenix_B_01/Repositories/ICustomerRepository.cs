﻿using Appenix_B_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);
    }
}