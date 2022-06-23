using Newtonsoft.Json;

namespace Common.Dto.Devops
{
    public class VariableGroupError{
        
        [JsonProperty("innerException")]
        public string InnerException {get; set;}

        [JsonProperty("message")]
        public string Message {get; set;}

        [JsonProperty("typeName")]
        public string TypeName {get; set;}

        [JsonProperty("typeKey")]
        public string TypeKey {get; set;}

        [JsonProperty("errorCode")]
        public int ErrorCode {get; set;}

        [JsonProperty("eventId")]
        public int EventId {get; set;}
    }
}