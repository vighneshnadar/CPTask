using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repository.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

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
        public async Task<Questions> UpdateQuestions(string id,Questions questions)
        {
            var response  = await _container.ReplaceItemAsync<Questions>(questions,id,new PartitionKey(questions.Type));
            return response.Resource;
        }
        public async Task<List<Questions>> GetQuestionsByType(string type)
        {
            var response = _container.GetItemLinqQueryable<Questions>()
                                     .Where(c=>c.Type==type).ToFeedIterator();
            var questions = new List<Questions>();
            while (response.HasMoreResults)
            {
                var singlequestion = await response.ReadNextAsync();
                questions.AddRange(singlequestion);
            }
            return questions;
        }
        public async Task<Questions> GetQuestionsById(string id)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.id = @id")
                        .WithParameter("@id", id);

            var iterator = _container.GetItemQueryIterator<Questions>(query);
            var response = await iterator.ReadNextAsync();
            if (!response.Any())
            {
                return null;
            }         
           return response.FirstOrDefault();
        }
    } 
}
