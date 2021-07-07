using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {
        private string _connectionString = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a750bf_cc;User Id=db_a750bf_cc_admin;Password=admin123";
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            Description = reader["Description"].ToString(),
                            FileName = reader["FileName"].ToString()
                        };
                        products.Add(product);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return products;
        }
        public Product GetById(int id)
        {
            Product product = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = reader["Name"].ToString();
                        product.Price = Convert.ToDouble(reader["Price"]);
                        product.Description = reader["Description"].ToString();
                        product.FileName = reader["FileName"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return product;
        }
        public void Add(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Products (Name,Price,Description,FileName) VALUES(@name,@price,@description,@fileName)", connection);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@fileName", product.FileName);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Products SET Name = @name,Price = @price,Description = @description,FileName = @fileName WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", product.Id);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@fileName", product.FileName);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Products WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", productId);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
