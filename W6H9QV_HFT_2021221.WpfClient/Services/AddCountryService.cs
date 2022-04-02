using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.Services.Interfaces;
using W6H9QV_HFT_2021221.WpfClient.Windows;

namespace W6H9QV_HFT_2021221.WpfClient.Services
{
	class AddCountryService : IAddCountryService
	{
		public Country? AddCountry()
		{
			AddCountryWindow addCountryWindow = new AddCountryWindow();
			if (addCountryWindow.ShowDialog() == true)
			{
				return addCountryWindow.Country;
			}
			return null;
		}
	}
}
