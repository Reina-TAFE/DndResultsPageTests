using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DndResultsPageTests.Models
{
    public class ApiObjectInfo
    {
        [JsonPropertyName("index")]
        public string? Index {  get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        public ApiObjectInfo(string? index, string? name, string? url) 
        { 
            Index = index;
            Name = name;
            Url = url;
        }

        public override string ToString()
        {
            if (Name != null) { return Name; } else {  return "Missing Item Name."; }
        }
    }
}
