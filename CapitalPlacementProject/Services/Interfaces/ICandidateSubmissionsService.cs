using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Services.Interfaces
{
    public interface ICandidateSubmissionsService
    {
        Task AddSubmittedData(CandidateSubmitData candidateSubmitData);
    }
}
