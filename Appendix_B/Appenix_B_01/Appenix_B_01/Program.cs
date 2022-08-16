// See https://aka.ms/new-console-template for more information
using Appenix_B_01.Models;
using Appenix_B_01.Repositories;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // POCO

         ICustomerRepository repository = new CustomerRepository();
        // CRUD
        TestInsert(repository);
    }


    static void TestSelectAll(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAllCustomers());
    }
    static void TestSelect(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetCustomer(1));
    }

    static void TestInsert(ICustomerRepository repository)
    {
        Customer test = new Customer()
        {
            CustomerId = 62,
            FirstName = "Pelle",
            LastName = "Larsson",
            Company = "swederkgn",
            Email = "adam@adam.se",
            Address = "LarssonStreet",
            City = "Norrköping",
            Country = "Sweden",
            Fax = "",
            Phone = "2435789",
            PostalCode = "3456",
            State = "aesfg",
            SupportRepId = 1
        };
        if (repository.AddNewCustomer(test))
        {
            Console.WriteLine("Worked!");
            PrintCustomer(repository.GetCustomer(63));
        }
        else
        {
            Console.WriteLine("not worked boooooh");
        }
    }

    static void TestUpdate(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetCustomer(1));
    }
    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (var customer in customers)
        {
            PrintCustomer(customer);
        }
    }

    static void PrintCustomer(Customer customer)
    {
        Console.WriteLine($"--- {customer.CustomerId} {customer.LastName} {customer.FirstName} ---");
    }
}



