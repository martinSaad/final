using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.Threading.Tasks;

namespace final.Models
{
    public class ParseModel : ParseInterface
    {
        //business
        public Task<ParseObject> retrieveMyBusiness()
        {
            return BusinessParse.retrieveMyBusiness();
        }

        public Task<ParseObject> retrieveBusiness(string businessId)
        {
            return BusinessParse.retrieveBusiness(businessId);
        }

        public Task<bool> addProductToBusiness(string productId, string businessId)
        {
            return BusinessParse.addProductToBusiness(productId, businessId);
        }



        //product
        public Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            return ProductParse.businessesWhoHaveThisProduct(product);
        }
        public Task<IEnumerable<ParseObject>> retrieveAllProducts()
        {
            return ProductParse.retrieveAllProducts();
        }
        public Task<ParseObject> retrieveProduct(string productID)
        {
            return ProductParse.retrieveProduct(productID);
        }
        public Task<IEnumerable<ParseObject>> retrieveAllMyPoducts(string businessId)
        {
            return ProductParse.retrieveAllMyPoducts(businessId);
        }
        public string getProductTitle(ParseObject product)
        {
            return ProductParse.getProductTitle(product);
        }


        //group
        public Task<IEnumerable<ParseObject>> retrieveAllActiveGroups()
        {
            return GroupParse.retrieveAllActiveGroups();
        }
        public Task<bool> createGroup(ParseObject product)
        {
            return GroupParse.createGroup(product);

        }

        public Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            return GroupParse.retrieveUsersOfGroup(group);
        }

        public Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            return GroupParse.retrieveProductOfGroup(group);
        }

        public Task<ParseObject> retrieveGroup(string groupId)
        {
            return GroupParse.retrieveGroup(groupId);
        }


        //winning bid
        public Task<IEnumerable<ParseObject>> retrieveWinningBids()
        {
            return WinningBidParse.retrieveWinningBids();
        }

        public Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid)
        {
            return WinningBidParse.retrieveBidOfWinningBid(winningBid);
        }

        public Task<bool> createWinningBid(ParseObject bid)
        {
            return WinningBidParse.createWinningBid(bid);
        }


        //bid
        public Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            return BidParse.retrieveGroupOfBid(bid);
        }

        public Task<bool> createBid(ParseObject business, string groupId, double maxUnits, double originalPrice, double priceStep1, double priceStep2, double priceStep3, double priceStep4, double priceStep5, string comments, double guarantee, bool shipping)
        {
            return BidParse.createBid(business, groupId, maxUnits, originalPrice, priceStep1, priceStep2, priceStep3, priceStep4, priceStep5, comments, guarantee, shipping);
        }
        public Task<IEnumerable<ParseObject>> retrieveBids(string groupId)
        {
            return BidParse.retrieveBids(groupId);
        }

        public double getPriceStep1(ParseObject bid)
        {
            return BidParse.getPriceStep1(bid);
        }

        public double getPriceStep2(ParseObject bid)
        {
            return BidParse.getPriceStep2(bid);
        }

        public double getPriceStep3(ParseObject bid)
        {
            return BidParse.getPriceStep3(bid);
        }

        public double getPriceStep4(ParseObject bid)
        {
            return BidParse.getPriceStep5(bid);
        }

        public double getPriceStep5(ParseObject bid)
        {
            return BidParse.getPriceStep5(bid);
        }

        public double getGuarantee(ParseObject bid)
        {
            return BidParse.getGuarantee(bid);
        }

        public double getOriginalPrice(ParseObject bid)
        {
            return BidParse.getOriginalPrice(bid);
        }

        public double getMaxUints(ParseObject bid)
        {
            return BidParse.getMaxUints(bid);
        }

        public bool getShipping(ParseObject bid)
        {
            return BidParse.getShipping(bid);
        }



        //category
        public Task<IEnumerable<ParseObject>> retrieveCategories()
        {
            return CategoryParse.retrieveCategory();
        }

        public string getCategoryName(ParseObject category)
        {
            return CategoryParse.getCategoryName(category);
        }

        //sub category
        public Task<IEnumerable<ParseObject>> retrieveSubCategories()
        {
            return SubCategoryParse.retrieveSubCategory();
        }

        public string getSubCategoryName(ParseObject subCategory)
        {
            return SubCategoryParse.getSubCategoryName(subCategory);
        }
    }
}