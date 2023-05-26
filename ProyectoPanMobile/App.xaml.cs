using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;
using System.Reflection;

namespace ProyectoPanMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
		
        MainPage = new AppShell();
        //Shell.Current.GoToAsync(nameof(Login1));
		VersionTracking.Track();
		if (VersionTracking.IsFirstLaunchEver)
		{
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
			using (Stream stream = assembly.GetManifestResourceStream("ProyectoPanMobile.pan.db"))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					stream.CopyTo(memoryStream);
					File.WriteAllBytes(PanRepository.DbPath,memoryStream.ToArray());
				}
			}
		}
	}
	
    
}
