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
        TestCustomerCountries(repository);

        TestCustomerOrderedTotal(repository);

        TestGenreCount(repository);
    }
    static void TestCustomerCountries(ICustomerRepository repository)
    {
        PrintNumOfCountryCustomers(repository.GetNumberOfCountries());
    }
    static void PrintNumOfCountryCustomers(IEnumerable<NumberOfCountriesCustomer> customerCountries)
    {
        foreach (var customerCountry in customerCountries)
        {
            Console.WriteLine($"Number Of Customer: {customerCountry.NumberOfCountries} In: {customerCountry.Country}");

        }
    }
    static void TestGenreCount(ICustomerRepository repository)
    {
        
        var customer = repository.GetById(56);
        PrintGenreCountCustomer(repository.MostPopularGenre(56), customer);
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

    static void TestCustomerOrderedTotal(ICustomerRepository repository)
    {
        PrintCustomers(repository.HighestSpenders());
    }

    static void TestInsert(ICustomerRepository repository)
    {
        var TestAdd = new Customer("Pelle", "Jansson", "Pelle@hotmail.com")
        {
            Company = "swederkgn",
            Address = "LarssonStreet",
            City = "Norrköping",
            Country = "Sweden",
            Fax = "",
            Phone = "2435789",
            PostalCode = "3456",
            State = "aesfg"
        };
        if (repository.Add(TestAdd))
        {
            Console.WriteLine("Worked!");
            PrintCustomer(repository.GetById(64));
        }
        else
        {
            Console.WriteLine("not worked boooooh");
        }
    }

    static void TestUpdate(ICustomerRepository repository)
    {
        var testAdd = new Customer("Pelle", "Jansson", "Pelle@hotmail.com")
        {
            CustomerId = 1,
            Company = "swederkgn",
            Address = "LarssonStreet",
            City = "Norrköping",
            Country = "Sweden",
            Fax = "",
            Phone = "2435789",
            PostalCode = "3456",
            State = "aesfg",
        };
        if (repository.Edit(testAdd))
        {
            Console.WriteLine("Success! Updated an customer!");
            PrintCustomer(repository.GetById(1));
        }
        else
        {
            Console.WriteLine("Not a good day.. a customer couldn't update customer");
        }
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
        if(customer.Invoice.Total > 0)
        {
            Console.WriteLine($"---Id: {customer.CustomerId} LastName: {customer.LastName} FirstName: {customer.FirstName} Country: {customer.Country} Phone number: {customer.Phone} email: {customer.Email} total: {customer.Invoice.Total} ---");

        }
        else Console.WriteLine($"---Id: {customer.CustomerId} LastName: {customer.LastName} FirstName: {customer.FirstName} Country: {customer.Country} Phone number: {customer.Phone} email: {customer.Email} ---");
    }

    static void PrintGenreCountCustomer(IEnumerable<GenreCountCustomer> genreCount, Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName} \n Have: ");
        foreach (var _genreCount in genreCount)
        {
            Console.WriteLine($"Count: {_genreCount.GenreCount} Of genre: {_genreCount.GenreName} \n");
        }
    }
}



