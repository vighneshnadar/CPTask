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
        public async Task<IActionResult> SubmitAnswer(List<CandidateSubmitData> answersData)
        {
            await _candidateSubmissionsService.AddSubmittedData(answersData);
            return Ok();
        }
        [HttpGet("/GetSubmissionById/{id}")]
        public async Task<IActionResult> GetSubmissionById(string id)
        {
            var submission = await _candidateSubmissionsService.GetSubmissionById(id);
            return Ok(submission);
        }
        [HttpDelete("/DeleteSubmission/{id}")]
        public async Task<IActionResult> DeleteSubmission(string id)
        {
            var isDeleted = await _candidateSubmissionsService.DeleteSubmission(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
