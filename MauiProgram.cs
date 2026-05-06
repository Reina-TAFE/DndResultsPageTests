using Microsoft.Extensions.Logging;
using DndResultsPageTests.Pages;
using DndResultsPageTests.ViewModels;
using DndResultsPageTests.ViewModels.ResultsPageComponentModels;

namespace DndResultsPageTests
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddTransient < ResultsPage>();
            builder.Services.AddTransient<ResultsPageViewModel>();
            builder.Services.AddTransient<ResultsPageHeaderViewModel>();
            builder.Services.AddTransient<ResultsPageSectionViewModel>();
#endif

            return builder.Build();
        }
    }
}
