using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ICollabRL
    {
        public CollabratorEntity CreateCollab(long noteId, string email);
        public IEnumerable<CollabratorEntity> RetriveCollab(long noteId);
    }
}
