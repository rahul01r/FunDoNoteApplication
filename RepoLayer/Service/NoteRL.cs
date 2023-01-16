using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Service
{
    public class NoteRL:INoteRL
    {
        private readonly FunDoContext fundoContext;
        private readonly IConfiguration iconfiguration;

        public NoteRL(FunDoContext fundooContext, IConfiguration iconfiguration)
        {
            this.fundoContext = fundooContext;
            this.iconfiguration = iconfiguration;

        }

        public NoteEntity CreateNotes(NoteRegistration createNoteModel)
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

                //add to table
                fundoContext.NotesTable.Add(notesEntity);
                //upload database
                int result = fundoContext.SaveChanges();

                if (result != 0)
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


    }
}

