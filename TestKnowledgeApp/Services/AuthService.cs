using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TestKnowledgeApp.Interfaces;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.Responses;

namespace TestKnowledgeApp.Services;

public class AuthService : IAuthService
{
    private readonly IConfigurationSettings _configurationSettings;

    public AuthService(IConfigurationSettings configurationSettings)
    {
        _configurationSettings = configurationSettings;
    }
    
    public async Task<LoginResponse?> LoginAsync(LoginRequest loginRequest)
    {
        using var httpClient = new HttpClient();

        var uri = _configurationSettings.AuthServiceBaseUrl + "/auth/signin";
        
        var responseMessage = await httpClient.PostAsJsonAsync(uri, loginRequest);
        responseMessage.EnsureSuccessStatusCode();

        var json = await responseMessage.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<LoginResponse>(json);
    }

    public async Task<RegisterResponse?> RegisterAsync(RegisterRequest registerRequest)
    {
        using var httpClient = new HttpClient();
        var uri = _configurationSettings.AuthServiceBaseUrl + "/api/auth/signup";
        
        var responseMessage = await httpClient.PostAsJsonAsync(uri, registerRequest);
        responseMessage.EnsureSuccessStatusCode();

        var json = await responseMessage.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<RegisterResponse>(json);
    }
}