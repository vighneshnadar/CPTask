using CapitalPlacementProject.Repository;
using CapitalPlacementProject.Repository.Interfaces;
using CapitalPlacementProject.Services;
using CapitalPlacementProject.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Text.Json.Serialization;
namespace CapitalPlacementProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            // Add services to the container.
            builder.Services.AddSingleton((configs) =>
            {
                var uri = config["CosmosDb:Uri"];
                var primaryKey = config["CosmosDb:PrimaryKey"];
                var dbName = config["CosmosDb:DatabaseName"];
                var clientCosmo = new CosmosClient(uri, primaryKey, new CosmosClientOptions { ApplicationName = dbName });
                return clientCosmo;
                
            });
            builder.Services.AddTransient<IQuestionsService, QuestionsService>();
            builder.Services.AddSingleton<IQuestionsRepository,QuestionsRepository>();

            builder.Services.AddTransient<ICandidateSubmissionsService, CandidateSubmissionsService>();
            builder.Services.AddSingleton<ICandidateSubmissionRepository, CandidatesSubmissionRepository>();

            builder.Services.AddControllers().AddJsonOptions(options=>
                                           options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
                    
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
