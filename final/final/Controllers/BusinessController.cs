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
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Model model = new Model();


        // GET: Business
        public ActionResult Dashboard()
        {

            logger.Debug("Dashboard method is called");
            logger.Error("error in logger");   
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
            List<TimeSpan> timeToOffer = new List<TimeSpan>(); //return value

            ParseObject myBusiness = await model.retrieveMyBusiness();

            IEnumerable<ParseObject> allGroups = await model.retrieveAllActiveGroups();

            foreach (ParseObject group in allGroups)
            {

                ParseObject product = await model.retrieveProductOfGroup(group);

                //extract business field from product
                IEnumerable<ParseObject> businesses = await model.businessesWhoHaveThisProduct(product);

                //check if my business has this particular product
                foreach (ParseObject business in businesses)
                {
                    if (myBusiness.ObjectId == business.ObjectId)
                    {
                        DateTime groupCreationTime = (DateTime)group.CreatedAt;
                        TimeSpan timeToOfferABid = canBusinessOferBid(groupCreationTime);

                        //if there is time to offer
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

            ParseObject myBusiness = await model.retrieveMyBusiness();

            IEnumerable<ParseObject> winningBids = await model.retrieveWinningBids();

            foreach (ParseObject winningBid in winningBids)
            {
                ParseObject bid = await model.retrieveBidOfWinningBid(winningBid);

                ParseObject businessOfBid = bid.Get<ParseObject>(Constants.BUSINESS_ID);

                if (businessOfBid.ObjectId == myBusiness.ObjectId)
                {
                    int price = bid.Get<int>(Constants.PRICE);
                    string comment = bid.Get<string>(Constants.COMMENTS);

                    ParseObject group = await model.retrieveGroupOfBid(bid);

                    //extract how many users are currently in the group
                    IEnumerable<ParseObject> groupUsers = await model.retrieveUsersOfGroup(group);

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


   /*          public async System.Threading.Tasks.Task<ActionResult> CreateBid([Bind(Include = "price,comments,groupBuyingId")] Bid bid)
             {
                ParseObject myBusiness = await retrieveMyBusiness();

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



        public async System.Threading.Tasks.Task<ActionResult> MyProducts()
        {



            return View();
        }


    }
}