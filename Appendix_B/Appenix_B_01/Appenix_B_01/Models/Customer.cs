using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.Models
{
    /// <summary>
    /// Model of customer with properties
    /// </summary>
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string _firstName, string _lastName, string _email)
        {
            FirstName = _firstName;
            LastName = _lastName; 
            Email = _email;
        }

        public int CustomerId { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string? Company { get; set; } 
        public string? Address { get; set; } 
        public string? City { get; set; } 
        public string? State { get; set; } 
        public string? Country { get; set; } 
        public string? PostalCode { get; set; } 
        public string? Phone { get; set; } 
        public string? Fax { get; set; } 
        public string Email { get; set; } 
        public int SupportRepId { get; set; }

    }
}
