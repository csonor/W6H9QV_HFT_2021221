using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.Windows;

namespace W6H9QV_HFT_2021221.WpfClient.Services
{
	class AddOrEditEntityService<T> : IAddOrEditEntityService<T>
	{
		public void Add()
		{
			if (typeof(T) == typeof(Country))
				new AddOrEditCountryWindow().ShowDialog();
			else if (typeof(T) == typeof(County))
				new AddOrEditCountyWindow().ShowDialog();
			else if (typeof(T) == typeof(City))
				new AddOrEditCityWindow().ShowDialog();
		}

		public void Edit(T item)
		{
			if (typeof(T) == typeof(Country))
				new AddOrEditCountryWindow(item as Country).ShowDialog();
			else if (typeof(T) == typeof(County))
				new AddOrEditCountyWindow(item as County).ShowDialog();
			else if (typeof(T) == typeof(City))
				new AddOrEditCityWindow(item as City).ShowDialog();
		}
	}
}
