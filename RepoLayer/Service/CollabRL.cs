using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class CollabRL: ICollabRL
    {
        FunDoContext fundoContex;
        IConfiguration configuration;

        public CollabRL(FunDoContext fundoContext, IConfiguration configuration)
        {
            this.fundoContex = fundoContext;
            this.configuration = configuration;
        }
        public CollabratorEntity CreateCollab(long noteId, string email)
        {
            try
            {
                var noteResult = fundoContex.NotesTable.Where(e => e.NoteID == noteId).FirstOrDefault();
                var emailResult = fundoContex.UserTable.Where(e => e.Email == email).FirstOrDefault();
                if (emailResult != null && noteResult != null)
                {
                    CollabratorEntity collabratorEntity = new CollabratorEntity();
                    collabratorEntity.UserId = emailResult.UserId;
                    collabratorEntity.NoteID = noteResult.NoteID;
                    collabratorEntity.Email = emailResult.Email;

                    fundoContex.CollabTable.Add(collabratorEntity);
                    int result = fundoContex.SaveChanges();
                    return collabratorEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<CollabratorEntity> RetriveCollab(long noteId)
        {
            try
            {
                var result = fundoContex.CollabTable.Where(e => e.NoteID == noteId).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveCollab(long collabId)
        {
            try
            {
                var result = fundoContex.CollabTable.Where(e => e.CollabId == collabId).FirstOrDefault();

                if (result != null)
                {

                    fundoContex.CollabTable.Remove(result);
                    fundoContex.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
