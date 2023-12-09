﻿using Example.BussinesLayer.Abstract;
using Example.CORE.Model;
using Example.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Example.BussinesLayer.Concrate
{
    public class UserManager : IUserService
    {
        public UserManager(IUserRepoStory repoStory, IHttpContextAccessor acx )
        {
            RepoStory = repoStory;
            Context = acx;
        }

        private IUserRepoStory RepoStory { get; set; }
        private IHttpContextAccessor Context { get; set; }

        public ServiceResult<User> Add(User Item)
        {
            return ServiceResult<User>.SuccessResult(RepoStory.Add(Item),"Kullanıcı Oluşturuldu");
        }

        public ServiceResult<object> GetToken(string Username,string Password)
        {
            if (!RepoStory.Any(x => x.UserName == Username && x.Password == Password))
            {   
                return ServiceResult<object>.FailureResult("Kullanıcı Adı Veya Parola Doğrulanamdı");


            }
            else
            {
                var UserItem = RepoStory.Get(x => x.UserName == Username && x.Password == Password);
                var authClaims = new List<Claim>
                             {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim("ID",UserItem.ID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                             };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BB698DAF-6E3F-45FF-8493-06ECCF2F60D0"));

                var token = new JwtSecurityToken(

                    expires: DateTime.Now.AddHours(24),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                 
                return ServiceResult<object>.SuccessResult(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo

                } , "Token Alma İşlemi Başarılı");
            }

            
        }
    }
}
