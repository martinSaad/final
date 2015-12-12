using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Parse;

namespace final.Models
{
    public class BidParse
    {
        public static async Task<ParseObject> retrieveGroupOfBid(ParseObject bid)
        {
            try
            {
                //minGroup is just to obtain the group objectId
                ParseObject minGroup = bid.Get<ParseObject>(Constants.GROUP_BUYING);

                //group is a Pointer in the bid, therefore we need to query him
                var groupQuery = ParseObject.GetQuery(Constants.GROUP_BUYING_TABLE).WhereEqualTo(Constants.OBJECT_ID, minGroup.ObjectId);
                ParseObject group = await groupQuery.FirstAsync();

                return group;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<bool> createBid(ParseObject business, string groupId, double maxUnits, double originalPrice, double priceStep1, double priceStep2, double priceStep3, double priceStep4, double priceStep5, string comments, double guarantee, bool shipping)
        {
            try
            {
                var bidObject = new ParseObject(Constants.BID_TABLE);

                //TODO: check max units - between 10-50
                bidObject[Constants.MAX_UNITS] = maxUnits;


                bidObject[Constants.ORIGINAL_PRICE] = originalPrice;
                bidObject[Constants.PRICE_STEP_1] = priceStep1;
                bidObject[Constants.PRICE_STEP_2] = priceStep2;
                bidObject[Constants.PRICE_STEP_3] = priceStep3;
                bidObject[Constants.PRICE_STEP_4] = priceStep4;
                bidObject[Constants.PRICE_STEP_5] = priceStep5;
                bidObject[Constants.COMMENTS] = comments;
                bidObject[Constants.BUSINESS] = business;
                bidObject[Constants.GUARANTEE] = guarantee;
                bidObject[Constants.SHIPPING] = shipping;

                Model model = new Model();
                ParseObject group = await model.retrieveGroup(groupId);

                bidObject[Constants.GROUP_BUYING] = group;

                await bidObject.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }
        }

        public static async Task<IEnumerable<ParseObject>> retrieveBids(string groupId)
        {
            try
            {
                var bidsQuery = ParseObject.GetQuery(Constants.BID_TABLE).WhereEqualTo(Constants.GROUP_BUYING, groupId);
                IEnumerable<ParseObject> bids = await bidsQuery.FindAsync();

                return bids;
            }
            catch (Exception e)
            {
                //add log
                throw e;
            }       
        }

        public static double getBidPriceStep1(ParseObject bid)
        {
            return bid.Get<double>(Constants.PRICE_STEP_1);
        }
        public static double getBidPriceStep2(ParseObject bid)
        {
            return bid.Get<double>(Constants.PRICE_STEP_2);
        }
        public static double getBidPriceStep3(ParseObject bid)
        {
            return bid.Get<double>(Constants.PRICE_STEP_3);
        }
        public static double getBidPriceStep4(ParseObject bid)
        {
            return bid.Get<double>(Constants.PRICE_STEP_4);
        }
        public static double getBidPriceStep5(ParseObject bid)
        {
            return bid.Get<double>(Constants.PRICE_STEP_5);
        }
        public static double getBidGuarantee(ParseObject bid)
        {
            return bid.Get<double>(Constants.GUARANTEE);
        }
        public static double getBidOriginalPrice(ParseObject bid)
        {
            return bid.Get<double>(Constants.ORIGINAL_PRICE);
        }
        public static double getBidMaxUints(ParseObject bid)
        {
            return bid.Get<double>(Constants.MAX_UNITS);
        }
        public static bool getBidShipping(ParseObject bid)
        {
            return bid.Get<bool>(Constants.SHIPPING);

        }
        public static string getBusinessIdOfBid(ParseObject bid)
        {
            ParseObject businessOfBid = bid.Get<ParseObject>(Constants.BUSINESS);
            return businessOfBid.ObjectId;
        }
        public static string getCommentsOfBid(ParseObject bid)
        {
            return bid.Get<string>(Constants.COMMENTS);
        }


    }
}