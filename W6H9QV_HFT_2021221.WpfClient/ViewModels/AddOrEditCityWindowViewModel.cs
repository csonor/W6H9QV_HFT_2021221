using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class AddOrEditCityWindowViewModel : ObservableRecipient
	{
		private City currentCity;
		public City CurrentCity { get => currentCity; set { SetProperty(ref currentCity, value); } }
		private RestCollection<City> cities;

		public AddOrEditCityWindowViewModel()
		{
			currentCity = new City();
			cities = new RestCollection<City>("http://localhost:7649/", "city", "hub");
		}

		public void Add()
		{
			cities.Add(CurrentCity);
		}

		public void Update(City city)
		{
			cities.Update(city);
		}
	}
}
