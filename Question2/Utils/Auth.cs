using Question2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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


            return new Tuple<bool, string> ( false, "error" );
        }
    }
}
