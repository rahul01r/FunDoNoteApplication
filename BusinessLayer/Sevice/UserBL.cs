using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userrl.Login(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        public string ForgetPassword(string email)
        {
            try
            {
                return userrl.ForgetPassword(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPassword(string Email, string New_Password, string Confirm_password)
        {
            try
            {
               
                return userrl.ResetPassword(Email, New_Password, Confirm_password); 
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
