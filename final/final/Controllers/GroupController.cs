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
    public class GroupController : Controller
    {
        // GET: Group
        public async System.Threading.Tasks.Task<ActionResult> CreateGroup()
        {

            //Query for the select Lists of Category, SubCategory & Product
            var CategoriesQuery = ParseObject.GetQuery(Constants.CATEGORY);
            IEnumerable<ParseObject> categories = await CategoriesQuery.FindAsync();
            var SubCategoriesQuery = ParseObject.GetQuery(Constants.SUB_CATEGORY);
            IEnumerable<ParseObject> subCategories = await SubCategoriesQuery.FindAsync();
            var ProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE);
            IEnumerable<ParseObject> products = await ProductsQuery.FindAsync();


            //ViewBags sent to the view
            ViewBag.Categories = categories;
            ViewBag.SubCategories = subCategories;
            ViewBag.Products = products;


            return View();

        }

        

        public async System.Threading.Tasks.Task<ActionResult> OpenGroup(FormCollection coll)
        {
            TempData["NewGroupCreated"] = null;

            //User wants to open new group of those parameters:
            string selectedCategory = coll[Constants.CATEGORY_ID];
            string selectedSubCategory = coll[Constants.SUB_CATEGORY_ID];
            string selectedProduct = coll[Constants.PRODUCT_ID];

            
            //check if we have active group for the same product
            bool AlreadyHaveActiveGroupForThisProduct = false;
            var allGroups = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.ACTIVE, true);
            IEnumerable<ParseObject> groups = await allGroups.FindAsync();
            foreach (ParseObject group in groups)
            {
                ParseObject minProduct = group.Get<ParseObject>(Constants.PRODUCT);
                if (minProduct.ObjectId == selectedProduct)
                    AlreadyHaveActiveGroupForThisProduct = true;
            }


            //if we don't have active group right now of this product, lets create a new one!
            if (!AlreadyHaveActiveGroupForThisProduct)
            {
                
                var product = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.OBJECT_ID, selectedProduct);
                IEnumerable<ParseObject> results = await product.FindAsync();
                var newGroup = new ParseObject(Constants.GROUP_BUYING_TABLE);
                newGroup[Constants.PRODUCT] = results.FirstOrDefault();
                newGroup[Constants.ACTIVE] = true; //we just created new group of this product so now we have an active group until the group will finished
                
                //pass parameters to the GroupPage Action Result (because this function is in the middle)
                TempData["NewGroupCreated"] = newGroup;
                
                await newGroup.SaveAsync();
            }


            //pass parameters to the GroupPage Action Result (because this function is in the middle)
            ParseObject productToPass = new ParseObject(selectedProduct);
            productToPass.ObjectId = selectedProduct;
            TempData["Product"] = productToPass;


            return RedirectToAction("GroupPage");
        }


        public ActionResult GroupPage()
        {
            ViewBag.Product = TempData["Product"];
            if (TempData["NewGroupCreated"] != null)
            {
                ViewBag.NewGroupCreatedRightNow = true;
            }
            else
                ViewBag.NewGroupCreatedRightNow = false;

           return View();
        }



        public ActionResult Group()
        {
            return View();
        }








        public async void newGroupCreated(string ObjectId)
        {
            //notify relevant bussiness In Email by product type
            var Business = ParseObject.GetQuery("Business");
            IEnumerable<ParseObject> bs = await Business.FindAsync();




        }

    }
}






