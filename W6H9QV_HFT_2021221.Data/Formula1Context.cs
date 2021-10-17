using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Data
{
	public class Formula1Context : DbContext
	{
		public virtual DbSet<Driver> Drivers { get; set; }
		public virtual DbSet<Team> Teams { get; set; }
		public virtual DbSet<Race> Races { get; set; }
		public Formula1Context()
		{
			this.Database.EnsureCreated();
		}
		public Formula1Context(DbContextOptions<Formula1Context> options)
		   : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseLazyLoadingProxies()
					.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Team alfar = new Team() { TeamID = 1, Constructor = "Alfa Romeo Racing", LicensedIn = "Switzerland", Engine = Engine.Ferrari };
			Team alphat = new Team() { TeamID = 2, Constructor = "AlphaTauri", LicensedIn = "Italy", Engine = Engine.Honda };
			Team alp = new Team() { TeamID = 3, Constructor = "Alpine", LicensedIn = "France", Engine = Engine.Renault };
			Team ast = new Team() { TeamID = 4, Constructor = "Aston Martin", LicensedIn = "Britain", Engine = Engine.Mercedes };
			Team fer = new Team() { TeamID = 5, Constructor = "Ferrari", LicensedIn = "Italy", Engine = Engine.Ferrari };
			Team haas = new Team() { TeamID = 6, Constructor = "Haas", LicensedIn = "USA", Engine = Engine.Ferrari };
			Team mcl = new Team() { TeamID = 7, Constructor = "McLaren", LicensedIn = "Britain", Engine = Engine.Mercedes };
			Team merc = new Team() { TeamID = 8, Constructor = "Mercedes", LicensedIn = "Germany", Engine = Engine.Mercedes };
			Team rbr = new Team() { TeamID = 9, Constructor = "Red Bull Racing", LicensedIn = "Austria", Engine = Engine.Honda };
			Team wil = new Team() { TeamID = 10, Constructor = "Williams", LicensedIn = "Britain", Engine = Engine.Mercedes };

			//################################################################################################

			Driver ham = new Driver() { DriverID = "ham", FirstName = "Lewis", LastName = "Hamilton", CarNumber = 44, Nationality = "British", BirthDate = new DateTime(1985, 1, 7), Championships = 7, DriverStatus = DriverStatus.FirstDriver };
			Driver bot = new Driver() { DriverID = "bot", FirstName = "Valtteri", LastName = "Bottas", CarNumber = 77, Nationality = "Finnish", BirthDate = new DateTime(1989, 8, 28), DriverStatus = DriverStatus.SecondDriver };
			Driver ver = new Driver() { DriverID = "ver", FirstName = "Max", LastName = "Verstappen", CarNumber = 33, Nationality = "Dutch", BirthDate = new DateTime(1997, 9, 30), DriverStatus = DriverStatus.FirstDriver };
			Driver per = new Driver() { DriverID = "per", FirstName = "Sergio", LastName = "Perez", CarNumber = 11, Nationality = "Mexican", BirthDate = new DateTime(1990, 1, 26), DriverStatus = DriverStatus.SecondDriver };
			Driver ric = new Driver() { DriverID = "ric", FirstName = "Daniel", LastName = "Ricciardo", CarNumber = 3, Nationality = "Australian", BirthDate = new DateTime(1989, 7, 1), DriverStatus = DriverStatus.FirstDriver };
			Driver nor = new Driver() { DriverID = "nor", FirstName = "Lando", LastName = "Norris", CarNumber = 4, Nationality = "British", BirthDate = new DateTime(1999, 11, 13), DriverStatus = DriverStatus.SecondDriver };
			Driver vet = new Driver() { DriverID = "vet", FirstName = "Sebastian", LastName = "Vettel", CarNumber = 5, Nationality = "German", BirthDate = new DateTime(1987, 7, 3), Championships = 4, DriverStatus = DriverStatus.FirstDriver };
			Driver str = new Driver() { DriverID = "str", FirstName = "Lance", LastName = "Stroll", CarNumber = 18, Nationality = "Canadian", BirthDate = new DateTime(1998, 10, 29), DriverStatus = DriverStatus.SecondDriver };
			Driver oco = new Driver() { DriverID = "oco", FirstName = "Esteban", LastName = "Ocon", CarNumber = 31, Nationality = "French", BirthDate = new DateTime(1996, 9, 17), DriverStatus = DriverStatus.FirstDriver };
			Driver alo = new Driver() { DriverID = "alo", FirstName = "Fernando", LastName = "Alonso", CarNumber = 14, Nationality = "Spanish", BirthDate = new DateTime(1981, 7, 29), Championships = 2, DriverStatus = DriverStatus.SecondDriver };
			Driver sai = new Driver() { DriverID = "sai", FirstName = "Carlos", LastName = "Sainz", CarNumber = 55, Nationality = "Spanish", BirthDate = new DateTime(1994, 7, 1), DriverStatus = DriverStatus.FirstDriver };
			Driver lec = new Driver() { DriverID = "lec", FirstName = "Charles", LastName = "Leclerc", CarNumber = 16, Nationality = "Monacan", BirthDate = new DateTime(1997, 10, 16), DriverStatus = DriverStatus.SecondDriver };
			Driver tsu = new Driver() { DriverID = "tsu", FirstName = "Yuki", LastName = "Tsunoda", CarNumber = 22, Nationality = "Japanese", BirthDate = new DateTime(2000, 5, 11), DriverStatus = DriverStatus.FirstDriver };
			Driver gas = new Driver() { DriverID = "gas", FirstName = "Pierre", LastName = "Gasly", CarNumber = 10, Nationality = "French", BirthDate = new DateTime(1996, 2, 7), DriverStatus = DriverStatus.SecondDriver };
			Driver rai = new Driver() { DriverID = "rai", FirstName = "Kimi", LastName = "Raikonen", CarNumber = 7, Nationality = "Finnish", BirthDate = new DateTime(1979, 10, 17), Championships = 1, DriverStatus = DriverStatus.FirstDriver };
			Driver gio = new Driver() { DriverID = "gio", FirstName = "Antonio", LastName = "Giovinazzi", CarNumber = 99, Nationality = "Italian", BirthDate = new DateTime(1993, 12, 14), DriverStatus = DriverStatus.SecondDriver };
			Driver msc = new Driver() { DriverID = "msc", FirstName = "Mick", LastName = "Schumacher", CarNumber = 47, Nationality = "German", BirthDate = new DateTime(1999, 3, 22), DriverStatus = DriverStatus.FirstDriver };
			Driver maz = new Driver() { DriverID = "maz", FirstName = "Nikita", LastName = "Mazepin", CarNumber = 9, Nationality = "Russian", BirthDate = new DateTime(1999, 3, 2), DriverStatus = DriverStatus.SecondDriver };
			Driver rus = new Driver() { DriverID = "rus", FirstName = "George", LastName = "Russell", CarNumber = 63, Nationality = "British", BirthDate = new DateTime(1998, 2, 15), DriverStatus = DriverStatus.FirstDriver };
			Driver lat = new Driver() { DriverID = "lat", FirstName = "Nicolas", LastName = "Latifi", CarNumber = 6, Nationality = "Canadian", BirthDate = new DateTime(1995, 6, 29), DriverStatus = DriverStatus.SecondDriver };

			//################################################################################################

			ham.TeamID = merc.TeamID;
			bot.TeamID = merc.TeamID;

			ver.TeamID = rbr.TeamID;
			per.TeamID = rbr.TeamID;

			ric.TeamID = mcl.TeamID;
			nor.TeamID = mcl.TeamID;

			vet.TeamID = ast.TeamID;
			str.TeamID = ast.TeamID;

			oco.TeamID = alp.TeamID;
			alo.TeamID = alp.TeamID;

			sai.TeamID = fer.TeamID;
			lec.TeamID = fer.TeamID;

			tsu.TeamID = alphat.TeamID;
			gas.TeamID = alphat.TeamID;

			rai.TeamID = alfar.TeamID;
			gio.TeamID = alfar.TeamID;

			msc.TeamID = haas.TeamID;
			maz.TeamID = haas.TeamID;

			rus.TeamID = wil.TeamID;
			lat.TeamID = wil.TeamID;

			//################################################################################################

			Race r0 = new Race() { GrandPrix = "Turkish Grand Prix", Date = new DateTime(2021, 10, 10), FirstPlaceID = "bot", SecondPlaceID = "ver", ThirdPlaceID = "per", PolePositionID = "bot", Weather = Weather.Light_Rain, WinningConstructorID = 8, LapRecord = new TimeSpan(0, 0, 1, 30, 432) };
			Race r1 = new Race() { GrandPrix = "Russian Grand Prix", Date = new DateTime(2021, 9, 26), FirstPlaceID = "ham", SecondPlaceID = "ver", ThirdPlaceID = "sai", PolePositionID = "nor", Weather = Weather.Light_Rain, WinningConstructorID = 8, LapRecord = new TimeSpan(0, 0, 1, 37, 423) };
			Race r2 = new Race() { GrandPrix = "Italian Grand Prix", Date = new DateTime(2021, 9, 12), FirstPlaceID = "ric", SecondPlaceID = "nor", ThirdPlaceID = "bot", PolePositionID = "ver", Weather = Weather.Clear, WinningConstructorID = 7, LapRecord = new TimeSpan(0, 0, 1, 24, 812) };
			Race r3 = new Race() { GrandPrix = "Dutch Grand Prix", Date = new DateTime(2021, 9, 5), FirstPlaceID = "ver", SecondPlaceID = "ham", ThirdPlaceID = "bot", PolePositionID = "ver", Weather = Weather.Clear, WinningConstructorID = 9, LapRecord = new TimeSpan(0, 0, 1, 11, 097) };
			Race r4 = new Race() { GrandPrix = "Belgian Grand Prix", Date = new DateTime(2021, 8, 29), FirstPlaceID = "ver", SecondPlaceID = "rus", ThirdPlaceID = "ham", PolePositionID = "ver", Weather = Weather.Heavy_Rain, WinningConstructorID = 9 };
			Race r5 = new Race() { GrandPrix = "Hungarian Grand Prix", Date = new DateTime(2021, 8, 1), FirstPlaceID = "oco", SecondPlaceID = "ham", ThirdPlaceID = "sai", PolePositionID = "ham", Weather = Weather.Clear, WinningConstructorID = 8, LapRecord = new TimeSpan(0, 0, 1, 18, 394) };

			//################################################################################################

			modelBuilder.Entity<Driver>(driver =>
			{
				driver
				.HasOne(driver => driver.Team)
				.WithMany(team => team.Drivers)
				.HasForeignKey(driver => driver.TeamID)
				.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Driver>().HasData(ham, bot, ver, per, nor, ric, str, vet, oco, alo, sai, lec, tsu, gas, rai, gio, maz, msc, rus, lat);
			modelBuilder.Entity<Team>().HasData(merc, rbr, mcl, ast, alp, fer, alphat, alfar, wil, haas);
			modelBuilder.Entity<Race>().HasData(r0, r1, r2, r3, r4, r5);
		}
	}
}
