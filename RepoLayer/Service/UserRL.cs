using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRL: IUserRL
    {
        FunDoContext funDo;
        private readonly string _secret;
        private readonly string _expDate;
        public UserRL(FunDoContext funDo, IConfiguration config)
        {
            this.funDo = funDo;
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
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
                    var token = GenerateSecurityToken(result.Email, result.UserId);
                    return token;
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
        public string GenerateSecurityToken(string email,long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("userId",userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        public string ForgetPassword(string email)
        {
            try
            {
                var result = funDo.UserTable.Where(x => x.Email == email).FirstOrDefault();
                if(result != null)
                {
                    var token = GenerateSecurityToken(result.Email, result.UserId);
                    MSMQModel mq = new MSMQModel();
                    mq.sendData2Queue(token);
                    return token;
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
        public bool ResetPassword(string Email, string New_Password,string Confirm_password)
        {
            try
            {
                if(New_Password == Confirm_password)
                {
                    var result = funDo.UserTable.Where(x => x.Email == Email).FirstOrDefault();
                    result.PassWord = New_Password;
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

