using System.Text.Json;

namespace AttractionAdvisor.Utils;

public class Utils
{
    public static bool ValidateRequest(HttpRequest request)
    {
        // Check if the request body is empty
        if (request?.Body == null)
        {
            return false;
        }

        return true;
    }
    
    public static async Task<T> Deserialize<T>(HttpRequest request) where T : class
    {
        // Deserialize the json from the request body
        string json = await new StreamReader(request.Body).ReadToEndAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<T>(json, options);

        return result;
    }
}