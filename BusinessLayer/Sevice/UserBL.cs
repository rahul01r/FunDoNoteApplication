using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Sevice
{
    public class UserBL: IUserBL
    {
        IUserRL userrl;
        public UserBL(IUserRL userrl)
        {
            this.userrl = userrl;   
        }
        
        public UserEntity RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                return userrl.RegisterUser(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
