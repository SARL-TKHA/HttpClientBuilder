using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace HttpClientBuilder;

/// <summary>
/// A class that provides a fluent API for building an HttpClient instance.
/// </summary>
public class HttpClientBuilder
{
    /// <summary>
    /// The HttpClient instance.
    /// </summary>
    private HttpClient _httpClient = new HttpClient();

    #region private properties

    private string? _baseAddress = null;
    private Dictionary<string, string> _headers = new Dictionary<string, string>();
    private List<MediaTypeWithQualityHeaderValue> _contentTypes = new List<MediaTypeWithQualityHeaderValue>();
    private AuthenticationHeaderValue? _authentication = null;
    private TimeSpan _timeout = TimeSpan.FromSeconds(30);
    private long _maxResponseContentBufferSize = 1024 * 1024 * 10; // 10 MB

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientBuilder"/> class.
    /// </summary>
    public HttpClientBuilder()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientBuilder"/> class with a base address.
    /// </summary>
    /// <param name="baseAddress">The base address of the HttpClient.</param>
    public HttpClientBuilder(string baseAddress) : base()
    {

        this.AddBaseAddress(baseAddress);
    }

    /// <summary>
    /// Sets the base address of the HttpClient.
    /// </summary>
    /// <param name="baseAddress">The base address of the HttpClient.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddBaseAddress(string baseAddress)
    {
        if (string.IsNullOrWhiteSpace(baseAddress))
        {
            throw new ArgumentNullException(nameof(baseAddress), "The base address cannot be null or empty.");
        }
        _baseAddress = baseAddress;
        return this;
    }

    #region Headers

    /// <summary>
    /// Adds a header to the HttpClient's default request headers.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddHeader(string name, string value)
    {
        _headers.Add(name, value);
        return this;
    }

