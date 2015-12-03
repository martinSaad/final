using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace final.Models
{
    public class CategoryParse
    {
        public static async Task<IEnumerable<ParseObject>> retrieveCategory()
        {
            try
            {
                var CategoriesQuery = ParseObject.GetQuery(Constants.CATEGORY_TABLE);
                IEnumerable<ParseObject> categories = await CategoriesQuery.FindAsync();

                return categories;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
    }
}