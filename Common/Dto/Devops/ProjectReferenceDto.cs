using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Dto.Devops{
    public class ProjectReferenceDto
    {
        
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
    }
}