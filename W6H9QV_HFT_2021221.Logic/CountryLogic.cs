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
		IList<Country> GetCountries();

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

		//non-cruds
		string CountryWithHighestPopulatedCity();
		IList<CountryAveragePopulation> GetAverageCountryPopulation();
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

		public IList<CountryAveragePopulation> GetAverageCountryPopulation()
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
			for (int i = 0; i < q.Count(); i++)
			{
				if (averages.Count == 0)
					averages.Add(q[i]);
				else
				{
					int count = averages.Count;
					for (int j = 0; j < count; j++)
					{
						if (q[i].Name == averages[j].Name)
							averages[j].CountyAveragePopulation
								.Add(q[i].CountyAveragePopulation.SingleOrDefault());
						else averages.Add(q[i]);
					}
				}
			}
			return averages;
		}

		#region CRUD methods
		public void AddNewCountry(Country country)
		{
			if (country == null)
				throw new ArgumentNullException("The given object was null.");

			countryRepo.AddNew(country);
		}

		public void ChangeCountryCode(int id, string newCode)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newCode == null || newCode == "")
				throw new ArgumentNullException("The given code was null or empty.");

			countryRepo.ChangeCode(id, newCode);
		}

		public void ChangeCountryCode(string name, string newCode)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newCode == null || newCode == "")
				throw new ArgumentNullException("The given code was null or empty.");

			countryRepo.ChangeCode(name, newCode);
		}

		public void ChangeCountryCurrency(int id, string newCurrency)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newCurrency == null || newCurrency == "")
				throw new ArgumentNullException("The given currency was null or empty.");

			countryRepo.ChangeCurrency(id, newCurrency);
		}

		public void ChangeCountryCurrency(string name, string newCurrency)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newCurrency == null || newCurrency == "")
				throw new ArgumentNullException("The given currency was null or empty.");

			countryRepo.ChangeCurrency(name, newCurrency);
		}

		public void ChangeCountryEnglishName(int id, string newName)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			countryRepo.ChangeEnglishName(id, newName);
		}

		public void ChangeCountryEnglishName(string name, string newName)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			countryRepo.ChangeEnglishName(name, newName);
		}

		public void ChangeCountryName(int id, string newName)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			countryRepo.ChangeName(id, newName);
		}

		public void ChangeCountryName(string name, string newName)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			countryRepo.ChangeName(name, newName);
		}

		public void ChangeCountryPopulation(int id, int newPopulation)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newPopulation < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			countryRepo.ChangePopulation(id, newPopulation);
		}

		public void ChangeCountryPopulation(string name, int newPopulation)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newPopulation < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			countryRepo.ChangePopulation(name, newPopulation);
		}

		public void DeleteCountryBy(int id)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			countryRepo.DeleteBy(id);
		}

		public void DeleteCountryBy(string name)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			countryRepo.DeleteBy(name);
		}

		public IList<Country> GetCountries()
		{
			return countryRepo.GetAll().ToList();
		}

		public Country GetCountryBy(int id)
		{
			if (id > countryRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			return countryRepo.GetBy(id);
		}

		public Country GetCountryBy(string name)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (countryRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			return countryRepo.GetBy(name);
		}

		public void UpdateCountry(Country country)
		{
			if (country == null)
				throw new ArgumentNullException("The given object was null.");

			countryRepo.Update(country);
		}
		#endregion
	}
}
