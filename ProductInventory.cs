using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    class ProductInventory
    {
        public ProductInventory()
        {


        }

        public ProductInventory(string ProductId, string ProductName)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
        }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string RetailerName { get; set; }
        public string RetailerProductCode { get; set; }

        public Dictionary<string, DateTime> CodeTypeDateMap = new Dictionary<string, DateTime>();

        public string Log()
        {
            var logString = ProductId + ", " +
                            ProductName + ", ";

            var outputString = "";

            foreach(var item in CodeTypeDateMap)
            {
                outputString += logString + item.Key + ", " + RetailerProductCode + ", "+ item.Value +"\n";
            }

            return outputString;

        }
    }
}

