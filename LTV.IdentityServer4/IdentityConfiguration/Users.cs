using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LTV.IdentityServer4.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "12345",
                    Username = "vuongle",
                    Password = "admin123",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "vuongle@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Email, "https://vuongle.com"),
                    }
                }
            };
        }
    }
}
