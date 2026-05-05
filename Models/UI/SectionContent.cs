using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models.UI
{
    public class SectionContent
    {
        public string? SectionTitle { get; set; } = null;
        public string? ContentType { get; set; } = null;

        public List<SectionItem>? Content { get; set; } = null;
    }

    public class SectionItem 
    {
        public string? SectionItemTitle { get; set; } = null;
        public string? ItemType { get; set; } = null;

        public List<Dictionary<string, string?>>? ItemContent { get; set; } = null;
        public List<object?>? ItemObjects { get; set; } = null;
    }
}
