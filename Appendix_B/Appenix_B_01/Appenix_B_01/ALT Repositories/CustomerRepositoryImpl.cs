using Appenix_B_01.Models;
using Appenix_B_01.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
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

        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

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

        
        public IEnumerable<Customer> GetAllWhitLimit(int offset, int limit)
        {
            List<Customer> tempList = new List<Customer>();
            string sql = $" SELECT CustomerId, FirstName, LastName, Country, PostalCode FROM Customer ORDER BY CustomerId OFFSET {offset}  ROWS FETCH NEXT {limit}  ROWS ONLY";
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
                                //temp.Company = reader.GetString(2);
                                //temp.Address = reader.GetString(3) == null ? "null" : reader.GetString(3);
                                //temp.City = reader.GetString(4) == null ? "null" : reader.GetString(4);
                                ////temp.State = reader.GetString(4);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4) == null ? "null" : reader.GetString(4);
                                //temp.Phone = reader.GetString(7) == null ? "null" : reader.GetString(7);
                                ////temp.Fax = reader.GetString(7)
                                ////temp.Email = reader.GetString(10);

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
