using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Repository.Interfaces
{
    public interface ICandidateSubmissionRepository
    {
        Task AddSubmittedData(CandidateSubmitData candidateSubmitData);
    }
}
