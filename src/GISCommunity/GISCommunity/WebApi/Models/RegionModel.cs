using Newtonsoft.Json;
using System;

namespace GISCommunity.WebApi.Models
{
    public class RegionEntry
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("region")]
        public String Region { get; set; }
        [JsonProperty("localizedName")]
        public String LocalizedName { get; set; }
    }

    public class LanguageEntry
    {
        [JsonProperty("language")]
        public String Language { get; set; }
        [JsonProperty("culture")]
        public String Culture { get; set; }
        [JsonProperty("localizedName")]
        public String LocalizedName { get; set; }
    }
}