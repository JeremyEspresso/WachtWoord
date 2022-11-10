using Microsoft.Extensions.Logging;
using WachtWoord.Logic.Abstractions;
using WachtWoord.Logic.Services;

namespace WachtWoord;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IEntryService, EntryService>();
		builder.Services.AddSingleton<IHistoryService, HistoryService>();

        return builder.Build();
	}
}
