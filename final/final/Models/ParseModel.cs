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

        //bid
        public Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            return BidParse.retrieveGroupOfBid(bid);
        }

        public Task<bool> createBid(ParseObject business, string groupId, double price, string comments)
        {
            return BidParse.createBid(business, groupId, price, comments);
        }


        //category
        public Task<IEnumerable<ParseObject>> retrieveCategories()
        {
            return CategoryParse.retrieveCategory();
        }

        //sub category
        public Task<IEnumerable<ParseObject>> retrieveSubCategories()
        {
            return SubCategoryParse.retrieveSubCategory();
        }

    }
}