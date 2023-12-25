using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Json Web tokenlerinin oluşturulabilmesi için
        //Web API'ye anlatmak için;
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) //Asp Netin hangi anahtarı kullanacağı
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //Asp Netin hangi algoritmayı kullanacağı
        }
    }
}