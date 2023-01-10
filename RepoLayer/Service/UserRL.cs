﻿using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRL: IUserRL
    {
        FunDoContext funDo;
        public UserRL(FunDoContext funDo)
        {
            this.funDo = funDo;
        }
        public UserEntity RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                UserEntity objUserentity = new UserEntity();
                objUserentity.FirstName = userRegistration.FirstName;
                objUserentity.LastName = userRegistration.LastName;
                objUserentity.Email = userRegistration.Email;
                objUserentity.PassWord = userRegistration.PassWord;
                funDo.UserTable.Add(objUserentity);
                int result = funDo.SaveChanges();
                if (result > 0)
                {
                    return objUserentity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Login(UserLogin userLogin)
        {
            try
            {
                var result =funDo.UserTable.Where(x => x.Email == userLogin.Email && x.PassWord == userLogin.PassWord).FirstOrDefault();
                if (result != null)
                {
                    return "Login Sucessful";
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
