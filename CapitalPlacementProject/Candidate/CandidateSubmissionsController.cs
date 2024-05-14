using CapitalPlacementProject.Models;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static CapitalPlacementProject.Enums.Enum;


namespace CapitalPlacementProject.Candidate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSubmissionsController : ControllerBase
    {
        private readonly ICandidateSubmissionsService _candidateSubmissionsService;
        public CandidateSubmissionsController(ICandidateSubmissionsService candidateSubmissionsService)
        {
            _candidateSubmissionsService = candidateSubmissionsService;
        }

        [HttpPost]
        [Route("/SubmitAnswer")]
        public async Task<IActionResult> SubmitAnswer(CandidateSubmitData answersData)
        {
            await _candidateSubmissionsService.AddSubmittedData(answersData);
            return Ok();
        }
       

    }
}
