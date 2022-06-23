using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Dto.Devops{
    public class VariableGroupProjectReferencesDto
    {
        [JsonProperty("description")]
        public string Description {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("projectReference")]
        public ProjectReferenceDto ProjectReference {get; set;}
    }
}