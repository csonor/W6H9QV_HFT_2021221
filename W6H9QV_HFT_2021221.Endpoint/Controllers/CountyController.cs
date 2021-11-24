using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W6H9QV_HFT_2021221.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CountyController : ControllerBase
	{
		ICountyLogic countyLogic;

		public CountyController(ICountyLogic countyLogic)
		{
			this.countyLogic = countyLogic;
		}

		// GET: api/<CountyController>
		[HttpGet]
		public IEnumerable<County> Get()
		{
			return countyLogic.GetCounties();
		}

		// GET api/<CountyController>/5
		[Route("id/{id}")]
		[HttpGet("{id}")]
		public County Get(int id)
		{
			return countyLogic.GetCountyBy(id);
		}

		[Route("nm/{name}")]
		[HttpGet("{name}")]
		public County Get(string name)
		{
			return countyLogic.GetCountyBy(name);
		}

		// POST api/<CountyController>
		[HttpPost]
		public void Post([FromBody] County value)
		{
			countyLogic.AddNewCounty(value);
		}

		#region HttpPuts
		// PUT api/<CountyController>/5
		[HttpPut]
		public void Put([FromBody] County value)
		{
			countyLogic.UpdateCounty(value);
		}

		//district
		[Route("distid/{id}/{newDistricts}")]
		[HttpPut("{id} {newDistricts}")]
		public void PutCountyDistricts(int id, int newDistricts)
		{
			countyLogic.ChangeCountyDistricts(id, newDistricts);
		}

		[Route("distnm/{name}/{newDistricts}")]
		[HttpPut("{name} {newDistricts}")]
		public void PutCountyDistricts(string name, int newDistricts)
		{
			countyLogic.ChangeCountyDistricts(name, newDistricts);
		}

		//name
		[Route("nameid/{id}/{newName}")]
		[HttpPut("{id} {newName}")]
		public void PutCountyName(int id, string newName)
		{
			countyLogic.ChangeCountyName(id, newName);
		}

		[Route("namenm/{name}/{newName}")]
		[HttpPut("{name} {newName}")]
		public void PutCountyName(string name, string newName)
		{
			countyLogic.ChangeCountyName(name, newName);
		}

		//population
		[Route("popid/{id}/{newPopulation}")]
		[HttpPut("{id} {newPopulation}")]
		public void PutCountyPopulation(int id, int newPopulation)
		{
			countyLogic.ChangeCountyPopulation(id, newPopulation);
		}

		[Route("popnm/{name}/{newPopulation}")]
		[HttpPut("{name} {newPopulation}")]
		public void PutCountyPopulation(string name, int newPopulation)
		{
			countyLogic.ChangeCountyPopulation(name, newPopulation);
		}

		//countySeat
		[Route("seatid/{id}/{newSeat}")]
		[HttpPut("{id} {newSeat}")]
		public void PutCountySeat(int id, string newSeat)
		{
			countyLogic.ChangeCountySeat(id, newSeat);
		}

		[Route("seatnm/{name}/{newSeat}")]
		[HttpPut("{name} {newSeat}")]
		public void PutCountySeat(string name, string newSeat)
		{
			countyLogic.ChangeCountySeat(name, newSeat);
		}
		#endregion

		// DELETE api/<CountyController>/5
		[Route("delid/{id}")]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			countyLogic.DeleteCountyBy(id);
		}

		[Route("delnm/{name}")]
		[HttpDelete("{name}")]
		public void Delete(string name)
		{
			countyLogic.DeleteCountyBy(name);
		}
	}
}
