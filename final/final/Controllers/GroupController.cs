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
        Model model = new Model();
        // GET: Group


        //create group page - return the values of the select lists in create group view
        //[Authorize]
        public async System.Threading.Tasks.Task<ActionResult> CreateGroup()
        {

            //Query for the select Lists of Category, SubCategory & Product
            IEnumerable<ParseObject> categories = await model.retrieveCategories();
            IEnumerable<ParseObject> subCategories = await model.retrieveSubCategories();
            IEnumerable<ParseObject> products = await model.retrieveAllProducts();

            //Names of products, categories and subcategories
            List<string> productsNames = new List<string>();
            List<string> categoriesNames = new List<string>();
            List<string> subCategoriesNames = new List<string>();
            foreach (ParseObject category in categories)
                categoriesNames.Add(model.getCategoryName(category));
            foreach (ParseObject subCategory in subCategories)
                subCategoriesNames.Add(model.getSubCategoryName(subCategory));
            foreach (ParseObject product in products)
                productsNames.Add(model.getProductTitle(product));
            
            
            //ViewBags sent to the view
            ViewBag.Categories = categories;
            ViewBag.SubCategories = subCategories;
            ViewBag.Products = products;
            ViewBag.ProductsNames = productsNames;
            ViewBag.CategoriesNames = categoriesNames;
            ViewBag.SubCategoriesNames = subCategoriesNames;


            return View();
        }



        //[Authorize]
        public async System.Threading.Tasks.Task<ActionResult> OpenGroup(FormCollection coll)
        {
            TempData["NewGroupCreated"] = null;

            //User wants to open new group of those parameters:
            string selectedCategory = coll[Constants.CATEGORY_ID];
            string selectedSubCategory = coll[Constants.SUB_CATEGORY_ID];
            string selectedProduct = coll[Constants.PRODUCT_ID];

            
            //check if we have active group for the same product
            bool AlreadyHaveActiveGroupForThisProduct = false;
            IEnumerable<ParseObject> groups = await model.retrieveAllActiveGroups();
            foreach (ParseObject group in groups){
                ParseObject product = await model.retrieveProductOfGroup(group);
                if (product.ObjectId == selectedProduct)
                    AlreadyHaveActiveGroupForThisProduct = true;
            }
            
            //if we don't have active group right now of this product, lets create a new one!
            if (!AlreadyHaveActiveGroupForThisProduct){
                ParseObject product = await model.retrieveProduct(selectedProduct);
                await model.createGroup(product);
                
                //pass parameters to the GroupPage Action Result (because this function is in the middle)
                TempData["NewGroupCreated"] = product;    
            }


            //pass parameters to the GroupPage Action Result (because this function is in the middle)
            ParseObject productToPass = new ParseObject(selectedProduct);
            productToPass.ObjectId = selectedProduct;
            TempData["Product"] = productToPass;


            return RedirectToAction("GroupPage");
        }

        //[Authorize]
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


        //The group Page
        public async Task<ActionResult> Group(string groupId)
        {
            ParseObject group = await model.retrieveGroup(groupId);
            



            return View();
        }







/*
        public async void newGroupCreated(string ObjectId)
        {
            //notify relevant bussiness In Email by product type
            var Business = ParseObject.GetQuery("Business");
            IEnumerable<ParseObject> bs = await Business.FindAsync();




        }
        */
    }
}






