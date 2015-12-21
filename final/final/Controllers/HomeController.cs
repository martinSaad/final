using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        Model model = new Model();
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<ParseObject> groups = new List<ParseObject>(); //return value
            IEnumerable<ParseObject> allActiveGroups = await model.retrieveAllActiveGroups();
            List<string> allActiveGroupsNames = new List<string>();
            List<string> productImages = new List<string>();
            foreach (ParseObject group in allActiveGroups)
            {
                ParseObject productOfGroup = group.Get<ParseObject>(Constants.PRODUCT);
                ParseObject product = await model.retrieveProduct(productOfGroup.ObjectId);
                ParseFile file = model.getProductImage(product);
                productImages.Add(file.Url.ToString());
                allActiveGroupsNames.Add(product.Get<string>(Constants.TITLE));
            }    
            

            //ViewBag.groupsNames = groupsNames;
            ViewBag.allActiveGroups = allActiveGroups;
            ViewBag.allActiveGroupsNames = allActiveGroupsNames;
            ViewBag.productImages = productImages;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}