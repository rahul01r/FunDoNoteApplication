using BusinessLayer.Interface;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Sevice
{
    public class LabelBL : ILabelBL
    {
        ILabelRL ilabelRL;
        public LabelBL(ILabelRL ilabelRL)
        {
            this.ilabelRL = ilabelRL;
        }
        public bool CreateLabel(long noteId, long userId, string labelName)
        {
            try
            {
                return this.ilabelRL.CreateLabel(noteId, userId, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
