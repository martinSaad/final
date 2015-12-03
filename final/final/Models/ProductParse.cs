using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.Threading.Tasks;

namespace final.Models
{
    public class ProductParse
    {
        public static async Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            try
            {
                var relation = product.GetRelation<ParseObject>(Constants.BUSINESS);
                IEnumerable<ParseObject> businesses = await relation.Query.FindAsync();
                return businesses;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
    }
}