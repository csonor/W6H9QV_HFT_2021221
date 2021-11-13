using Microsoft.EntityFrameworkCore;
using System.Linq;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Repository
{
	public class CityRepository : Repository<City>, ICityRepository
	{
		public CityRepository(DbContext ctx) : base(ctx)
		{
		}

		public void AddNewCity(City city)
		{
			ctx.Add(city);
			ctx.SaveChanges();
		}

		public void ChangeArea(int id, int newArea)
		{
			var city = GetBy(id);
			city.Area = newArea;
			ctx.SaveChanges();
		}

		public void ChangeArea(string name, int newArea)
		{
			var city = GetBy(name);
			city.Area = newArea;
			ctx.SaveChanges();
		}

		public void ChangeName(int id, string newName)
		{
			var city = GetBy(id);
			city.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangeName(string name, string newName)
		{
			var city = GetBy(name);
			city.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangePopulation(int id, int newPopulation)
		{
			var city = GetBy(id);
			city.Population = newPopulation;
			ctx.SaveChanges();
		}

		public void ChangePopulation(string name, int newPopulation)
		{
			var city = GetBy(name);
			city.Population = newPopulation;
			ctx.SaveChanges();
		}

		public void DeleteBy(int id)
		{
			var toDel = GetBy(id);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public void DeleteBy(string name)
		{
			var toDel = GetBy(name);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public override City GetBy(int id)
		{
			return GetAll().SingleOrDefault(x => x.ID == id);
		}

		public override City GetBy(string name)
		{
			return GetAll().SingleOrDefault(x => x.Name == name);
		}

		public void UpdateCity(City city)
		{
			var toUpdate = GetBy(city.ID);
			toUpdate.Name = city.Name;
			toUpdate.Population = city.Population;
			toUpdate.Elevation = city.Elevation;
			toUpdate.Area = city.Area;
			toUpdate.CountyID = city.CountyID;
			ctx.SaveChanges();
		}
	}
}
