using ConsoleTools;
using System;
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
			var countryChangeMenu = new ConsoleMenu()
				.Add("CHANGE NAME", () =>
				{
					var entity = rest.Get<Country>(GetByIdOrName());
					if (entity== null)
						Console.WriteLine("\nDidn't find anything with this input\n");
					else rest.PutName<Country>(GetByIdOrName(),
							UserInputCheck<string>("Enter new name:"));
					PressToGoBack();
				})
				//.Add("CHANGE ENGLISH NAME",)
				//.Add("CHANGE COUNTRY CODE",)
				//.Add("CHANGE POPULATION",)
				//.Add("CHANGE CURRENCY",)
				.Add("BACK", ConsoleMenu.Close)
				.Configure(conf =>
				{
					conf.Selector = "-->";
					conf.Title = "Country menu";
				});

			var countryMenu = new ConsoleMenu()
				.Add("LIST ALL COUNTRY", () =>
				{
					rest.Get<Country>().ForEach(x => Console.WriteLine(x));
					PressToGoBack();
				})
				 .Add("GET A COUNTRY", () => GetObject<Country>())
				 //.Add("ADD NEW COUNTRY",)
				 .Add("UPDATE WHOLE OBJECT", () => UpdateObject<Country>())
				 .Add("UPDATE ONE PROPERTY", () => countryChangeMenu.Show())
				 //.Add("DELETE",)
				 .Add("BACK", ConsoleMenu.Close)
				 .Configure(conf =>
				 {
					 conf.Selector = "-->";
					 conf.Title = "Country menu";
				 });

			var mainMenu = new ConsoleMenu()
				.Add("LIST EVERYTHING", () => ListEverything())
				.Add("COUNTRY OPTIONS", () => countryMenu.Show())
				.Add("COUNTY OPTIONS", () => County_Menu())
				.Add("CITY OPTIONS", () => City_Menu())
				.Add("CUSTOM METHODS", () => City_Menu())
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

			var countries = rest.Get<Country>();
			var counties = rest.Get<County>();
			var cities = rest.Get<City>();

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

		static void UpdateObject<T>()
		{
			var entity = rest.Get<T>(GetByIdOrName());
			T newEntity = entity;
			if (entity == null)
				Console.WriteLine("\nDidn't find anything with this input\n");
			else
			{
				foreach (var item in entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
				{
					if (item.PropertyType == typeof(int))
						newEntity.GetType().GetProperty(item.Name).SetValue(entity,
						UserInputCheck<int>($"{item.Name}: {item.GetValue(entity)}\t==>"));

					else if (item.PropertyType == typeof(string))
						newEntity.GetType().GetProperty(item.Name).SetValue(entity,
						UserInputCheck<string>($"{item.Name}: {item.GetValue(entity)}\t==>"));

					else if (item.PropertyType == typeof(double))
						newEntity.GetType().GetProperty(item.Name).SetValue(entity,
						UserInputCheck<double>($"{item.Name}: {item.GetValue(entity)}\t==>"));

					else if (item.PropertyType == typeof(int?))
						newEntity.GetType().GetProperty(item.Name).SetValue(entity,
						UserInputCheck<int?>($"{item.Name}: {item.GetValue(entity)}\t==>"));

					else newEntity.GetType().GetProperty(item.Name).SetValue(entity,
						UserInputCheck<DrivingSide>($"{item.Name}: {item.GetValue(entity)}\t==>"));
				}
				rest.Put(newEntity);
				Console.WriteLine("\nItem updated!\n");
			}
			PressToGoBack();
		}

		static void County_Menu()
		{

		}

		static void City_Menu()
		{

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

		static T UserInputCheck<T>(string valueToAsk)
		{
			var type = typeof(T);
			T input;
			if (type == typeof(string))
			{
				Console.Write(valueToAsk + " ");
				try
				{
					var answer = Console.ReadLine();
					if (answer == "")
						throw new Exception();
					input = (T)(object)answer;
					return input;
				}
				catch (Exception)
				{
					DeleteLastline(1);
					return UserInputCheck<T>(valueToAsk);
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
					if (!Enum.TryParse(Console.ReadLine(), out DrivingSide side))
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
