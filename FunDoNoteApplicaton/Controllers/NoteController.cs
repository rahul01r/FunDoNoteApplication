﻿using BusinessLayer.Interface;
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
    }
}
