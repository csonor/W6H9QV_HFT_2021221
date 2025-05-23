﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace W6H9QV_HFT_2021221.Models
{
	[Table("cities")]
	public class City
	{
		[Key]
		[ToString]
		public int ID { get; set; }

		[Required]
		[ToString]
		public string Name { get; set; }

		[Required]
		[ToString]
		public int Population { get; set; }

		[ToString]
		public int? Elevation { get; set; }

		[ToString]
		/// <summary>
		/// In square kilometers
		/// </summary>
		public double Area { get; set; }

		[ToString]
		[ForeignKey(nameof(County))]
		public int CountyID { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual County County { get; set; }

		public override string ToString()
		{
			string x = "";

			foreach (var item in GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
			{
				if (item.GetValue(this) != null)
					x += $"{item.Name,-15}==>\t{item.GetValue(this)}\n";
			}
			return x;
		}
	}
}
