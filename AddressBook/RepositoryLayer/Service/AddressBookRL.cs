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
    public class AddressBookRL : IAddressBookRL
    {
        private readonly string ConnectionString;
        public AddressBookRL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Addressbooksql");
        }
        public AddressBookModel CreateAddressBook(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand Address = new SqlCommand("SpAddressBook", connection);
                Address.CommandType = CommandType.StoredProcedure;
                Address.Parameters.AddWithValue("@FirstName", model.FirstName);
                Address.Parameters.AddWithValue("@LastName", model.LastName);
                Address.Parameters.AddWithValue("@Email", model.Email);
                Address.Parameters.AddWithValue("@Mobile", model.Mobile);
                Address.Parameters.AddWithValue("@Address", model.Address);
                Address.Parameters.AddWithValue("@City", model.City);
                Address.Parameters.AddWithValue("@State", model.State);
                Address.Parameters.AddWithValue("@Pincode", model.Pincode);
                connection.Open();
                var result = Address.ExecuteNonQuery();
                connection.Close();
                if (result != null)
                {
                    return model;
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
