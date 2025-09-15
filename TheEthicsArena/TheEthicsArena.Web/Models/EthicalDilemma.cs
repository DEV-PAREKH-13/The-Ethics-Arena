namespace TheEthicsArena.Web.Models
{
    public class EthicalDilemma
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int ResponsesA { get; set; }
        public int ResponsesB { get; set; }
    }
}
