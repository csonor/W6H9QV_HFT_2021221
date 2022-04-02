using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.Services.Interfaces
{
	interface IAddOrEditCountryService
	{
		void AddCountry();
		void EditCountry(Country country);
	}
}
