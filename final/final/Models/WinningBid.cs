using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class WinningBid : Convertor
    {
        public string objectId { get; set; }
        public Bid bid { get; set; }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<WinningBid> winningBids = new List<WinningBid>();
            foreach (ParseObject w in objects)
            {
                WinningBid winningBid = new WinningBid();
                winningBid.objectId = w.ObjectId;

                Bid b = new Bid();
                List<ParseObject> bid = new List<ParseObject>();
                bid.Add(w.Get<ParseObject>(Constants.BIDS));
                winningBid.bid = (Bid)b.convert(bid);

            }
            return winningBids;
            throw new NotImplementedException();
        }
    }
}