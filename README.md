# IRIProducts
### Assumptions

 The Data will be supplied in a text file with comma separated values in the same order as in the sample txt and Word document:

<b>ProductId, 
RetailerName, 
RetailerProductCode, 
RetailerProductCodeType, 
DateReceived<b>

 I noticed hat more than one retailer has the same product code type for a single product with different dates received. In that case, I assumed I have to take the latest code type amongst the ones supplied by different retailers.

## Algorithm

I created 2 hashmaps. One is the master products map which simply has the Product Id as the key and Master Product details as value. This will be useful to get the product name later on in our output since it is not given in the retailer products inventory.

The second is the Product Inventory map which also has the product ID as the key and the retailer product class as value. This class has a dictionary as an attribute with Product code type as key and a tuple of (DateReceived,ProductCode) as value. Since we are to output a distinct list of Product code for each product, it makes sense to make this a key. Whenever, we come across the same Product code for the same product in the file, we simply compare the date received of the latter with the date received value in the tuple. If the latter has a greater date received value, we update the tuple value in the hashmap with the product code received and latest for the current product in the file 

## Complexity Analysis

Since Hashmap lookups run in O(1) time, we only need to consider the number of lines in the file. We initially run through the Master list to populate the Master hashmap and then the Retailer Product hashmap. Hence, both the space and time complexity of this solution is O(M+N) where M is the number of lines in Master products file and N is the Number of lines in Retailer Products file

## Coding Practices

I tried to follow the repository pattern here where I have a separate class to populate the hashmaps and ensure that the classes only have the responsibilities to supply the attributes. I also tried to incorporate a few aspects of SOLID design principles by implenting 2 interfaces i.e the ILoggable to print class data and IParseFile to populate the 2 hashmaps in the 2 repositories. I would have liked to further decouple my code and write more Unit tests especially for the ProductInventoryRepository Class for better readibility.

