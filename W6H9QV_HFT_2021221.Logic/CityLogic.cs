using System;
using System.Collections.Generic;
using System.Linq;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.Repository;

namespace W6H9QV_HFT_2021221.Logic
{
	public interface ICityLogic
	{
		City GetCityBy(int id);
		City GetCityBy(string name);
		IList<City> GetCities();

		void AddNewCity(City city);

		void ChangeCityName(int id, string newName);
		void ChangeCityName(string name, string newName);

		void ChangeCityPopulation(int id, int newPopulation);
		void ChangeCityPopulation(string name, int newPopulation);

		void ChangeCityArea(int id, int newArea);
		void ChangeCityArea(string name, int newArea);

		void UpdateCity(City city);

		void DeleteCityBy(int id);
		void DeleteCityBy(string name);

		//TODO non-curds
	}

	public class CityLogic : ICityLogic
	{
		ICityRepository cityRepo;

		public CityLogic(ICityRepository cityRepo)
		{
			this.cityRepo = cityRepo;
		}

		#region CRUD methods
		public void AddNewCity(City city)
		{
			if (city == null)
				throw new ArgumentNullException("The given object was null.");

			cityRepo.AddNew(city);
		}

		public void ChangeCityArea(int id, int newArea)
		{
			if (id > cityRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newArea < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			cityRepo.ChangeArea(id, newArea);
		}

		public void ChangeCityArea(string name, int newArea)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (cityRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newArea < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			cityRepo.ChangeArea(name, newArea);
		}

		public void ChangeCityName(int id, string newName)
		{
			if (id > cityRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			cityRepo.ChangeName(id, newName);
		}

		public void ChangeCityName(string name, string newName)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (cityRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newName == null || newName == "")
				throw new ArgumentNullException("The given name was null or empty.");

			cityRepo.ChangeName(name, newName);
		}

		public void ChangeCityPopulation(int id, int newPopulation)
		{
			if (id > cityRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			if (newPopulation < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			cityRepo.ChangePopulation(id, newPopulation);
		}

		public void ChangeCityPopulation(string name, int newPopulation)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (cityRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			if (newPopulation < 0)
				throw new ArgumentOutOfRangeException("The given number value cannot be lower than zero.");

			cityRepo.ChangePopulation(name, newPopulation);
		}

		public void DeleteCityBy(int id)
		{
			if (id > cityRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			cityRepo.DeleteBy(id);
		}

		public void DeleteCityBy(string name)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (cityRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			cityRepo.DeleteBy(name);
		}

		public IList<City> GetCities()
		{
			return cityRepo.GetAll().ToList();
		}

		public City GetCityBy(int id)
		{
			if (id > cityRepo.GetAll().Count() || id < 1)
				throw new IndexOutOfRangeException("The given ID was outside of the database.");

			return cityRepo.GetBy(id);
		}

		public City GetCityBy(string name)
		{
			if (name == null)
				throw new ArgumentNullException("The given name was null.");

			if (cityRepo.GetBy(name) == null)
				throw new Exception("The given name was not found in the database.");

			return cityRepo.GetBy(name);
		}

		public void UpdateCity(City city)
		{
			if (city == null)
				throw new ArgumentNullException("The given object was null.");

			cityRepo.Update(city);
		}
		#endregion
	}
}
