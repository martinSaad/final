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

        public static async Task<IEnumerable<ParseObject>> retrieveAllActiveGroups()
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
                // add log
                throw e;
            }
        }



        public static async Task<bool> createGroup(ParseObject product)
        {
            try
            {
                var newGroup = new ParseObject(Constants.GROUP_BUYING_TABLE);
                newGroup[Constants.PRODUCT] = product;
                newGroup[Constants.ACTIVE] = true; //we just created new group of this product so now we have an active group until the group will finished
                newGroup[Constants.EXPIRATION_DATE] = DateTime.Now.AddDays(Constants.GROUP_LIFE_TIME);

                await newGroup.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveGroup(string groupId)
        {
            try
            {
                var groupQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.OBJECT_ID, groupId);
                ParseObject group = await groupQuery.FirstAsync();

                return group;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
        public static DateTime getExpirationDate(ParseObject group)
        {
            return group.Get<DateTime>(Constants.EXPIRATION_DATE);
        }

        public static async Task<bool> setGroupActive(ParseObject group, bool status)
        {
            group[Constants.ACTIVE] = status;
            await group.SaveAsync();
            return true;
        }


    }
}