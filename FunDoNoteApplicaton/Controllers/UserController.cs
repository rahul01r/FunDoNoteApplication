using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunDoNoteApplicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBl;
        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;

        }
        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = userBl.RegisterUser(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration Unsuccessfull!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var result = userBl.Login(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull!", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Registration Unsuccessfull!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = userBl.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Mail Send Sucessfully", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Mail Sent Unsucessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Authorize]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string New_Password, string Confirm_password)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBl.ResetPassword(email, New_Password, Confirm_password);
                if (result == true)
                {

                    return this.Ok(new { success = true, message = "Reset password Sucessfully", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Reset Password Failed" });

                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
