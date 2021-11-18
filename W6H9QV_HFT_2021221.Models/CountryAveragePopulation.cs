using System.Collections.Generic;
using System.Linq;

namespace W6H9QV_HFT_2021221.Models
{
	public class CountryAveragePopulation
	{
		public string Name { get; set; }
		public double Avg { get => CountyAveragePopulation.Average(x => x.Avg); }
		public IList<CountyAveragePopulation> CountyAveragePopulation { get; set; }
	}

	public class CountyAveragePopulation
	{
		public string Name { get; set; }
		public string CountryName { get; set; }
		public double Avg { get; set; }
	}
}
