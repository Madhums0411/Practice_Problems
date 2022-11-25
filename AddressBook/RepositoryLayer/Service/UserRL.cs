using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
                command.Parameters.AddWithValue("@Password", EncryptPassword(userRegister.Password));
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
        public string UserLogin(UserLoginModel userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                string Password = "";
                long Id = 0;
                SqlCommand cmd = new SqlCommand("Userlogin", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                var pass = Password;
                if (pass == userLogin.Password)
                {

                    return GenerateJWTToken(userLogin.Email, Id);
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
        private string GenerateJWTToken(string email, long Id)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("ThisismySecretKey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Email", email),

                    new Claim("Id", Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),

                    SigningCredentials =
                    new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ForgotPassword(string Email)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                long Id = 0;
                SqlCommand cmd = new SqlCommand("ForgotPassword", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                //SqlDataReader sqlData = cmd.ExecuteReader();
                UserModel userModel = new UserModel();
                //if (sqlData.Read())
                //{
                //    //userModel.Id = sqlData.GetInt32("Id");
                //    userModel.Email = sqlData.GetString("Email");
                //    //userModel.FirstName = sqlData.GetString("FirstName");
                //    //userModel.LastName = sqlData.GetString("LastName");
                //}
                if (userModel.Email != null)
                {
                    MSMQModel mSMQModel = new MSMQModel();
                    var token = GenerateJWTToken(Email, Id);
                    mSMQModel.sendData2Queue(token);
                    return token.ToString();
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
        public bool ResetPassword(string Email, ResetModel resetModel)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SpResetPassword", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();
                if (resetModel.Password == resetModel.ConfirmPassword)
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", resetModel.Password);
                }

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += "";
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public string Decrypt(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodedData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length);
            return result;
        }
    }
}
