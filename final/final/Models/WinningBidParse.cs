using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class WinningBidParse
    {
        public static async Task<IEnumerable<ParseObject>> retrieveWinningBids()
        {
            try
            {
                var winningBidsQuery = ParseObject.GetQuery(Constants.WINNING_BID_TABLE);
                IEnumerable<ParseObject> winningBids = await winningBidsQuery.FindAsync();
                return winningBids;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid)
        {
            Model model = new Model();
            try
            {
                ParseObject bid = await model.getBid(winningBid);
                var bidQuery = ParseObject.GetQuery(Constants.BID_TABLE).WhereEqualTo(Constants.OBJECT_ID, bid.ObjectId);
                //ParseObject bid = await bidQuery.FirstAsync();

                return bid;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<bool> createWinningBid(ParseObject bid)
        {
            try
            {
                ParseObject winningBid = new ParseObject(Constants.WINNING_BID_TABLE);
                winningBid[Constants.BID] = bid;

                await winningBid.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

    }
}