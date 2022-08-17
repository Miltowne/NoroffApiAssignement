// See https://aka.ms/new-console-template for more information
using Appenix_B_01.ALT_Repositories;
using Appenix_B_01.Models;
using Appenix_B_01.Repositories;
using ICustomerRepository = Appenix_B_01.ALT_Repositories.ICustomerRepository;

class Program
{
    /// <summary>
    /// Creates a Customer Repository and test runs it trough some tests
    /// Press "run" to view the results
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        ICustomerRepository repository = new CustomerRepositoryImpl();

        TestCustomerCountries(repository);

        TestHighestSpenders(repository);

        TestCustomerGenre(repository);

        TestUpdate(repository);

        TestGetAllWithLimit(repository);

        TestSearchByString(repository);
    }
    /// <summary>
    /// Prints the number of customers in each country (hight to low) USA at 13.
    /// </summary>
    /// <param name="repository"></param>
    static void TestCustomerCountries(ICustomerRepository repository)
    {
        PrintCustomerCountry(repository.GetNumberOfCountries());
    }
    /// <summary>
    /// For given customer, their most popular gener that corresponds to the most tracks from invoice associated to that customer.
    /// </summary>
    /// <param name="repository"></param>
    static void TestCustomerGenre(ICustomerRepository repository)
    {
        
        var customer = repository.GetById(56);
        PrintGenreCountCustomer(repository.MostPopularGenre(56), customer);
    }
    /// <summary>
    /// Prints customer from database geting subset of customers data
    /// based on the offset and limit values
    /// </summary>
    /// <param name="repository"></param>
    static void TestGetAllWithLimit(ICustomerRepository repository)
    {
        PrintCustomers(repository.GetAllWithLimit(40, 20));
    }
    /// <summary>
    /// Prints the specific search of customers firstname in the database.
    /// </summary>
    /// <param name="repository"></param>
    static void TestSearchByString(ICustomerRepository repository)
    {
        PrintCustomer(repository.Search("a"));
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
    static void TestHighestSpenders(ICustomerRepository repository)
    {
        PrintHighestSpenders(repository.HighestSpenders());
    }
    /// <summary>
    /// Inserts a new customer. Gets added last in database
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
    /// Updates an customer of given id
    /// </summary>
    /// <param name="repository"></param>
    static void TestUpdate(ICustomerRepository repository)
    {
        var testAdd = new Customer()
        {
            CustomerId = 1,
            FirstName = "Pelle",
            LastName = "Karlsson",
            Email = "Pelle@gmail.com",
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
    /// Prints number of customers in each country.
    /// </summary>
    /// <param name="customerCountries"></param>
    static void PrintCustomerCountry(IEnumerable<CustomerCountry> customerCountries)
    {
        foreach (var customerCountry in customerCountries)
        {
            Console.WriteLine($"Number Of Customer: {customerCountry.NumberOfCountries} In: {customerCountry.Country}");

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
        Console.WriteLine($"---Id: {customer.CustomerId} LastName: {customer.LastName} FirstName: {customer.FirstName} Country: {customer.Country} Phone number: {customer.Phone} email: {customer.Email} ---");
    }
    /// <summary>
    /// Prints ganre count and customer.
    /// </summary>
    /// <param name="genreCount"></param>
    /// <param name="customer"></param>
    static void PrintGenreCountCustomer(IEnumerable<CustomerGenre> genreCount, Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName} \n Have: ");
        foreach (var _genreCount in genreCount)
        {
            Console.WriteLine($"Count: {_genreCount.GenreCount} Of genre: {_genreCount.GenreName} \n");
        }
    }
    /// <summary>
    /// Prints highest spenders
    /// </summary>
    /// <param name="cusSpenders"></param>
    static void PrintHighestSpenders(IEnumerable<CustomerSpender> cusSpenders)
    {
        foreach (var cusSpender in cusSpenders)
        {
            PrintHighestSpender(cusSpender);
        }
    }
    /// <summary>
    /// Prints a highest spender
    /// </summary>
    /// <param name="cusSpender"></param>
    static void PrintHighestSpender(CustomerSpender cusSpender)
    {
        Console.WriteLine($"FirstName: {cusSpender.FirstName} LastName: {cusSpender.LastName} Total: {cusSpender.Total}");
    }
}



