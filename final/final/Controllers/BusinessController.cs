using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //check if the difference between NOW and creation time of the group is under 24 horus
        private TimeSpan canBusinessOferBid(DateTime groupCreationTime)
        {
            TimeSpan ts = DateTime.Now - groupCreationTime;

            int differenceInDays = ts.Days;
            int differenceInHours = ts.Hours;
            if (differenceInDays==0 && differenceInHours < 24)
                return ts;

            //if not
            return TimeSpan.Zero;
        }


        //return list of groups - waiting for bid! - that are relevant for this current business
        public async System.Threading.Tasks.Task<ActionResult> GroupsWitingForBid()
        {
            List<ParseObject> groups = new List<ParseObject>(); //return value
            List<string> products = new List<string>(); //return value
            List<TimeSpan> timeToOffer = new List<TimeSpan>();

            var currentUser = ParseUser.CurrentUser;
            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USER, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();

            var allGroupsQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.ACTIVE,true);
            IEnumerable<ParseObject> allGroups = await allGroupsQuery.FindAsync();

            foreach (ParseObject group in allGroups)
            {
                //minProduct is just to obtain the product objectId
                ParseObject minProduct = group.Get<ParseObject>(Constants.PRODUCT);

                //product is a Pointer in the group, therefore we need to query him
                var productQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.OBJECT_ID, minProduct.ObjectId);
                ParseObject product = await productQuery.FirstAsync();

                //extract business field from product
                var relation = product.GetRelation<ParseObject>(Constants.BUSINESS);
                IEnumerable<ParseObject> businesses = await relation.Query.FindAsync();

                //check if my business has this particular product
                foreach (ParseObject business in businesses)
                {
                    if (myBusiness.ObjectId == business.ObjectId)
                    {
                        DateTime creationTime = (DateTime)group.CreatedAt;
                        TimeSpan timeToOfferABid = canBusinessOferBid(creationTime);
                        if (timeToOfferABid != TimeSpan.Zero)
                        {
                            products.Add(product.Get<string>(Constants.TITLE));
                            groups.Add(group);
                            timeToOffer.Add(timeToOfferABid);

                        }
                    }
                }
            }
            ViewBag.groups = groups;
            ViewBag.products = products;
            ViewBag.timeToOffer = timeToOffer;

            return View();
        }

        //return a list of groups that the current business "won".
        public async System.Threading.Tasks.Task<ActionResult> MyActiveGroups()
        {
            List<int> prices = new List<int>(); //return value
            List<string> comments = new List<string>(); //return value
            List<ParseObject> groups = new List<ParseObject>(); //return value
            List<int> users = new List<int>(); //return value

            //extracting current businessId
            var currentUser = ParseUser.CurrentUser;
            var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USERS, currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();

            var winningBidsQuery = ParseObject.GetQuery(Constants.WINNING_BID_TABLE);
            IEnumerable<ParseObject> winningBids = await winningBidsQuery.FindAsync();

            foreach (ParseObject winningBid in winningBids)
            {
                ParseObject WinnigBidId = winningBid.Get<ParseObject>(Constants.BID);
                var bidQuery = ParseObject.GetQuery(Constants.BID_TABLE).WhereEqualTo(Constants.OBJECT_ID, WinnigBidId.ObjectId);
                ParseObject bid = await bidQuery.FirstAsync();

                ParseObject businessOfBid = bid.Get<ParseObject>(Constants.BUSINESS_ID);

                if (businessOfBid.ObjectId == myBusiness.ObjectId)
                {
                    int price = bid.Get<int>(Constants.PRICE);
                    string comment = bid.Get<string>(Constants.COMMENTS);

                    //minGroup is just to obtain the group objectId
                    ParseObject minGroup = bid.Get<ParseObject>(Constants.GROUP_BUYING_ID);

                    //group is a Pointer in the bid, therefore we need to query him
                    var groupQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.OBJECT_ID, minGroup.ObjectId);
                    ParseObject group = await groupQuery.FirstAsync();

                    //extract how many users are currently in the group
                    ParseRelation<ParseUser> userRelation = group.GetRelation<ParseUser>(Constants.USERS);
                    IEnumerable<ParseObject> groupUsers = await userRelation.Query.FindAsync();

                    users.Add(groupUsers.Count());
                    prices.Add(price);
                    comments.Add(comment);
                    groups.Add(group);
                }
            }
            ViewBag.groups = groups;
            ViewBag.prices = prices;
            ViewBag.comments = comments;
            ViewBag.users = users;

            return View();
        }


        /*     public async System.Threading.Tasks.Task<ActionResult> CreateBid([Bind(Include = "price,comments,groupBuyingId")] Bid bid)
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

         */






    }
}