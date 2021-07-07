using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class ShoppingCartDal : IShoppingCartDal
    {
        private string _connectionString = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a750bf_cc;User Id=db_a750bf_cc_admin;Password=admin123";
        public List<ShoppingCart> GetByCustomerId(int customerId)
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ShoppingCarts sc JOIN Products p ON sc.ProductId = p.Id WHERE CustomerId = @id", connection);
                    command.Parameters.AddWithValue("@id", customerId);
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

                        ShoppingCart shoppingCart = new ShoppingCart
                        {
                            Product = product,
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Amount = Convert.ToInt32(reader["Amount"])
                        };
                        shoppingCarts.Add(shoppingCart);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return shoppingCarts;
        }
        public ShoppingCart Get(int customerId, int productId)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ShoppingCarts WHERE CustomerId = @customerId AND ProductId = @productId", connection);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@productId", productId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        shoppingCart.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                        shoppingCart.Product = new Product { Id = Convert.ToInt32(reader["ProductId"]) };
                        shoppingCart.Amount = Convert.ToInt32(reader["Amount"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return shoppingCart;
        }
        public void Add(ShoppingCart shoppingCart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO ShoppingCarts (CustomerId,ProductId,Amount) VALUES(@customerId,@productId,@amount)", connection);
                    command.Parameters.AddWithValue("@customerId", shoppingCart.CustomerId);
                    command.Parameters.AddWithValue("@productId", shoppingCart.Product.Id);
                    command.Parameters.AddWithValue("@amount", shoppingCart.Amount);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Update(ShoppingCart shoppingCart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE ShoppingCarts SET Amount = @amount WHERE CustomerId=@customerId AND ProductId=@productId", connection);
                    command.Parameters.AddWithValue("@amount", shoppingCart.Amount);
                    command.Parameters.AddWithValue("@customerId", shoppingCart.CustomerId);
                    command.Parameters.AddWithValue("@productId", shoppingCart.Product.Id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Delete(ShoppingCart shoppingCart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM ShoppingCarts WHERE CustomerId=@customerId AND ProductId=@productId", connection);
                    command.Parameters.AddWithValue("@customerId", shoppingCart.CustomerId);
                    command.Parameters.AddWithValue("@productId", shoppingCart.Product.Id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void ClearCart(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM ShoppingCarts WHERE CustomerId=@customerId", connection);
                    command.Parameters.AddWithValue("@customerId", customerId);
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
