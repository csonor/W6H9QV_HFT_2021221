using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class AddOrEditCountyWindowViewModel : ObservableRecipient
	{
		private County currentCounty;
		public County CurrentCounty { get => currentCounty; set { SetProperty(ref currentCounty, value); } }
		private RestCollection<County> counties;

		public AddOrEditCountyWindowViewModel()
		{
			currentCounty = new County();
			counties = new RestCollection<County>("http://localhost:7649/", "county", "hub");
		}

		public void Add()
		{
			counties.Add(CurrentCounty);
		}

		public void Update(County county)
		{
			counties.Update(county);
		}
	}
}
