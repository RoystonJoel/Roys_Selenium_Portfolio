using Xunit.Abstractions;
using System;
using System.IO;
using System.Text.Json;



namespace Roys_Selenium_Portfolio;


public class SecretReader
{
    // Using @ makes it a verbatim string, handling backslashes correctly.
    private static string SecretsFilePath = @"seed\secrets.json";

    private static SecretsConfig _cachedSecrets = null; // Simple caching
    
    public static SecretsConfig LoadSecrets(ITestOutputHelper output)
    {
        SecretsFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory+ @"..\..\..\", SecretsFilePath);

        // Return cached version if already loaded
        if (_cachedSecrets != null)
        {
            return _cachedSecrets;
        }

        // Check if file exists
        if (!File.Exists(SecretsFilePath))
        {
            throw new FileNotFoundException($"Secrets file not found at path: {SecretsFilePath}");
        }

        // Read the entire file content
        string jsonString = File.ReadAllText(SecretsFilePath);

        // Deserialize the JSON string into our C# object structure
        // We use JsonSerializerOptions to ensure case-insensitive property matching,
        // which is helpful if C# property casing (PascalCase) differs from JSON (camelCase/exact).
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        SecretsConfig secrets = JsonSerializer.Deserialize<SecretsConfig>(jsonString, options);

        // Basic validation after deserialization
        if (secrets == null)
        {
             throw new InvalidOperationException("Failed to deserialize secrets file. Result was null.");
        }
        if (secrets.OrangeHRM == null)
        {
             throw new InvalidOperationException("Secrets file loaded, but 'OrangeHRM' section is missing or null.");
        }
         if (string.IsNullOrEmpty(secrets.OrangeHRM.Username) || string.IsNullOrEmpty(secrets.OrangeHRM.Password))
        {
             // Depending on requirements, you might allow empty values, but often they are required.
             output.WriteLine("Warning: Username or Password in OrangeHRM secrets is null or empty."); // Or throw an exception
        }


        _cachedSecrets = secrets; // Cache the loaded secrets
        return _cachedSecrets;
    }

    /// <summary>
    /// Convenience method to directly get OrangeHRM credentials.
    /// </summary>
    /// <returns>The OrangeHrmCredentials object.</returns>
    public static OrangeHrmCredentials GetOrangeHrmCredentials(ITestOutputHelper output)
    {
        return LoadSecrets(output).OrangeHRM;
    }
}

public class OrangeHrmCredentials
{
    // Property names should match the JSON keys (case-insensitive by default with System.Text.Json,
    // but matching case is good practice or use [JsonPropertyName("json_key")] attribute)
    public string Username { get; set; }
    public string Password { get; set; }
}

public class SecretsConfig
{
    // This property name MUST match the top-level key in your JSON file.
    public OrangeHrmCredentials OrangeHRM { get; set; }
}
