using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProyectoPanMobile.ViewModels;
using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

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
		builder.Services.AddSingleton<Inicio>();
		builder.Services.AddSingleton<InicioViewModel>();
		builder.Services.AddSingleton<Carrito>();
		builder.Services.AddSingleton<Cuenta>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
