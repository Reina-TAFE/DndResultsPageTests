using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;

namespace DndResultsPageTests.ViewModels.ResultsPageComponentModels;

public partial class ResultsPageHeaderViewModel : ContentView
{
    public string? HeaderTitle { get; set; }
    public string? HeaderSubtitle { get; set; }
    public Image? HeaderIcon { get; set; }
    public ResultsPageHeaderViewModel(ResultsPageHeaderModel headerModel)
    {
        HeaderTitle = headerModel.TitleText;
        HeaderSubtitle = headerModel.SubtitleText;
        HeaderIcon = headerModel.Icon;

        Grid ContentGrid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            },
        };
        Label TitleLabel = new Label
        {
            Text = HeaderTitle,
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        Label SubtitleLabel = new Label
        {
            Text = HeaderSubtitle,
            FontSize = 18,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        BoxView seperator = new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill };
        ContentGrid.Add(TitleLabel, 0, 0);
        ContentGrid.Add(HeaderIcon, 1, 0);
        ContentGrid.AddWithSpan(seperator, 1, 0, 1, 2);
        ContentGrid.Add(SubtitleLabel, 0, 2);
        Content = ContentGrid;
    }
}