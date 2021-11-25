using System;
using System.Collections.Generic;
using System.Linq;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.Repository;

namespace W6H9QV_HFT_2021221.Logic
{
	public interface ICountyLogic
	{
		County GetCountyBy(int id);
		County GetCountyBy(string name);
		IEnumerable<County> GetCounties();

		void AddNewCounty(County county);

		void ChangeCountyName(int id, string newName);
		void ChangeCountyName(string name, string newName);

		void ChangeCountyPopulation(int id, int newPopulation);
		void ChangeCountyPopulation(string name, int newPopulation);

		void ChangeCountySeat(int id, string newSeat);
		void ChangeCountySeat(string name, string newSeat);

		void ChangeCountyDistricts(int id, int newDistricts);
		void ChangeCountyDistricts(string name, int newDistricts);

		void UpdateCounty(County county);

		void DeleteCountyBy(int id);
		void DeleteCountyBy(string name);

		IEnumerable<CountyAveragePopulation> GetAverageCountyPopulation();
		double CountySeatsAveragePopulation();
	}

	public class CountyLogic : ICountyLogic
	{
		ICountyRepository countyRepo;
		ICityRepository cityRepo;

		public CountyLogic(ICountyRepository countyRepo, ICityRepository cityRepo)
		{
			this.countyRepo = countyRepo;
			this.cityRepo = cityRepo;
		}

		public IEnumerable<CountyAveragePopulation> GetAverageCountyPopulation()
		{
			var q = from x in countyRepo.GetAll()
					select new CountyAveragePopulation
					{
						CountryName = x.Country.Name,
						Name = x.Name,
						Avg = x.Cities.Average(x => x.Population)
					};
			return q;
		}

		public double CountySeatsAveragePopulation()
		{
			var pops = new List<int>();
			foreach (var item in countyRepo.GetAll().ToList())
			{
				pops.Add(item.Cities.SingleOrDefault(x => x.Name == item.CountySeat).Population);
			}
			return pops.Average();
		}

		#region CRUD methods
		public void AddNewCounty(County county)
		{
			countyRepo.AddNew(county);
		}

		public void ChangeCountyDistricts(int id, int newDistricts)
		{
			countyRepo.ChangeDistricts(id, newDistricts);
		}

		public void ChangeCountyDistricts(string name, int newDistricts)
		{
			countyRepo.ChangeDistricts(name, newDistricts);
		}

		public void ChangeCountyName(int id, string newName)
		{
			countyRepo.ChangeName(id, newName);
		}

		public void ChangeCountyName(string name, string newName)
		{
			countyRepo.ChangeName(name, newName);
		}

		public void ChangeCountyPopulation(int id, int newPopulation)
		{
			countyRepo.ChangePopulation(id, newPopulation);
		}

		public void ChangeCountyPopulation(string name, int newPopulation)
		{
			countyRepo.ChangePopulation(name, newPopulation);
		}

		public void ChangeCountySeat(int id, string newSeat)
		{
			countyRepo.ChangeCountySeat(id, newSeat);
		}

		public void ChangeCountySeat(string name, string newSeat)
		{
			countyRepo.ChangeCountySeat(name, newSeat);
		}

		public void DeleteCountyBy(int id)
		{
			if (id > countyRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			countyRepo.DeleteBy(id);
		}

		public void DeleteCountyBy(string name)
		{
			countyRepo.DeleteBy(name);
		}

		public IEnumerable<County> GetCounties()
		{
			return countyRepo.GetAll();
		}

		public County GetCountyBy(int id)
		{
			return countyRepo.GetBy(id);
		}

		public County GetCountyBy(string name)
		{
			return countyRepo.GetBy(name);
		}

		public void UpdateCounty(County county)
		{
			countyRepo.Update(county);
		}
		#endregion
	}
}
