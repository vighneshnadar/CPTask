using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Repository.Interfaces
{
    public interface ICandidateSubmissionRepository
    {
        Task AddSubmittedData(List<CandidateSubmitData> candidateSubmitDataList);
        Task<List<CandidateSubmitData>> GetSubmissionById(string id);
        Task<bool> DeleteSubmission(string id);
    }
}
