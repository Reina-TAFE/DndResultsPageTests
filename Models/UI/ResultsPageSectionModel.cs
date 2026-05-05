using System;
using System.Collections.Generic;
using System.Text;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;

namespace DndResultsPageTests.Models.UI
{
    public class ResultsPageSectionModel
    {
        private string? _sectionType;
        public string SectionType // Determines how the ContentViewModel will formot the content
        {
            get { return (_sectionType != null) ? _sectionType : "standard"; }
            set { _sectionType = value; }
        }
        private string? _sectionTitle;
        public string SectionTitle
        {
            get { return (_sectionTitle != null) ? _sectionTitle : ""; }
            set { _sectionTitle = value; }
        }

        private List<SectionContent>? _sectionContent;
        public List<SectionContent>? SectionContent
        {
            get { return (_sectionContent != null) ? _sectionContent : new List<SectionContent>(); }
            set { _sectionContent = value; }
        }

        public ResultsPageSectionModel(string? sectionTitle, List<SectionContent>? sectionContent)
        {
            SectionTitle = sectionTitle;
            SectionContent = sectionContent;
        }

        public object ToObject()
        {
            return this as object;
        }
    }
}
