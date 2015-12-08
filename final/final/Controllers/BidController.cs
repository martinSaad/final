using final.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class BidController : Controller
    {
        Model model = new Model();


        // GET: Bid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBidLink(string groupId)
        {
            TempData["groupId"] = groupId;
            return View();
        }

        private async System.Threading.Tasks.Task<ActionResult> CreateBid(FormCollection coll)
        {
            ParseObject myBusiness = await model.retrieveMyBusiness();

            double maxUints = Convert.ToDouble(coll[Constants.MAX_UNITS]);
            double originalPrice = Convert.ToDouble(coll[Constants.ORIGINAL_PRICE]);
            double priceStep1 = Convert.ToDouble(coll[Constants.PRICE_STEP_1]);
            double priceStep2 = Convert.ToDouble(coll[Constants.PRICE_STEP_2]);
            double priceStep3 = Convert.ToDouble(coll[Constants.PRICE_STEP_3]);
            double priceStep4 = Convert.ToDouble(coll[Constants.PRICE_STEP_4]);
            double priceStep5 = Convert.ToDouble(coll[Constants.PRICE_STEP_5]);
            string comments = coll[Constants.COMMENTS];
            double guarantee = Convert.ToDouble(coll[Constants.GUARANTEE]);
            bool shipping = Convert.ToBoolean(coll[Constants.SHIPPING]);

            string groupId = (string)TempData["groupId"];

            await model.createBid(myBusiness, groupId, maxUints, originalPrice, priceStep1, priceStep2, priceStep3, priceStep4, priceStep5, comments, guarantee, shipping);
            return View();
        }


        /*
        winning bid is determined by several parameters:
        1. select biggest difference between second and third prices steps, or between 3h and 4h.
        2. lowest price of the product (depends on max units)
        3. original price
        4. ability to deliver to maximum people (max units)
        5. does have shipping
        6. how much guarantee (if any)
        7. reviews of the business

        Each parameter is weighted with a certain percentage - specified in Constants class
        */
        private async System.Threading.Tasks.Task<ParseObject> selectWinningBid(string groupId)
        {
            IEnumerable<ParseObject> bids = await model.retrieveBids(groupId);

            double maxScore = 0;
            ParseObject bestBid = null;

            double stepDifference;
            double lowestPrice;
            double startingPrice;
            double deliveryCapability;
            double shippingCapability;
            double guaranteeCapability;

            foreach (ParseObject bid in bids)
            {
                //step difference calculation
                double step2to3Difference = model.getPriceStep2(bid) - model.getPriceStep3(bid);
                double step3to4Difference = model.getPriceStep3(bid) - model.getPriceStep4(bid);
                if (step2to3Difference > step3to4Difference)
                    stepDifference = step2to3Difference * Constants.CALCULATION_STEPS_DIFFERENCE / 100;
                else
                    stepDifference = step3to4Difference * Constants.CALCULATION_STEPS_DIFFERENCE / 100;

                //lowest price calculation
                //not always there is a 5th step. if exsist - take it.
                if (bid.Get<double>(Constants.PRICE_STEP_5) != 0)
                    lowestPrice = model.getPriceStep5(bid) * Constants.CALCULATION_LOWEST_PRICE / 100;
                else
                    lowestPrice = model.getPriceStep4(bid) * Constants.CALCULATION_LOWEST_PRICE / 100;

                //starting price calculation
                startingPrice = model.getOriginalPrice(bid) * Constants.CALCULATION_STARTING_PRICE / 100;

                //delivery capability calculation
                deliveryCapability = model.getMaxUints(bid) * Constants.CALCULATION_DELIVERY_CAPABILITY / 100;

                //shipping capability calculation
                if (model.getShipping(bid) == true)
                    shippingCapability = Constants.CALCULATION_SHIPPING_CAPABILITY;
                else
                    shippingCapability = 0;

                //guarantee capability calculation
                guaranteeCapability = model.getGuarantee(bid) * Constants.CALCULATION_GUARANTEE_CAPABILITY / 100;

                //add review if necessary


                double score = stepDifference + lowestPrice + startingPrice + deliveryCapability + shippingCapability + guaranteeCapability;
                if (score > maxScore)
                {
                    maxScore = score;
                    bestBid = bid;
                }                   
             }

            await model.createWinningBid(bestBid);
            return null;
        }
    }
}