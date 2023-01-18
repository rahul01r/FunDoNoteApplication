using BusinessLayer.Interface;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Sevice
{
    public class CollabBL : ICollabBL
    {
        ICollabRL icollabRl;
        public CollabBL(ICollabRL icollabRl)
        {
            this.icollabRl = icollabRl;
        }

        public CollabratorEntity CreateCollab(long noteId, string email)
        {
            try
            {
                return this.icollabRl.CreateCollab(noteId,email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CollabratorEntity> RetriveCollab(long noteId)
        {
            try
            {
                return this.icollabRl.RetriveCollab(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
