using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //MasterProductRepository masterProductRepository = new MasterProductRepository();
            //masterProductRepository.ParseProductsFile("C:/Users/SaadmanSayed/Desktop/IRI Technical Test/IRIProducts.txt");
            //masterProductRepository.Log();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"IRIProducts.txt");
            ProductInventoryRepository productInventoryRepository = new ProductInventoryRepository(path);
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"RetailerProducts.txt");
            productInventoryRepository.ParseProductsFile(path);
            productInventoryRepository.Log();
        }
    }
}
