using System.Windows;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.ViewModels;

namespace W6H9QV_HFT_2021221.WpfClient.Windows
{
	/// <summary>
	/// Interaction logic for AddCountryWindow.xaml
	/// </summary>
	public partial class AddOrEditCountryWindow : Window
	{
		public Country Country { get => ((AddOrEditCountryWindowViewModel)DataContext).CurrentCountry; }
		bool edit = false;

		public AddOrEditCountryWindow()
		{
			InitializeComponent();
		}

		public AddOrEditCountryWindow(Country country) : this()
		{
			edit = true;
			((AddOrEditCountryWindowViewModel)DataContext).CurrentCountry = country;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (edit)
				((AddOrEditCountryWindowViewModel)DataContext).Update(Country);
			else
				((AddOrEditCountryWindowViewModel)DataContext).Add();
			DialogResult = true;
		}
	}
}
