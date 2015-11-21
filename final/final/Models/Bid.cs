using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class Bid : Convertor
    {
        public string objectId { get; set; }
        public string comments { get; set; }
        public float price { get; set; }
        public GroupBuying groupBuying { get; set; }
        public Business business { get; set; }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<Bid> bids = new List<Bid>();
            foreach (ParseObject b in objects)
            {
                Bid bid = new Bid();
                bid.objectId = b.ObjectId;
                bid.price = b.Get<float>(Constants.PRICE);
                bid.comments = b.Get<string>(Constants.COMMENTS);

                Business bus = new Business();
                List<ParseObject> business = new List<ParseObject>();
                business.Add(b.Get<ParseObject>(Constants.BUSINESS_ID));
                bid.business = (Business)(bus.convert(business));

                GroupBuying group = new GroupBuying();
                List<ParseObject> groups = new List<ParseObject>();
                groups.Add(b.Get<ParseObject>(Constants.GROUP_BUYING_ID));
                bid.groupBuying = (GroupBuying)(bus.convert(groups));
            }
            return bids;
            throw new NotImplementedException();
        }
    }
}