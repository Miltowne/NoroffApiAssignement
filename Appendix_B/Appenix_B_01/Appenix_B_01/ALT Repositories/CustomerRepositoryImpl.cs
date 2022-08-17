using Appenix_B_01.Models;
using Appenix_B_01.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    /// <summary>
    ///  Interface of ICustomerRepository.
    /// </summary>
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        /// <summary>
        /// Add method to INSERT IN TO customer.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(Customer entity)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Address, Email) VALUES(@FirstName, @LastName, @Address, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();
                    Console.WriteLine("Connected");
                    // Make A Command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        // Handle Result
                        //cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Address", entity.Address);
                        cmd.Parameters.AddWithValue("@Email", entity.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("sql exception " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }
        /// <summary>
        /// Delete method that is not in use.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method that updates the customer.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Edit(Customer entity)
        {
            bool success = false;
            string sql = $"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone WHERE CustomerId = {entity.CustomerId}";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Open Connection
                    Console.WriteLine("Connecting...");
                    conn.Open();
                    Console.WriteLine("Connected");
                    // Make A Command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Handle Result
                        cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Address", entity.Address);
                        cmd.Parameters.AddWithValue("@Email", entity.Email);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("sql exception " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }
        /// <summary>
        /// Method that gets all the customers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> tempList = new List<Customer>();
            string sql = "Select  CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                tempList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine(sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tempList;
        }

        /// <summary>
        /// Method that gets the subset of customers data.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllWhitLimit(int offset, int limit)
        {
            List<Customer> tempList = new List<Customer>();
            string sql = $" SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET {offset}  ROWS FETCH NEXT {limit}  ROWS ONLY";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? String.Empty : reader.GetString(3); // If value is null, set it to string (easier for foreachloop later on if value is not null)
                                temp.PostalCode = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
                                temp.Email = reader.IsDBNull(6) ? String.Empty : reader.GetString(6);
                                tempList.Add(temp);
                            }
                        }
                    }

                }
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("sql exception" + sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception generic" + ex.Message);
            }
            return tempList;
        }
        /// <summary>
        /// Method that gets the customers by (id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetById(int id)
        {
            Customer temp = new Customer();
            string sql = $"Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = {id}";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);

                            }
                        }
                    }

                }

            }
            catch (SqlException sqlex)
            {

                Console.WriteLine(sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return temp;
        }
        /// <summary>
        /// Method that gets the number of customers in each country (hight to low) USA at 13.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NumberOfCountriesCustomer> GetNumberOfCountries()
        {
            List<NumberOfCountriesCustomer> tempList = new List<NumberOfCountriesCustomer>();
            string sql = $"SELECT Country, COUNT(*) NumberOfCountries FROM Customer GROUP BY Country ORDER BY NumberOfCountries DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NumberOfCountriesCustomer temp = new NumberOfCountriesCustomer();
                                // If value is null, set it to string (easier for foreachloop later on if value is not null)
                                temp.Country = reader.IsDBNull(0) ? "No Country" : reader.GetString(0);
                                temp.NumberOfCountries = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                tempList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("sql exception" + sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception generic" + ex.Message);
            }
            return tempList;
        }
        /// <summary>
        /// Method that sort customer on highest spenders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> HighestSpenders()
        {
            List<Customer> tempList = new List<Customer>();
            string sql = $"SELECT Customer.FirstName, Customer.LastName, Invoice.Total FROM Customer INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId ORDER BY Invoice.Total DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                // If value is null, set it to string (easier for foreachloop later on if value is not null)
                                //temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(0);
                                temp.LastName = reader.GetString(1);
                                //SqlDecimal s = new SqlDecimal(reader.GetDecimal(2));
                                temp.Invoice.Total = reader.GetDecimal(2);
                                tempList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("sql exception" + sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception generic" + ex.Message);
            }
            return tempList;
        }
        /// <summary>
        /// Method that sort the most popular gener.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<GenreCountCustomer> MostPopularGenre(int id)
        {
            List<GenreCountCustomer> tempList = new List<GenreCountCustomer>();

            string sql = "with GenreCountTable as (" +
                "SELECT Genre.Name, COUNT(Genre.GenreId) AS genreCount " +
                "FROM Genre " +
                "JOIN Track " +
                "ON Genre.GenreId = Track.GenreId " +
                "JOIN InvoiceLine " +
                "ON InvoiceLine.TrackId = Track.TrackId " + 
                "JOIN Invoice " +
                "ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                "JOIN Customer " +
                $"ON Invoice.CustomerId = Customer.CustomerId WHERE Customer.CustomerId = {id} " +
                "GROUP BY Genre.Name) " +
                "(SELECT GenreCountTable.Name, GenreCountTable.genreCount " +
                "FROM GenreCountTable JOIN(SELECT MAX(genreCount) as maxCount FROM GenreCountTable) table2 " +
                "ON GenreCountTable.genreCount = table2.maxCount)";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GenreCountCustomer tempCustomer = new GenreCountCustomer();
                                tempCustomer.GenreName = reader.GetString(0);
                                tempCustomer.GenreCount = reader.GetInt32(1);
                                tempList.Add(tempCustomer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Genreric Error: " + ex.Message);
            }
            return tempList;
        }
        /// <summary>
        /// Method for serching on specific customer.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Customer Search(string searchString)
        {
            Customer temp = new Customer();
            string sql = $"Select CustomerId, FirstName, LastName, Country, Address, PostalCode, Phone, Email from Customer where Address like  '{searchString}%';";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    connection.Open();
                    Console.WriteLine("Connected");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.Address = reader.GetString(4);
                                temp.PostalCode = reader.GetString(5);
                                temp.Phone = reader.GetString(6);
                                temp.Email = reader.GetString(7);

                            }
                        }
                    }

                }

            }
            catch (SqlException sqlex)
            {

                Console.WriteLine(sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return temp;
        }



    }
}
