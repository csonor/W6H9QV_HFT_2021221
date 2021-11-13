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

		public override void ChangeName(int id, string newName)
		{
			var county = GetBy(id);
			county.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangeName(string name, string newName)
		{
			var county = GetBy(name);
			county.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(int id, int newPopulation)
		{
			var county = GetBy(id);
			county.Population = newPopulation;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(string name, int newPopulation)
		{
			var county = GetBy(name);
			county.Population = newPopulation;
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

		public override void Update(County type)
		{
			var toUpdate = GetBy(type.ID);
			toUpdate.Name = type.Name;
			toUpdate.Population = type.Population;
			toUpdate.CountySeat = type.CountySeat;
			toUpdate.Districts = type.Districts;
			toUpdate.CountryID = type.CountryID;
			ctx.SaveChanges();
		}
	}
}
