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
        Task<ParseObject> retrieveBusiness(string businessId);
        Task<bool> addProductToBusiness(string productId, ParseObject business);

        //product
        Task<IEnumerable<ParseObject>> businessesWhoHaveThisProduct(ParseObject product);
        Task<IEnumerable<ParseObject>> retrieveAllProducts();
        Task<ParseObject> retrieveProduct(string productID);
        Task<IEnumerable<ParseObject>> retrieveAllMyPoducts(string businessId);
        string getProductTitle(ParseObject product);
        Task<ParseObject> retrieveActiveGroupForProduct(string productId);
        ParseFile getProductImage(ParseObject product);
        Task<bool> addBusinessToProduct(string productId, ParseObject business);





        //group
        Task<IEnumerable<ParseObject>> retrieveAllActiveGroups();
        Task<IEnumerable<ParseObject>> retrieveUsersOfGroup(ParseObject group);
        Task<ParseObject> retrieveProductOfGroup(ParseObject group);
        Task<ParseObject> retrieveGroup(string groupId);
        Task<bool> createGroup(ParseObject product);
        DateTime getExpirationDate(ParseObject group);
        Task<bool> setGroupActive(ParseObject group, bool status);


        //winning bid
        Task<IEnumerable<ParseObject>> retrieveWinningBids();
        Task<ParseObject> retrieveBidOfWinningBid(ParseObject winningBid);
        Task<bool> createWinningBid(ParseObject bid);

        //bid
        Task<ParseObject> retrieveGroupOfBid(ParseObject bid);
        Task<bool> createBid(ParseObject business, string groupId, double maxUnits, double originalPrice, double priceStep1, double priceStep2, double priceStep3, double priceStep4, double priceStep5, string comments, double guarantee, bool shipping);
        Task<IEnumerable<ParseObject>> retrieveBids(string groupId);
        Task<ParseObject> getBid(ParseObject winningBid);
        double getBidPriceStep1(ParseObject bid);
        double getBidPriceStep2(ParseObject bid);
        double getBidPriceStep3(ParseObject bid);
        double getBidPriceStep4(ParseObject bid);
        double getBidPriceStep5(ParseObject bid);
        double getBidGuarantee(ParseObject bid);
        double getBidOriginalPrice(ParseObject bid);
        double getBidMaxUints(ParseObject bid);
        bool getBidShipping(ParseObject bid);
        string getBusinessIdOfBid(ParseObject bid);
        string getCommentsOfBid(ParseObject bid);



        //category
        Task<IEnumerable<ParseObject>> retrieveCategories();
        string getCategoryName(ParseObject category);

        //subcategory
        Task<IEnumerable<ParseObject>> retrieveSubCategories();
        string getSubCategoryName(ParseObject subCategory);

        //user
        bool isBusiness(ParseUser user);

    }

}
