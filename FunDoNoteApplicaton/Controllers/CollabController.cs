using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FunDoNoteApplicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        ICollabBL icollabBL;
        public CollabController(ICollabBL icollabBL)
        {
            this.icollabBL = icollabBL; 
        }
        [Authorize]
        [HttpPost]
        [Route("CreateCollabrator")]
        public IActionResult CreateCollab(long noteId, string email)
        {
            try
            {

                var result = icollabBL.CreateCollab(noteId, email);
                if (result != null)
                {
                    return Ok(new { success = true, mesage = "Collabrator created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to add collabrator." });
                }
            }
            
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Retrieve")]
        public IActionResult RetrieveCollab(long noteId)
        {
            try
            {
                //long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = icollabBL.RetriveCollab(noteId);

                if (result != null)
                {
                    return Ok(new { success = true, mesage = "Collabrator fetched", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Data Not Found." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
