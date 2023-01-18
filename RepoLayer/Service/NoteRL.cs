using CloudinaryDotNet;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class NoteRL:INoteRL
    {
        FunDoContext fundoContext;
        IConfiguration configuration;

        public NoteRL(FunDoContext fundoContext, IConfiguration configuration)
        {
            this.fundoContext = fundoContext;
            this.configuration = configuration;

        }

        public NoteEntity CreateNotes(NoteRegistration createNoteModel,long userId)
        {
            try
            {
                //mapped entity and model properties
                NoteEntity notesEntity = new NoteEntity();
                notesEntity.Title = createNoteModel.Title;
                notesEntity.Description = createNoteModel.Description;
                notesEntity.Reminder = createNoteModel.Reminder;
                notesEntity.Color = createNoteModel.Color;
                notesEntity.Archive = createNoteModel.Archive;
                notesEntity.Image = createNoteModel.Image;
                notesEntity.Trash = createNoteModel.Trash;
                notesEntity.Edited = createNoteModel.Edited;
                notesEntity.Created = createNoteModel.Created;
                notesEntity.Pin = createNoteModel.Pin;
                notesEntity.UserId = userId;

                //add to table
                fundoContext.NotesTable.Add(notesEntity);
                //upload database
                int result = fundoContext.SaveChanges();

                if (result > 0)
                {
                    return notesEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<NoteEntity> RetrieveNotes(long userId, long noteId)
        {
            try
            {
                var result = fundoContext.NotesTable.Where(e => e.UserId == userId && e.NoteID == noteId);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UpdateNotes(long noteId, long userId, NoteRegistration createNoteModel)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == noteId && e.UserId == userId);

                if (result != null)
                {
                    if (createNoteModel.Title != null)
                    {
                        result.Title = createNoteModel.Title;
                    }
                    if (createNoteModel.Description != null)
                    {
                        result.Description = createNoteModel.Description;
                    }

                    result.Edited = DateTime.Now;
                    fundoContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteNotes(long noteId, long userId)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == noteId && e.UserId == userId);

                if (result != null)
                {

                    fundoContext.NotesTable.Remove(result);
                    fundoContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PinNote(long NoteId)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == NoteId);

                if (result.Pin == true)
                {
                    result.Pin = false;
                    fundoContext.SaveChanges();

                    return false;
                }
                else
                {
                    result.Pin = true;
                    fundoContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Trash(long NoteId)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == NoteId);

                if (result.Trash == true)
                {
                    result.Trash = false;
                    fundoContext.SaveChanges();

                    return false;
                }
                else
                {
                    result.Trash = true;
                    fundoContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Archive(long NoteId)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == NoteId);

                if (result.Archive == true)
                {
                    result.Archive = false;
                    fundoContext.SaveChanges();

                    return false;
                }
                else
                {
                    result.Archive = true;
                    fundoContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public NoteEntity BackgroundColor(ColorModel colorModel, long UserId )
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID ==colorModel.NoteID && e.UserId == UserId);

                if (result.Color != null)
                {
                    result.Color = colorModel.Color;
                    //fundooContext.NotesTable.Remove(result);
                    fundoContext.SaveChanges();

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string UploadImage(IFormFile image, long noteId, long userId)
        {
            try
            {
                var result = fundoContext.NotesTable.FirstOrDefault(e => e.NoteID == noteId && e.UserId == userId);
                if (result != null)
                {
                    Account accounnt = new Account(
                        this.configuration["CloudinarySettings:CloudName"],
                       this.configuration["CloudinarySettings:ApiKey"],
                        this.configuration["CloudinarySettings:ApiSecret"]
                        );
                    Cloudinary cloudinary = new Cloudinary(accounnt);
                    var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream()),
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    string imagePath = uploadResult.Url.ToString();
                    result.Image = imagePath;
                    fundoContext.SaveChanges();

                    return "Image uploaded successfully";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}



