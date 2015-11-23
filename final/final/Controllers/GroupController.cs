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
        public async System.Threading.Tasks.Task<ActionResult> CreateGroup()
        {
            
            Models.CreateGroup createGroup = new CreateGroup();

            var CategoriesQuery = ParseObject.GetQuery(Constants.CATEGORY);
            IEnumerable<ParseObject> categories = await CategoriesQuery.FindAsync();
            ProductCategory product_category = new ProductCategory();
            createGroup.categories = (List<ProductCategory>)product_category.convert(categories);


            var SubCategoriesQuery = ParseObject.GetQuery(Constants.SUB_CATEGORY);
            IEnumerable<ParseObject> subCategories = await SubCategoriesQuery.FindAsync();
            SubCategory sub_category = new SubCategory();
            createGroup.subCategories = (List<SubCategory>)sub_category.convert(subCategories);

            
            var ProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE);
            IEnumerable<ParseObject> products = await ProductsQuery.FindAsync();
            Product product = new Product();
            createGroup.products = (List<Product>)product.convert(products);
            

            /*
            foreach (ParseObject p in categories)
            {
                Business temp = new Business();
                temp.CategoryID = p.ObjectId;
                temp.CategoryName = p.Get<string>("name");
                gp.categories.Add(temp);
            }
            

            var ProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE);
            IEnumerable<ParseObject> myProducts = await ProductsQuery.FindAsync();

            foreach (ParseObject p in myProducts)
            {
                Product temp = new Product();
                temp.productID = p.ObjectId;
                temp.title = p.Get<string>("title");
                gp.products.Add(temp);
            }

            gp.groupCreated = new DateTime();
            */
            return View(createGroup);



        }




        /*public async System.Threading.Tasks.Task<ActionResult> OpenGroup([Bind(Include = "productID")] GroupBuying group)
        {
            //var product = ParseObject.GetQuery("Product").WhereEqualTo(Constants.OBJECT_ID, group.productID);
            IEnumerable<ParseObject> results = await product.FindAsync();



            var new_group = new ParseObject("Group_Buying");
            new_group[Constants.PRODUCT] = results.FirstOrDefault();
            await new_group.SaveAsync();


            return RedirectToAction("GroupPage", group);
        }*/


        public ActionResult GroupPage(GroupBuying gp)
        {
            //gp.bidSelected = false;
            newGroupCreated(gp);


            return View(gp);
        }




        public async void newGroupCreated(GroupBuying gp)
        {

            //notify relevant bussiness In Email by product type
            var Business = ParseObject.GetQuery("Business");
            IEnumerable<ParseObject> bs = await Business.FindAsync();

            /*
            foreach (ParseObject b in bs)
            {
                
            }*/

            //
        }

    }
}






