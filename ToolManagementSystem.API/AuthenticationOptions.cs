using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolManagementSystem.API
{
    public class AuthenticationOptions
    {
        public const string ISSUER = "https://localhost:5000"; // издатель токена
        public const string AUDIENCE = "https://localhost:5001"; // потребитель токена
        const string KEY = "API_Cipher_testKey";
        public const int LIFETIME = 7; // TTL in days
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
