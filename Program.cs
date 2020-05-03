using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MasterProductRepository masterProductRepository = new MasterProductRepository();
            masterProductRepository.ParseMasterProductsFile("C:/Users/SaadmanSayed/Desktop/IRI Technical Test/IRIProducts.txt");
            masterProductRepository.Log();
        }
    }
}
