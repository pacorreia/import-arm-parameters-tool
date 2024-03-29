using Newtonsoft.Json;

namespace Common.Dto.Devops
{
    public class DefaultTeamDto
    {
        [JsonProperty("id")]
        public string Id {get; set;}

        [JsonProperty("name")]
        public string Name {get; set;}

        [JsonProperty("url")]
        public string Url {get; set;}
    }
}