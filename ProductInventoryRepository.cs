using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIProducts
{
    class ProductInventoryRepository:IPasrseFile<ProductInventory>
    {
        public ProductInventoryRepository(String MasterProductFiile)
        {
            MasterProductRepository masterProductRepository = new MasterProductRepository();
            masterProductsMap = masterProductRepository.ParseProductsFile(MasterProductFiile);
        }
        Dictionary<System.String, ProductInventory> productInventoryMap = new Dictionary<System.String, ProductInventory>();
        Dictionary<System.String, MasterProduct> masterProductsMap = new Dictionary<System.String, MasterProduct>();
        String ProductId;
        String ProductName;
        String RetailerName;
        String RetailerProductCode;
        String RetailerProductCodeType;
        DateTime DateReceived;

        
        public Dictionary<string,ProductInventory> ParseProductsFile(string FileName)
        {
            var lines = File.ReadAllLines(FileName);
           

            ProductInventory masterProduct = new ProductInventory();
            foreach (var line in lines)
            {
                var col = line.Split(',');
                ProductId = col[0];
                ProductName = masterProductsMap[ProductId].ProductName;
                RetailerName = col[1];
                RetailerProductCode = col[2];
                RetailerProductCodeType = col[3];
                DateReceived = DateTime.ParseExact(col[4], "d/M/yyyy", CultureInfo.InvariantCulture);

                if (!productInventoryMap.ContainsKey(ProductId))
                {
                    ProductInventory productInventory = new ProductInventory(ProductId, ProductName);
                    productInventory.RetailerName = RetailerName;
                    productInventory.RetailerProductCode = RetailerProductCode;
                    productInventory.CodeTypeDateMap.Add(RetailerProductCodeType,DateReceived);
                    productInventoryMap.Add(ProductId, productInventory);
                }
                else
                {
                    var product = productInventoryMap[ProductId];
                    if (!product.CodeTypeDateMap.ContainsKey(RetailerProductCodeType))
                    {
                        product.CodeTypeDateMap.Add(RetailerProductCodeType,DateReceived);
                        product.RetailerProductCode = RetailerProductCode;
                    }
                    else
                    {
                        if (DateReceived > product.CodeTypeDateMap[RetailerProductCodeType])
                        {
                            product.CodeTypeDateMap[RetailerProductCodeType] = DateReceived;
                            product.RetailerProductCode = RetailerProductCode;
                        }
                    }
                    productInventoryMap[ProductId] = product;
                }


            }
            return productInventoryMap;

        }

        public void Log()
        {
            foreach (var product in productInventoryMap)
            {

                Console.WriteLine(product.Value.Log());
            }
        }
    }
}
