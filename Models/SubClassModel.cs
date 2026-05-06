

using DndResultsPageTests;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.ResponseModels;
using DndResultsPageTests.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DndResultsPageTests.Models
{
    public class SubClassModel : ApiObjectInfo
    {
        [JsonPropertyName("class")]
        public ApiObjectInfo? ParentClass { get; set; }
        public string? SubclassFlavor { get; set; }
        public List<string?>? Desc { get; set; }
        public List<Spell>? Spells { get; set; }
        public string? SubclassLevels { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public SubClassModel(string? index, string? name, string? url, ApiObjectInfo? @class,
            string? subclass_flavor, List<string?>? desc, List<Spell>? spells,
            string? subclass_levels, DateTime? updated_at) 
            : base(index, name, url)
        {
            ParentClass = @class;
            SubclassFlavor = subclass_flavor;
            Desc = desc;
            Spells = spells;
            SubclassLevels = subclass_levels;
            UpdatedAt = updated_at;
        }

        public ResultsPageViewModel ToResultsPageViewModel()
        {
            return new ResultsPageViewModel(null, null);
        }
    }

    public class Spell
    {
        public string? prerequisites { get; set; }
        public string? spell { get; set; }
    }
}
