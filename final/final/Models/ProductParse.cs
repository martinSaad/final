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
    }
}