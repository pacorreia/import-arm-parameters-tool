using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Dto.Devops{
    [Serializable]
    public class VariableGroupRequestDto
    {
        
        [JsonProperty("description")]
        public string Description {get; set;}
	    
        [JsonProperty("name")]
        public string Name {get; set;}
	    
        [JsonProperty("providerData")]
        public string ProviderData { get; set;} = null;
	    
        [JsonProperty("type")]
        public string Type {get; set;} = "Vsts";
        
        [JsonProperty("variables")]
        public Dictionary<string,VariableGroupVariablesDto> Variables {get; set;}
        
        [JsonProperty("variableGroupProjectReferences")]
        public List<VariableGroupProjectReferencesDto> VariableGroupProjectReferences {get; set;}

    }
}