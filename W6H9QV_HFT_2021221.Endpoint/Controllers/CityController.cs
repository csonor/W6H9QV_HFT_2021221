using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W6H9QV_HFT_2021221.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		ICityLogic cityLogic;

		public CityController(ICityLogic cityLogic)
		{
			this.cityLogic = cityLogic;
		}

		// GET: api/<CityController>
		[HttpGet]
		public IEnumerable<City> Get()
		{
			return cityLogic.GetCities();
		}

		// GET api/<CityController>/5
		[Route("id/{id}")]
		[HttpGet("{id}")]
		public City Get(int id)
		{
			return cityLogic.GetCityBy(id);
		}

		[Route("nm/{name}")]
		[HttpGet("{name}")]
		public City Get(string name)
		{
			return cityLogic.GetCityBy(name);
		}

		// POST api/<CityController>
		[HttpPost]
		public void Post([FromBody] City value)
		{
			cityLogic.AddNewCity(value);
		}

		#region HttpPuts
		// PUT api/<CityController>/5
		[HttpPut]
		public void Put([FromBody] City value)
		{
			cityLogic.UpdateCity(value);
		}

		//name
		[Route("nameid/{id}/{newName}")]
		[HttpPut("{id} {newName}")]
		public void PutCityName(int id, string newName)
		{
			cityLogic.ChangeCityName(id, newName);
		}

		[Route("namenm/{name}/{newName}")]
		[HttpPut("{name} {newName}")]
		public void PutCityName(string name, string newName)
		{
			cityLogic.ChangeCityName(name, newName);
		}

		//population
		[Route("popid/{id}/{newPopulation}")]
		[HttpPut("{id} {newPopulation}")]
		public void PutCityPopulation(int id, int newPopulation)
		{
			cityLogic.ChangeCityPopulation(id, newPopulation);
		}

		[Route("popnm/{name}/{newPopulation}")]
		[HttpPut("{name} {newPopulation}")]
		public void PutCityPopulation(string name, int newPopulation)
		{
			cityLogic.ChangeCityPopulation(name, newPopulation);
		}

		//area
		[Route("areaid/{id}/{newArea}")]
		[HttpPut("{id} {newArea}")]
		public void PutCityArea(int id, double newArea)
		{
			cityLogic.ChangeCityArea(id, newArea);
		}

		[Route("areanm/{name}/{newArea}")]
		[HttpPut("{name} {newArea}")]
		public void PutCityArea(string name, double newArea)
		{
			cityLogic.ChangeCityArea(name, newArea);
		}
		#endregion

		// DELETE api/<CityController>/5
		[Route("delid/{id}")]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			cityLogic.DeleteCityBy(id);
		}

		[Route("delnm/{name}")]
		[HttpDelete("{name}")]
		public void Delete(string name)
		{
			cityLogic.DeleteCityBy(name);
		}
	}
}
