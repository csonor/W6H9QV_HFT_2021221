using Microsoft.EntityFrameworkCore;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Data
{
	public class CountriesDbContext : DbContext
	{
		public virtual DbSet<City> Cities { get; set; }
		public virtual DbSet<County> Counties { get; set; }
		public virtual DbSet<Country> Countries { get; set; }

		public CountriesDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder
					.UseLazyLoadingProxies()
					.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<City>(e =>
			e.HasOne(c => c.County)
			.WithMany(c => c.Cities)
			.HasForeignKey(c => c.CountyID)
			.OnDelete(DeleteBehavior.Cascade));

			modelBuilder.Entity<County>(e =>
			e.HasOne(c => c.Country)
			.WithMany(c => c.Counties)
			.HasForeignKey(c => c.CountryID)
			.OnDelete(DeleteBehavior.Cascade));

			Country hu = new Country() { ID = 1, Name = "Magyarország", EnglishName = "Hungary", CountryCode = "hu", Currency = "huf", DrivingSide = DrivingSide.right, Population = 9730000 };

			County bacs = new County() { ID = 1, Name = "Bács-Kiskun", Population = 513687, CountySeat = "Kecskemét", Districts = 11, CountryID = hu.ID };
			County jasz = new County() { ID = 2, Name = "Jász-Nagykun-Szolnok", Population = 379897, CountySeat = "Szolnok", Districts = 9, CountryID = hu.ID };
			County csongr = new County() { ID = 3, Name = "Csongrád-Csanád", Population = 406205, CountySeat = "Szeged", Districts = 7, CountryID = hu.ID };

			City kecs = new City() { ID = 1, Name = "Kecskemét", Population = 110813, Elevation = 105, Area = 321.35, CountyID = bacs.ID };
			City kisk = new City() { ID = 2, Name = "Kiskőrös", Population = 14452, Area = 102.23, CountyID = bacs.ID };
			City solt = new City() { ID = 3, Name = "Solt", Population = 6721, Area = 132.67, CountyID = bacs.ID };

			City szol = new City() { ID = 4, Name = "Szolnok", Population = 71285, Elevation = 68, Area = 187.24, CountyID = jasz.ID };
			City abad = new City() { ID = 5, Name = "Abádszalók", Population = 4279, Area = 132.23, CountyID = jasz.ID };
			City mezo = new City() { ID = 6, Name = "Mezőtúr", Population = 19483, Area = 289.72, CountyID = jasz.ID };

			City szeg = new City() { ID = 7, Name = "Szeged", Population = 160766, Elevation = 76, Area = 280.84, CountyID = csongr.ID };
			City mako = new City() { ID = 8, Name = "Makó", Population = 27727, Area = 229.23, CountyID = csongr.ID };
			City csong = new City() { ID = 9, Name = "Csongrád", Population = 17686, Elevation = 83, Area = 183.68, CountyID = csongr.ID };


			Country aus = new Country() { ID = 2, Name = "Österreich", EnglishName = "Austria", CountryCode = "at", Currency = "eur", DrivingSide = DrivingSide.right, Population = 8935112 };

			County styr = new County() { ID = 4, Name = "Styria", Population = 1246576, CountySeat = "Graz", Districts = 13, CountryID = aus.ID };

			City graz = new City() { ID = 10, Name = "Graz", Population = 294630, Elevation = 353, Area = 127.57, CountyID = styr.ID };
			City kapf = new City() { ID = 11, Name = "Kapfenberg", Population = 22798, Elevation = 502, Area = 82.08, CountyID = styr.ID };
			City leob = new City() { ID = 12, Name = "Leoben", Population = 24645, Elevation = 541, Area = 107.77, CountyID = styr.ID };


			Country austr = new Country() { ID = 3, Name = "Australia", EnglishName = "Australia", CountryCode = "au", Currency = "aud", DrivingSide = DrivingSide.left, Population = 2590190 };

			County vic = new County() { ID = 5, Name = "Victoria", Population = 6648564, CountySeat = "Melbourne", Districts = 79, CountryID = austr.ID };

			City melb = new City() { ID = 13, Name = "Melbourne", Population = 5159211, Elevation = 31, Area = 9993, CountyID = vic.ID };
			City bend = new City() { ID = 14, Name = "Bendigo", Population = 100632, Elevation = 213, Area = 287.4, CountyID = vic.ID };
			City sale = new City() { ID = 15, Name = "Sale", Population = 15135, Area = 45.6, CountyID = vic.ID };

			modelBuilder.Entity<Country>().HasData(hu, aus, austr);
			modelBuilder.Entity<County>().HasData(bacs, jasz, csongr, styr, vic);
			modelBuilder.Entity<City>().HasData(kecs, kisk, solt, szol, abad, mezo, szeg, mako, csong, graz, kapf, leob, melb, bend, sale);

		}

	}
}
