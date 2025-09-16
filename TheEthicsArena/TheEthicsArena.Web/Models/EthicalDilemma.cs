namespace TheEthicsArena.Web.Models
{
    public class EthicalDilemma
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Scenario { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionADescription { get; set; } = string.Empty;
        public string OptionBDescription { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int ResponsesA { get; set; }
        public int ResponsesB { get; set; }
        public string PhilosophicalContext { get; set; } = string.Empty;
    }

    public class DilemmaResponse
    {
        public string UserID { get; set; } = string.Empty;
        public int DilemmaId { get; set; }
        public string Choice { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int TimeToDecide { get; set; } // seconds
    }
}
