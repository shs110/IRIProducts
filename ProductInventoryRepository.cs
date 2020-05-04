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

            try
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

                    if (!productInventoryMap.ContainsKey(ProductId))//if product id key doesnt exist in map just create a new class and add it as value to the map with product id as key 
                    {
                        ProductInventory productInventory = new ProductInventory(ProductId, ProductName);
                        productInventory.RetailerName = RetailerName;
                        productInventory.RetailerProductCode = RetailerProductCode;
                        productInventory.CodeTypeDateMap.Add(RetailerProductCodeType, Tuple.Create(DateReceived, RetailerProductCode));
                        productInventoryMap.Add(ProductId, productInventory);
                    }
                    else
                    {
                        var product = productInventoryMap[ProductId];
                        if (!product.CodeTypeDateMap.ContainsKey(RetailerProductCodeType))//add product code type to class if it doesn't exist
                        {
                            product.CodeTypeDateMap.Add(RetailerProductCodeType, Tuple.Create(DateReceived, RetailerProductCode));
                            product.RetailerProductCode = RetailerProductCode;
                        }
                        else
                        {
                            if (DateReceived > product.CodeTypeDateMap[RetailerProductCodeType].Item1)//update date and retailer product code if it is received at a later date than the existing date of the map for the product code type
                            {
                                product.CodeTypeDateMap[RetailerProductCodeType] = Tuple.Create(DateReceived, RetailerProductCode);
                                product.RetailerProductCode = RetailerProductCode;
                            }
                        }
                        productInventoryMap[ProductId] = product;
                    }


                }
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
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
