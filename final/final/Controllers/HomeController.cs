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
            IEnumerable<ParseObject> allGroups = await model.retrieveAllActiveGroups();
            /*List<string> groupsForProducts = new List<string>();
            foreach (var group in allGroups)
            {
                groupsNames.Add(group.Get<string>(Constants.NAME));
            }*/


            //ViewBag.groupsNames = groupsNames;
            ViewBag.allGroups = allGroups;
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