using System;
using System.Collections.Generic;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.Repository;

namespace W6H9QV_HFT_2021221.Logic
{
	public interface ICityLogic
	{
		City GetCityBy(int id);
		City GetCityBy(string name);
		IEnumerable<City> GetCities();

		void AddNewCity(City city);

		void ChangeCityName(int id, string newName);
		void ChangeCityName(string name, string newName);

		void ChangeCityPopulation(int id, int newPopulation);
		void ChangeCityPopulation(string name, int newPopulation);

		void ChangeCityArea(int id, double newArea);
		void ChangeCityArea(string name, double newArea);

		void UpdateCity(City city);

		void DeleteCityBy(int id);
		void DeleteCityBy(string name);
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
				throw new ArgumentNullException();
			cityRepo.AddNew(city);
		}

		public void ChangeCityArea(int id, double newArea)
		{
			cityRepo.ChangeArea(id, newArea);
		}

		public void ChangeCityArea(string name, double newArea)
		{
			cityRepo.ChangeArea(name, newArea);
		}

		public void ChangeCityName(int id, string newName)
		{
			cityRepo.ChangeName(id, newName);
		}

		public void ChangeCityName(string name, string newName)
		{
			cityRepo.ChangeName(name, newName);
		}

		public void ChangeCityPopulation(int id, int newPopulation)
		{
			cityRepo.ChangePopulation(id, newPopulation);
		}

		public void ChangeCityPopulation(string name, int newPopulation)
		{
			cityRepo.ChangePopulation(name, newPopulation);
		}

		public void DeleteCityBy(int id)
		{
			cityRepo.DeleteBy(id);
		}

		public void DeleteCityBy(string name)
		{
			cityRepo.DeleteBy(name);
		}

		public IEnumerable<City> GetCities()
		{
			return cityRepo.GetAll();
		}

		public City GetCityBy(int id)
		{
			return cityRepo.GetBy(id);
		}

		public City GetCityBy(string name)
		{
			return cityRepo.GetBy(name);
		}

		public void UpdateCity(City city)
		{
			cityRepo.Update(city);
		}
		#endregion
	}
}
