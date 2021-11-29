using System;
using System.Collections.Generic;
using System.Linq;

namespace W6H9QV_HFT_2021221.Models
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ToStringAttribute : Attribute
	{
	}

	static class ToString
	{
		public static string Tostring(object obj)
		{
			string x = "";

			foreach (var item in obj.GetType().GetProperties())
			{
				x += $"{item.Name,-20}==>\t{item.GetValue(obj)}\n";
			}
			return x;
		}
	}

	public class CitiesGroupedByDrivingSide
	{
		public DrivingSide DrivingSide { get; set; }
		public IList<City> Cities { get; set; }
		public int SumPopulation { get => Cities.Sum(x => x.Population); }

		public override string ToString()
		{
			string x = "";
			foreach (var item in GetType().GetProperties())
			{
				if (item.Name == "Cities")
				{
					x += $"{item.Name,-15}==>\t";
					bool first = true;
					foreach (var city in Cities)
					{
						if (first)
						{
							x += $"{city.Name}\n";
							first = false;
						}
						else x += $"{"",-24}{city.Name}\n";
					}
				}
				else x += $"{item.Name,-15}==>\t{item.GetValue(this)}\n";
			}
			return x;
		}
	}

	public class CountryAveragePopulation
	{
		public string Name { get; set; }
		public double Avg { get => Math.Round(CountyAveragePopulation.Average(x => x.Avg), 2); }
		public IList<CountyAveragePopulation> CountyAveragePopulation { get; set; }

		public override string ToString()
		{
			string x = "";

			foreach (var item in GetType().GetProperties())
			{
				if (item.Name == "CountyAveragePopulation")
				{
					x += "Counties:\n";
					foreach (var county in CountyAveragePopulation)
					{
						x += $"{"",-9}{"Name",-10}==>\t{county.Name}\n";
						x += $"{"",-9}{"Average",-10}==>\t{county.Avg}\n";
					}
				}
				else x += $"{item.Name,-15}==>\t{item.GetValue(this)}\n";
			}
			return x;
		}
	}

	public class CountyAveragePopulation
	{
		public string Name { get; set; }
		public string CountryName { get; set; }
		public double Avg { get => Math.Round(avg, 2); set => avg = value; }
		double avg;

		public override string ToString()
		{
			return Models.ToString.Tostring(this);
		}
	}

	public class SumAreaByCountry
	{
		public string Name { get; set; }
		public double Sum { get => Math.Round(sum, 2); set => sum = value; }
		double sum;

		public override string ToString()
		{
			return Models.ToString.Tostring(this);
		}
	}

	public class AverageCityInCounties
	{
		public string CountryName { get; set; }
		public double AverageCityCount { get => Math.Round(avg, 2); set => avg = value; }
		double avg;

		public override string ToString()
		{
			return Models.ToString.Tostring(this);
		}
	}
}
