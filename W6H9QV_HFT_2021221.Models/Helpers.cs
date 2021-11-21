using System;
using System.Collections.Generic;
using System.Linq;

namespace W6H9QV_HFT_2021221.Models
{
	[AttributeUsage(AttributeTargets.Property)]
	class ToStringAttribute : Attribute
	{
	}

	public class CitiesGroupedByDrivingSide
	{
		public DrivingSide DrivingSide { get; set; }
		public string CityName { get; set; }
	}

	public class CountryAveragePopulation
	{
		public string Name { get; set; }
		public double Avg { get => Math.Round(CountyAveragePopulation.Average(x => x.Avg), 2); }
		public IList<CountyAveragePopulation> CountyAveragePopulation { get; set; }
	}

	public class CountyAveragePopulation
	{
		public string Name { get; set; }
		public string CountryName { get; set; }
		public double Avg { get => Math.Round(avg, 2); set => avg = value; }
		double avg;
	}

	public class SumAreaByCountry
	{
		public string Name { get; set; }
		public double Sum { get; set; }
	}
}
