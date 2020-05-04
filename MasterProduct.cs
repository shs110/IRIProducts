using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProducts
{
    public class MasterProduct:ILoggable
    {
        public MasterProduct()
        {

        }

        public MasterProduct(int ProductId,string ProductName)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Log()=>
        
            $"{ProductId}: {ProductName}";
        
    }
}
