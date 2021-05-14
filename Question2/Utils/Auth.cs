using Question2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Play_Web.Utils
{
    public class Auth
    {
       public Tuple<bool, string> AuthenticateHeader(AuthenticationData authenticationData)
        {
            if(string.IsNullOrWhiteSpace(authenticationData.AppKey) || string.IsNullOrWhiteSpace(authenticationData.Authorization) || string.IsNullOrEmpty(authenticationData.TimeStamp))
            {
                return new Tuple<bool, string>(false, "Invalid Message request");
            }

            using (SHA512 shaM = new SHA512Managed())
            {
                var hashed = Convert.ToBase64String(shaM.ComputeHash(Encoding.UTF8.GetBytes(authenticationData.AppKey + authenticationData.TimeStamp)));


                if (!authenticationData.Authorization.Contains(hashed))
                {
                    return new Tuple<bool, string>(false, "UnAuthorized access");
                }
            }

            return new Tuple<bool, string> ( true, "Authorization success" );
        }
    }
}
