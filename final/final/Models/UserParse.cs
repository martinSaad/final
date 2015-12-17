using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class UserParse
    {
        public static bool isBusiness(ParseUser user)
        {
            return user.Get<bool>(Constants.IS_BUSINESS);
        }
    }
}