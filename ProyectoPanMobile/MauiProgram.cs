using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProyectoPanMobile.Data;
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
        builder.Services.AddSingleton<PanRepository>();
        builder.Services.AddSingleton<Inicio>();
		builder.Services.AddSingleton<InicioViewModel>();
		builder.Services.AddTransient<DetallesPage>();
		builder.Services.AddTransient<DetallesPageViewModel>();
		builder.Services.AddTransient<Carrito>();
		builder.Services.AddTransient<CarritoViewModel>();
		builder.Services.AddSingleton<Cuenta>();
		
		//builder.Services.AddTransient<PanRepository,PanRepository>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
