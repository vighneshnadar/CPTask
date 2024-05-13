using CapitalPlacementProject.Models;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static CapitalPlacementProject.Enums.Enum;


namespace CapitalPlacementProject.Employer
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;
        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        [Route("/CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(Questions question)
        {
            await _questionsService.CreateQuestion(question);
            return Ok();
        }
        [HttpPut]
        [Route("/UpdateQuestion/{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, Questions updatedQuestion)
        {
            var res = await _questionsService.UpdateQuestion(id, updatedQuestion);
            return Ok(res);
        }
        [HttpGet]
        [Route("/GetQuestionsByType/{type}")]
        public async Task<IActionResult> GetQuestionsByType(QuestionType type)
        {
            var typeString = ((int)type).ToString();
            var res = await _questionsService.GetQuestionsByType(typeString);
            return Ok(res);
        }

    }
}
