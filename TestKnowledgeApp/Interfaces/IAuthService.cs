using System.Threading.Tasks;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.Responses;

namespace TestKnowledgeApp.Interfaces;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest loginRequest);
    Task<RegisterResponse?> RegisterAsync(RegisterRequest registerRequest);
}