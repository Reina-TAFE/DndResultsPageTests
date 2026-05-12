using DndResultsPageTests.ViewModels;

namespace DndResultsPageTests.Pages;

[QueryProperty(nameof(ViewModel), "ViewModel")]
public partial class ResultsPage : ContentPage
{
    private ResultsPageViewModel viewModel;
    public ResultsPageViewModel ViewModel 
    {
        get => viewModel; 
        set
        {
            OnPropertyChanged();
            if (value != null)
            {
                viewModel = value;
                LoadViewModel(value);
            }
        }
    }
	public ResultsPage()
	{
		InitializeComponent();
        BindingContext = this;
        //ResultsPageWrapper.Content = ViewModel.PageContent.Content;
    }

    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    ResultsPageViewModel viewModel = query["ViewModel"] as ResultsPageViewModel;

    //}

    public void LoadViewModel(ResultsPageViewModel vm)
    {
        vm.PageContent.Content.Parent = null;
        ResultsPageWrapper.Content = vm.PageContent.Content;
    }
}