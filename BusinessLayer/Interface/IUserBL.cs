﻿using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserEntity RegisterUser(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);

        public string ForgetPassword(string email);
    }
}
