using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class AddOrEditCountryWindowViewModel : ObservableRecipient
	{
		private Country currentCountry;
		public Country CurrentCountry { get => currentCountry; set { SetProperty(ref currentCountry, value); } }
		public RestCollection<Country> Countries { get; set; }

		public AddOrEditCountryWindowViewModel()
		{
			currentCountry = new Country();
			Countries = new RestCollection<Country>("http://localhost:7649/", "country", "hub");
		}

		public void Add()
		{
			Countries.Add(currentCountry);
		}

		public void Update(Country country)
		{
			Countries.Update(country);
		}
	}
}
