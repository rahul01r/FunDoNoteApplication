using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity RegisterUser(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);
    }
}
