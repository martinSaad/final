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

            var myProductsQuery = ParseObject.GetQuery(Models.Constants.PRODUCT_TABLE).WhereEqualTo("business", myBusiness);
            IEnumerable<ParseObject> myProducts = await myProductsQuery.FindAsync();


            var myValidGroupsQuery = ParseObject.GetQuery(Models.Constants.GROUP_BUYING_TABLE).WhereEqualTo("product", myProducts.FirstOrDefault());
            IEnumerable<ParseObject> myValidGroups = await myValidGroupsQuery.FindAsync();

            return View();
        }
    }
}