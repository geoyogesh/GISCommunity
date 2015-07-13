using Newtonsoft.Json;
using System;

namespace GISCommunity.WebApi.Models
{
    public class TagEntry
    {
        [JsonProperty("tag")]
        public String Tag { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}