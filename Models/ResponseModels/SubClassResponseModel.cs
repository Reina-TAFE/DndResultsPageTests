using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DndResultsPageTests.Models.ResponseModels
{
    public class SubClassResponseModel
    {
        public string? index { get; set; }
        [JsonPropertyName("class")]
        public ApiObjectInfo? _class { get; set; }
        public string? name { get; set; }
        public string? subclass_flavor { get; set; }
        public List<string?>? desc { get; set; }
        public List<Spell>? spells { get; set; }
        public string? subclass_levels { get; set; }
        public string? url { get; set; }
        public DateTime? updated_at { get; set; }

        public SubClassModel ToModel()
        {
            return new SubClassModel
            (
                index,
                name,
                url,
                _class,
                subclass_flavor,
                desc,
                spells,
                subclass_levels,
                updated_at
            );
        }
    }
}
