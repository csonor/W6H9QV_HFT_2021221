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

		public void ChangeArea(int id, double newArea)
		{
			var city = GetBy(id);
			city.Area = newArea;
			ctx.SaveChanges();
		}

		public void ChangeArea(string name, double newArea)
		{
			var city = GetBy(name);
			city.Area = newArea;
			ctx.SaveChanges();
		}

		public override void ChangeName(int id, string newName)
		{
			var city = GetBy(id);
			city.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangeName(string name, string newName)
		{
			var city = GetBy(name);
			city.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(int id, int newPopulation)
		{
			var city = GetBy(id);
			city.Population = newPopulation;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(string name, int newPopulation)
		{
			var city = GetBy(name);
			city.Population = newPopulation;
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

		public override void Update(City type)
		{
			var toUpdate = GetBy(type.ID);
			toUpdate.Name = type.Name;
			toUpdate.Population = type.Population;
			toUpdate.Elevation = type.Elevation;
			toUpdate.Area = type.Area;
			toUpdate.CountyID = type.CountyID;
			ctx.SaveChanges();
		}
	}
}
