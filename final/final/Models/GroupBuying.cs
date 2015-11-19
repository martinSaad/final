using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class GroupBuying
    {
        public Bid bid { get; set; }
        public string productID { get; set; }
        public List<Product> products { get; set; }
        public DateTime groupCreated { get; set; }

        public List<Business> categories { get; set; }
        public bool bidSelected { get; set; }


        public string BID = "bid";
        public string PRODUCT = "product";
        public string USER = "user";
        public string CATEGORIES = "category";



        public GroupBuying()
        {
            groupCreated = new DateTime();
            this.products = new List<Product>();
            this.categories = new List<Business>();
            this.bidSelected = false;

        }
    }



}