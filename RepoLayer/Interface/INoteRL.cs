﻿using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRL
    {
        public NoteEntity CreateNotes(NoteRegistration createNoteModel, long userId);
        public IEnumerable<NoteEntity> RetrieveNotes(long userId, long noteId);
        public bool UpdateNotes(long noteId, long userId, NoteRegistration createNoteModel);
        public bool DeleteNotes(long noteId, long userId);
        public bool PinNote(long NoteId);
    }
}
