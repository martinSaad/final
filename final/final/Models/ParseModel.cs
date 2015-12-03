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

        //group
        public Task<IEnumerable<ParseObject>> retrieveAllActiveGroups()
        {
            return GroupParse.retrieveAllActiveGroups();
        }
        public void createGroup(ParseObject product)
        {
            GroupParse.createGroup(product);

        }

        public Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            return GroupParse.retrieveUsersOfGroup(group);
        }

        public Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            return GroupParse.retrieveProductOfGroup(group);
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