using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using CapitalPlacementProject.Services.Interfaces;

namespace CapitalPlacementProject.Services
{
    public class QuestionsService:IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;
        public QuestionsService(IQuestionsRepository questionsRepository) 
        {
            _questionsRepository = questionsRepository;
        }
        public async Task CreateQuestion(Questions question)
        {
            await _questionsRepository.AddQuestions(question);
        }
    }
}
