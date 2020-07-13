using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebAPI.Security.Entities
{
    public class SigninConfiguration
    {
        public SigninConfiguration()
        {
            using(var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}
