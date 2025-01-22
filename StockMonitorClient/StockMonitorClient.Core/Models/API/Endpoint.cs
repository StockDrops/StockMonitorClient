using StockMonitorClient.Core.Models.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Models.API;
public class Endpoint
{
    /// <summary>
    /// Url to format with the values or queries needed.
    /// </summary>
    public required string Url { get; set; }
    public Retailer Retailer { get; set; }
    //public HttpMethod Method { get; set; }
}