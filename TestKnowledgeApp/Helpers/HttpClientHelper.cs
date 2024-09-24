using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestKnowledgeApp.Helpers;

public static class HttpClientHelper
{
    public static async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest request)
    {
        using var httpClient = new HttpClient();
        
        var responseMessage = await httpClient.PostAsJsonAsync(uri, request);
        responseMessage.EnsureSuccessStatusCode();

        var json = await responseMessage.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<TResponse>(json);
    }
}