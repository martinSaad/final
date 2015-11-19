using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class ProductType
    {
        public string objectId { get; set; }
        public ProductCellphone productCellphone { get; set; }
        public ProductTelevision productTelevision { get; set; }
    }
}