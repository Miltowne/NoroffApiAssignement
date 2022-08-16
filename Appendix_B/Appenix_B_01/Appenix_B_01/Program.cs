// See https://aka.ms/new-console-template for more information
using Appenix_B_01.ALT_Repositories;
using Appenix_B_01.Models;
using Appenix_B_01.Repositories;
using ICustomerRepository = Appenix_B_01.ALT_Repositories.ICustomerRepository;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // POCO

         ICustomerRepository repository = new CustomerRepositoryImpl();
        // CRUD
        TestGetAllWhitLimit(repository);
    }

    static void TestGetAllWhitLimit(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAllWhitLimit(40, 20));
    }

    static void TestSearchByString(ICustomerRepository repository)
    {
        PrintCustomer(repository.Search("barbaro"));
    }

    static void TestSelectAll(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAll());
    }
    static void TestSelect(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetById(1));
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
        if (repository.Add(test))
        {
            Console.WriteLine("Worked!");
            PrintCustomer(repository.GetById(63));
        }
        else
        {
            Console.WriteLine("not worked boooooh");
        }
    }

    static void TestUpdate(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetById(1));
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
        Console.WriteLine($"--- {customer.CustomerId} {customer.LastName} {customer.FirstName} {customer.Country}  {customer.Phone} {customer.Email} ---");
    }
}



