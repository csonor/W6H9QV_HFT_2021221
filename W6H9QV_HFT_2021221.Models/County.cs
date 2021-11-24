using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace W6H9QV_HFT_2021221.Models
{
	[Table("counties")]
	public class County
	{
		[Key]
		[ToString]
		public int ID { get; set; }

		[Required]
		[ToString]
		public string Name { get; set; }

		[ToString]
		public int Population { get; set; }

		[ToString]
		public string CountySeat { get; set; }

		public int? Districts { get; set; }

		[ForeignKey(nameof(Country))]
		public int CountryID { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual Country Country { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<City> Cities { get; set; }

		public County()
		{
			Cities = new HashSet<City>();
		}

		public override string ToString()
		{
			string x = "";

			foreach (var item in this.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
			{
				if (item.GetValue(this) != null)
					x += $"{item.Name} \t==>\t {item.GetValue(this)}\n";
			}
			return x;
		}
	}
}
