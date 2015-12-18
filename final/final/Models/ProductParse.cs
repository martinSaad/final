using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.Threading.Tasks;

namespace final.Models
{
    public class ProductParse
    {
        public static async Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            try
            {
                var relation = product.GetRelation<ParseObject>(Constants.BUSINESS);
                IEnumerable<ParseObject> businesses = await relation.Query.FindAsync();
                return businesses;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }



        public static async Task<IEnumerable<ParseObject>> retrieveAllProducts()
        {
            try
            {
                var ProductsQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE);
                IEnumerable<ParseObject> products = await ProductsQuery.FindAsync();

                return products;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<IEnumerable<ParseObject>> retrieveAllMyPoducts(string businessId)
        {
            try
            {
                Model model = new Model();
                ParseObject business = await model.retrieveBusiness(businessId);

                var relation = business.GetRelation<ParseObject>(Constants.PRODUCTS);
                IEnumerable<ParseObject> products = await relation.Query.FindAsync();

                return products;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveProduct(string productID)
        {
            try
            {
                var productQuery = ParseObject.GetQuery(Constants.PRODUCT_TABLE).WhereEqualTo(Constants.OBJECT_ID, productID);
                ParseObject product = await productQuery.FirstAsync();


                return product;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveActiveGroupForProduct(string productID)
        {
            try
            {
                ParseObject product = await retrieveProduct(productID);
                var productQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.PRODUCT, product).WhereEqualTo(Constants.ACTIVE, true);
                ParseObject group = await productQuery.FirstAsync();


                return group;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }


        public static string getProductTitle(ParseObject product)
        {
            return product.Get<string>(Constants.TITLE);
        }

        public static ParseFile getProductImage(ParseObject product)
        {
            return product.Get<ParseFile>(Constants.IMAGE);
        }

    }
}