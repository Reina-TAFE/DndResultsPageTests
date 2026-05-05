using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models.UI
{
    public class UITheme
    {
        public string Name { get; set; }
        public string BackgroundColour { get; set; }
        public string SectionColour { get; set; }
        public string ButtonColour { get; set; }
        public string TextColour { get; set; }
        public string TitleColour { get; set; }
        public string NavColour { get; set; }
        
        public UITheme(string themeName, string backgroundColour, string sectionColour,
            string buttonColour, string textColour, string titleColour, string navColour) 
        {
            Name = themeName;
            BackgroundColour = backgroundColour;
            SectionColour = sectionColour;
            ButtonColour = buttonColour;
            TextColour = textColour;
            TitleColour = titleColour;
            NavColour = navColour;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
