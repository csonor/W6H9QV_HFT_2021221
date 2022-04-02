using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.WpfClient.Services;

namespace W6H9QV_HFT_2021221.WpfClient.ViewModels
{
	class MainWindowViewModel : ObservableRecipient
	{
		public static bool IsInDesignMode
		{
			get
			{
				var prop = DesignerProperties.IsInDesignModeProperty;
				return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
			}
		}

		private Country selectedCountry;
		private County selectedCounty;
		private City selectedCity;

		IAddOrEditEntityService<Country> addOrEditCountryService;
		IAddOrEditEntityService<County> addOrEditCountyService;
		IAddOrEditEntityService<City> addOrEditCityService;

		public RestCollection<Country> Countries { get; set; }
		public RestCollection<County> Counties { get; set; }
		public RestCollection<City> Cities { get; set; }

		public ICommand CreateCountryCommand { get; set; }
		public ICommand CreateCountyCommand { get; set; }
		public ICommand CreateCityCommand { get; set; }

		public ICommand ModifyCountryCommand { get; set; }
		public ICommand ModifyCountyCommand { get; set; }
		public ICommand ModifyCityCommand { get; set; }

		public ICommand DeleteCountryCommand { get; set; }
		public ICommand DeleteCountyCommand { get; set; }
		public ICommand DeleteCityCommand { get; set; }

		public Country SelectedCountry
		{
			get { return selectedCountry; }
			set
			{
				selectedCounty = null;
				if (value != null)
				{
					if (value.CountryCode == null)
						value.CountryCode = "";
					if (value.Currency == null)
						value.Currency = "";
					selectedCountry = new Country()
					{
						Name = value.Name,
						Counties = value.Counties,
						CountryCode = value.CountryCode,
						Currency = value.Currency,
						DrivingSide = value.DrivingSide,
						EnglishName = value.EnglishName,
						ID = value.ID,
						Population = value.Population
					};
					OnPropertyChanged("ListSelectedCounties");
					OnPropertyChanged("ListSelectedCities");
				}
			}
		}

		public County SelectedCounty
		{
			get { return selectedCounty; }
			set
			{
				if (value != null)
				{
					selectedCounty = new County()
					{
						Population = value.Population,
						ID = value.ID,
						Country = value.Country,
						Cities = value.Cities,
						CountryID = value.CountryID,
						CountySeat = value.CountySeat,
						Districts = value.Districts,
						Name = value.Name
					};
					OnPropertyChanged("ListSelectedCities");
				}
			}
		}

		public City SelectedCity
		{
			get { return selectedCity; }
			set
			{
				if (value != null)
				{
					selectedCity = new City()
					{
						Name = value.Name,
						ID = value.ID,
						Population = value.Population,
						Area = value.Area,
						County = value.County,
						CountyID = value.CountyID,
						Elevation = value.Elevation
					};
					OnPropertyChanged();
				}
			}
		}

		public IEnumerable<County> ListSelectedCounties { get => Counties.Where(x => x.CountryID == selectedCountry.ID); }
		public IEnumerable<City> ListSelectedCities
		{
			get
			{
				if (selectedCounty != null) return Cities.Where(x => x.CountyID == selectedCounty.ID);
				else return null;
			}
		}
		public MainWindowViewModel() :
			this(IsInDesignMode ? null : Ioc.Default.GetService<IAddOrEditEntityService<Country>>(),
				IsInDesignMode ? null : Ioc.Default.GetService<IAddOrEditEntityService<County>>(),
				IsInDesignMode ? null : Ioc.Default.GetService<IAddOrEditEntityService<City>>())
		{
		}

		public MainWindowViewModel(IAddOrEditEntityService<Country> addOrEditCountryService,
			IAddOrEditEntityService<County> addOrEditCountyService,
			IAddOrEditEntityService<City> addOrEditCityService)
		{
			if (!IsInDesignMode)
			{
				Countries = new RestCollection<Country>("http://localhost:7649/", "country", "hub");
				Counties = new RestCollection<County>("http://localhost:7649/", "county", "hub");
				Cities = new RestCollection<City>("http://localhost:7649/", "city", "hub");
			}
			
			this.addOrEditCountryService = addOrEditCountryService;
			this.addOrEditCountyService = addOrEditCountyService;
			this.addOrEditCityService = addOrEditCityService;

			CreateCountryCommand = new RelayCommand(() => addOrEditCountryService.Add());
			ModifyCountryCommand = new RelayCommand(() => addOrEditCountryService.Edit(SelectedCountry), () => SelectedCountry != null);
			DeleteCountryCommand = new RelayCommand(() => Countries.Delete(SelectedCountry.ID), () => SelectedCountry != null);

			CreateCountyCommand = new RelayCommand(() => addOrEditCountyService.Add());
			ModifyCountyCommand = new RelayCommand(() => addOrEditCountyService.Edit(SelectedCounty), () => SelectedCounty != null);
			DeleteCountyCommand = new RelayCommand(() => Counties.Delete(SelectedCounty.ID), () => SelectedCounty != null);

			SelectedCountry = new Country();
			SelectedCounty = new County();
		}
	}
}
