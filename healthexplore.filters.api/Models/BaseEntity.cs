namespace healthexplore.filters.api.Models
{
    using Newtonsoft.Json;

    public class BaseEntity
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("doc_count")]
        public int DocCount { get; set; }
    }
}
