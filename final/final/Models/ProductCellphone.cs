using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace final.Models
{
    public class ProductCellphone : Convertor
    {
        public string objectId { get; set; }
        public string screenSize { get; set; }
        public float camera { get; set; }
        public string storageCapacity { get; set; }
        public string operatingSystem { get; set; }

        public IEnumerable<object> convert(IEnumerable<ParseObject> objects)
        {
            List<ProductCellphone> productCellphones = new List<ProductCellphone>();
            foreach (ParseObject p in objects)
            {
                ProductCellphone productCellphone = new ProductCellphone();
                productCellphone.objectId = p.ObjectId;
                productCellphone.camera = p.Get<float>(Constants.CAMERA);
                productCellphone.screenSize = p.Get<string>(Constants.SCREEN_SIZE);
                productCellphone.operatingSystem = p.Get<string>(Constants.OPERATING_SYSTEM);

            }
            return productCellphones;
            throw new NotImplementedException();
        }
    }
}