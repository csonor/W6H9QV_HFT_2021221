using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W6H9QV_HFT_2021221.Endpoint.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class StatController : ControllerBase
	{
		ICountryLogic countryLogic;
		ICountyLogic countyLogic;

		public StatController(ICountryLogic countryLogic, ICountyLogic countyLogic)
		{
			this.countryLogic = countryLogic;
			this.countyLogic = countyLogic;
		}

		[HttpGet]
		public IEnumerable<CitiesGroupedByDrivingSide> CitiesGroupedByDrivingSide()
		{
			return countryLogic.CitiesGroupedByDrivingSide();
		}

		[HttpGet]
		public string CountryWithHighestPopulatedCity()
		{
			return countryLogic.CountryWithHighestPopulatedCity();
		}

		[HttpGet]
		public IEnumerable<CountryAveragePopulation> GetAverageCountryPopulation()
		{
			return countryLogic.GetAverageCountryPopulation();
		}

		[HttpGet]
		public IEnumerable<SumAreaByCountry> SumAreaByCountries()
		{
			return countryLogic.SumAreaByCountries();
		}

		[HttpGet]
		public double CountySeatsAveragePopulation()
		{
			return countyLogic.CountySeatsAveragePopulation();
		}

		[HttpGet]
		public IEnumerable<CountyAveragePopulation> GetAverageCountyPopulation()
		{
			return countyLogic.GetAverageCountyPopulation();
		}
	}
}
