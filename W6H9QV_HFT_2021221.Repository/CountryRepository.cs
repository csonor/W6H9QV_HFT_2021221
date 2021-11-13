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

		public void AddNewCountry(Country country)
		{
			ctx.Add(country);
			ctx.SaveChanges();
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

		public void ChangeName(int id, string newName)
		{
			var country = GetBy(id);
			country.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangeName(string name, string newName)
		{
			var country = GetBy(name);
			country.Name = newName;
			ctx.SaveChanges();
		}

		public void ChangePopulation(int id, int newPopulation)
		{
			var country = GetBy(id);
			country.Population = newPopulation;
			ctx.SaveChanges();
		}

		public void ChangePopulation(string name, int newPopulation)
		{
			var country = GetBy(name);
			country.Population = newPopulation;
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

		public override Country GetBy(int id)
		{
			return GetAll().SingleOrDefault(x => x.ID == id);
		}

		public override Country GetBy(string name)
		{
			return GetAll().SingleOrDefault(x => x.Name == name);
		}

		public void UpdateCountry(Country country)
		{
			var toUpdate = GetBy(country.ID);
			toUpdate.Name = country.Name;
			toUpdate.Population = country.Population;
			toUpdate.CountryCode = country.CountryCode;
			toUpdate.Currency = country.Currency;
			toUpdate.DrivingSide = country.DrivingSide;
			toUpdate.EnglishName = country.EnglishName;
			ctx.SaveChanges();
		}
	}
}
