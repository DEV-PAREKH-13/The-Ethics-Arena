using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheEthicsArena.Web.Models
{
    public class DilemmaResponseMongo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string UserId { get; set; } = string.Empty;
    public int DilemmaId { get; set; }
    public string Choice { get; set; } = string.Empty; // "A" or "B"
    public DateTime Timestamp { get; set; }
    public int TimeToDecide { get; set; }
    public string? UserAgent { get; set; }
    public string? IpAddress { get; set; }
    public string UserName { get; set; } = string.Empty; // <-- ADD THIS LINE
}


    public class EthicalDilemmaMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public int DilemmaId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Scenario { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionADescription { get; set; } = string.Empty;
        public string OptionBDescription { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string PhilosophicalContext { get; set; } = string.Empty;
        public int ResponsesA { get; set; }
        public int ResponsesB { get; set; }
    }
}
