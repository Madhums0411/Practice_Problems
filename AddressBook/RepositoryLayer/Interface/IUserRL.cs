using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserModel userRegistration(UserModel userRegister);
        public string UserLogin(UserLoginModel userLogin);
        public string ForgotPassword(string Email);
        public bool ResetPassword(string password, string confirmPassword);
        public string Encrypt(string password);
        public string Decrypt(string base64EncodeData);

    }
}
