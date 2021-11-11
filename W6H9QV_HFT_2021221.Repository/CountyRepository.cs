using Microsoft.EntityFrameworkCore;
using System.Linq;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Repository
{
	public class CountyRepository : Repository<County>, ICountyRepository
	{
		public CountyRepository(DbContext ctx) : base(ctx)
		{
		}

		public void AddNewCounty(County county)
		{
			ctx.Add(county);
			ctx.SaveChanges();
		}

		public void ChangeCountySeat(int id, string newSeat)
		{
			var county = GetBy(id);
			county.CountySeat = newSeat;
			ctx.SaveChanges();
		}

		public void ChangeCountySeat(string name, string newSeat)
		{
			var county = GetBy(name);
			county.CountySeat = newSeat;
			ctx.SaveChanges();
		}

		public void ChangeDistricts(int id, int newDistricts)
		{
			var county = GetBy(id);
			county.Districts = newDistricts;
			ctx.SaveChanges();
		}

		public void ChangeDistricts(string name, int newDistricts)
		{
			var county = GetBy(name);
			county.Districts = newDistricts;
			ctx.SaveChanges();
		}

		public void ChangeName(int id, string newName)
		{
			var county = GetBy(id);
			county.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangeName(string name, string newName)
		{
			var county = GetBy(name);
			county.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangePopulation(int id, int newPopulation)
		{
			var county = GetBy(id);
			county.Population = newPopulation;
			ctx.SaveChanges();
		}

		public void ChangePopulation(string name, int newPopulation)
		{
			var county = GetBy(name);
			county.Population = newPopulation;
			ctx.SaveChanges();
		}

		public void DeleteCountyBy(int id)
		{
			var toDel = GetBy(id);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public void DeleteCountyBy(string name)
		{
			var toDel = GetBy(name);
			ctx.Remove(toDel);
			ctx.SaveChanges();
		}

		public override County GetBy(int id)
		{
			return GetAll().SingleOrDefault(x => x.ID == id);
		}

		public override County GetBy(string name)
		{
			return GetAll().SingleOrDefault(x => x.Name == name);
		}

		public void UpdateCounty(County county)
		{
			var toUpdate = GetBy(county.ID);
			toUpdate.Name = county.Name;
			toUpdate.Population = county.Population;
			toUpdate.CountySeat = county.CountySeat;
			toUpdate.Districts = county.Districts;
			toUpdate.CountryID = county.CountryID;
			ctx.SaveChanges();
		}
	}
}
