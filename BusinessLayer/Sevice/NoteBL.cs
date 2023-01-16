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
    }
}
