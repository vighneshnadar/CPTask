using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Services.Interfaces
{
    public interface ICandidateSubmissionsService
    {
        Task AddSubmittedData(List<CandidateSubmitData> candidateSubmitData);
        Task<List<CandidateSubmitData>> GetSubmissionById(string id);
        Task<bool> DeleteSubmission(string id);
    }
}
