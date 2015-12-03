using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.Threading.Tasks;

namespace final.Models
{
    public class GroupParse
    {

        public static async Task<IEnumerable<ParseObject>> retrieveAllGroups()
        {
            try
            {
                var allGroupsQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.ACTIVE, true);
                IEnumerable<ParseObject> allGroups = await allGroupsQuery.FindAsync();
                return allGroups;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            try
            {
                //extract how many users are currently in the group
                ParseRelation<ParseUser> userRelation = group.GetRelation<ParseUser>(Constants.USERS);
                IEnumerable<ParseObject> groupUsers = await userRelation.Query.FindAsync();

                return groupUsers;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            try
            {
                //minProduct is just to obtain the product objectId
                ParseObject minProduct = group.Get<ParseObject>(Constants.PRODUCT);

                //product is a Pointer in the group, therefore we need to query him
                var productQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.OBJECT_ID, minProduct.ObjectId);
                ParseObject product = await productQuery.FirstAsync();

                return product;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}