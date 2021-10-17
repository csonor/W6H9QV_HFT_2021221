using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Data
{
	public partial class Formula1Context : DbContext
	{
		public virtual DbSet<Driver> Drivers { get; set; }
		public virtual DbSet<Team> Teams { get; set; }
		public virtual DbSet<Race> Races { get; set; }
		public Formula1Context()
		{
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseLazyLoadingProxies()
					.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
		}
	}
}
