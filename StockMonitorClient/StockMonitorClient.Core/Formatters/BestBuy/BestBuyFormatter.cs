using StockMonitorClient.Core.Interfaces.API;
using StockMonitorClient.Core.Models.API;
using StockMonitorClient.Core.Models.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Formatters.BestBuy;
public class BestBuyFormatter : IRequestFormatter
{
    private HttpRequestMessage CreateSearchRequestMessage(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var rnd = new Random();
        request.Headers.UserAgent.Clear();
        request.Headers.UserAgent.ParseAdd($"Bby-Android/19.1.20 (Linux; U; Android {rnd.Next(7, 14)}.0; en-us; google_sdk Build/JB_MR1.1 Build 1) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
        request.Headers.Connection.ParseAdd("close");

        request.Headers.Add("X-CLIENT-ID", "FRV");
        request.Headers.Add("X-REQUEST-ID", "BROWSE");
        request.Headers.Add("X-Requested-With", "com.bestbuy.android");

        request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("\u000D\u000a"));

        request.Content.Headers.ContentLength = 2;
        return request;

    }

    public ValueTask<HttpRequestMessage> GetRequestAsync(Endpoint endpoint, IEnumerable<Sku> skus, CancellationToken cancellationToken = default)
    {
        var stringSkus = string.Join(",", skus.Select(s => s.SkuRetailer));
        return ValueTask.FromResult(CreateSearchRequestMessage(string.Format(endpoint.Url, stringSkus)));
    }

    public ValueTask<HttpRequestMessage> GetRequestAsync(Endpoint endpoint, Sku sku, CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(CreateSearchRequestMessage(string.Format(endpoint.Url, sku.SkuRetailer)));
    }
}
