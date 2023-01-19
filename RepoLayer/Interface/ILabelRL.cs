using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ILabelRL
    {
        public bool CreateLabel(long noteId, long userId, string labelName);
    }
}
