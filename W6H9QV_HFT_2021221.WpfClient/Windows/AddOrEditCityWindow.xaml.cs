using System.Windows;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.ViewModels;

namespace W6H9QV_HFT_2021221.WpfClient.Windows
{
	/// <summary>
	/// Interaction logic for AddOrEditCityWindow.xaml
	/// </summary>
	public partial class AddOrEditCityWindow : Window
	{
		public City City { get => ((AddOrEditCityWindowViewModel)DataContext).CurrentCity; }
		bool edit = false;

		public AddOrEditCityWindow()
		{
			InitializeComponent();
		}

		public AddOrEditCityWindow(City city) : this()
		{
			edit = true;
			((AddOrEditCityWindowViewModel)DataContext).CurrentCity = city;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (edit)
				((AddOrEditCityWindowViewModel)DataContext).Update(City);
			else
				((AddOrEditCityWindowViewModel)DataContext).Add();
			DialogResult = true;
		}
	}
}
