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
            if (differenceInDays == 0 && differenceInHours < 24)
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
                            products.Add(model.getProductTitle(product));
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
            List<int> originalPrices = new List<int>(); //return value
            List<string> comments = new List<string>(); //return value
            List<ParseObject> groups = new List<ParseObject>(); //return value
            List<int> users = new List<int>(); //return value

            ParseObject myBusiness = await model.retrieveMyBusiness();

            IEnumerable<ParseObject> winningBids = await model.retrieveWinningBids();

            //check if the winnign bid is my bid (from my business)
            foreach (ParseObject winningBid in winningBids)
            {
                ParseObject bid = await model.retrieveBidOfWinningBid(winningBid);

                ParseObject businessOfBid = bid.Get<ParseObject>(Constants.BUSINESS);

                if (businessOfBid.ObjectId == myBusiness.ObjectId)
                {
                    int originalPrice = bid.Get<int>(Constants.ORIGINAL_PRICE);
                    string comment = bid.Get<string>(Constants.COMMENTS);

                    ParseObject group = await model.retrieveGroupOfBid(bid);

                    //extract how many users are currently in the group
                    IEnumerable<ParseObject> groupUsers = await model.retrieveUsersOfGroup(group);

                    users.Add(groupUsers.Count());
                    originalPrices.Add(originalPrice);
                    comments.Add(comment);
                    groups.Add(group);
                }
            }
            ViewBag.groups = groups;
            ViewBag.originalPrices = originalPrices;
            ViewBag.comments = comments;
            ViewBag.users = users;

            return View();
        }


        public async System.Threading.Tasks.Task<ActionResult> MyProducts()
        {
            ParseObject myBusiness = await model.retrieveMyBusiness();
            IEnumerable<ParseObject> allMyProducts = await model.retrieveAllMyPoducts(myBusiness.ObjectId);

            List<string> products = new List<string>();

            //extract the title from each product
            foreach (ParseObject product in allMyProducts)
            {
                products.Add(model.getProductTitle(product));
            }

            ViewBag.products = products;
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> AddProductLink()
        {

            //Query for the select Lists of Category, SubCategory & Product
            IEnumerable<ParseObject> categories = await model.retrieveCategories();
            IEnumerable<ParseObject> subCategories = await model.retrieveSubCategories();
            IEnumerable<ParseObject> products = await model.retrieveAllProducts();

            //Names of products, categories and subcategories. Will move to parse controller...
            List<string> productsNames = new List<string>();
            List<string> categoriesNames = new List<string>();
            List<string> subCategoriesNames = new List<string>();
            foreach (ParseObject c in categories)
                categoriesNames.Add(c.Get<string>(Constants.NAME));
            foreach (ParseObject sc in subCategories)
                subCategoriesNames.Add(sc.Get<string>(Constants.NAME));
            foreach (ParseObject p in products)
                productsNames.Add(p.Get<string>(Constants.TITLE));


            //ViewBags sent to the view
            ViewBag.Categories = categories;
            ViewBag.SubCategories = subCategories;
            ViewBag.Products = products;
            ViewBag.ProductsNames = productsNames;
            ViewBag.CategoriesNames = categoriesNames;
            ViewBag.SubCategoriesNames = subCategoriesNames;

            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> AddProductToBusiness(FormCollection coll)
        {
            TempData["NewGroupCreated"] = null;

            //User wants to open new group of those parameters:
            string selectedCategory = coll[Constants.CATEGORY_ID];
            string selectedSubCategory = coll[Constants.SUB_CATEGORY_ID];
            string selectedProduct = coll[Constants.PRODUCT_ID];

            ParseObject myBusiness = await model.retrieveMyBusiness();

            await model.addProductToBusiness(selectedProduct, myBusiness.ObjectId);
            return View("myProducts");
        }


        }
    }