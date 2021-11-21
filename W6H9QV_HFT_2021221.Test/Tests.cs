using Moq;
using System;
using NUnit.Framework;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Models;
using W6H9QV_HFT_2021221.Repository;
using System.Linq;

namespace W6H9QV_HFT_2021221.Test
{
	[TestFixture]
	public partial class Tests
	{
		ICountryLogic CountryLogic { get; set; }
		ICountyLogic CountyLogic { get; set; }
		ICityLogic CityLogic { get; set; }

		[SetUp]
		public void Setup()
		{
			Mock<ICityRepository> mockedCityRepo = new Mock<ICityRepository>();
			CityLogic = new CityLogic(mockedCityRepo.Object);
			mockedCityRepo.Setup(x => x.GetAll()).Returns(FakeCities);

			Mock<ICountyRepository> mockedCountyRepo = new Mock<ICountyRepository>();
			CountyLogic = new CountyLogic(mockedCountyRepo.Object, mockedCityRepo.Object);
			mockedCountyRepo.Setup(x => x.GetAll()).Returns(FakeCounties);

			Mock<ICountryRepository> mockedCountryRepo = new Mock<ICountryRepository>();
			CountryLogic = new CountryLogic(mockedCountryRepo.Object, mockedCountyRepo.Object, mockedCityRepo.Object);
			mockedCountryRepo.Setup(x => x.GetAll()).Returns(FakeCountries);
			mockedCountryRepo.Setup(x => x.GetBy(It.IsAny<int>())).Returns(
				new Country()
				{
					ID = 3,
					Name = "ASD",
					EnglishName = "ASD",
					Population = 111111,
					CountryCode = "A",
					DrivingSide = DrivingSide.left
				});
		}

		[Test]
		public void CountryWithHighestPopulatedCity_ReturnsCorrectValue()
		{
			Assert.That(CountryLogic.CountryWithHighestPopulatedCity(), Is.EqualTo("Österreich"));
		}

		[Test]
		public void GetAverageCountyPopulation_ReturnsCorrectValues()
		{
			Assert.That(CountyLogic.GetAverageCountyPopulation().Count(), Is.EqualTo(CountyLogic.GetCounties().Count()));
		}

		[Test]
		public void GetAverageCountryPopulation_ReturnsCorrectValues()
		{
			Assert.That(CountryLogic.GetAverageCountryPopulation().Count, Is.EqualTo(CountryLogic.GetCountries().Count()));
		}

		[Test]
		public void CountySeatsAveragePopulation_ReturnsCorrectValue()
		{
			Assert.That(CountyLogic.CountySeatsAveragePopulation(), Is.EqualTo(159373.5));
		}

		#region create and get tests
		[TestCase(-1)]
		[TestCase(2000000)]
		public void GetById_ThrowsException_IfIdIsOutside(int id)
		{
			Assert.Throws(typeof(IndexOutOfRangeException), () => CountryLogic.GetCountryBy(id));
		}

		[Test]
		public void GetById_ReturnsCorrectInstance()
		{
			Assert.That(CountryLogic.GetCountryBy(1).EnglishName, Is.EqualTo("ASD"));
		}

		[Test]
		public void GetAll_ReturnsCorrectNumber()
		{
			Assert.That(CountryLogic.GetCountries().Count, Is.EqualTo(2));
		}

		[TestCase("")]
		[TestCase("nothing")]
		public void GetByName_ThrowsException_IfNameIsNotFound(string name)
		{
			Assert.Throws(typeof(Exception), () => CountryLogic.GetCountryBy(name));
		}

		[TestCase(null)]
		public void GetByName_ThrowsException_IfNameIsNull(string name)
		{
			Assert.Throws(typeof(ArgumentNullException), () => CountryLogic.GetCountryBy(name));
		}

		[TestCase(null)]
		public void CreateCountry_ThrowsException_IfNull(Country country)
		{
			Assert.Throws(typeof(ArgumentNullException), () => CountryLogic.AddNewCountry(country));
		}

		[TestCase(null)]
		public void CreateCity_ThrowsException_IfNull(City city)
		{
			Assert.Throws(typeof(ArgumentNullException), () => CityLogic.AddNewCity(city));
		}

		[TestCase(null)]
		public void CreateCounty_ThrowsException_IfNull(County county)
		{
			Assert.Throws(typeof(ArgumentNullException), () => CountyLogic.AddNewCounty(county));
		}
		#endregion
	}
}
