using StockMonitorClient.Core.Formatters.BestBuy;
using StockMonitorClient.Core.Models.API;
using StockMonitorClient.Core.Models.Retailers;
using StockMonitorClient.Core.Services;
using StockMonitorClient.Tests.Resources;

namespace StockMonitorClient.Tests.Retailers.BestBuy;

[TestClass]
public sealed class BestBuyTests
{
    [TestMethod]
    public async Task TestStockStatusAsync()
    {
        var formatter = new BestBuyFormatter();
        var crawler = new Crawler(new HttpClient(), formatter);

        var endpoint = new Endpoint() { Url = Endpoints.BestBuy, Retailer = Core.Models.Retailers.Retailer.BestBuyUs };

        var sku = new Sku { SkuRetailer = "6612958" };

        var response = await crawler.SendRequestAsync(endpoint, [sku,]);

        if (response.IsSuccessStatusCode)
        {
            var expected = "{\"buttonStateResponseInfos\":[{\"skuId\":\"6612958\",\"buttonState\":\"PRE_ORDER\",\"displayText\":\"Pre-Order\"}]}";
            var res = await response.Content.ReadAsStringAsync();
            if (expected != res)
            {
                Assert.Fail("The result is different than expected: {0} \n got: {1}", expected, res);
            }
        }
        else
        {
            Assert.Fail(await response.Content.ReadAsStringAsync());
        }
    }
}
