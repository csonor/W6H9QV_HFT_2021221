using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
		public int FirstPlaceID { get; set; }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public int SecondPlaceID { get; set; }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public int ThirdPlaceID { get; set; }

		[Required]
		[ToString]
		[ForeignKey(nameof(Driver))]
		public int PolePositionID { get; set; }

		[Required]
		[ToString]
		[ForeignKey(nameof(Team))]
		public int WinningConstructorID { get; set; }

		public Weather Weather { get; set; }
	}
}
