using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        Model model = new Model();
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<ParseObject> groups = new List<ParseObject>(); //return value
            IEnumerable<ParseObject> allActiveGroups = await model.retrieveAllActiveGroups();
            List<string> allActiveGroupsNames = new List<string>();
            foreach (ParseObject group in allActiveGroups)
            {
                ParseObject productOfGroup = group.Get<ParseObject>(Constants.PRODUCT);
                ParseObject product = await model.retrieveProduct(productOfGroup.ObjectId);
                allActiveGroupsNames.Add(product.Get<string>(Constants.TITLE));
            }    
            

            //ViewBag.groupsNames = groupsNames;
            ViewBag.allActiveGroups = allActiveGroups;
            ViewBag.allActiveGroupsNames = allActiveGroupsNames;
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