using java.lang;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    class MasterProductRepository: IPasrseFile<MasterProduct>
    {
        
        Dictionary<System.String, MasterProduct> masterProductsMap = new Dictionary<System.String, MasterProduct> ();
        public Dictionary<System.String, MasterProduct> ParseProductsFile(string FileName)
        {
            var lines = File.ReadAllLines(FileName);
            MasterProduct masterProduct = new MasterProduct();
            foreach (var line in lines)
            {
                var col = line.Split(',');
                masterProduct = new MasterProduct(int.Parse(col[0]),col[1]);
       
                masterProductsMap.Add(col[0],masterProduct);
            }

            return masterProductsMap;

        }

        public void Log()
        {
            foreach(var product in masterProductsMap)
            {

                Console.WriteLine(product.Value.Log());
            }
        }


    }
}
