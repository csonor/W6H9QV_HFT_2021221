using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Windows;
using W6H9QV_HFT_2021221.WpfClient.Services;
using W6H9QV_HFT_2021221.WpfClient.Services.Interfaces;

namespace W6H9QV_HFT_2021221.WpfClient
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Ioc.Default.ConfigureServices(
				new ServiceCollection()
				.AddSingleton<IAddOrEditCountryService,AddOrEditCountryService>()
				.BuildServiceProvider());
		}
	}
}
