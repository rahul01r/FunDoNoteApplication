using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

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
    }
}
