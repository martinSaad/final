using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class BusinessParse
    {
        public static async Task<ParseObject> retrieveMyBusiness()
        {
            try
            {
                var currentUser = ParseUser.CurrentUser;
                var myBusinessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.USER, currentUser);
                ParseObject myBusiness = await myBusinessQuery.FirstAsync();
                return myBusiness;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveBusiness(string businessId)
        {
            try
            {
                var businessQuery = ParseObject.GetQuery(Constants.BUSINESS_TABLE).WhereEqualTo(Constants.OBJECT_ID, businessId);
                ParseObject business = await businessQuery.FirstAsync();
                return business;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<bool> addProductToBusiness(string productId, ParseObject business)
        {
            try
            {
                //get product
                Model model = new Model();
                ParseObject product = await model.retrieveProduct(productId);

                var relation = business.GetRelation<ParseObject>(Constants.PRODUCTS);
                relation.Add(product);
                await business.SaveAsync();

                return true; 
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }
    }
}