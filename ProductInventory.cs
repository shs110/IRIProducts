using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace IRIProducts
{
    class ProductInventory:ILoggable
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

        public Dictionary<string, Tuple<DateTime, string>> CodeTypeDateMap = new Dictionary<string, Tuple<DateTime, string>>();

        public string Log()
        {
            var logString = ProductId + ", " +
                            ProductName + ", ";

            var outputString = "";

            foreach(var item in CodeTypeDateMap)
            {
                outputString += logString + item.Key + ", "+ item.Value.Item2 +"\n";
            }

            return outputString;

        }
    }
}

