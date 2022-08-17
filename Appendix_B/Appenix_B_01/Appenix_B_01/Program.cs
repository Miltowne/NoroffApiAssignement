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
    /// <summary>
    /// Prints the number of customers in each country (hight to low) USA at 13.
    /// </summary>
    /// <param name="repository"></param>
    static void TestCustomerCountries(ICustomerRepository repository)
    {
        PrintNumOfCountryCustomers(repository.GetNumberOfCountries());
    }
    /// <summary>
    /// Prints number of customers in each country.
    /// </summary>
    /// <param name="customerCountries"></param>
    static void PrintNumOfCountryCustomers(IEnumerable<NumberOfCountriesCustomer> customerCountries)
    {
        foreach (var customerCountry in customerCountries)
        {
            Console.WriteLine($"Number Of Customer: {customerCountry.NumberOfCountries} In: {customerCountry.Country}");

        }
    }
    /// <summary>
    /// For given customer, their most popular gener that corresponds to the most tracks from invoice associated to that customer.
    /// </summary>
    /// <param name="repository"></param>
    static void TestGenreCount(ICustomerRepository repository)
    {
        
        var customer = repository.GetById(56);
        PrintGenreCountCustomer(repository.MostPopularGenre(56), customer);
    }
    /// <summary>
    /// Prints customer from database geting subset of customers data.
    /// </summary>
    /// <param name="repository"></param>
    static void TestGetAllWhitLimit(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAllWhitLimit(40, 20));
    }
    /// <summary>
    /// Prints the specific search of customer in the database.
    /// </summary>
    /// <param name="repository"></param>
    static void TestSearchByString(ICustomerRepository repository)
    {
        PrintCustomer(repository.Search("barbaro"));
    }
    /// <summary>
    ///  Prints all the customers in the database.
    /// </summary>
    /// <param name="repository"></param>
    static void TestSelectAll(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAll());
    }
    /// <summary>
    /// Prints the customer by (id).
    /// </summary>
    /// <param name="repository"></param>
    static void TestSelect(ICustomerRepository repository)
    {
        PrintCustomer(repository.GetById(1));
    }
    /// <summary>
    /// Sorting customers on higest spenders.
    /// </summary>
    /// <param name="repository"></param>
    static void TestCustomerOrderedTotal(ICustomerRepository repository)
    {
        PrintCustomers(repository.HighestSpenders());
    }
    /// <summary>
    /// Inserts a new customer.
    /// </summary>
    /// <param name="repository"></param>
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
    /// <summary>
    /// Updates the created customer.
    /// </summary>
    /// <param name="repository"></param>
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
    /// <summary>
    /// Prints out all the customers.
    /// </summary>
    /// <param name="customers"></param>
    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (var customer in customers)
        {
            PrintCustomer(customer);
        }
    }
    /// <summary>
    /// Prints a customer.
    /// </summary>
    /// <param name="customer"></param>
    static void PrintCustomer(Customer customer)
    {
        if(customer.Invoice.Total > 0)
        {
            Console.WriteLine($"---Id: {customer.CustomerId} LastName: {customer.LastName} FirstName: {customer.FirstName} Country: {customer.Country} Phone number: {customer.Phone} email: {customer.Email} total: {customer.Invoice.Total} ---");

        }
        else Console.WriteLine($"---Id: {customer.CustomerId} LastName: {customer.LastName} FirstName: {customer.FirstName} Country: {customer.Country} Phone number: {customer.Phone} email: {customer.Email} ---");
    }
    /// <summary>
    /// Prints ganre count and customer.
    /// </summary>
    /// <param name="genreCount"></param>
    /// <param name="customer"></param>
    static void PrintGenreCountCustomer(IEnumerable<GenreCountCustomer> genreCount, Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName} \n Have: ");
        foreach (var _genreCount in genreCount)
        {
            Console.WriteLine($"Count: {_genreCount.GenreCount} Of genre: {_genreCount.GenreName} \n");
        }
    }
}



