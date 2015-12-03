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

        //group
        public Task<IEnumerable<ParseObject>> retrieveAllGroups()
        {
            return GroupParse.retrieveAllGroups();
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
    }
}