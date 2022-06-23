using Newtonsoft.Json;
using System.Collections.Generic;


namespace Common.Dto.Template{
    public class ParametersDto{

        [JsonProperty("$schema")]
        public string Schema { get; set; }
        
        [JsonProperty("contentVersion")]
        public string ContentVersion { get; set; }
        
        [JsonProperty("parameters")]
        public Dictionary<string,ParameterValueDto> Parameters {get; set;}
    }


}