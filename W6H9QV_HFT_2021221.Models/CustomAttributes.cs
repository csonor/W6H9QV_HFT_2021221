using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6H9QV_HFT_2021221.Models
{
	[AttributeUsage(AttributeTargets.Property)]
	class ToStringAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property)]
	class MaxValueAttribute : ValidationAttribute
	{
		public int MaxValue { get; set; }
		public override bool IsValid(object value)
		{
			int carNumber = (int)value;
			return carNumber <= MaxValue;
		}

	}
}
