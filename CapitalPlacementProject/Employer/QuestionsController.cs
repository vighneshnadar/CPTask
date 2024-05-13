using CapitalPlacementProject.Models;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
    }
}
