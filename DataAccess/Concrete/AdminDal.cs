using DataAccess.Abstract;
using Entities;
using System;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class AdminDal : IAdminDal
    {
        private string _connectionString = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a750bf_cc;User Id=db_a750bf_cc_admin;Password=admin123";
        public Admin GetByEmail(string email)
        {
            Admin admin = new Admin();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Admins WHERE Email = @email", connection);
                    command.Parameters.AddWithValue("@email", email);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        admin.Id = Convert.ToInt32(reader["Id"]);
                        admin.FirstName = reader["FirstName"].ToString();
                        admin.LastName = reader["LastName"].ToString();
                        admin.Email = reader["Email"].ToString();
                        admin.Password = reader["Password"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return admin;
        }
    }
}
