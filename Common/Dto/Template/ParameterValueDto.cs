using Newtonsoft.Json;

namespace Common.Dto.Template{
    public class ParameterValueDto{

        [JsonProperty("value")]
        public dynamic Value {get; set; }
    }
}