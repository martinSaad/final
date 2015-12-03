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

        //product
        public Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product)
        {
            return parseModel.businessesWhoHaveThisProduct(product);
        }

        //group
        public Task<IEnumerable<ParseObject>> retrieveAllGroups()
        {
            return parseModel.retrieveAllGroups();
        }

        public Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group)
        {
            return parseModel.retrieveUsersOfGroup(group);
        }

        public Task<ParseObject> retrieveProductOfGroup(ParseObject group)
        {
            return parseModel.retrieveProductOfGroup(group);
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

        public Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            return parseModel.retrieveGroupOfBid(bid);
        }
    }
}