using System;
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
	class MaxValueAttribute : Attribute
	{
		public int MaxValue { get; set; }
	}
}
