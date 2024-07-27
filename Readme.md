# HttpClientBuilder

## Overview

`HttpClientBuilder` is a class that provides a fluent API for building an `HttpClient` instance. It allows for flexible configuration of the HttpClient by setting base addresses, headers, content types, timeouts, handlers, and more.

## Getting Started

### Usage

#### Creating an Instance

To create a new instance of `HttpClientBuilder`, you can use the default constructor or provide a base address:

```csharp
var builder = new HttpClientBuilder();
var builderWithBaseAddress = new HttpClientBuilder("<https://api.example.com>");
```

#### Configuring the HttpClient

`HttpClientBuilder` provides various methods to configure the `HttpClient` instance:

```csharp
var client = new HttpClientBuilder()
    .AddBaseAddress("<https://api.example.com>")
    .AddHeader("Custom-Header", "HeaderValue")
    .AddBearerToken("your_bearer_token")
    .AddJsonContentType()
    .SetTimeout(TimeSpan.FromMinutes(2))
    .Build();
```

#### Methods

##### Constructors

`HttpClientBuilder()`: Initializes a new instance of the `HttpClientBuilder` class.
`HttpClientBuilder(string baseAddress)`: Initializes a new instance with a base address.

##### Adding Headers

`AddBaseAddress(string baseAddress)`: Sets the base address of the `HttpClient`.
`AddHeader(string name, string value)`: Adds a header to the `HttpClient`'s default request headers.
`AddHeaders(Dictionary<string, string> headers)`: Adds multiple headers.

##### Adding Content Type

`AddJsonContentType()`: Adds the "application/json" content type.
`AddXmlContentType()`: Adds the "application/xml" content type.
`AddFormUrlEncodedContentType()`: Adds the "application/x-www-form-urlencoded" content type.
`AddTextPlainContentType()`: Adds the "text/plain" content type.
`AddCustomContentType(string contentType)`: Adds a custom content type.
`AddContent(HttpContent content)`: Adds specified content.

##### Adding Authentication

`AddBearerToken(string token)`: Adds a Bearer token to the `HttpClient`'s default request headers.
`AddBasicAuthentication(string username, string password)`: Adds Basic Authentication.
`AddApiKey(string apiKey)`: Adds an API key with the default header name "x-api-key".
`AddApiKey(string apiKey, string headerName)`: Adds an API key with a custom header name.

##### Setting Timeouts

_Default value_ : 30 seconds

`SetTimeout(TimeSpan timeout)`: Sets the timeout.
`SetTimeout(int milliseconds)`: Sets the timeout in milliseconds.
`SetTimeoutInSeconds(int seconds)`: Sets the timeout in seconds.
`SetTimeoutInMinutes(int minutes)`: Sets the timeout in minutes.
`SetTimeoutInHours(int hours)`: Sets the timeout in hours.

##### Adding Handlers

_Pay attention_ : Replace the `HttpClient`

`AddHandler(DelegatingHandler handler)`: Adds a custom handler.
`AddMessageHandler(HttpMessageHandler handler)`: Adds a custom message handler.
`AddDelegatingHandler(DelegatingHandler handler)`: Adds a custom delegating handler.

##### Setting Maximum Response Content Buffer Size

_Default value_: 10 MB

`SetMaxResponseContentBufferSize(long size)`: Sets the maximum buffer size.
`SetMaxResponseContentBufferSize(int size)`: Sets the maximum buffer size.
`SetMaxResponseContentBufferSizeInKilobytes(int size)`: Sets the maximum buffer size in kilobytes.
`SetMaxResponseContentBufferSizeInMegabytes(int size)`: Sets the maximum buffer size in megabytes.
`SetMaxResponseContentBufferSizeInGigabytes(int size)`: Sets the maximum buffer size in gigabytes.

##### Adding Cookies

`AddCookie(Cookie cookie)`: Adds a cookie.
`AddCookies(IEnumerable<Cookie> cookies)`: Adds multiple cookies.

##### Adding Query Parameters

`AddQueryParameter(string name, string value)`: Adds a query parameter.
`AddQueryParameters(Dictionary<string, string> parameters)`: Adds multiple query parameters.

##### Building the HttpClient

`Build()`: Builds and returns the configured `HttpClient` instance.

#### Example

Here's a comprehensive example demonstrating the usage of `HttpClientBuilder`:

```csharp
var client = new HttpClientBuilder()
    .AddBaseAddress("<https://api.example.com>")
    .AddBearerToken("your_bearer_token")
    .AddJsonContentType()
    .SetTimeoutInMinutes(5)
    .AddQueryParameter("version", "1.0")
    .Build();
```

In this example, we create a `HttpClient` instance with a base address, an "Accept" header, a Bearer token for authorization, and a timeout of 5 minutes.

# License

This project is licensed under the MIT License - see the LICENSE file for details.

----

This README provides a comprehensive guide to using the `HttpClientBuilder` class, detailing its constructors, methods, and usage examples. Adjust the content as necessary to better fit your specific context and requirements.
