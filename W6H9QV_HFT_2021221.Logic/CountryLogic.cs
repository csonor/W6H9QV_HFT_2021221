using System;
using System.Collections.Generic;
using System.Linq;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.Repository;

namespace W6H9QV_HFT_2021221.Logic
{
	public interface ICountryLogic
	{
		Country GetCountryBy(int id);
		Country GetCountryBy(string name);
		IEnumerable<Country> GetCountries();

		void AddNewCountry(Country country);

		void ChangeCountryName(int id, string newName);
		void ChangeCountryName(string name, string newName);

		void ChangeCountryEnglishName(int id, string newName);
		void ChangeCountryEnglishName(string name, string newName);

		void ChangeCountryCode(int id, string newCode);
		void ChangeCountryCode(string name, string newCode);

		void ChangeCountryPopulation(int id, int newPopulation);
		void ChangeCountryPopulation(string name, int newPopulation);

		void ChangeCountryCurrency(int id, string newCurrency);
		void ChangeCountryCurrency(string name, string newCurrency);

		void UpdateCountry(Country country);

		void DeleteCountryBy(int id);
		void DeleteCountryBy(string name);

		string CountryWithHighestPopulatedCity();
		IEnumerable<CountryAveragePopulation> GetAverageCountryPopulation();
		IEnumerable<SumAreaByCountry> SumAreaByCountries();
		IEnumerable<CitiesGroupedByDrivingSide> CitiesGroupedByDrivingSide();
	}

	public class CountryLogic : ICountryLogic
	{
		ICountryRepository countryRepo;
		ICountyRepository countyRepo;
		ICityRepository cityRepo;

		public CountryLogic(ICountryRepository countryRepository, ICountyRepository countyRepository, ICityRepository cityRepository)
		{
			countryRepo = countryRepository;
			countyRepo = countyRepository;
			cityRepo = cityRepository;
		}

		public string CountryWithHighestPopulatedCity()
		{
			var q = (from x in countryRepo.GetAll()
					 join y in countyRepo.GetAll() on x.ID equals y.CountryID
					 join z in cityRepo.GetAll() on y.ID equals z.CountyID
					 select new
					 {
						 NAME = x.Name,
						 MAX = z.Population
					 }).OrderByDescending(x => x.MAX).FirstOrDefault().NAME;
			return q;
		}

		public IEnumerable<CountryAveragePopulation> GetAverageCountryPopulation()
		{
			var q_sub = (from x in countyRepo.GetAll()
						 select new CountyAveragePopulation
						 {
							 CountryName = x.Country.Name,
							 Name = x.Name,
							 Avg = x.Cities.Average(x => x.Population)
						 }).AsQueryable();

			var q = (from x in countryRepo.GetAll()
					 join y in q_sub on x.Name equals y.CountryName
					 select new CountryAveragePopulation
					 {
						 Name = x.Name,
						 CountyAveragePopulation = new List<CountyAveragePopulation> { y }
					 }).ToList();

			var averages = new List<CountryAveragePopulation>();
			foreach (var item in q)
			{
				if (averages.Count == 0)
					averages.Add(item);
				else
				{
					bool found = false;
					foreach (var average in averages)
						if (item.Name == average.Name)
						{
							average.CountyAveragePopulation
								.Add(item.CountyAveragePopulation.SingleOrDefault());
							found = true;
						}
					if (!found) averages.Add(item);
				}
			}
			return averages;
		}

		public IEnumerable<SumAreaByCountry> SumAreaByCountries()
		{
			var q = from x in countryRepo.GetAll()
					join y in countyRepo.GetAll() on x.ID equals y.CountryID
					join z in cityRepo.GetAll() on y.ID equals z.CountyID
					group new { x, y, z } by x.Name into g
					select new SumAreaByCountry
					{
						Name = g.Key,
						Sum = g.Sum(x => x.z.Area)
					};
			return q;
		}

		public IEnumerable<CitiesGroupedByDrivingSide> CitiesGroupedByDrivingSide()
		{
			var q = from x in countryRepo.GetAll()
					join y in countyRepo.GetAll() on x.ID equals y.CountryID
					join z in cityRepo.GetAll() on y.ID equals z.CountyID
					select new CitiesGroupedByDrivingSide
					{
						DrivingSide = x.DrivingSide,
						Cities = y.Cities.ToList()
					};

			var sides = new List<CitiesGroupedByDrivingSide>();
			foreach (var item in q)
			{
				if (sides.Count == 0)
					sides.Add(item);
				else
				{
					bool found = false;
					foreach (var side in sides)
						if (item.DrivingSide == side.DrivingSide)
						{
							if (!side.Cities.Contains(item.Cities.First()))
								foreach (var city in item.Cities)
									side.Cities.Add(city);
							found = true;
						}
					if (!found) sides.Add(item);
				}
			}
			return sides;
		}

		#region CRUD methods
		public void AddNewCountry(Country country)
		{
			if (country == null)
				throw new ArgumentNullException();
			countryRepo.AddNew(country);
		}

		public void ChangeCountryCode(int id, string newCode)
		{
			countryRepo.ChangeCode(id, newCode);
		}

		public void ChangeCountryCode(string name, string newCode)
		{
			countryRepo.ChangeCode(name, newCode);
		}

		public void ChangeCountryCurrency(int id, string newCurrency)
		{
			countryRepo.ChangeCurrency(id, newCurrency);
		}

		public void ChangeCountryCurrency(string name, string newCurrency)
		{
			countryRepo.ChangeCurrency(name, newCurrency);
		}

		public void ChangeCountryEnglishName(int id, string newName)
		{
			countryRepo.ChangeEnglishName(id, newName);
		}

		public void ChangeCountryEnglishName(string name, string newName)
		{
			countryRepo.ChangeEnglishName(name, newName);
		}

		public void ChangeCountryName(int id, string newName)
		{
			countryRepo.ChangeName(id, newName);
		}

		public void ChangeCountryName(string name, string newName)
		{
			countryRepo.ChangeName(name, newName);
		}

		public void ChangeCountryPopulation(int id, int newPopulation)
		{
			countryRepo.ChangePopulation(id, newPopulation);
		}

		public void ChangeCountryPopulation(string name, int newPopulation)
		{
			countryRepo.ChangePopulation(name, newPopulation);
		}

		public void DeleteCountryBy(int id)
		{
			countryRepo.DeleteBy(id);
		}

		public void DeleteCountryBy(string name)
		{
			countryRepo.DeleteBy(name);
		}

		public IEnumerable<Country> GetCountries()
		{
			return countryRepo.GetAll();
		}

		public Country GetCountryBy(int id)
		{
			if (id < 0)
				throw new IndexOutOfRangeException();
			return countryRepo.GetBy(id);
		}

		public Country GetCountryBy(string name)
		{
			if (name == null) throw new ArgumentNullException();
			var country = countryRepo.GetBy(name);
			if (country == null)
				throw new Exception();
			return country;
		}

		public void UpdateCountry(Country country)
		{
			countryRepo.Update(country);
		}
		#endregion
	}
}
