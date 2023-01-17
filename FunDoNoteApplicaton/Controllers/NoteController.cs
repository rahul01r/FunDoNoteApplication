using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;

namespace FunDoNoteApplicaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteBL inoteBL;

        public NoteController(INoteBL inoteBL)
        {
            this.inoteBL = inoteBL;
        }
        [Authorize]
        [HttpPost]
        [Route("CreateNote")]
        public IActionResult CreateNotes(NoteRegistration createNoteModel)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = inoteBL.CreateNotes(createNoteModel,userid);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Note Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not get saved." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetNote")]
        public IActionResult RetrieveNotes( long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = inoteBL.RetrieveNotes(userId,noteId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Get Notes Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to get Note." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateNotes(long noteId, NoteRegistration createNoteModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = inoteBL.UpdateNotes(noteId, userId, createNoteModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Not get updated try again." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteNotes")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = inoteBL.DeleteNotes(noteId, userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Deleted Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Not Deleted." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Pin")]
        public IActionResult PinNote(long noteId)
        {
            try
            {
                // long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = inoteBL.PinNote(noteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Pinned Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "UnPinned." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Trash")]
        public IActionResult Trash(long noteId)
        {
            try
            {
                // long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = inoteBL.Trash(noteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Note is in trash", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Something went wrong" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

