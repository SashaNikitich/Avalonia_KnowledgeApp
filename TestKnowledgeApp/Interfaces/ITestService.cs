using System.Threading.Tasks;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.Responses;

namespace TestKnowledgeApp.Interfaces;

public interface ITestService
{
    Task<CreateTestResponse?> CreateAsync(CreateTestRequest request);
    Task<GetDetailedTestInfoResponse?> GetDetailedInfoAsync(GetDetailedInfoTestRequest id);
    Task<TestListByUserResponse> GetAllByUserIdAsync(int userId);
    Task<EditTestResponse> EditAsync(EditTestRequest request);
    Task DeleteAsync(int id);
}