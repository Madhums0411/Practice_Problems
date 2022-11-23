using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AddressBook.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        public IAddressBookBL addressBL;
        public AddressBookController(IAddressBookBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost("create")]
        public IActionResult CreateAddressBook(AddressBookModel model)
        {
            try
            {
                var result = addressBL.CreateAddressBook(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Addressbook created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
