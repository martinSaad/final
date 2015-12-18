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

        /*
        step sizes are calculeted as following:
        - first step: 10% of max units
        - second step: also 10% of max units
        
        - now we take the units left. if bigger than 15, we devide by 3 and split equally between steps 3,4,5.
        if smaller than 15, we devide by 2 and split equally between steps 3,4.

        step 5 is not mandatory.
            
        */
        private int[] calculateStepSizes(int maxUints)
        {
            int unitsLeft = maxUints;
            int[] result = new int[5];
            //ceiling round's up the number
            result[1] = (int)Math.Ceiling(maxUints * 0.1);
            result[2] = result[1];

            unitsLeft = unitsLeft - (result[1] + result[2]);
            if (unitsLeft > 15)
            {
                int tmp = (int)Math.Ceiling((double)unitsLeft / 3);
                result[3] = tmp;
                result[4] = tmp;
                result[5] = unitsLeft - result[3] - result[4];
            }
            else
            {
                int tmp = (int)Math.Ceiling((double)unitsLeft / 2);
                result[3] = tmp;
                result[4] = unitsLeft - result[3];
            }

            return result;
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

        public async void winningBidSelector(string groupId)
        {
            await selectWinningBid(groupId);
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
        private async System.Threading.Tasks.Task<bool> selectWinningBid(string groupId)
        {
            IEnumerable<ParseObject> bids = await model.retrieveBids(groupId);

            double maxScore = 0;
            ParseObject bestBid = null;

            double stepDifference = 0;
            double lowestPrice = 0;
            double startingPrice = 0;
            double deliveryCapability = 0;
            double shippingCapability = 0;
            double guaranteeCapability = 0;

            foreach (ParseObject bid in bids)
            {
                //step difference calculation
                double step2to3Difference = model.getBidPriceStep2(bid) - model.getBidPriceStep3(bid);
                double step3to4Difference = model.getBidPriceStep3(bid) - model.getBidPriceStep4(bid);
                if (step2to3Difference > step3to4Difference)
                    stepDifference = step2to3Difference * Constants.CALCULATION_STEPS_DIFFERENCE / 100;
                else
                    stepDifference = step3to4Difference * Constants.CALCULATION_STEPS_DIFFERENCE / 100;

                //lowest price calculation
                //not always there is a 5th step. if exsist - take it.
                if (bid.Get<double>(Constants.PRICE_STEP_5) != 0)
                    lowestPrice = model.getBidPriceStep5(bid) * Constants.CALCULATION_LOWEST_PRICE / 100;
                else
                    lowestPrice = model.getBidPriceStep4(bid) * Constants.CALCULATION_LOWEST_PRICE / 100;

                //starting price calculation
                startingPrice = model.getBidOriginalPrice(bid) * Constants.CALCULATION_STARTING_PRICE / 100;

                //delivery capability calculation
                deliveryCapability = model.getBidMaxUints(bid) * Constants.CALCULATION_DELIVERY_CAPABILITY / 100;

                //shipping capability calculation
                if (model.getBidShipping(bid) == true)
                    shippingCapability = Constants.CALCULATION_SHIPPING_CAPABILITY;
                else
                    shippingCapability = 0;

                //guarantee capability calculation
                guaranteeCapability = model.getBidGuarantee(bid) * Constants.CALCULATION_GUARANTEE_CAPABILITY / 100;

                //add review if necessary


                double score = stepDifference + lowestPrice + startingPrice + deliveryCapability + shippingCapability + guaranteeCapability;
                if (score > maxScore)
                {
                    maxScore = score;
                    bestBid = bid;
                }                   
             }

            try
            {
                await model.createWinningBid(bestBid);
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