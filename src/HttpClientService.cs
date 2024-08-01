namespace HttpClientHelper;

/// <summary>
/// Http Service
/// </summary>
public class HttpClientService
{
    #region Constants

    private const string URI_NULL_OR_EMPTY = "The URI cannot be null or empty.";
    private const string PATH_NULL_OR_EMPTY = "The path cannot be null or empty.";

    #endregion Constants

    private readonly HttpClient _httpClient;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpClient">HttpClient</param>
    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    #region Get

    #region GetString

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a string.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a string.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The query parameters dictionary cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///    .AddBearerToken("your_token")
    ///    .AddJsonContentType()
    ///    .GetStringAsync("resource");
    ///    Console.WriteLine(response);
    /// </code>
    ///  </example>
    ///  <remarks>
    ///    This method is asynchronous.
    ///  </remarks>
    ///  <seealso cref="HttpClient.GetStringAsync(string)"/>
    public async Task<string> GetStringAsync(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return await GetStringAsync(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a string.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a string.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The query parameters dictionary cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///    .AddBearerToken("your_token")
    ///    .AddJsonContentType()
    ///    .GetStringAsync("resource");
    ///    Console.WriteLine(response);
    /// </code>
    ///  </example>
    ///  <remarks>
    ///    This method is asynchronous.
    ///  </remarks>
    ///  <seealso cref="HttpClient.GetStringAsync(string)"/>
    public async Task<string> GetStringAsync(Uri? uri, CancellationToken cancellationToken = default)
    {
        return await _httpClient!.GetStringAsync(uri, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a string.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a string.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = new HttpClientBuilder("https://api.example.com")
    ///   .AddBearer("your token")
    ///   .AddJsonContentType()
    ///   .GetString("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStringAsync(string)"/>
    public string GetString(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return GetString(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a string.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a string.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = new HttpClientBuilder("https://api.example.com")
    ///   .AddBearer("your token")
    ///   .AddJsonContentType()
    ///   .GetString("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStringAsync(Uri?, CancellationToken)"/>
    public string GetString(Uri? uri, CancellationToken cancellationToken = default)
    {
        return _httpClient!.GetStringAsync(uri, cancellationToken).Result;
    }

    #endregion GetString

    #region GetByteArray

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a byte array.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a byte array.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///   .AddBearerToken("your token")
    ///   .AddJsonContentType()
    ///   .GetByteArrayAsync("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///   This method is asynchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetByteArrayAsync(string)"/>
    public async Task<byte[]> GetByteArrayAsync(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return await GetByteArrayAsync(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a byte array.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a byte array.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///   .AddBearerToken("your token")
    ///   .AddJsonContentType()
    ///   .GetByteArrayAsync("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///   This method is asynchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetByteArrayAsync(string)"/>
    public async Task<byte[]> GetByteArrayAsync(Uri? uri, CancellationToken cancellationToken = default)
    {
        return await _httpClient!.GetByteArrayAsync(uri, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a byte array.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a byte array.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///   .AddBearerToken("your token")
    ///   .AddJsonContentType()
    ///   .GetByteArrayAsync("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///   This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetByteArrayAsync(string)"/>
    public byte[] GetByteArray(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return GetByteArray(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a byte array.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a byte array.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///   .AddBearerToken("your token")
    ///   .AddJsonContentType()
    ///   .GetByteArrayAsync("resource");
    ///   Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///   This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetByteArrayAsync(string)"/>
    public byte[] GetByteArray(Uri? uri, CancellationToken cancellationToken = default)
    {
        return _httpClient!.GetByteArrayAsync(uri, cancellationToken).Result;
    }

    #endregion GetByteArray

    #region GetStream

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a stream.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a stream.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///  .AddBearerToken("your token")
    ///  .AddJsonContentType()
    ///  .GetStreamAsync("resource");
    ///  Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///  This method is asynchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    public async Task<Stream> GetStreamAsync(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return await GetStreamAsync(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a stream.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a stream.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///  .AddBearerToken("your token")
    ///  .AddJsonContentType()
    ///  .GetStreamAsync("resource");
    ///  Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///  This method is asynchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    public async Task<Stream> GetStreamAsync(Uri? uri, CancellationToken cancellationToken = default)
    {
        return await _httpClient!.GetStreamAsync(uri, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a stream.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a stream.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///  .AddBearerToken("your token")
    ///  .AddJsonContentType()
    ///  .GetStreamAsync("resource");
    ///  Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///  This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    public Stream GetStream(string uri, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        return GetStream(new Uri(uri), cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified Uri and returns the response body as a stream.
    /// </summary>
    /// <param name="uri">The Uri the request is sent to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The response body as a stream.</returns>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="TaskCanceledException">The request timed out.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <example>
    /// <code>
    /// var response = await new HttpClientBuilder("https://api.example.com")
    ///  .AddBearerToken("your token")
    ///  .AddJsonContentType()
    ///  .GetStreamAsync("resource");
    ///  Console.WriteLine(response);
    /// </code>
    /// </example>
    /// <remarks>
    ///  This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    public Stream GetStream(Uri? uri, CancellationToken cancellationToken = default)
    {
        return _httpClient!.GetStreamAsync(uri, cancellationToken).Result;
    }

    #endregion GetStream

    #endregion Get

    #region Download

    /// <summary>
    /// Downloads the resource with the specified URI to a local file.
    /// </summary>
    /// <param name="uri">The URI of the resource to download.</param>
    /// <param name="destination">The path to the file to save the content to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <exception cref="ArgumentNullException">The destination path cannot be null or empty.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <example>
    /// <code>
    /// await new HttpClientBuilder("https://api.example.com")
    /// .AddBearerToken("your token")
    /// .AddJsonContentType()
    /// .DownloadAsync("resource", "C:\\Downloads\\resource.json");
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is asynchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    /// <seealso cref="Stream.CopyToAsync(Stream)"/>
    /// <seealso cref="File.Create(string)"/>
    /// <seealso cref="FileStream"/>
    public async Task DownloadAsync(string uri, string destination, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        if (string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentNullException(nameof(destination), PATH_NULL_OR_EMPTY);
        }
        using (Stream contentStream = await _httpClient!.GetStreamAsync(uri, cancellationToken))
        {
            using (Stream fileStream = File.Create(destination))
            {
                await contentStream.CopyToAsync(fileStream, cancellationToken);
            }
        }
    }

    /// <summary>
    /// Downloads the resource with the specified URI to a local file.
    /// </summary>
    /// <param name="uri">The URI of the resource to download.</param>
    /// <param name="destination">The path to the file to save the content to.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. (default: CancellationToken.None)</param>
    /// <exception cref="ArgumentNullException">The URI cannot be null or empty.</exception>
    /// <exception cref="ArgumentNullException">The destination path cannot be null or empty.</exception>
    /// <exception cref="InvalidOperationException">The base address must be set before building the HttpClient.</exception>
    /// <example>
    /// <code>
    /// new HttpClientBuilder("https://api.example.com")
    /// .AddBearerToken("your token")
    /// .AddJsonContentType()
    /// .DownloadSync("resource", "C:\\Downloads\\resource.json");
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is synchronous.
    /// </remarks>
    /// <seealso cref="HttpClient.GetStreamAsync(string)"/>
    /// <seealso cref="Stream.CopyTo(Stream)"/>
    /// <seealso cref="File.Create(string)"/>
    /// <seealso cref="FileStream"/>
    public void Download(string uri, string destination, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new ArgumentNullException(nameof(uri), URI_NULL_OR_EMPTY);
        }
        if (string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentNullException(nameof(destination), PATH_NULL_OR_EMPTY);
        }
        using (Stream contentStream = _httpClient!.GetStreamAsync(uri, cancellationToken).Result)
        {
            using (Stream fileStream = File.Create(destination))
            {
                contentStream.CopyTo(fileStream);
            }
        }
    }

    #endregion Download
}