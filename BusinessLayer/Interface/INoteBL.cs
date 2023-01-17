using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        public NoteEntity CreateNotes(NoteRegistration createNoteModel, long userId);
        public IEnumerable<NoteEntity> RetrieveNotes(long userId, long noteId);
    }
}
