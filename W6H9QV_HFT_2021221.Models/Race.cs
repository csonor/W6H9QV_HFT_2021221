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
	public enum Weather
	{
		Clear, Light_Clouds, Heavy_Clouds, Light_Rain, Heavy_Rain
	}

	[Table("Races")]
	public class Race
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[ToString]
		public int RaceID { get; set; }

		[Required]
		[ToString]
		public string GrandPrix { get => GrandPrix; set => GrandPrix = Date.Year + " " + value; }

		[Required]
		[ToString]
		public DateTime Date { get; set; }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public string FirstPlaceID { get => FirstPlaceID; set => FirstPlaceID = value.ToUpper(); }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public string SecondPlaceID { get => SecondPlaceID; set => SecondPlaceID = value.ToUpper(); }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public string ThirdPlaceID { get => ThirdPlaceID; set => ThirdPlaceID = value.ToUpper(); }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public string PolePositionID { get => PolePositionID; set => PolePositionID = value.ToUpper(); }

		[Required]
		[ToString]
		[ForeignKey(nameof(Team))]
		public int WinningConstructorID { get; set; }

		public TimeSpan LapRecord { get; set; }

		public Weather Weather { get; set; }

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
