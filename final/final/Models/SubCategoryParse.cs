using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace final.Models
{
    public class SubCategoryParse
    {
        public static async Task<IEnumerable<ParseObject>> retrieveSubCategory()
        {
            try
            {
                var SubCategoriesQuery = ParseObject.GetQuery(Constants.SUB_CATEGORY_TABLE);
                IEnumerable<ParseObject> subCategories = await SubCategoriesQuery.FindAsync();

                return subCategories;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static string getSubCategoryName(ParseObject subCategory)
        {
            return subCategory.Get<string>(Constants.NAME);
        }

    }
}