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
        public async System.Threading.Tasks.Task<ActionResult> Groups()
        {
            var currentUser = ParseUser.CurrentUser;

            var myBusinessQuery = ParseObject.GetQuery("Business").WhereEqualTo("user", currentUser);
            ParseObject myBusiness = await myBusinessQuery.FirstAsync();

            var myProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo("business", myBusiness);
            IEnumerable<ParseObject> myProducts = await myProductsQuery.FindAsync();

            foreach (ParseObject product in myProducts)
            {
                var myValidGroupsQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo("product", product);
                IEnumerable<ParseObject> myValidGroups = await myValidGroupsQuery.FindAsync();
                foreach(ParseObject group in myValidGroups)
                {
                    //TODO: compare expiration date with current date and show only valid groups.
                }
                }
            

            return View();
        }
    }
}