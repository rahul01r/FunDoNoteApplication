using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using BusinessLayer.Sevice;
using CommonLayer.Model;

namespace FunDoNoteApplicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBL ilabelBL;
        public LabelController(ILabelBL ilabelBL)
        {
            this.ilabelBL = ilabelBL;
              
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateLabel(long noteId, string labelname)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                var result = ilabelBL.CreateLabel(noteId, userId, labelname);

                if (result != null)
                {
                    return Ok(new { success = true, mesage = "Label created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to add Label." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Retrive_Label")]
        public IActionResult RetriveLabel(long labelId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                var result = ilabelBL.RetriveLabel(labelId);

                if (result != null)
                {
                    return Ok(new { success = true, mesage = "Label retrieved", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to retrieved Label." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("UpdateLabel")]
        public IActionResult UpdateLabel(UpdateLabel update)
        {            try

            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = ilabelBL.UpdateLabel(userId, update);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Label Updated SuccessFully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Label not updated !" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("Remove")]
        public IActionResult DeleteLabel(long labelId)
        {
            try
            {
                var result = ilabelBL.DeleteLabel(labelId);

                if (result == true)
                {
                    return Ok(new { success = true, mesage = "Label Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to Delete Label." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
