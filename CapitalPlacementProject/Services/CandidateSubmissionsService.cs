using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using CapitalPlacementProject.Services.Interfaces;

namespace CapitalPlacementProject.Services
{
    public class CandidateSubmissionsService: ICandidateSubmissionsService
    {
        private readonly ICandidateSubmissionRepository _candidateSubmissionRepository;
        public CandidateSubmissionsService(ICandidateSubmissionRepository candidateSubmissionRepository) 
        { 
            _candidateSubmissionRepository = candidateSubmissionRepository;
        }

        public async Task AddSubmittedData(List<CandidateSubmitData> candidateSubmitData)
        {
            await _candidateSubmissionRepository.AddSubmittedData(candidateSubmitData);
        }
        public async Task<List<CandidateSubmitData>> GetSubmissionById(string id)
        {
            var response = await _candidateSubmissionRepository.GetSubmissionById(id);
            return response;
        }
        public async Task<bool> DeleteSubmission(string id)
        {
            var response = await _candidateSubmissionRepository.DeleteSubmission(id);
            return response;
        }
    }
}
