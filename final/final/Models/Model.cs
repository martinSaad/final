using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class Model : ParseInterface
    {
        ParseModel parseModel;

        //constructor
        public Model()
        {
            parseModel = new ParseModel();
        }

        //business
        public Task<ParseObject> retrieveMyBusiness()
        {
            return parseModel.retrieveMyBusiness();
        }

        public Task<ParseObject> retrieveBusiness(string businessId)
        {
            return parseModel.retrieveBusiness(businessId);
        }

        public Task<bool> addProductToBusiness(string productId, string businessId)
        {
            return parseModel.addProductToBusiness(productId, businessId);
        }

        //product
        public Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            return parseModel.businessesWhoHaveThisProduct(product);
        }

        public Task<IEnumerable<ParseObject>> retrieveAllProducts()
        {
            return parseModel.retrieveAllProducts();
        }
        public Task<ParseObject> retrieveProduct(string productID)
        {
            return parseModel.retrieveProduct(productID);

        }
        public Task<IEnumerable<ParseObject>> retrieveAllMyPoducts(string businessId)
        {
            return parseModel.retrieveAllMyPoducts(businessId);
        }
        public string getProductTitle(ParseObject product)
        {
            return parseModel.getProductTitle(product);
        }


        //group
        public Task<IEnumerable<ParseObject>> retrieveAllActiveGroups()
        {
            return parseModel.retrieveAllActiveGroups();
        }

        public Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            return parseModel.retrieveUsersOfGroup(group);
        }

        public Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            return parseModel.retrieveProductOfGroup(group);
        }

        public Task<bool> createGroup(ParseObject product)
        {
            return parseModel.createGroup(product);

        }
        public Task<ParseObject> retrieveGroup(string groupId)
        {
            return parseModel.retrieveGroup(groupId);
        }


        //winning bid
        public Task<IEnumerable<ParseObject>> retrieveWinningBids()
        {
            return parseModel.retrieveWinningBids();
        }

        public Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid)
        {
            return parseModel.retrieveBidOfWinningBid(winningBid);
        }

        public Task<bool> createWinningBid(ParseObject bid)
        {
            return parseModel.createWinningBid(bid);
        }
        //bid
        public Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            return parseModel.retrieveGroupOfBid(bid);
        }

        public Task<bool> createBid(ParseObject business, string groupId, double maxUnits, double originalPrice, double priceStep1, double priceStep2, double priceStep3, double priceStep4, double priceStep5, string comments, double guarantee, bool shipping)
        {
            return parseModel.createBid(business, groupId, maxUnits, originalPrice, priceStep1, priceStep2, priceStep3, priceStep4, priceStep5, comments, guarantee, shipping);
        }

        public Task<IEnumerable<ParseObject>> retrieveBids(string groupId)
        {
            return parseModel.retrieveBids(groupId);
        }

        public double getPriceStep1(ParseObject bid)
        {
            return parseModel.getPriceStep1(bid);
        }

        public double getPriceStep2(ParseObject bid)
        {
            return parseModel.getPriceStep2(bid);
        }

        public double getPriceStep3(ParseObject bid)
        {
            return parseModel.getPriceStep3(bid);
        }

        public double getPriceStep4(ParseObject bid)
        {
            return parseModel.getPriceStep4(bid);
        }

        public double getPriceStep5(ParseObject bid)
        {
            return parseModel.getPriceStep5(bid);
        }

        public double getGuarantee(ParseObject bid)
        {
            return parseModel.getGuarantee(bid);
        }

        public double getOriginalPrice(ParseObject bid)
        {
            return parseModel.getOriginalPrice(bid);
        }

        public double getMaxUints(ParseObject bid)
        {
            return parseModel.getOriginalPrice(bid);
        }

        public bool getShipping(ParseObject bid)
        {
            return parseModel.getShipping(bid);
        }



        //categories
        public Task<IEnumerable<ParseObject>> retrieveCategories()
        {
            return parseModel.retrieveCategories();
        }
        public string getCategoryName(ParseObject category)
        {
            return parseModel.getCategoryName(category);
        }


        //sub categories
        public Task<IEnumerable<ParseObject>> retrieveSubCategories()
        {
            return parseModel.retrieveSubCategories();
        }
        public string getSubCategoryName(ParseObject subCategory)
        {
            return parseModel.getSubCategoryName(subCategory);
        }
    }
}