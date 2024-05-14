using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Net;

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
        public async Task AddSubmittedData(List<CandidateSubmitData> candidateSubmitDataList)
        {
            foreach (var candidateSubmitData in candidateSubmitDataList)
            {
                try
                {
                    await _container.CreateItemAsync(candidateSubmitData, new PartitionKey(candidateSubmitData.QuestionId));
                }
                catch (CosmosException ex)
                {
                }
            }
        }

        public async Task<List<CandidateSubmitData>> GetSubmissionById(string id)
        {
            var query = new QueryDefinition("SELECT * FROM s WHERE s.id = @id")
                .WithParameter("@id", id);
            var response = _container.GetItemQueryIterator<CandidateSubmitData>(query);
            var answers = new List<CandidateSubmitData>();
            while (response.HasMoreResults)
            {
                var singlequestion = await response.ReadNextAsync();
                answers.AddRange(singlequestion);
            }      
            return answers;
        }
        public async Task<bool> DeleteSubmission(string id)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.id = @id")
                    .WithParameter("@id", id);

            var iterator = _container.GetItemQueryIterator<CandidateSubmitData>(query);
            var response = await iterator.ReadNextAsync();

            foreach (var submission in response)
            {
                try
                {
                    var deleteSubmissions = _container.DeleteItemAsync<CandidateSubmitData>(submission.Id, new PartitionKey(submission.QuestionId));                 
                }
                catch (CosmosException ex)
                { 
                    return false;
                }
            }
            return true;
        }
    }
}
