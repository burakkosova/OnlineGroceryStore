using DataAccess.Abstract;
using Entities;
using System;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class CustomerDal : ICustomerDal
    {
        private string _connectionString = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a750bf_cc;User Id=db_a750bf_cc_admin;Password=admin123";
        public void Add(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Customers (FirstName,LastName,Email,Password,PhoneNumber,Address) VALUES(@firstName,@lastName,@email,@password,@phoneNumber,@address)", connection);
                    command.Parameters.AddWithValue("@firstName", customer.FirstName);
                    command.Parameters.AddWithValue("@lastName", customer.LastName);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@password", customer.Password);
                    command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Customers SET FirstName = @firstName,LastName = @lastName,Email = @email,PhoneNumber = @phoneNumber, Address = @address, ProfilePicture = @profilePicture WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@firstName", customer.FirstName);
                    command.Parameters.AddWithValue("@lastName", customer.LastName);
                    command.Parameters.AddWithValue("@email", customer.Email);
                    command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@address", customer.Address);
                    command.Parameters.AddWithValue("@profilePicture", customer.ProfilePicture);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void UpdatePassword(int customerId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Customers SET Password=@password WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", customerId);
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Delete(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Customers WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", customerId);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Customer GetByEmail(string email)
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Email = @email", connection);
                    command.Parameters.AddWithValue("@email", email);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        customer.Id = Convert.ToInt32(reader["Id"]);
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Email = reader["Email"].ToString();
                        customer.Password = reader["Password"].ToString();
                        customer.PhoneNumber = reader["PhoneNumber"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.ProfilePicture = reader["ProfilePicture"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return customer;
        }
    }
}
