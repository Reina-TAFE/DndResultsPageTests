using DndResultsPageTests.Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models
{
    public class ClassLevelsTableModel
    {
        public List<ClassLevelsModel>? Levels { get; set; }

        public SectionItem ToSectionItem()
        {
            return new SectionItem
            {
                SectionItemTitle = null,
                ItemType = "LevelTable",
                ItemContent = null,
                ItemObjects = null,
            };

        }
    }
}
