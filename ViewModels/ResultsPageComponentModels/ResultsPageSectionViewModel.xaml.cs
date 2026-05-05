using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;
using Microsoft.Maui.Layouts;

namespace DndResultsPageTests.ViewModels.ResultsPageComponentModels;

public partial class ResultsPageSectionViewModel : ContentView
{
	public ResultsPageSectionModel SectionModel;
	public ResultsPageSectionViewModel(ResultsPageSectionModel sectionModel)
	{
		InitializeComponent();
		SectionModel = sectionModel;

		FlexLayout sections = new FlexLayout
		{
			Direction = FlexDirection.Column,
			Padding = new Thickness(10,20),
			AlignContent = FlexAlignContent.SpaceAround,
			AlignItems = FlexAlignItems.Start
			
		};
        foreach (SectionContent section in SectionModel.SectionContent)
		{
			VerticalStackLayout sectionElement = FormatSectionContent(section);
            sections.Children.Add(sectionElement);
        }
        Content = sections;
    }

	public VerticalStackLayout FormatSectionContent(SectionContent sectionContent)
	{
		{
			VerticalStackLayout contentLayout = new VerticalStackLayout();
			contentLayout.Spacing = 5;
			BoxView separator = new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill };
            foreach (SectionItem item in sectionContent.Content)
			{
				if (item.SectionItemTitle != null)
				{

					Label itemTitle = new Label() { Text = item.SectionItemTitle, FontAttributes = FontAttributes.Bold, VerticalTextAlignment= TextAlignment.End};
					//BoxView separator = new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill };
                    contentLayout.Children.Add(itemTitle);
                    contentLayout.Children.Add(separator);
				}
				if (item.ItemType == "KeyValueList")
				{
					foreach (Dictionary<string, string?> contentDict in item.ItemContent)
					{
						foreach (KeyValuePair<string, string?> kvp in contentDict)
						{
							if (kvp.Value != null)
							{
								Label contentLabel = new Label() { Text = $"{kvp.Key}: {kvp.Value}" };
								contentLayout.Children.Add(contentLabel);
							}
						}
					}
				}
				else if (item.ItemType == "text")
				{
					foreach (Dictionary<string, string?> contentDict in item.ItemContent)
					{
						foreach (KeyValuePair<string, string?> kvp in contentDict)
						{
							if (kvp.Value != null)
							{
								if (kvp.Key == "text")
								{
									Label contentLabel = new Label() { Text = kvp.Value };
									contentLayout.Children.Add(contentLabel);
								}
								else
								{
									Label contentLabelKey = new Label() { Text = $"{kvp.Key}:" };
									Label contentLabel = new Label() { Text = $"{kvp.Value}" };
									contentLayout.Children.Add(contentLabelKey);
									contentLayout.Children.Add(contentLabel);
								}
							}
                        }
                    }
					contentLayout.Children.Add(separator);
				}
			}
			return contentLayout;
		}
	}
}