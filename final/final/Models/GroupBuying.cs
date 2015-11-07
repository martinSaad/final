using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class GroupBuying
    {
        public Bid bid { get; set; }
        public Product product { get; set; }
        public User user { get; set; }
    }
}