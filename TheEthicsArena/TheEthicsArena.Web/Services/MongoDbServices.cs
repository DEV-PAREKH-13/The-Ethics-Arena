using MongoDB.Driver;
using TheEthicsArena.Web.Models;

namespace TheEthicsArena.Web.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<DilemmaResponseMongo> _responses;
        private readonly IMongoCollection<EthicalDilemmaMongo> _dilemmas;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB") ?? "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("EthicsArena");
            _responses = _database.GetCollection<DilemmaResponseMongo>("responses");
            _dilemmas = _database.GetCollection<EthicalDilemmaMongo>("dilemmas");
        }

        public async Task SaveResponseAsync(DilemmaResponseMongo response)
        {
            await _responses.InsertOneAsync(response);
        }

        public async Task<List<DilemmaResponseMongo>> GetResponsesForDilemmaAsync(int dilemmaId)
        {
            return await _responses.Find(r => r.DilemmaId == dilemmaId).ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetResponseStatsAsync(int dilemmaId)
        {
            var responses = await GetResponsesForDilemmaAsync(dilemmaId);
            return new Dictionary<string, int>
            {
                ["A"] = responses.Count(r => r.Choice == "A"),
                ["B"] = responses.Count(r => r.Choice == "B")
            };
        }

        public async Task<long> GetTotalResponsesAsync()
        {
            return await _responses.CountDocumentsAsync(FilterDefinition<DilemmaResponseMongo>.Empty);
        }
    }
}
