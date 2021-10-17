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
	public enum DriverStatus
	{
		FirstDriver, SecondDriver, Reserve, Retired
	}

	[Table("Drivers")]
	public class Driver
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[ToString]
		public string DriverID { get => DriverID; set => DriverID = value.ToUpper(); }

		[Required]
		[MaxLength(30)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(30)]
		public string LastName { get; set; }

		[NotMapped]
		[ToString]
		public string Name { get => FirstName + " " + LastName; }

		[MaxValue(MaxValue = 99,ErrorMessage ="Car numer too high.")]
		[ToString]
		[Required]
		public int CarNumber { get; set; }

		public string Nationality { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		[NotMapped]
		[ToString]
		public int Age
		{
			get
			{
				var today = DateTime.Today;
				var age = today.Year - BirthDate.Year;
				if (BirthDate.Date > today.AddYears(-age)) return age--;
				else return age;
			}
		}

		public int? Championships { get; set; }

		[Required]
		[ToString]
		public DriverStatus DriverStatus { get; set; }

		[NotMapped]
		public virtual Team Team { get; set; }

		[ForeignKey(nameof(Team))]
		public int TeamID { get; set; }

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
