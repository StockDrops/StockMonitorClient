using Microsoft.Extensions.DependencyInjection;
using StockMonitorClient.Core.Formatters.BestBuy;
using StockMonitorClient.Core.Interfaces.API;
using StockMonitorClient.Core.Models.Retailers;
using StockMonitorClient.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Extensions;
public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddRetailerServices(this IServiceCollection services)
    {
        services.AddKeyedSingleton<IRequestFormatter, BestBuyFormatter>("bestBuy_formatter");
        services.AddKeyedSingleton<Crawler>("bestbuy_crawler", (s, c) =>
        {
            return new Crawler(s.GetRequiredService<HttpClient>(), s.GetRequiredKeyedService<IRequestFormatter>("bestBuy_formatter"));
        });

        return services;
    }
}
