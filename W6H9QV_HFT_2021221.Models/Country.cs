﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace W6H9QV_HFT_2021221.Models
{
	public enum DrivingSide
	{
		left, right
	}

	[Table("countries")]
	public class Country
	{
		[Key]
		[ToString]
		public int ID { get; set; }

		[Required]
		[ToString]
		public string Name { get; set; }

		[Required]
		[ToString]
		public string EnglishName { get; set; }

		[Required]
		[ToString]
		public string CountryCode { get => countryCode; set => countryCode = value.ToUpper(); }
		string countryCode;

		[Required]
		[ToString]
		public int Population { get; set; }

		[ToString]
		public string Currency { get => currency; set => currency = value.ToUpper(); }
		string currency;

		[ToString]
		public DrivingSide DrivingSide { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<County> Counties { get; set; }

		public Country()
		{
			Counties = new HashSet<County>();
		}

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
