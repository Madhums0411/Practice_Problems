using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.Model;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly string ConnectionString;
        public UserRL(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("Addressbooksql");
        }
        public UserModel userRegistration(UserModel userRegister)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("UserRegister", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", userRegister.FirstName);
                command.Parameters.AddWithValue("@LastName", userRegister.LastName);
                command.Parameters.AddWithValue("@Email", userRegister.Email);
                command.Parameters.AddWithValue("@Password", userRegister.Password);
                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();
                if (result != null)
                {
                    return userRegister;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
