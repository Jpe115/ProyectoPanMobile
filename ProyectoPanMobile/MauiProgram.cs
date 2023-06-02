using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.ViewModels;
using ProyectoPanMobile.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace ProyectoPanMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<PanRepository>();
        builder.Services.AddSingleton<Inicio>();
		builder.Services.AddTransient<InicioViewModel>();
		builder.Services.AddTransient<DetallesPage>();
		builder.Services.AddTransient<DetallesPageViewModel>();
		builder.Services.AddSingleton<Carrito>();
		builder.Services.AddTransient<CarritoViewModel>();
		builder.Services.AddTransient<Cuenta>();
		builder.Services.AddTransient<CuentaViewModel>();
		builder.Services.AddTransient<AppShellViewModel>();
		
		//builder.Services.AddTransient<PanRepository,PanRepository>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
