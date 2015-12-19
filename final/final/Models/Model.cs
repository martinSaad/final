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

        public Task<bool> addProductToBusiness(string productId, ParseObject business)
        {
            return parseModel.addProductToBusiness(productId, business);
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
        public Task<ParseObject> retrieveActiveGroupForProduct(string productID)
        {
            return parseModel.retrieveActiveGroupForProduct(productID);
        }

        public string getProductTitle(ParseObject product)
        {
            return parseModel.getProductTitle(product);
        }
        public ParseFile getProductImage(ParseObject product)
        {
            return parseModel.getProductImage(product);
        }
        public Task<bool> addBusinessToProduct(string productId, ParseObject business)
        {
            return parseModel.addBusinessToProduct(productId, business);
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
        public DateTime getExpirationDate(ParseObject group)
        {
            return parseModel.getExpirationDate(group);
        }
        public Task<bool> setGroupActive(ParseObject group, bool status)
        {
            return parseModel.setGroupActive(group, status);
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

        public Task<ParseObject> getBid(ParseObject bid)
        {
            return parseModel.getBid(bid);
        }
        public double getBidPriceStep1(ParseObject bid)
        {
            return parseModel.getBidPriceStep1(bid);
        }

        public double getBidPriceStep2(ParseObject bid)
        {
            return parseModel.getBidPriceStep2(bid);
        }

        public double getBidPriceStep3(ParseObject bid)
        {
            return parseModel.getBidPriceStep3(bid);
        }

        public double getBidPriceStep4(ParseObject bid)
        {
            return parseModel.getBidPriceStep4(bid);
        }

        public double getBidPriceStep5(ParseObject bid)
        {
            return parseModel.getBidPriceStep5(bid);
        }

        public double getBidGuarantee(ParseObject bid)
        {
            return parseModel.getBidGuarantee(bid);
        }

        public double getBidOriginalPrice(ParseObject bid)
        {
            return parseModel.getBidOriginalPrice(bid);
        }

        public double getBidMaxUints(ParseObject bid)
        {
            return parseModel.getBidMaxUints(bid);
        }

        public bool getBidShipping(ParseObject bid)
        {
            return parseModel.getBidShipping(bid);
        }

        public string getBusinessIdOfBid(ParseObject bid)
        {
            return parseModel.getBusinessIdOfBid(bid);
        }

        public string getCommentsOfBid(ParseObject bid)
        {
            return parseModel.getCommentsOfBid(bid);
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

        //user
        public bool isBusiness(ParseUser user)
        {
            return parseModel.isBusiness(user);
        }

    }
}