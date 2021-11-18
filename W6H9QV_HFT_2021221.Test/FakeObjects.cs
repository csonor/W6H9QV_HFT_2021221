using System.Collections.Generic;
using System.Linq;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Test
{
	public partial class Tests
	{
		IQueryable<Country> FakeCountries()
		{
			Country hu = new Country() { ID = 1, Name = "Magyarország", EnglishName = "Hungary", CountryCode = "hu", Currency = "huf", DrivingSide = DrivingSide.right, Population = 9730000 };
			Country aus = new Country() { ID = 2, Name = "Österreich", EnglishName = "Austria", CountryCode = "at", Currency = "eur", DrivingSide = DrivingSide.right, Population = 8935112 };

			County bacs = new County() { ID = 1, Name = "Bács-Kiskun", Population = 513687, CountySeat = "Kecskemét", Districts = 11, CountryID = hu.ID };
			County jasz = new County() { ID = 2, Name = "Jász-Nagykun-Szolnok", Population = 379897, CountySeat = "Szolnok", Districts = 9, CountryID = hu.ID };
			County csongr = new County() { ID = 3, Name = "Csongrád-Csanád", Population = 406205, CountySeat = "Szeged", Districts = 7, CountryID = hu.ID };
			County styr = new County() { ID = 4, Name = "Styria", Population = 1246576, CountySeat = "Graz", Districts = 13, CountryID = aus.ID };

			hu.Counties = new List<County> { bacs, jasz, csongr };
			aus.Counties = new List<County> { styr };

			bacs.Country = hu; jasz.Country = hu; csongr.Country = hu;
			styr.Country = aus;

			City kecs = new City() { ID = 1, Name = "Kecskemét", Population = 110813, Elevation = 105, Area = 321.35, CountyID = bacs.ID };
			City kisk = new City() { ID = 2, Name = "Kiskőrös", Population = 14452, Area = 102.23, CountyID = bacs.ID };
			City solt = new City() { ID = 3, Name = "Solt", Population = 6721, Area = 132.67, CountyID = bacs.ID };
			City szol = new City() { ID = 4, Name = "Szolnok", Population = 71285, Elevation = 68, Area = 187.24, CountyID = jasz.ID };
			City abad = new City() { ID = 5, Name = "Abádszalók", Population = 4279, Area = 132.23, CountyID = jasz.ID };
			City mezo = new City() { ID = 6, Name = "Mezőtúr", Population = 19483, Area = 289.72, CountyID = jasz.ID };
			City szeg = new City() { ID = 7, Name = "Szeged", Population = 160766, Elevation = 76, Area = 280.84, CountyID = csongr.ID };
			City mako = new City() { ID = 8, Name = "Makó", Population = 27727, Area = 229.23, CountyID = csongr.ID };
			City csong = new City() { ID = 9, Name = "Csongrád", Population = 17686, Elevation = 83, Area = 183.68, CountyID = csongr.ID };
			City graz = new City() { ID = 10, Name = "Graz", Population = 294630, Elevation = 353, Area = 127.57, CountyID = styr.ID };
			City kapf = new City() { ID = 11, Name = "Kapfenberg", Population = 22798, Elevation = 502, Area = 82.08, CountyID = styr.ID };
			City leob = new City() { ID = 12, Name = "Leoben", Population = 24645, Elevation = 541, Area = 107.77, CountyID = styr.ID };

			bacs.Cities = new List<City> { kecs, kisk, solt };
			jasz.Cities = new List<City> { szol, abad, mezo };
			csongr.Cities = new List<City> { szeg, mako, csong };
			styr.Cities = new List<City> { graz, kapf, leob };

			kecs.County = bacs; kisk.County = bacs; solt.County = bacs;
			szol.County = jasz; abad.County = jasz; mezo.County = jasz;
			szeg.County = csongr; mako.County = csongr; csong.County = csongr;
			graz.County = styr; kapf.County = styr; leob.County = styr;

			var items = new List<Country>();
			items.Add(hu); items.Add(aus);
			return items.AsQueryable();
		}

		IQueryable<County> FakeCounties()
		{
			Country hu = new Country() { ID = 1, Name = "Magyarország", EnglishName = "Hungary", CountryCode = "hu", Currency = "huf", DrivingSide = DrivingSide.right, Population = 9730000 };
			Country aus = new Country() { ID = 2, Name = "Österreich", EnglishName = "Austria", CountryCode = "at", Currency = "eur", DrivingSide = DrivingSide.right, Population = 8935112 };

			County bacs = new County() { ID = 1, Name = "Bács-Kiskun", Population = 513687, CountySeat = "Kecskemét", Districts = 11, CountryID = hu.ID };
			County jasz = new County() { ID = 2, Name = "Jász-Nagykun-Szolnok", Population = 379897, CountySeat = "Szolnok", Districts = 9, CountryID = hu.ID };
			County csongr = new County() { ID = 3, Name = "Csongrád-Csanád", Population = 406205, CountySeat = "Szeged", Districts = 7, CountryID = hu.ID };
			County styr = new County() { ID = 4, Name = "Styria", Population = 1246576, CountySeat = "Graz", Districts = 13, CountryID = aus.ID };

			hu.Counties = new List<County> { bacs, jasz, csongr };
			aus.Counties = new List<County> { styr };

			bacs.Country = hu; jasz.Country = hu; csongr.Country = hu;
			styr.Country = aus;

			City kecs = new City() { ID = 1, Name = "Kecskemét", Population = 110813, Elevation = 105, Area = 321.35, CountyID = bacs.ID };
			City kisk = new City() { ID = 2, Name = "Kiskőrös", Population = 14452, Area = 102.23, CountyID = bacs.ID };
			City solt = new City() { ID = 3, Name = "Solt", Population = 6721, Area = 132.67, CountyID = bacs.ID };
			City szol = new City() { ID = 4, Name = "Szolnok", Population = 71285, Elevation = 68, Area = 187.24, CountyID = jasz.ID };
			City abad = new City() { ID = 5, Name = "Abádszalók", Population = 4279, Area = 132.23, CountyID = jasz.ID };
			City mezo = new City() { ID = 6, Name = "Mezőtúr", Population = 19483, Area = 289.72, CountyID = jasz.ID };
			City szeg = new City() { ID = 7, Name = "Szeged", Population = 160766, Elevation = 76, Area = 280.84, CountyID = csongr.ID };
			City mako = new City() { ID = 8, Name = "Makó", Population = 27727, Area = 229.23, CountyID = csongr.ID };
			City csong = new City() { ID = 9, Name = "Csongrád", Population = 17686, Elevation = 83, Area = 183.68, CountyID = csongr.ID };
			City graz = new City() { ID = 10, Name = "Graz", Population = 294630, Elevation = 353, Area = 127.57, CountyID = styr.ID };
			City kapf = new City() { ID = 11, Name = "Kapfenberg", Population = 22798, Elevation = 502, Area = 82.08, CountyID = styr.ID };
			City leob = new City() { ID = 12, Name = "Leoben", Population = 24645, Elevation = 541, Area = 107.77, CountyID = styr.ID };

			bacs.Cities = new List<City> { kecs, kisk, solt };
			jasz.Cities = new List<City> { szol, abad, mezo };
			csongr.Cities = new List<City> { szeg, mako, csong };
			styr.Cities = new List<City> { graz, kapf, leob };

			kecs.County = bacs; kisk.County = bacs; solt.County = bacs;
			szol.County = jasz; abad.County = jasz; mezo.County = jasz;
			szeg.County = csongr; mako.County = csongr; csong.County = csongr;
			graz.County = styr; kapf.County = styr; leob.County = styr;

			var items = new List<County>();
			items.Add(bacs); items.Add(jasz); items.Add(csongr); items.Add(styr);
			return items.AsQueryable();
		}

		IQueryable<City> FakeCities()
		{
			Country hu = new Country() { ID = 1, Name = "Magyarország", EnglishName = "Hungary", CountryCode = "hu", Currency = "huf", DrivingSide = DrivingSide.right, Population = 9730000 };
			Country aus = new Country() { ID = 2, Name = "Österreich", EnglishName = "Austria", CountryCode = "at", Currency = "eur", DrivingSide = DrivingSide.right, Population = 8935112 };

			County bacs = new County() { ID = 1, Name = "Bács-Kiskun", Population = 513687, CountySeat = "Kecskemét", Districts = 11, CountryID = hu.ID };
			County jasz = new County() { ID = 2, Name = "Jász-Nagykun-Szolnok", Population = 379897, CountySeat = "Szolnok", Districts = 9, CountryID = hu.ID };
			County csongr = new County() { ID = 3, Name = "Csongrád-Csanád", Population = 406205, CountySeat = "Szeged", Districts = 7, CountryID = hu.ID };
			County styr = new County() { ID = 4, Name = "Styria", Population = 1246576, CountySeat = "Graz", Districts = 13, CountryID = aus.ID };

			hu.Counties = new List<County> { bacs, jasz, csongr };
			aus.Counties = new List<County> { styr };

			bacs.Country = hu; jasz.Country = hu; csongr.Country = hu;
			styr.Country = aus;

			City kecs = new City() { ID = 1, Name = "Kecskemét", Population = 110813, Elevation = 105, Area = 321.35, CountyID = bacs.ID };
			City kisk = new City() { ID = 2, Name = "Kiskőrös", Population = 14452, Area = 102.23, CountyID = bacs.ID };
			City solt = new City() { ID = 3, Name = "Solt", Population = 6721, Area = 132.67, CountyID = bacs.ID };
			City szol = new City() { ID = 4, Name = "Szolnok", Population = 71285, Elevation = 68, Area = 187.24, CountyID = jasz.ID };
			City abad = new City() { ID = 5, Name = "Abádszalók", Population = 4279, Area = 132.23, CountyID = jasz.ID };
			City mezo = new City() { ID = 6, Name = "Mezőtúr", Population = 19483, Area = 289.72, CountyID = jasz.ID };
			City szeg = new City() { ID = 7, Name = "Szeged", Population = 160766, Elevation = 76, Area = 280.84, CountyID = csongr.ID };
			City mako = new City() { ID = 8, Name = "Makó", Population = 27727, Area = 229.23, CountyID = csongr.ID };
			City csong = new City() { ID = 9, Name = "Csongrád", Population = 17686, Elevation = 83, Area = 183.68, CountyID = csongr.ID };
			City graz = new City() { ID = 10, Name = "Graz", Population = 294630, Elevation = 353, Area = 127.57, CountyID = styr.ID };
			City kapf = new City() { ID = 11, Name = "Kapfenberg", Population = 22798, Elevation = 502, Area = 82.08, CountyID = styr.ID };
			City leob = new City() { ID = 12, Name = "Leoben", Population = 24645, Elevation = 541, Area = 107.77, CountyID = styr.ID };

			bacs.Cities = new List<City> { kecs, kisk, solt };
			jasz.Cities = new List<City> { szol, abad, mezo };
			csongr.Cities = new List<City> { szeg, mako, csong };
			styr.Cities = new List<City> { graz, kapf, leob };

			kecs.County = bacs; kisk.County = bacs; solt.County = bacs;
			szol.County = jasz; abad.County = jasz; mezo.County = jasz;
			szeg.County = csongr; mako.County = csongr; csong.County = csongr;
			graz.County = styr; kapf.County = styr; leob.County = styr;

			var items = new List<City>();
			items.Add(kecs); items.Add(kisk); items.Add(solt);
			items.Add(szol); items.Add(abad); items.Add(mezo);
			items.Add(szeg); items.Add(mako); items.Add(csong);
			items.Add(graz); items.Add(kapf); items.Add(leob);
			return items.AsQueryable();
		}
	}
}
