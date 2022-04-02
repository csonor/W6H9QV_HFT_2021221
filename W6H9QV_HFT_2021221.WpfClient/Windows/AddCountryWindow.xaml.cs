using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.ViewModels;

namespace W6H9QV_HFT_2021221.WpfClient.Windows
{
	/// <summary>
	/// Interaction logic for AddCountryWindow.xaml
	/// </summary>
	public partial class AddCountryWindow : Window
	{
		public Country Country { get => ((AddCountryWindowViewModel)DataContext).AddedCountry; }

		public AddCountryWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			((AddCountryWindowViewModel)DataContext).Add();
			DialogResult = true;
		}
	}
}
