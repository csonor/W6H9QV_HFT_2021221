using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace W6H9QV_HFT_2021221.Models
{
	[Table("cities")]
	public class City
	{
		[Key]
		[ToString]
		public int ID { get; set; }

		[ToString]
		public string Name { get; set; }

		[Required]
		[ToString]
		public int Population { get; set; }

		[ToString]
		public int? Elevation { get; set; }

		//in square km
		public double Area { get; set; }

		[ForeignKey(nameof(County))]
		public int CountyID { get; set; }

		[NotMapped]
		public virtual County County { get; set; }

		public override string ToString()
		{
			string x = "";

			foreach (var item in this.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
			{
				if (item.Name != null)
					x += $"{item.Name} \t==>\t {item.GetValue(this)}\n";
			}
			return x;
		}
	}
}
