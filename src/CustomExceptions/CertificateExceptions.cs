namespace HttpClientHelper.CustomExceptions;

/// <summary>
/// Certificate Exceptions
/// </summary>
public class CertificateException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CertificateException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    public CertificateException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    /// <param name="innerException">Inner Exception</param>
    public CertificateException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Certificate Not Found Exception
/// </summary>
public class CertificateNotFoundException : CertificateException
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CertificateNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    public CertificateNotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    /// <param name="innerException">Inner Exception</param>
    public CertificateNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Certificate Invalid Exception
/// </summary>
public class CertificateInvalidException : CertificateException
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CertificateInvalidException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    public CertificateInvalidException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Message</param>
    /// <param name="innerException">Inner Exception</param>
    public CertificateInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}