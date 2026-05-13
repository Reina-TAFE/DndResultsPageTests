using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using DndResultsPageTests.Models;
using DndResultsPageTests.Models.UI;
using DndResultsPageTests.Services;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;

namespace DndResultsPageTests.ViewModels
{
    [QueryProperty("ViewModel", "ViewModel")]
    public class ResultsPageViewModel : ObservableObject
    {  
        public ContentView PageContent = new ContentView();
        public ResultsPageHeaderViewModel? Header { get; set; }
        public ResultsPageSectionViewModel? Body { get; set; }
        public List<ImageButton> NavBar = NavBarModel.NavBarButtons;

        public ResultsPageViewModel(ResultsPageHeaderViewModel? header, ResultsPageSectionViewModel? body) 
        {
            Header = header;
            Body = body;
            Header?.Content.Parent = null;
            //Body.Content.Parent = null;
            Grid PageWrapper = new Grid
            {
                    RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto },
                },
            };
            Grid ContentGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
            };
            VerticalStackLayout gridWrapper = new VerticalStackLayout();
            ContentGrid.Add(Header, 0, 0);
            ContentGrid.Add(Body, 0, 1);
            ScrollView ContentScrollView = new ScrollView
            {
                Content = ContentGrid
            };
            PageWrapper.Add(ContentScrollView, 0, 0);
            PageContent.Content = PageWrapper;
            //PageContent.Content = ContentGrid;

        }
    }
}
