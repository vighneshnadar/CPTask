using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Repository.Interfaces
{
    public interface IQuestionsRepository
    {
        Task AddQuestions(Questions questions);
    }
}
