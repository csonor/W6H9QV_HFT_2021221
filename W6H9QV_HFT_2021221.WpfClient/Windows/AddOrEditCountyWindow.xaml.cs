using System.Windows;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.ViewModels;

namespace W6H9QV_HFT_2021221.WpfClient.Windows
{
	/// <summary>
	/// Interaction logic for AddOrEditCountyWindow.xaml
	/// </summary>
	public partial class AddOrEditCountyWindow : Window
	{
		public County County { get => ((AddOrEditCountyWindowViewModel)DataContext).CurrentCounty; }
		bool edit = false;
		public AddOrEditCountyWindow()
		{
			InitializeComponent();
		}

		public AddOrEditCountyWindow(County county) : this()
		{
			edit = true;
			((AddOrEditCountyWindowViewModel)DataContext).CurrentCounty = county;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (edit)
				((AddOrEditCountyWindowViewModel)DataContext).Update(County);
			else
				((AddOrEditCountyWindowViewModel)DataContext).Add();
			DialogResult = true;
		}
	}
}
