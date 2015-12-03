using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class BusinessParse
    {
        public static async Task<ParseObject> retrieveMyBusiness()
        {
            try
            {
                var currentUser = ParseUser.CurrentUser;
                var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USER, currentUser);
                ParseObject myBusiness = await myBusinessQuery.FirstAsync();
                return myBusiness;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
    }
}