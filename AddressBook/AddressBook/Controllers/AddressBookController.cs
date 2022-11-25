using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AddressBook.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        public IAddressBookBL addressBL;
        private readonly ILogger<AddressBookController> _logger;
        public AddressBookController(IAddressBookBL addressBL, ILogger<AddressBookController> _logger)
        {
            this.addressBL = addressBL;
            this._logger = _logger;
        }
        [HttpPost("Create")]
        public IActionResult CreateAddressBook(AddressBookModel model)
        {
            try
            {
                var result = addressBL.CreateAddressBook(model);
                if (result != null)
                {
                    _logger.LogInformation(" AddressBook Created");
                    return Ok(new { success = true, message = "Addressbook created Successfully", data = result });
                }
                else
                {
                    _logger.LogInformation("Unsuccessfull");
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpGet("Get")]
        public IActionResult GetAddressBook()
        {
            try
            {
                var result = addressBL.GetAddressBook();
                if (result != null)
                {
                    _logger.LogInformation("Addressbook retrived successfully");
                    return Ok(new { success = true, message = "Addressbook retrived successfully", data = result });
                }
                else
                {
                    _logger.LogInformation("Unsuccessfull");
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateAddressBook(long Id, AddressBookModel model)
        {
            try
            {
                var result = addressBL.UpdateAddressBook(Id, model);
                if (result != null)
                {
                    _logger.LogInformation("Address Book Updated Successfully");
                    return Ok(new { success = true, message = "Address Book Updated Successfully", data = result });
                }
                else
                {
                    _logger.LogInformation("Unsuccessfull");
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteAddressBook(long Id)
        {
            try
            {
                var result = addressBL.DeleteAddressBook(Id);
                if (result != null)
                {
                    _logger.LogInformation("Address Book Deleted Successfull");
                    return Ok(new { success = true, message = "Address Book Deleted Successfully" });
                }
                else
                {
                    _logger.LogInformation("Unsuccessfull");
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

    }
}
