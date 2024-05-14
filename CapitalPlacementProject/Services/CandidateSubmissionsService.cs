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

        public async Task AddSubmittedData(CandidateSubmitData candidateSubmitData)
        {
            await _candidateSubmissionRepository.AddSubmittedData(candidateSubmitData);
        }
    }
}
