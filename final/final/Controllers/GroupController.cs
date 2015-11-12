using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult CreateGroup()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> OpenGroup([Bind(Include = "productID")] GroupBuying group)
        {
            var product = ParseObject.GetQuery("Product").WhereEqualTo(Constants.OBJECT_ID, group.productID);
            IEnumerable<ParseObject> results = await product.FindAsync();


            var new_group = new ParseObject("Group_Buying");
            new_group[group.PRODUCT] = results.FirstOrDefault();

            await new_group.SaveAsync();
            return View();
        }

    }
}