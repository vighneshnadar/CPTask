using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Repository.Interfaces
{
    public interface IQuestionsRepository
    {
        Task AddQuestions(Questions questions);
        Task<Questions> UpdateQuestions(string id, Questions questions);
        Task<List<Questions>> GetQuestionsByType(string type);
        Task<Questions> GetQuestionsById(string id);
    }
}
