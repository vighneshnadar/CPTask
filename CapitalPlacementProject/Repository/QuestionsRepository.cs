using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacementProject.Repository
{
    public class QuestionsRepository:IQuestionsRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _container;
        public QuestionsRepository(CosmosClient cosmosClient, IConfiguration configuration) 
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            var dbName = configuration["CosmosDb:DatabaseName"];
            var containerName = "Questions";
            _container = _cosmosClient.GetContainer(dbName, containerName);
        }
        public async Task AddQuestions(Questions questions)
        {
            //questions.id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(questions,new PartitionKey(questions.Type));
        }
    }
}
