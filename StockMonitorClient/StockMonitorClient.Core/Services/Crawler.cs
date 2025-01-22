using StockMonitorClient.Core.Interfaces.API;
using StockMonitorClient.Core.Models.API;
using StockMonitorClient.Core.Models.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Services;
public class Crawler
{
    private readonly HttpClient httpClient;
    private readonly IRequestFormatter requestFormatter;

    public Crawler(HttpClient httpClient, IRequestFormatter requestFormatter)
    {
        this.httpClient = httpClient;
        this.requestFormatter = requestFormatter;
    }

    public async Task<HttpResponseMessage> SendRequestAsync(Endpoint endpoint, IEnumerable<Sku> skus, CancellationToken cancellationToken = default)
    {
        return await httpClient.SendAsync(await requestFormatter.GetRequestAsync(endpoint, skus, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
    }
}
