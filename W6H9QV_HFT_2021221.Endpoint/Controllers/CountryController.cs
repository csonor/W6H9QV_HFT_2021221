using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W6H9QV_HFT_2021221.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		ICountryLogic countryLogic;

		public CountryController(ICountryLogic countryLogic)
		{
			this.countryLogic = countryLogic;
		}

		// GET: api/<CountryController>
		[HttpGet]
		public IEnumerable<Country> Get()
		{
			return countryLogic.GetCountries();
		}

		// GET api/<CountryController>/5
		[Route("id/{id}")]
		[HttpGet("{id}")]
		public Country Get(int id)
		{
			return countryLogic.GetCountryBy(id);
		}

		[Route("nm/{name}")]
		[HttpGet("{name}")]
		public Country Get(string name)
		{
			return countryLogic.GetCountryBy(name);
		}

		// POST api/<CountryController>
		[HttpPost]
		public void Post([FromBody] Country value)
		{
			countryLogic.AddNewCountry(value);
		}

		#region HttpPuts
		// PUT api/<CountryController>/5
		[HttpPut]
		public void Put([FromBody] Country value)
		{
			countryLogic.UpdateCountry(value);
		}

		//countrycode
		[Route("codeid/{id}/{newCode}")]
		[HttpPut("{id} {newCode}")]
		public void PutCountryCode(int id, string newCode)
		{
			countryLogic.ChangeCountryCode(id, newCode);
		}

		[Route("codenm/{name}/{newCode}")]
		[HttpPut("{name} {newCode}")]
		public void PutCountryCode(string name, string newCode)
		{
			countryLogic.ChangeCountryCode(name, newCode);
		}

		//currency
		[Route("currid/{id}/{newCurrency}")]
		[HttpPut("{id} {newCurrency}")]
		public void PutCountryCurrency(int id, string newCurrency)
		{
			countryLogic.ChangeCountryCurrency(id, newCurrency);
		}

		[Route("currnm/{name}/{newCurrency}")]
		[HttpPut("{name} {newCurrency}")]
		public void PutCountryCurrency(string name, string newCurrency)
		{
			countryLogic.ChangeCountryCurrency(name, newCurrency);
		}

		//english name
		[Route("engid/{id}/{newName}")]
		[HttpPut("{id} {newName}")]
		public void PutCountryEnglishName(int id, string newName)
		{
			countryLogic.ChangeCountryEnglishName(id, newName);
		}

		[Route("engnm/{name}/{newName}")]
		[HttpPut("{name} {newName}")]
		public void PutCountryEnglishName(string name, string newName)
		{
			countryLogic.ChangeCountryEnglishName(name, newName);
		}

		//name
		[Route("nameid/{id}/{newName}")]
		[HttpPut("{id} {newName}")]
		public void PutCountryName(int id, string newName)
		{
			countryLogic.ChangeCountryName(id, newName);
		}

		[Route("namenm/{name}/{newName}")]
		[HttpPut("{name} {newName}")]
		public void PutCountryName(string name, string newName)
		{
			countryLogic.ChangeCountryName(name, newName);
		}

		//population
		[Route("popid/{id}/{newPopulation}")]
		[HttpPut("{id} {newPopulation}")]
		public void PutCountryPopulation(int id, int newPopulation)
		{
			countryLogic.ChangeCountryPopulation(id, newPopulation);
		}

		[Route("popnm/{name}/{newPopulation}")]
		[HttpPut("{name} {newPopulation}")]
		public void PutCountryPopulation(string name, int newPopulation)
		{
			countryLogic.ChangeCountryPopulation(name, newPopulation);
		}
		#endregion

		// DELETE api/<CountryController>/5
		[Route("delid/{id}")]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			countryLogic.DeleteCountryBy(id);
		}

		[Route("delnm/{name}")]
		[HttpDelete("{name}")]
		public void Delete(string name)
		{
			countryLogic.DeleteCountryBy(name);
		}
	}
}
