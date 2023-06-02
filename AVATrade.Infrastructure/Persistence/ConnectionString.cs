using System;

namespace AVATrade.Infrastructure.Persistence;

public static class ConnectionString
{
    private static string DatabaseServer = "localhost";

    private static string DatabasePort = "1433";

    private static string DatabaseName = "AVATrade";

    private static string DatabaseUser = "sa";

    private static string DatabasePassword = "Password123";

    public static string BuildConnection()
    {
        return
            $"Server={DatabaseServer},{DatabasePort};Database={DatabaseName};User Id={DatabaseUser};Password={DatabasePassword};TrustServerCertificate=true";
    }
}

