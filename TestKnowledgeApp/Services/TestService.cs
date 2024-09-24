using System.Threading.Tasks;
using TestKnowledgeApp.Helpers;
using TestKnowledgeApp.Interfaces;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.Responses;

namespace TestKnowledgeApp.Services;

public class TestService : ITestService
{
    private readonly IConfigurationSettings _settings;

    public TestService(IConfigurationSettings settings)
    {
        _settings = settings;
    }
    
    public async Task<CreateTestResponse?> CreateAsync(CreateTestRequest request)
    {
        var uri = _settings.AuthServiceBaseUrl + "/test/create";
        return await HttpClientHelper.PostAsync<CreateTestRequest, CreateTestResponse>(uri, request);
    }

    public async Task<GetDetailedTestInfoResponse?> GetDetailedInfoAsync(GetDetailedInfoTestRequest request)
    {
        var uri = _settings.AuthServiceBaseUrl + "/test/get";
        return await HttpClientHelper.PostAsync<GetDetailedInfoTestRequest, GetDetailedTestInfoResponse>(uri, request);
    }

    public Task<TestListByUserResponse> GetAllByUserIdAsync(int userId)
    {
        throw new System.NotImplementedException();
    }

    public Task<EditTestResponse> EditAsync(EditTestRequest request)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}