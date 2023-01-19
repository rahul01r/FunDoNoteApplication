using CommonLayer.Model;
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
    public class LabelRL: ILabelRL
    {
        FunDoContext fundoContext;
        public LabelRL(FunDoContext fundoContext)
        {
            this.fundoContext = fundoContext;
            
        }
        public bool CreateLabel(long noteId, long userId,string labelName)
        {
            try
            {
                var result = fundoContext.LabelTable.Where(e => e.UserId == userId);
                if (result != null)
                {
                    LabelEntity labelEntity = new LabelEntity();
                    labelEntity.NoteID = noteId;
                    labelEntity.UserId = userId;
                    labelEntity.LabelName = labelName;

                    fundoContext.LabelTable.Add(labelEntity);
                    int saveResult = fundoContext.SaveChanges();
                    if (saveResult > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<LabelEntity> RetriveLabel(long labelId)
        {
            try
            {
                var result = fundoContext.LabelTable.Where(e => e.LabelId == labelId).ToList();
                return result;
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
                var result = fundoContext.LabelTable.Where(e => e.UserId == userId && e.LabelName == update.OldLabelName).FirstOrDefault();
                if (result != null)
                {
                    result.LabelName = update.NewLabelName;
                    fundoContext.SaveChanges();
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

