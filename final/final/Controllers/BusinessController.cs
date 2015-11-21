using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Dashboard()
        {

                
            return View();
        }

        //return list of groups - waiting for bid! - that are relevant for this current business
        public async System.Threading.Tasks.Task<ActionResult> GroupsWithMyProducts()
        {
            var currentUser = ParseUser.CurrentUser;

            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USERS, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();

            var myProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.BUSINESS, myBusiness);
            IEnumerable<ParseObject> myProducts = await myProductsQuery.FindAsync();

            DateTime currentDateTime = DateTime.Now;
            List<ParseObject> myGroups = new List<ParseObject>();

            foreach (ParseObject product in myProducts)
            {
                var groupsWithMyProductQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.PRODUCT, product);
                IEnumerable<ParseObject> groupsWithMyProduct = await groupsWithMyProductQuery.FindAsync();
                foreach(ParseObject group in groupsWithMyProduct)
                {
                    DateTime groupExpirationDateTime = group.Get<DateTime>(Constants.EXPIRATION_DATE);
                    //check if the business can still offer a bid for the group
                    System.TimeSpan diff = groupExpirationDateTime.Subtract(currentDateTime);
                    if (diff.Hours >=0 && diff.Minutes>=0 && diff.Seconds >= 0)
                    {
                        myGroups.Add(group);
                    }    
                }
            }

            List<GroupBuying> groups = new List<GroupBuying>();
            foreach(ParseObject parseGroup in myGroups)
            {
                GroupBuying group = new GroupBuying();
                group.objectId = parseGroup.ObjectId;
                group.products = parseGroup.Get<ParseObject>(Constants.PRODUCT);
            }
            return View(myGroups);
        }


        public async System.Threading.Tasks.Task<ActionResult> CreateBid([Bind(Include = "price,comments,groupBuyingId")] Bid bid)
        {
            //extracting current businessId
            var currentUser = ParseUser.CurrentUser;
            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USERS, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();
         
            //create new bid
            var bidObject = new ParseObject(Constants.BID_TABLE);
            bidObject[Constants.PRICE] = bid.price;
            bidObject[Constants.COMMENTS] = bid.comments;
            
            //TODO: groupBuyingId is passeed from previous page (Groups)
            //bidObject[Constants.GROUP_BUYING_ID] = bid.groupBuyingId;
            bidObject[Constants.BUSINESS_ID] = myBusiness.Get<string>(Constants.OBJECT_ID);

            await bidObject.SaveAsync();
            return View();
        }

        //return a list of groups that the current business "won".
        public async System.Threading.Tasks.Task<ActionResult> MyActiveGroups()
        {
            //extracting current businessId
            var currentUser = ParseUser.CurrentUser;
            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USERS, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();

            var winningBidsQuery = ParseObject.GetQuery(Constants.WINNING_BID_TABLE);
            IEnumerable<ParseObject> winningBids = await winningBidsQuery.FindAsync();

            List<ParseObject> myActiveGroups = new List<ParseObject>();

            foreach (ParseObject winningBid in winningBids)
            {
                string WinnigBidId = winningBid.Get<string>(Constants.BID_ID);
                var bidQuery = ParseObject.GetQuery(Constants.BID_TABLE).WhereEqualTo(Constants.OBJECT_ID, WinnigBidId);
                ParseObject bid = await bidQuery.FirstAsync();

                string businessIdOfBid = bid.Get<string>(Constants.BUSINESS_ID);

                if (businessIdOfBid == myBusiness.ObjectId)
                {
                    myActiveGroups.Add(winningBid);
                }
            }
            return View(myActiveGroups);
        }





    }
}