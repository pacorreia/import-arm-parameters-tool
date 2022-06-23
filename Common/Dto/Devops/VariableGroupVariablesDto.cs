using Newtonsoft.Json;

namespace Common.Dto.Devops{
    public class VariableGroupVariablesDto
    {
        
        [JsonProperty("value")]
        public dynamic Value {get; set;}
        
        [JsonProperty("isSecret")]
        public bool IsSecret {get; set;}
    }
}