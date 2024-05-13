using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task CreateQuestion(Questions question);
    }
}
