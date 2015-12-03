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

        //group
        Task<IEnumerable<ParseObject>> retrieveAllGroups();
        Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group);
        Task<ParseObject> retrieveProductOfGroup(ParseObject group);

        //winning bid
        Task<IEnumerable<ParseObject>> retrieveWinningBids();
        Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid);

        //bid
        Task<ParseObject> retrieveGroupOfBid(ParseObject bid);

    }

}
