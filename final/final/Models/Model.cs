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

        public Task<IEnumerable<ParseObject>> retrieveAllProducts()
        {
            return parseModel.retrieveAllProducts();
        }
        public Task<ParseObject> retrieveProduct(string productID)
        {
            return parseModel.retrieveProduct(productID);

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

        public void createGroup(ParseObject product)
        {
            parseModel.createGroup(product);

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

        //categories
        public Task<IEnumerable<ParseObject>> retrieveCategories()
        {
            return parseModel.retrieveCategories();
        }


        //sub categories
        public Task<IEnumerable<ParseObject>> retrieveSubCategories()
        {
            return parseModel.retrieveSubCategories();
        }
    }
}