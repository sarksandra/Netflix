using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Netflix.Services;
using Netflix.Pages;
using Netflix.ViewModels;

namespace Netflix;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName,
            httpClient => httpClient.BaseAddress = new Uri("https://api.themoviedb.org"));

        builder.Services.AddSingleton<TmdbService>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<CategoriesViewModel>();
        builder.Services.AddSingleton<CategoriePage>();

        return builder.Build();
	}
}
