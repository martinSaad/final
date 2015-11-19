using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class Bid
    {
        public string objectId { get; set; }
        public string comments { get; set; }
        public float price { get; set; }
        public GroupBuying groupBuying { get; set; }
        public Business business { get; set; }
    }
}