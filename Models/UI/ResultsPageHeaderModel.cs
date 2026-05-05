using System;
using System.Collections.Generic;
using System.Text;

namespace DndResultsPageTests.Models.UI
{
    public class ResultsPageHeaderModel
    {
        private string? _titleText;
        public string? TitleText
        {
            get { return (_titleText != null) ? _titleText : ""; }
            set { _titleText = value; }
        }

        private string? _subtitleText;
        public string? SubtitleText
        {
            get { return (_subtitleText != null) ? _subtitleText : ""; }
            set { _subtitleText = value; }
        }

        private Image? _icon;
        public Image? Icon
        {
            get { return (_icon != null) ? _icon : new Image(); }
            set { _icon = value; }
        }

        public ResultsPageHeaderModel(string? titleText, string? subTitleText, Image? icon = null)
        {
            TitleText = titleText;
            SubtitleText = subTitleText;
            Icon = icon;
        }
    }
}
