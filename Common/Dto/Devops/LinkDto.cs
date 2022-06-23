using Newtonsoft.Json;

namespace Common.Dto.Devops
{
    public class LinkDto
    {
        [JsonProperty("href")]
        public string Href {get; set;}
    }
}