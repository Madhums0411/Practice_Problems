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
                command.Parameters.AddWithValue("@Password", Encrypt(userRegister.Password));
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
                // sqlConnection.Close();
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    string Name = Convert.ToString(Dr["FirstName"]);
                    string Email = Convert.ToString(Dr["Email"]);
                    Id = Convert.ToInt32(Dr["Id"]);
                    Password = Convert.ToString(Dr["Password"]);


                }
                sqlConnection.Close();
                var pass = Decrypt(Password);
                // var email = userLogin.Email;
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
                // generate token
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
                SqlDataReader sqlData = cmd.ExecuteReader();
                UserModel userRegisterModels = new UserModel();
                if (sqlData.Read())
                {

                    userRegisterModels.Email = sqlData.GetString("Email");

                }
                if (userRegisterModels.Email != null)
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
        public bool ResetPassword(string Password, string ConfirmPassword)
        {
            try
            {
                if (Password.Equals(ConfirmPassword))
                {
                    Password = Password;

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
        public string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += "";
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public string Decrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncoddeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncoddeBytes);
            result = result.Substring(0, result.Length);
            return result;
        }
    }
}
