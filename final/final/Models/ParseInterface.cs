using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace final.Models
{
    interface ParseInterface
    {
        //business
        Task<ParseObject> retrieveMyBusiness();

        //product
        Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product);
        Task<IEnumerable<ParseObject>> retrieveAllProducts();
        Task<ParseObject> retrieveProduct(string productID);

        //group
        Task<IEnumerable<ParseObject>> retrieveAllActiveGroups();
        Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group);
        Task<ParseObject> retrieveProductOfGroup(ParseObject group);
        void createGroup(ParseObject product);

        //winning bid
        Task<IEnumerable<ParseObject>> retrieveWinningBids();
        Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid);

        //bid
        Task<ParseObject> retrieveGroupOfBid(ParseObject bid);

        //category
        Task<IEnumerable<ParseObject>> retrieveCategories();

        //subcategory
        Task<IEnumerable<ParseObject>> retrieveSubCategories();

    }

}
