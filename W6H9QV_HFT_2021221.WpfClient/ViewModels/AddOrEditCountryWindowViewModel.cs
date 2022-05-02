using Microsoft.Toolkit.Mvvm.ComponentModel;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class AddOrEditCountryWindowViewModel : ObservableRecipient
	{
		private Country currentCountry;
		public Country CurrentCountry { get => currentCountry; set { SetProperty(ref currentCountry, value); } }
		private RestCollection<Country> countries;

		public AddOrEditCountryWindowViewModel()
		{
			currentCountry = new Country();
			countries = new RestCollection<Country>("http://localhost:7649/", "country", "hub");
		}

		public void Add()
		{
			countries.Add(CurrentCountry);
		}

		public void Update(Country country)
		{
			countries.Update(country);
		}
	}
}