    /// <summary>
    /// Adds multiple headers to the HttpClient's default request headers.
    /// </summary>
    /// <param name="headers">A dictionary containing the headers to be added.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            _headers.Add(header.Key, header.Value);
        }
        return this;
    }

    #endregion

    #region Content Types

    /// <summary>
    /// Adds the "application/json" content type to the HttpClient's default request headers.
    /// </summary>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddJsonContentType()
    {
        _contentTypes.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return this;
    }

    /// <summary>
    /// Adds the "application/xml" content type to the HttpClient's default request headers.
    /// </summary>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddXmlContentType()
    {
        _contentTypes.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        return this;
    }

    /// <summary>
    /// Adds the "application/x-www-form-urlencoded" content type to the HttpClient's default request headers.
    /// </summary>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddFormUrlEncodedContentType()
    {
        _contentTypes.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        return this;
    }

    /// <summary>
    /// Adds the "text/plain" content type to the HttpClient's default request headers.
    /// </summary>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddTextPlainContentType()
    {
        _contentTypes.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        return this;
    }

    /// <summary>
    /// Adds a custom content type to the HttpClient's default request headers.
    /// </summary>
    /// <param name="contentType">The custom content type.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddCustomContentType(string contentType)
    {
        _contentTypes.Add(new MediaTypeWithQualityHeaderValue(contentType));
        return this;
    }

    /// <summary>
    /// Adds the specified content to the HttpClient's default request headers.
    /// </summary>
    /// <param name="content">The content to be added.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddContent(HttpContent content)
    {
        if (content.Headers.ContentType?.MediaType != null)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content.Headers.ContentType.MediaType));
        }
        return this;
    }

    #endregion

    #region Authentication

    /// <summary>
    /// Adds a Bearer token to the HttpClient's default request headers.
    /// </summary>
    /// <param name="token">The Bearer token.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddBearerToken(string token)
    {
        _authentication = new AuthenticationHeaderValue("Bearer", token);
        return this;
    }

    /// <summary>
    /// Adds Basic Authentication to the HttpClient's default request headers.
    /// </summary>
    /// <param name="username">The username for Basic Authentication.</param>
    /// <param name="password">The password for Basic Authentication.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddBasicAuthentication(string username, string password)
    {
        byte[] byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
        _authentication = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        return this;
    }

    /// <summary>
    /// Adds an API key to the HttpClient's default request headers.
    /// header name is "x-api-key"
    /// </summary>
    /// <param name="apiKey">The API key.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddApiKey(string apiKey)
    {
        _authentication = new AuthenticationHeaderValue("x-api-key", apiKey);
        return this;
    }

    /// <summary>
    /// Adds an API key with a custom header name to the HttpClient's default request headers.
    /// </summary>
    /// <param name="apiKey">The API key.</param>
    /// <param name="headerName">The custom header name.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddApiKey(string apiKey, string headerName)
    {
        _authentication = new AuthenticationHeaderValue(headerName, apiKey);
        return this;
    }

    #endregion

    #region Timeouts

    /// <summary>
    /// Sets the timeout for the HttpClient.
    /// <b>Default:</b> 30 seconds
    /// </summary>
    /// <param name="timeout">The timeout duration.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetTimeout(TimeSpan timeout)
    {
        _timeout = timeout;
        return this;
    }

    /// <summary>
    /// Sets the timeout for the HttpClient in milliseconds.
    /// <b>Default:</b> 30 seconds
    /// </summary>
    /// <param name="milliseconds">The timeout duration in milliseconds.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetTimeout(int milliseconds)
    {
        _timeout = TimeSpan.FromMilliseconds(milliseconds);
        return this;
    }

    /// <summary>
    /// Sets the timeout for the HttpClient in seconds.
    /// <b>Default:</b> 30 seconds 
    /// </summary>
    /// <param name="seconds">The timeout duration in seconds.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetTimeoutInSeconds(int seconds)
    {
        _timeout = TimeSpan.FromSeconds(seconds);
        return this;
    }

    /// <summary>
    /// Sets the timeout for the HttpClient in minutes.
    /// <b>Default:</b> 30 seconds
    /// </summary>
    /// <param name="minutes">The timeout duration in minutes.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetTimeoutInMinutes(int minutes)
    {
        _timeout = TimeSpan.FromMinutes(minutes);
        return this;
    }

    /// <summary>
    /// Sets the timeout for the HttpClient in hours.
    /// <b>Default:</b> 30 seconds
    /// </summary>
    /// <param name="hours">The timeout duration in hours.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetTimeoutInHours(int hours)
    {
        _timeout = TimeSpan.FromHours(hours);
        return this;
    }

    #endregion

    #region Handlers

    /// <summary>
    /// Adds a custom handler to the HttpClient.
    /// <b>Warning:</b> This method will override the default HttpClient instance.
    /// </summary>
    /// <param name="handler">The custom handler.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddHandler(DelegatingHandler handler)
    {
        _httpClient = new HttpClient(handler);
        return this;
    }

    /// <summary>
    /// Adds a custom message handler to the HttpClient.
    /// <b>Warning:</b> This method will override the default HttpClient instance.
    /// </summary>
    /// <param name="handler">The custom message handler.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddMessageHandler(HttpMessageHandler handler)
    {
        _httpClient = new HttpClient(handler);
        return this;
    }

    /// <summary>
    /// Adds a custom delegating handler to the HttpClient.
    /// <b>Warning:</b> This method will override the default HttpClient instance.
    /// </summary>
    /// <param name="handler">The custom delegating handler.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddDelegatingHandler(DelegatingHandler handler)
    {
        _httpClient = new HttpClient(handler);
        return this;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Sets the maximum response content buffer size for the HttpClient.
    /// <b>Default:</b> 10 MB
    /// <b>Warning:</b> If the response content exceeds this size, an exception will be thrown.
    /// </summary>
    /// <param name="size">The maximum response content buffer size.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetMaxResponseContentBufferSize(long size)
    {
        _maxResponseContentBufferSize = size;
        return this;
    }

    /// <summary>
    /// Sets the maximum response content buffer size for the HttpClient.
    /// <b>Default:</b> 10 MB
    /// <b>Warning:</b> If the response content exceeds this size, an exception will be thrown.
    /// </summary>
    /// <param name="size">The maximum response content buffer size.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetMaxResponseContentBufferSize(int size)
    {
        _maxResponseContentBufferSize = size;
        return this;
    }

    /// <summary>
    /// Sets the maximum response content buffer size for the HttpClient in kilobytes.
    /// <b>Default:</b> 10 MB
    /// <b>Warning:</b> If the response content exceeds this size, an exception will be thrown. 
    /// </summary>
    /// <param name="size">The maximum response content buffer size in kilobytes.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetMaxResponseContentBufferSizeInKilobytes(int size)
    {
        _maxResponseContentBufferSize = size * 1024;
        return this;
    }

    /// <summary>
    /// Sets the maximum response content buffer size for the HttpClient in megabytes.
    /// </summary>
    /// <b>Default:</b> 10 MB
    /// <b>Warning:</b> If the response content exceeds this size, an exception will be thrown. 
    /// <param name="size">The maximum response content buffer size in megabytes.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetMaxResponseContentBufferSizeInMegabytes(int size)
    {
        _maxResponseContentBufferSize = size * 1024 * 1024;
        return this;
    }

    /// <summary>
    /// Sets the maximum response content buffer size for the HttpClient in gigabytes.
    /// <b>Default:</b> 10 MB
    /// <b>Warning:</b> If the response content exceeds this size, an exception will be thrown. 
    /// </summary>
    /// <param name="size">The maximum response content buffer size in gigabytes.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder SetMaxResponseContentBufferSizeInGigabytes(int size)
    {
        _maxResponseContentBufferSize = size * 1024 * 1024 * 1024;
        return this;
    }

    #endregion

    #region Cookies

    /// <summary>
    /// Adds a cookie to the HttpClient's default request headers.
    /// </summary>
    /// <param name="cookie">The cookie to add.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddCookie(Cookie cookie)
    {
        _headers.Add("Cookie", cookie.ToString());
        return this;
    }

    /// <summary>
    /// Adds cookies to the HttpClient's default request headers.
    /// </summary>
    /// <param name="cookies">The cookies to add.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddCookies(IEnumerable<Cookie> cookies)
    {
        foreach (var cookie in cookies)
        {
            _headers.Add("Cookie", cookie.ToString());
        }
        return this;
    }

    #endregion

    #region Query Parameters

    /// <summary>
    /// Adds a query parameter to the HttpClient's base address.
    /// </summary>
    /// <param name="name">The name of the query parameter.</param>
    /// <param name="value">The value of the query parameter.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddQueryParameter(string name, string value)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "The query parameter name cannot be null or empty.");
        }
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "The query parameter value cannot be null or empty.");
        }
        _baseAddress += $"?{name}={HttpUtility.UrlEncode(value)}";
        return this;
    }

    /// <summary>
    /// Adds multiple query parameters to the HttpClient's base address.
    /// </summary>
    /// <param name="parameters">A dictionary containing the query parameters to be added.</param>
    /// <returns>The current instance of the <see cref="HttpClientBuilder"/>.</returns>
    public HttpClientBuilder AddQueryParameters(Dictionary<string, string> parameters)
    {
        if (parameters == null || parameters.Count == 0)
        {
            throw new ArgumentNullException(nameof(parameters), "The query parameters dictionary cannot be null or empty.");
        }
        StringBuilder queryString = new StringBuilder();
        foreach (var parameter in parameters)
        {
            queryString.Append($"{parameter.Key}={HttpUtility.UrlEncode(parameter.Value)}&");
        }
        _baseAddress += $"?{queryString.ToString().TrimEnd('&')}";
        return this;
    }

    #endregion

    #region Build

    /// <summary>
    /// Builds and returns the configured HttpClient instance.
    /// </summary>
    /// <returns>The configured HttpClient instance.</returns>
    public HttpClient Build()
    {
        if (_baseAddress == null)
        {
            throw new InvalidOperationException("The base address must be set before building the HttpClient.");
        }
        _httpClient!.BaseAddress = new Uri(_baseAddress);
        _httpClient!.Timeout = _timeout;
        _httpClient!.MaxResponseContentBufferSize = _maxResponseContentBufferSize;
        foreach (var header in _headers)
        {
            _httpClient!.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
        _httpClient!.DefaultRequestHeaders.Accept.Clear();
        foreach (var contentType in _contentTypes)
        {
            _httpClient!.DefaultRequestHeaders.Accept.Add(contentType);
        }
        if (_authentication != null)
        {
            _httpClient!.DefaultRequestHeaders.Authorization = _authentication;
        }

        return _httpClient!;
    }

    #endregion
}
