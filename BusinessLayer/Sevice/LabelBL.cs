using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
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
        public IEnumerable<LabelEntity> RetriveLabel(long labelId)
        {
            try
            {
                return this.ilabelRL.RetriveLabel(labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateLabel(long userId, UpdateLabel update)
        {
            try
            {
                return this.ilabelRL.UpdateLabel(userId, update);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
