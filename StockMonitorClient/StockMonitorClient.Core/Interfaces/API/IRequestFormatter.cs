using StockMonitorClient.Core.Models.API;
using StockMonitorClient.Core.Models.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Interfaces.API;
public interface IRequestFormatter
{
        /// <summary>
        /// Gets a request to search all the given skus.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="skus"></param>
        /// <returns></returns>
        /// <param name="cancellationToken"></param>
        ValueTask<HttpRequestMessage> GetRequestAsync(Endpoint endpoint, IEnumerable<Sku> skus, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets a request to search a given sku.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="sku"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<HttpRequestMessage> GetRequestAsync(Endpoint endpoint, Sku sku, CancellationToken cancellationToken = default);
        
   
}
