using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("30b576f250884428a020ec9e35aeef56");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", "id-1") }),
                Expires = DateTime.UtcNow.AddYears(1),
                Audience = "WELCOM",
                Claims = new Dictionary<string, object>(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenDescriptor.Claims["KeyKeeperId"] = "id-1";
            tokenDescriptor.Claims["PublicKeyPem"] = "hi hi hi";
            tokenDescriptor.Claims["tenant-id"] = "t-id-1";
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Console.WriteLine(tokenHandler.WriteToken(token));
        }
    }
}


