using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class BidParse
    {
        public static async Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            try
            {
                //minGroup is just to obtain the group objectId
                ParseObject minGroup = bid.Get<ParseObject>(Constants.GROUP_BUYING_ID);

                //group is a Pointer in the bid, therefore we need to query him
                var groupQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.OBJECT_ID, minGroup.ObjectId);
                ParseObject group = await groupQuery.FirstAsync();

                return group;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
    }
}