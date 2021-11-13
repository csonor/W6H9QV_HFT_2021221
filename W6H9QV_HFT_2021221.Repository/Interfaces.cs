using System.Linq;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Repository
{
	public interface IRepository<T> where T : class
	{
		T GetBy(int id);
		T GetBy(string name);
		IQueryable<T> GetAll();

		void ChangeName(int id, string newName);
		void ChangeName(string name, string newName);

		void ChangePopulation(int id, int newPopulation);
		void ChangePopulation(string name, int newPopulation);

		void DeleteBy(int id);
		void DeleteBy(string name);
	}

	public interface ICountryRepository : IRepository<Country>
	{
		void AddNewCountry(Country country);

		void ChangeEnglishName(int id, string newName);
		void ChangeEnglishName(string name, string newName);

		void ChangeCode(int id, string newCode);
		void ChangeCode(string name, string newCode);

		void ChangeCurrency(int id, string newCurrency);
		void ChangeCurrency(string name, string newCurrency);

		void UpdateCountry(Country country);
	}

	public interface ICountyRepository : IRepository<County>
	{
		void AddNewCounty(County county);

		void ChangeCountySeat(int id, string newSeat);
		void ChangeCountySeat(string name, string newSeat);

		void ChangeDistricts(int id, int newDistricts);
		void ChangeDistricts(string name, int newDistricts);

		void UpdateCounty(County county);
	}

	public interface ICityRepository : IRepository<City>
	{
		void AddNewCity(City city);

		void ChangeArea(int id, int newArea);
		void ChangeArea(string name, int newArea);

		void UpdateCity(City city);
	}
}
