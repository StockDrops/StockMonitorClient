using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Models.Retailers;
public class Sku
{
    /// <summary>
    /// The unique id chosen by the retailer.
    /// </summary>
    public required string SkuRetailer { get; set; }
}
