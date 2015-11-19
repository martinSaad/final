using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class ProductTelevision : Convertor
    {
        public string objectId { get; set; }
        public string screenSize { get; set; }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<ProductTelevision> productTelevisions = new List<ProductTelevision>();
            foreach (ParseObject p in objects)
            {
                ProductTelevision productTelevision = new ProductTelevision();
                productTelevision.objectId = p.ObjectId;
                productTelevision.screenSize = p.Get<string>(Constants.SCREEN_SIZE);
            }
            return productTelevisions;
            throw new NotImplementedException();
        }
    }
}