using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Common.Dto.Devops
{
    public class ProjectDto
    {
        [JsonProperty("id")]
        public string Id {get; set;}

        [JsonProperty("name")]
        public string Name {get; set;}

        [JsonProperty("url")]
        public string Url {get; set;}

        [JsonProperty("state")]
        public string State {get; set;}

        [JsonProperty("revision")]
        public int? Revision {get; set;}

        [JsonProperty("_links")]
        public Dictionary<string,LinkDto> Links {get; set;}

        [JsonProperty("visibility")]
        public string Visibility {get; set;}

        [JsonProperty("defaultTeam")]
        public DefaultTeamDto DefaultTeam {get; set;}

        [JsonProperty("lastUpdateTime")]
        public DateTime? LastUpdateTime {get; set;}
    }
}