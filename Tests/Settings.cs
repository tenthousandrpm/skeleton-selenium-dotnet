using Microsoft.Extensions.Configuration;

public static class Settings
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile("appsettings.local.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    public static string BaseUrl => _config["BaseUrl"] ?? "https://example.com";
    public static string SeleniumHub => _config["SeleniumHub"] ?? _config["SELENIUM_HUB"] ?? _config["SELENIUMHUB"] ?? "http://localhost:4444";
    public static bool Headless => bool.Parse(_config["Headless"] ?? _config["HEADLESS"] ?? "true");
    public static int TimeoutSeconds => int.Parse(_config["TimeoutSeconds"] ?? _config["TIMEOUTSECONDS"] ?? "10");
}
