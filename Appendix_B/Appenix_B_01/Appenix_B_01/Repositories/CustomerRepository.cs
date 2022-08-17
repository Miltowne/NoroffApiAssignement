using Appenix_B_01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> cusList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Address FROM customer";
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();
                    Console.WriteLine("Connected");

                    // Make A Command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle Result
                                Customer temp = new Customer(reader.GetString(1), reader.GetString(2), );
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Address = reader.GetString(3);
                                cusList.Add(temp);
                            }
                        }
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
            return cusList;

        }

        public Customer GetCustomer(int id)
        {
            Customer temp = new Customer();

            string sql = "SELECT CustomerId, FirstName, LastName, Address FROM Customer " + $"WHERE Customer.CustomerId = {id}";
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

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle Result
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Address = reader.GetString(3);
                            }
                        }
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
            return temp;
        }

        public bool DeleteCustomer(string id)
        {

            return true;
        }

        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Address, Email) VALUES('Pele', 'Jansson', 'sfghj', '@Email')";
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
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);


            //            CustomerId = 40,
            //FirstName = "Pelle",
            //LastName = "Larsson",
            //Company = "swederkgn",
            //Email = "adam@adam.se",
            //Address = "LarssonStreet",
            //City = "Norrköping",
            //Country = "Sweden",
            //Fax = "",
            //Phone = "2435789",
            //PostalCode = "3456",
            //State = "aesfg",
            //SupportRepId = 1
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


        public bool UpdateCustomer(Customer customer)
        {
            return false;
        }
    }
}
