using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ModernPos.Infrastructure.DependencyInjection;
using ModernPos.Services;
using ModernPos.ViewModels;
using ModernPos.Views;

namespace ModernPos;

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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "modernpos.db");

		builder.Services.AddInfrastructureServices(dbPath);
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<IThemeService, ThemeService>();
		
		builder.Services.AddTransient<CustomerPage>();
		builder.Services.AddTransient<CustomerViewModel>();
		
		return builder.Build();
	}
}