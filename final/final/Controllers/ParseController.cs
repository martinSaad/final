using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parse;
using System.Threading.Tasks;
using final.Models;

namespace final.Controllers
{
    public class ParseController : Controller
    {
        // GET: Parse
        public ActionResult Index()
        {
            return View();
        }

        //check if the difference between NOW and creation time of the group is under 24 horus
        private TimeSpan canBusinessOferBid(DateTime groupCreationTime)
        {
            TimeSpan ts = DateTime.Now - groupCreationTime;

            int differenceInDays = ts.Days;
            int differenceInHours = ts.Hours;
            if (differenceInDays == 0 && differenceInHours < 24)
                return ts;

            //if not
            return TimeSpan.Zero;
        }

        private async Task<IEnumerable<ParseObject>> retrieveAllGroups()
        {
            var allGroupsQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.ACTIVE, true);
            IEnumerable<ParseObject> allGroups = await allGroupsQuery.FindAsync();
            return allGroups;
        }

        protected async Task<ParseObject> retrieveMyBusiness()
        {
            var currentUser = ParseUser.CurrentUser;
            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USER, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();
            return myBusiness;
        }


        private async Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            //minProduct is just to obtain the product objectId
            ParseObject minProduct = group.Get<ParseObject>(Constants.PRODUCT);

            //product is a Pointer in the group, therefore we need to query him
            var productQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.OBJECT_ID, minProduct.ObjectId);
            ParseObject product = await productQuery.FirstAsync();

            return product;
        }

        private async Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            var relation = product.GetRelation<ParseObject>(Constants.BUSINESS);
            IEnumerable<ParseObject> businesses = await relation.Query.FindAsync();
            return businesses;
        }

        private async Task<IEnumerable<ParseObject>> retrieveWinningBids()
        {
            var winningBidsQuery = ParseObject.GetQuery(Constants.WINNING_BID_TABLE);
            IEnumerable<ParseObject> winningBids = await winningBidsQuery.FindAsync();
            return winningBids;
        }

        private async Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid)
        {
            var bidQuery = ParseObject.GetQuery(Constants.BID_TABLE).WhereEqualTo(Constants.OBJECT_ID, winningBid.ObjectId);
            ParseObject bid = await bidQuery.FirstAsync();

            return bid;
        }

        private async Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            //minGroup is just to obtain the group objectId
            ParseObject minGroup = bid.Get<ParseObject>(Constants.GROUP_BUYING_ID);

            //group is a Pointer in the bid, therefore we need to query him
            var groupQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.OBJECT_ID, minGroup.ObjectId);
            ParseObject group = await groupQuery.FirstAsync();

            return group;
        }

        private async Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            //extract how many users are currently in the group
            ParseRelation<ParseUser> userRelation = group.GetRelation<ParseUser>(Constants.USERS);
            IEnumerable<ParseObject> groupUsers = await userRelation.Query.FindAsync();

            return groupUsers;
        }


    }
}