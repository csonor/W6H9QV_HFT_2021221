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
	public enum Engine
	{
		Mercedes, Honda, Ferrari, Renault
	}

	[Table("Teams")]
	public class Team
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[ToString]
		public int TeamID { get; set; }

		[Required]
		[ToString]
		public string Constructor { get; set; }

		[Required]
		[ToString]
		public string LicensedIn { get; set; }

		[ToString]
		public Engine Engine { get; set; }

		[NotMapped]
		public virtual ICollection<Driver> Drivers { get; set; }

		public Team()
		{
			Drivers = new HashSet<Driver>();
		}

		public override string ToString()
		{
			string x = "";

			foreach (var item in this.GetType().GetProperties().Where(x =>
			   x.GetCustomAttribute<ToStringAttribute>() != null))
			{
				x += "   ";
				x += item.Name + "\t=> ";
				x += item.GetValue(this);
				x += "\n";
			}
			return x;
		}
	}
}
