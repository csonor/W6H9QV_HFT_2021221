using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class AddCountryWindowViewModel : ObservableRecipient
	{
		private Country addedCountry;
		public Country AddedCountry { get => addedCountry; set { SetProperty(ref addedCountry, value); } }
		public RestCollection<Country> Countries { get; set; }

		public AddCountryWindowViewModel()
		{
			addedCountry = new Country();
			Countries = new RestCollection<Country>("http://localhost:7649/", "country", "hub");
		}

		public void Add()
		{
			Countries.Add(addedCountry);
		}
	}
}
