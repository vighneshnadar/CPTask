using Newtonsoft.Json;

namespace CapitalPlacementProject.Models
{
    public class CandidateSubmitData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
