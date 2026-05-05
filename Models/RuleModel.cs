using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models
{
    public class RuleModel : ApiObjectInfo
    {
        public string? Description { get; set; }
        public string? UpdatedAt { get; set; }

        public RuleModel(string? index, string? name, string?url, string? desc, string? updatedAt) 
            : base(index, name, url)
        { 
            Description = desc;
            UpdatedAt = updatedAt;
        }
    }
}
