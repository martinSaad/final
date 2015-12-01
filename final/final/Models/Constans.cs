﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public static class Constants
    {
        public const int MAX_TIME_GRPUO_OFFER = 24; //hours

        //tables
        public const string OBJECT_ID = "objectId";
        public const string PRODUCT_TABLE = "Product";
        public const string GROUP_BUYING_TABLE = "Group_Buying";
        public const string BID_TABLE = "Bid";
        public const string BUSINESS_TABLE = "Business";
        public const string WINNING_BID_TABLE = "Winning_Bid";
        public const string CATEGORY = "Product_Category";
        public const string SUB_CATEGORY = "Product_Sub_Category";



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
        public const string PRICE = "price";
        public const string COMMENTS = "comments";
        public const string BUSINESS_ID = "business_id";
        public const string GROUP_BUYING_ID = "group_buying_id";

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
    }
}