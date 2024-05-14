using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacementProject.Repository
{
    public class CandidatesSubmissionRepository: ICandidateSubmissionRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _container;
        public CandidatesSubmissionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            var dbName = configuration["CosmosDb:DatabaseName"];
            var containerName = "Submissions";
            _container = _cosmosClient.GetContainer(dbName, containerName);
        }
        public async Task AddSubmittedData(CandidateSubmitData candidateSubmitData)
        {
            await _container.CreateItemAsync(candidateSubmitData, new PartitionKey(candidateSubmitData.QuestionId));
        }
    }
}
