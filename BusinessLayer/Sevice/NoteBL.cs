using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Sevice
{
    public class NoteBL : INoteBL
    {
        private readonly INoteRL inoteRL;
        public NoteBL(INoteRL inoteRL)
        {
            this.inoteRL = inoteRL;
        }
        public NoteEntity CreateNotes(NoteRegistration createNoteModel, long userId)
        {
            try
            {
                return inoteRL.CreateNotes(createNoteModel,userId);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public IEnumerable<NoteEntity> RetrieveNotes(long userId, long noteId)
        {
            try
            {
                return inoteRL.RetrieveNotes(userId,noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateNotes(long noteId, long userId, NoteRegistration createNoteModel)
        {
            try
            {
                return this.inoteRL.UpdateNotes(noteId, userId, createNoteModel);
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
                return this.inoteRL.DeleteNotes(noteId, userId);
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
                return this.inoteRL.PinNote(NoteId);
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
                return this.inoteRL.Trash(NoteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
