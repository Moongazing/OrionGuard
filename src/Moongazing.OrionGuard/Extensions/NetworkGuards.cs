namespace Moongazing.OrionGuard.Extensions;

public static class NetworkGuards
{
    public static void AgainstInvalidIpAddress(this string ipAddress, string parameterName)
    {
        if (!System.Net.IPAddress.TryParse(ipAddress, out _))
        {
            throw new ArgumentException($"{parameterName} must be a valid IP address.", parameterName);
        }
    }

    public static void AgainstInvalidPort(this int port, string parameterName)
    {
        if (port < 0 || port > 65535)
        {
            throw new ArgumentException($"{parameterName} must be a valid port number between 0 and 65535.", parameterName);
        }
    }
}
