using ConsoleTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using W6H9QV_HFT_2021221.Models;

namespace W6H9QV_HFT_2021221.Client
{
	class Program
	{
		static RestService rest;
		static void Main(string[] args)
		{
			Console.Title = "Country Database";
			Console.OutputEncoding = Encoding.Unicode;
			Thread.Sleep(3000);
			rest = new RestService("http://localhost:7649");

			Menus();

			Console.WriteLine("Have a good day!");
			Thread.Sleep(2000);
			Environment.Exit(0);
		}

		static void Menus()
		{
			var statMenu = new ConsoleMenu()
				.Add("Cities grouped by driving side", () =>
				{
					Console.Clear(); Console.WriteLine("Cities grouped by driving side:\n");
					rest.StatGet<IEnumerable<CitiesGroupedByDrivingSide>>("CitiesGroupedByDrivingSide")
					.ToList().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("Country with highest populated city", () =>
				{
					Console.Clear(); Console.WriteLine("Country with highest populated city: {0}",
					rest.StatGet<string>("CountryWithHighestPopulatedCity"));
					PressToGoBack();
				})
				.Add("Get average country population", () =>
				{
					Console.Clear(); Console.WriteLine("Average country population:\n");
					rest.StatGet<IEnumerable<CountryAveragePopulation>>("GetAverageCountryPopulation")
					.ToList().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("Area summed by countries", () =>
				{
					Console.Clear(); Console.WriteLine("Area summed by countries:\n");
					rest.StatGet<IEnumerable<SumAreaByCountry>>("SumAreaByCountries")
					.ToList().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("County seats average population", () =>
				{
					Console.Clear(); Console.WriteLine("County seats average population: {0}",
					rest.StatGet<double>("CountySeatsAveragePopulation"));
					PressToGoBack();
				})
				.Add("Get average county population", () =>
				{
					Console.Clear(); Console.WriteLine("Average county population:\n");
					rest.StatGet<IEnumerable<CountyAveragePopulation>>("GetAverageCountyPopulation")
					.ToList().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("Average city count in counties by countries", () =>
				{
					Console.Clear(); Console.WriteLine("Average city count in counties by countries:\n");
					rest.StatGet<IEnumerable<AverageCityInCounties>>("AverageCityInCounties")
					.ToList().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "Custom methods menu";
				});

			var cityChangeMenu = new ConsoleMenu()
				.Add("CHANGE NAME", () => ChangeProperty<City, string>("Enter new name:", ChangeType.name))
				.Add("CHANGE POPULATION", () => ChangeProperty<City, int>("Enter new population:", ChangeType.pop))
				.Add("CHANGE COUNTY AREA", () => ChangeProperty<City, double>("Enter new area:", ChangeType.area))
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "City change menu";
				});

			var cityMenu = new ConsoleMenu()
				.Add("LIST ALL CITY", () =>
				{
					Console.Clear(); Console.WriteLine("All cities in database:\n");
					rest.GetAll<City>().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("GET A CITY", () => GetObject<City>())
				.Add("ADD NEW CITY", () => AddObject<City>())
				.Add("UPDATE WHOLE OBJECT", () => UpdateObject<City>())
				.Add("UPDATE ONE PROPERTY", () => cityChangeMenu.Show())
				.Add("DELETE", () => DeleteObject<City>())
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "City menu";
				});

			var countyChangeMenu = new ConsoleMenu()
				.Add("CHANGE NAME", () => ChangeProperty<County, string>("Enter new name:", ChangeType.name))
				.Add("CHANGE POPULATION", () => ChangeProperty<County, int>("Enter new population:", ChangeType.pop))
				.Add("CHANGE COUNTY SEAT", () => ChangeProperty<County, string>("Enter new county seat:", ChangeType.seat))
				.Add("CHANGE DISTRICTS", () => ChangeProperty<County, int?>("Enter new districts:", ChangeType.dist))
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "County change menu";
				});

			var countyMenu = new ConsoleMenu()
				.Add("LIST ALL COUNTY", () =>
				{
					Console.Clear(); Console.WriteLine("All counties in database:\n");
					rest.GetAll<County>().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("GET A COUNTY", () => GetObject<County>())
				.Add("ADD NEW COUNTY", () => AddObject<County>())
				.Add("UPDATE WHOLE OBJECT", () => UpdateObject<County>())
				.Add("UPDATE ONE PROPERTY", () => countyChangeMenu.Show())
				.Add("DELETE", () => DeleteObject<County>())
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "County menu";
				});

			var countryChangeMenu = new ConsoleMenu()
				.Add("CHANGE NAME", () => ChangeProperty<Country, string>("Enter new name:", ChangeType.name))
				.Add("CHANGE ENGLISH NAME", () => ChangeProperty<Country, string>("Enter new name:", ChangeType.eng))
				.Add("CHANGE COUNTRY CODE", () => ChangeProperty<Country, string>("Enter new code:", ChangeType.code))
				.Add("CHANGE POPULATION", () => ChangeProperty<Country, int>("Enter new population:", ChangeType.pop))
				.Add("CHANGE CURRENCY", () => ChangeProperty<Country, string>("Enter new currency:", ChangeType.curr))
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "Country change menu";
				});

			var countryMenu = new ConsoleMenu()
				.Add("LIST ALL COUNTRY", () =>
				{
					Console.Clear(); Console.WriteLine("All countries in database:\n");
					rest.GetAll<Country>().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				.Add("GET A COUNTRY", () => GetObject<Country>())
				.Add("ADD NEW COUNTRY", () => AddObject<Country>())
				.Add("UPDATE WHOLE OBJECT", () => UpdateObject<Country>())
				.Add("UPDATE ONE PROPERTY", () => countryChangeMenu.Show())
				.Add("DELETE", () => DeleteObject<Country>())
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "Country menu";
				});

			var mainMenu = new ConsoleMenu()
				.Add("LIST EVERYTHING", () => ListEverything())
				.Add("COUNTRY OPTIONS", () => countryMenu.Show())
				.Add("COUNTY OPTIONS", () => countyMenu.Show())
				.Add("CITY OPTIONS", () => cityMenu.Show())
				.Add("CUSTOM METHODS", () => statMenu.Show())
				.Add("EXIT", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "Main menu";
				});
			mainMenu.Show();
		}

		static void ListEverything()
		{
			Console.Clear();

			var countries = rest.GetAll<Country>();
			var counties = rest.GetAll<County>();
			var cities = rest.GetAll<City>();

			string output = "";

			Console.WriteLine("All entity in database:\n");
			foreach (Country country in countries)
			{
				string line = $"{country.Name} {country.EnglishName} {country.CountryCode} Population: {country.Population}";
				Console.WriteLine(line);
				output += line + "\n";
				var counties_filtered = counties.Where(x => x.CountryID == country.ID);

				foreach (County county in counties_filtered)
				{
					line = $"\t{county.Name} Seat: {county.CountySeat} Population: {county.Population}";
					Console.WriteLine(line);
					output += line + "\n";
					var cities_filtered = cities.Where(x => x.CountyID == county.ID);

					foreach (City city in cities_filtered)
					{
						line = $"\t\t{city.Name} ";
						Console.Write(line);
						output += line;
						if (city.Elevation != null)
						{
							line = $"Elevation: {city.Elevation}m ";
							Console.Write(line);
							output += line;
						}
						line = $"Area: {city.Area}km\xB2 Population: {city.Population}";
						Console.WriteLine(line);
						output += line + "\n";
					}
				}
				Console.WriteLine();
				output += "\n";
			}

			var key = UserInputCheck<ConsoleKey>("Do you want to write this out to a file? (y/n)");

			if (key == ConsoleKey.Y)
			{
				DeleteLastline(0);
				Console.SetCursorPosition(0, Console.CursorTop - 1);
				string file = UserInputCheck<string>("The name of the file you want to save in (without .txt):");
				File.WriteAllText(file + ".txt", output);
			}
		}

		static void PressToGoBack()
		{
			Console.WriteLine("Press something to go back"); Console.ReadKey();
		}

		static void GetObject<T>()
		{
			var entity = rest.Get<T>(GetByIdOrName());
			Console.WriteLine(entity != null ? "\n" + entity : "\nDidn't find anything with this input\n");
			PressToGoBack();
		}

		static void AddObject<T>()
		{
			var props = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null);
			var newEntity = (T)Activator.CreateInstance(typeof(T));
			Console.WriteLine("\nDefine the entity:\n");
			foreach (var item in props)
			{
				if (item.Name != "ID")
				{
					if (item.PropertyType == typeof(int))
						newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
						UserInputCheck<int>($"{item.Name,-15}==> "));

					else if (item.PropertyType == typeof(string))
						newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
						UserInputCheck<string>($"{item.Name,-15}==> ", true));

					else if (item.PropertyType == typeof(double))
						newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
						UserInputCheck<double>($"{item.Name,-15}==> "));

