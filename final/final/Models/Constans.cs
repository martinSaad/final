using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public static class Constants
    {
        public const int MAX_TIME_GRPUO_OFFER = 24; //hours
        public const double GROUP_LIFE_TIME = 4.0;

        //tables
        public const string OBJECT_ID = "objectId";
        public const string PRODUCT_TABLE = "Product";
        public const string GROUP_BUYING_TABLE = "Group_Buying";
        public const string BID_TABLE = "Bid";
        public const string BUSINESS_TABLE = "Business";
        public const string WINNING_BID_TABLE = "Winning_Bid";
        public const string CATEGORY_TABLE = "Product_Category";
        public const string SUB_CATEGORY_TABLE = "Product_Sub_Category";



        //group buying
        public const string EXPIRATION_DATE = "expiration_date";
        public const string USERS = "users";
        public const string PRODUCT = "product";
        public const string BIDS = "bids";
        public const string GROUP_MANAGER = "group_manager";
        public const string ACTIVE = "active";


        //user
        public const string USER_NAME = "username";
        public const string FIRST_NAME = "firstName";
        public const string LAST_NAME = "lastName";
        public const string EMAIL = "email";
        public const string IS_CLIENT = "isClient";
        public const string IS_BUSINESS = "isBusiness";
        public const string GROUPS = "groups";

        //business
        public const string NAME = "name";
        public const string ADRESS = "adress";
        public const string WEBSITE = "website";
        public const string FACEBOOK_PAGE = "facebookPage";
        public const string PHONE_NUMBER = "phoneNumber";
        public const string LOGO = "logo";
        public const string USER = "user";
        public const string PRODUCTS = "products";

        //bid
        public const string PRICE_STEP_1 = "price_step_1";
        public const string PRICE_STEP_2 = "price_step_2";
        public const string PRICE_STEP_3 = "price_step_3";
        public const string PRICE_STEP_4 = "price_step_4";
        public const string PRICE_STEP_5 = "price_step_5";
        public const string ORIGINAL_PRICE = "original_price";
        public const string COMMENTS = "comments";
        public const string GROUP_BUYING = "group_buying";
        public const string MAX_UNITS = "max_units";


        //product
        public const string TITLE = "title";
        public const string CELLPHONE_ID = "cellphone_id";
        public const string MANUFACTURER_ID = "manufacturer_id";
        public const string BUSINESS = "business";
        public const string IMAGE = "image";

        //winnig Bid
        public const string BID = "bid";

        //product cellphone
        public const string SCREEN_SIZE = "screen_size";
        public const string CAMERA = "camera";
        public const string STORAGE_CAPACITY = "storage_capacity";
        public const string OPERATING_SYSTEM = "operating_system";

        //product type
        public const string TYPE = "type";
        public const string PRODUCT_CELLPHONE = "product_cellphone";
        public const string PRODUCT_TELEVISION = "product_television";



        //form input names
        public const string PRODUCT_ID = "ProductID";
        public const string CATEGORY_ID = "CategoryID";
        public const string SUB_CATEGORY_ID = "SubCategoryID";
    }
}