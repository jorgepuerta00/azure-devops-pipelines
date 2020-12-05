namespace healthexplore.job.api.Models
{
    using Newtonsoft.Json;

    public class BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }
    }
}
