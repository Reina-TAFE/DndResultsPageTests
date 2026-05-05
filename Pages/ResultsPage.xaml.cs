using DndResultsPageTests.ViewModels;

namespace DndResultsPageTests.Pages;

public partial class ResultsPage : ContentPage, IQueryAttributable
{
	public ResultsPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ResultsPageViewModel viewModel = query["ViewModel"] as ResultsPageViewModel;
        ResultsPageWrapper.Content = viewModel.PageContent.Content;
    }
}