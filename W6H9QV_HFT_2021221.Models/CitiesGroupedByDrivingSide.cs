using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6H9QV_HFT_2021221.Models
{
	public class CitiesGroupedByDrivingSide
	{
		public DrivingSide DrivingSide { get; set; }
		public List<City> Cities { get; set; }
		public int SumPopulation { get => Cities.Sum(x => x.Population); }
	}
}
