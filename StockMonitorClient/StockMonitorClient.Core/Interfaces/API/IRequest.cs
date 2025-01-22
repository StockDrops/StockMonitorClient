using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitorClient.Core.Interfaces.API;
public interface IRequest
{
    /// <summary>
    /// Gets or sets the URI to be called.
    /// </summary>
    Uri Uri { get; set; }
    /// <summary>
    /// Gets or sets the HTTP method of the request. Normally you don't need to set this explicitly; it will be set
    /// when you call the sending method, such as GetAsync, PostAsync, etc.
    /// </summary>
    HttpMethod Verb { get; set; }
    /// <summary>
    /// Collection of headers sent on this request or all requests using this client.
    /// </summary>
    IDictionary<string, string> Headers { get; }
    /// <summary>
    /// Content used in the http request.
    /// </summary>
    HttpContent? HttpContent { get; set; }

    /// <summary>
    /// Converts the abstract request to a C# request message.
    /// </summary>
    /// <returns></returns>
    HttpRequestMessage ToRequestMessage();
}