using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        public bool CreateLabel(long noteId, long userId, string labelName);
        public IEnumerable<LabelEntity> RetriveLabel(long labelId);
        public bool UpdateLabel(long userId, UpdateLabel update);
        public bool DeleteLabel(long labelId);
    }
}
