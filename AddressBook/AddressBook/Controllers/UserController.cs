using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult userRegister(UserModel model)
        {
            try
            {
                var result = userBL.userRegistration(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Login")]
        public IActionResult UserLogin(UserLoginModel model)
        {
            try
            {
                var result = userBL.UserLogin(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("Forgot")]
        public IActionResult ForgotPassword(string Email)
        {
            try
            {
                var result = userBL.ForgotPassword(Email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Sent successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("Reset")]
        public ActionResult ResetPassword(string Password, string ConfirmPassword)
        {
            try
            {
                
                if (userBL.ResetPassword(Password, ConfirmPassword))
                {
                    return Ok(new { success = true, message = "Password reseted successfully"});
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