					else if (item.PropertyType == typeof(int?))
						newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
						UserInputCheck<int?>($"{item.Name,-15}==> "));

					else newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
						UserInputCheck<DrivingSide>($"{item.Name,-15}==> "));
				}
			}
			rest.Post(newEntity);
			Console.WriteLine("\nItem added!\n");
			PressToGoBack();
		}

		static void DeleteObject<T>()
		{
			object answer = GetByIdOrName();
			var entity = rest.Get<T>(answer);
			if (entity == null) Console.WriteLine("\nDidn't find anything with this input\n");
			else
			{
				rest.Delete<T>(answer);
				Console.WriteLine("\nItem deleted!\n");
			}
			PressToGoBack();
		}

		static void UpdateObject<T>()
		{
			var entity = rest.Get<T>(GetByIdOrName());
			T newEntity = entity;
			if (entity == null)
				Console.WriteLine("\nDidn't find anything with this input\n");
			else
			{
				Console.WriteLine("\nUpdate the entity:\n");
				foreach (var item in entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
				{
					if (item.Name != "ID")
					{
						if (item.PropertyType == typeof(int))
							newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
							UserInputCheck<int>($"{item.Name,-15}Now: {item.GetValue(entity),-20}==>"));

						else if (item.PropertyType == typeof(string))
							newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
							UserInputCheck<string>($"{item.Name,-15}Now: {item.GetValue(entity),-20}==>", true));

						else if (item.PropertyType == typeof(double))
							newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
							UserInputCheck<double>($"{item.Name,-15}Now: {item.GetValue(entity),-20}==>"));

						else if (item.PropertyType == typeof(int?))
							newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
							UserInputCheck<int?>($"{item.Name,-15}Now: {item.GetValue(entity),-20}==>"));

						else newEntity.GetType().GetProperty(item.Name).SetValue(newEntity,
							UserInputCheck<DrivingSide>($"{item.Name,-15}Now: {item.GetValue(entity),-20}==>"));
					}
				}
				rest.Put(newEntity);
				Console.WriteLine("\nItem updated!\n");
			}
			PressToGoBack();
		}

		static void DeleteLastline(int numberOfLines)
		{
			Console.SetCursorPosition(0, Console.CursorTop - numberOfLines);
			Console.Write(new String(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, Console.CursorTop - numberOfLines);
		}

		static object GetByIdOrName()
		{
			string input = UserInputCheck<string>("Enter ID or Entity name:");
			if (int.TryParse(input, out int id))
				return id;
			else return input;
		}

		static void ChangeProperty<T, K>(string inputAsk, ChangeType changeType)
		{
			object answer = GetByIdOrName();
			var entity = rest.Get<T>(answer);
			if (entity == null) Console.WriteLine("\nDidn't find anything with this input\n");
			else if (typeof(K) == typeof(string))
				rest.PutProperty(answer, UserInputCheck<string>(inputAsk, true), entity, changeType);

			else if (typeof(K) == typeof(int))
				rest.PutProperty(answer, UserInputCheck<int>(inputAsk).ToString(), entity, changeType);

			else if (typeof(K) == typeof(double))
				rest.PutProperty(answer, UserInputCheck<double>(inputAsk).ToString(), entity, changeType);

			else rest.PutProperty(answer, UserInputCheck<int?>(inputAsk).ToString(), entity, changeType);
			PressToGoBack();
		}

		static T UserInputCheck<T>(string valueToAsk, bool checkForDigit = false)
		{
			var type = typeof(T);
			T input;
			if (type == typeof(string))
			{
				Console.Write(valueToAsk + " ");
				try
				{
					var answer = Console.ReadLine();
					if (checkForDigit)
						if (answer.Any(x => char.IsDigit(x)))
							throw new Exception();
					if (answer == "")
						throw new Exception();
					input = (T)(object)answer;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk, checkForDigit);
				}
			}
			else if (type == typeof(ConsoleKey))
			{
				Console.Write("\n" + valueToAsk + " ");
				try
				{
					var key = Console.ReadKey(true).Key;
					if (key is not ConsoleKey.Y and not ConsoleKey.N)
						throw new Exception();
					input = (T)(object)key;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk);
				}
			}
			else if (type == typeof(double))
			{
				Console.Write(valueToAsk + " ");
				try
				{
					var number = double.Parse(Console.ReadLine());
					input = (T)(object)number;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk);
				}
			}
			else if (type == typeof(int))
			{
				Console.Write(valueToAsk + " ");
				try
				{
					var number = int.Parse(Console.ReadLine());
					input = (T)(object)number;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk);
				}
			}
			else if (type == typeof(DrivingSide))
			{
				Console.Write(valueToAsk + " ");
				try
				{
					if (!Enum.TryParse<DrivingSide>(Console.ReadLine(), false, out DrivingSide side))
						throw new Exception();
					if (!Enum.IsDefined(typeof(DrivingSide), side))
						throw new Exception();
					input = (T)(object)side;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk);
				}
			}
			else
			{
				Console.Write(valueToAsk + " ");
				if (int.TryParse(Console.ReadLine(), out int number))
				{
					input = (T)(object)number;
					return input;
				}
				return default(T);
			}
		}
	}
}
