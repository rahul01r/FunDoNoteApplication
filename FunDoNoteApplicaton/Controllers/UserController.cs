using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                if (result == "Login Sucessful")
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
    }
}
