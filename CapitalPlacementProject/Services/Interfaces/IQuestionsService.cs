using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task CreateQuestion(Questions question);
        Task<Questions> UpdateQuestion(string id, Questions question);
        Task<List<Questions>> GetQuestionsByType(string type);
        Task<Questions> GetQuestionsById(string id);
    }
}
