using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class ProductType : Convertor
    {
        public string objectId { get; set; }
        public string type { get; set; }
        public ProductCellphone productCellphone { get; set; }
        public ProductTelevision productTelevision { get; set; }

        public IEnumerable<Object> convert(IEnumerable<ParseObject> objects)
        {
            List<ProductType> productTypes = new List<ProductType>();
            foreach (ParseObject p in objects)
            {
                ProductType productType = new ProductType();
                productType.objectId = p.ObjectId;
                productType.type = p.Get<string>(Constants.TITLE);

                ProductCellphone prodcell = new ProductCellphone();
                List<ParseObject> productCellphone = new List<ParseObject>();
                productCellphone.Add(p.Get<ParseObject>(Constants.PRODUCT_CELLPHONE));
                productType.productCellphone = (ProductCellphone)prodcell.convert(productCellphone);

                ProductTelevision prodtele = new ProductTelevision();
                List<ParseObject> productTelevision = new List<ParseObject>();
                productTelevision.Add(p.Get<ParseObject>(Constants.PRODUCT_TELEVISION));
                productType.productTelevision = (ProductTelevision)prodtele.convert(productTelevision);

            }
            return productTypes;
            throw new NotImplementedException();
        }
    }
}