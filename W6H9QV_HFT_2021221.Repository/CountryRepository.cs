using Microsoft.EntityFrameworkCore;
using System.Linq;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Repository
{
	public class CountryRepository : Repository<Country>, ICountryRepository
	{
		public CountryRepository(DbContext ctx) : base(ctx)
		{
		}

		public void ChangeCode(int id, string newCode)
		{
			var country = GetBy(id);
			country.CountryCode = newCode;
			ctx.SaveChanges();
		}

		public void ChangeCode(string name, string newCode)
		{
			var country = GetBy(name);
			country.CountryCode = newCode;
			ctx.SaveChanges();
		}

		public void ChangeCurrency(int id, string newCurrency)
		{
			var country = GetBy(id);
			country.Currency = newCurrency;
			ctx.SaveChanges();
		}

		public void ChangeCurrency(string name, string newCurrency)
		{
			var country = GetBy(name);
			country.Currency = newCurrency;
			ctx.SaveChanges();
		}

		public void ChangeEnglishName(int id, string newName)
		{
			var country = GetBy(id);
			country.EnglishName = newName;
			ctx.SaveChanges();
		}

		public void ChangeEnglishName(string name, string newName)
		{
			var country = GetBy(name);
			country.EnglishName = newName;
			ctx.SaveChanges();
		}

		public override void ChangeName(int id, string newName)
		{
			var country = GetBy(id);
			country.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangeName(string name, string newName)
		{
			var country = GetBy(name);
			country.Name = newName;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(int id, int newPopulation)
		{
			var country = GetBy(id);
			country.Population = newPopulation;
			ctx.SaveChanges();
		}

		public override void ChangePopulation(string name, int newPopulation)
		{
			var country = GetBy(name);
			country.Population = newPopulation;
			ctx.SaveChanges();
		}

		public override Country GetBy(int id)
		{
			return GetAll().SingleOrDefault(x => x.ID == id);
		}

		public override Country GetBy(string name)
		{
			return GetAll().SingleOrDefault(x => x.Name == name);
		}

		public override void Update(Country type)
		{
			var toUpdate = GetBy(type.ID);
			toUpdate.Name = type.Name;
			toUpdate.Population = type.Population;
			toUpdate.CountryCode = type.CountryCode;
			toUpdate.Currency = type.Currency;
			toUpdate.DrivingSide = type.DrivingSide;
			toUpdate.EnglishName = type.EnglishName;
			ctx.SaveChanges();
		}
	}
}
